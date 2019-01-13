using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.Entity.Migrations;
using System.Text;
using System.Threading;
using CIPAOnLine.DTO;
using CIPAOnLine.Resources;
using System.Linq;

namespace CIPAOnLine.Services
{
    public class ImportacaoOleDB
    {
        private OleDbConnection conexao;
        private OleDbDataAdapter adapter;
        private Modelo db;
        private Usuario user = null;
        public string FileName { get; set; }

        public ImportacaoOleDB() { }

        public ImportacaoOleDB(string fileName, Usuario user)
        {
            FileName = fileName;
            this.user = user;
        }

        private void Conectar()
        {
            conexao = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + FileName + ";Extended Properties='Excel 12.0 Xml; HDR = YES';");
        }

        private void Desconectar()
        {
            if (conexao.State == ConnectionState.Open) conexao.Close();
        }

        public void ExecutarImportacaoGestores()
        {
            DataSet ds;
            Conectar();
            db = new Modelo();
            List<GestoresDuplicadosDTO> retorno = new List<GestoresDuplicadosDTO>();

            conexao.Open();

            adapter = new OleDbDataAdapter("select * from[Gestores$]", conexao);
            ds = new DataSet() { DataSetName = "Gestores" };
            try
            {
                adapter.Fill(ds);
                ImportacaoGestores(ds);
            }
            catch (OleDbException e)
            {
                if (e.Message.Split(new char[] { '.' })[0] != "'Gestores' is not a valid name") throw;
            }
            finally
            {
                Desconectar();
            }

        }

        public List<InconsistenciaFuncionarioDTO> ExecutarImportacaoFuncionarios(int codEleicao)
        {
            DataSet ds;
            Conectar();
            db = new Modelo();
            string tab = "";
            EleicoesService eleicoeService = new EleicoesService();
            if (!eleicoeService.EleicaoExiste(codEleicao)) throw new Exception("Código de Eleição não encontrado!");
            List<InconsistenciaFuncionarioDTO> retorno = new List<InconsistenciaFuncionarioDTO>();
            try
            {

                conexao.Open();

                tab = "Funcionários";
                adapter = new OleDbDataAdapter("select * from[" + tab + "$]", conexao);
                ds = new DataSet() { DataSetName = tab };
                try
                {
                    adapter.Fill(ds);
                    retorno = ImportacaoFuncionarios(ds, codEleicao);
                }
                catch (OleDbException e)
                {
                    if (e.Message.Split(new char[] { '.' })[0] != "'" + tab + "' is not a valid name") throw;
                }

            }
            catch (ResourceNotFoundException e)
            {
                throw new Exception("'" + e.Resource + "' não informado! '" + e.Resource + "' é um campo obrigatório. (Linha " + e.Linha + ")");
            }
            catch (FormatoDataInvalidoException e)
            {
                throw new Exception("Data em formato inválido: " + e.DataValor + ". (Linha " + e.Linha + ")");
            }
            catch (ExcelException e)
            {
                throw new Exception("Erro ao importar linha " + e.Linha + ". Mensagem: " + e.Message);
            }
            catch (OleDbException e)
            {
                throw new Exception("Erro ao salvar os dados: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro inesperado! " + e.Message);
            }
            finally
            {
                Desconectar();
            }


            db.Dispose();

            return retorno;
        }

        public void ImportacaoGestores(DataSet ds)
        {
            GestoresService service = new GestoresService();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                //Condição de parada
                if (r[0] == null || r[0].ToString() == "")
                    return;

                Gestor g = new Gestor
                {
                    Nome = r[0].ToString(),
                    Email = r[1].ToString()
                };

                Gestor atual = service.Get(g.Nome);

                if (atual != null)
                    g.Codigo = atual.Codigo;

                service.Save(g);

            }
        }
        

        public List<InconsistenciaFuncionarioDTO> ImportacaoFuncionarios(DataSet ds, int codEleicao)
        {
            int l = 2;
            FuncionariosService funcService = new FuncionariosService();
            UsuariosService userService = new UsuariosService();
            EleicoesService eleicoesService = new EleicoesService();
            GestoresService gestoresService = new GestoresService();
            //List<InconsistenciaFuncionarioDTO> inconsistencias = new List<InconsistenciaFuncionarioDTO>(); //Guarda os funcionários com a mesma matrícula com Login's diferentes
            HashSet<string> notRequiredFields = new HashSet<string> { "Email", "Nome do Gestor" };

            try
            {
                Eleicao eleicao = eleicoesService.GetEleicao(codEleicao);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    //Condição de parada
                    if (r[1] == null || r[1].ToString() == "")
                        return null;

                    //Validações
                    foreach (DataColumn c in ds.Tables[0].Columns)
                    {
                        if (!notRequiredFields.Contains(c.ColumnName))
                            if (r[c.ColumnName] == null || r[c.ColumnName].ToString() == "")
                                throw new ResourceNotFoundException(ds.DataSetName, l, c.ColumnName);
                    }

                    if (!DateTime.TryParse(r[5].ToString(), out DateTime dataAdmissao))
                        throw new FormatoDataInvalidoException(ds.DataSetName, l, r[5].ToString());

                    if (!DateTime.TryParse(r[6].ToString(), out DateTime dataNascimento))
                        throw new FormatoDataInvalidoException(ds.DataSetName, l, r[6].ToString());

                    Gestor gestor = null;
                    if (r[8].ToString() == "")
                    {
                        gestor = null;
                    } else
                    {
                        gestor = gestoresService.Get(r[8].ToString());
                        if (gestor == null)
                        {
                            throw new GestorNaoEncontradoException(r[8].ToString());
                        }
                    }


                    //if (gestor == null) throw new GestorNaoEncontradoException(r[8].ToString());
                    //string cpf = new string(r[1].ToString().Where(x => char.IsDigit(x)).ToArray());
                    string login = r[1].ToString().Trim().ToLower();
                    string matricula = r[0].ToString();
                    Funcionario func = new Funcionario
                    {
                        MatriculaFuncionario = matricula,
                        Login = login,
                        Nome = r[2].ToString(),
                        Cargo = r[3].ToString(),
                        Area = r[4].ToString(),
                        DataAdmissao = dataAdmissao,
                        DataNascimento = dataNascimento,
                        CodigoGestor = gestor?.Codigo,
                        Email = r[7].ToString(),
                        CodigoEmpresa = eleicao.Unidade.CodigoEmpresa
                    };

                    Funcionario atual = funcService.GetByLogin(login);

                    if (atual == null || atual.MatriculaFuncionario == matricula) {
                        if (atual != null) func.Id = atual.Id;
                        funcService.AddOrUpdateFuncionario(func);
                    } else
                        throw new Exception($"Já existe um funcionário cadastrado com o login {login}! Matrícula: {atual.MatriculaFuncionario}.");

                    Usuario usuario = null;
                    try
                    {
                        usuario = userService.GetUsuario(login);
                        usuario.FuncionarioId = atual.Id;
                        usuario.Nome = func.Nome;
                        userService.AddOrUpdateUsuario(usuario);
                    }
                    catch (UsuarioNaoEncontradoException) { }
                    eleicoesService.AddFuncionario(codEleicao, func.Id);

                    l++;
                }               

            }
            catch (ResourceNotFoundException e)
            {
                throw e;
            }
            catch (FormatoDataInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcelException(e.Message, ds.DataSetName, l);
            }

            return null;


        }
    }
}