using CIPAOnLine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using CIPAOnLine.Resources;
using CIPAOnLine.Models;
using System.Configuration;
using CIPAOnLine.Exceptions;

namespace CIPAOnLine.Services
{
    public class EmailService
    {
        Modelo db = new Modelo();

        public static void Send(object obj)
        {
            EmailDTO email = (EmailDTO)obj;
            try
            {
                EnviaMensagemEmail(Emails.EmailOrigem, email.To, email.Bcc, email.Copy, email.Subject, email.Message, BodyHtml: true);
                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("Smtp.Gmail.com");

                //mail.From = new MailAddress(Emails.EmailEndereco);
                //foreach (string to in email.To.Where(x => x != "").Distinct())
                //    mail.To.Add(to);

                //foreach (string copy in email.Copy.Where(x => x != "").Distinct())
                //    mail.CC.Add(copy);

                //foreach (string bcc in email.Bcc.Where(x => x != "").Distinct())
                //    mail.Bcc.Add(bcc);

                //mail.Subject = email.Subject;
                //mail.IsBodyHtml = true;
                //mail.Body = email.Message;
                
                //SmtpServer.Port = 587;
                //SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UsuarioEmail"], CryptoGraph.Decrypt(ConfigurationManager.AppSettings["SenhaEmail"]));
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                LogEmailsService log = new LogEmailsService();
                log.SaveLogEmail(email, ex);
            }
        }


        /// <summary>
        /// Envio de e-mail
        /// </summary>
        /// <param name="from">quem envia o e-mail</param>
        /// <param name="recepient">quem recebe o e-mail</param>
        /// <param name="bcc">cópia oculta</param>
        /// <param name="cc">cópia</param>
        /// <param name="subject">assunto</param>
        /// <param name="body">corpo do email</param>
        /// <param name="anexo">anexo</param>
        /// <param name="BodyHtml">corpo do e-mail html</param>
        private static void EnviaMensagemEmail(string from, ICollection<string> recepient, ICollection<string> bcc, ICollection<string> cc, string subject, string body, List<object> anexo = null, bool BodyHtml = false)
        {
            try
            {

                //cria uma instância do objeto MailMessage
                var mMailMessage = new MailMessage();

                //Define o endereço do remetente
                mMailMessage.From = new MailAddress(from);

                if (!(recepient == null))
                {

                    foreach (var recep in recepient)
                    {
                        //Define o destinario da mensagem
                        mMailMessage.To.Add(new MailAddress(recep));
                    }

                }



                if (!(anexo == null))
                {
                    //Percorre os elementos da ArrayList
                    //usando o laço for
                    for (int i = 0; i < anexo.Count - 1; i++)
                    {
                        //Inclui um anexo a partir do arquivo de sistema
                        mMailMessage.Attachments.Add(new Attachment(anexo[i].ToString()));
                    }

                }

                if (bcc != null) { 
                    foreach (var objBcc in bcc)
                    {
                        //Define o endereço bcc
                        mMailMessage.Bcc.Add(new MailAddress(objBcc));
                    }
                }

                //Se tiver mais de um destinario
                if (cc != null)
                {
                    foreach (var objBcc in cc)
                    {
                        //Define o endereço bcc
                        mMailMessage.CC.Add(new MailAddress(objBcc));
                    }
                }


                //Define o assunto 
                mMailMessage.Subject = subject;
                //Define o corpo da mensagem
                mMailMessage.Body = body;
                //Define o formato do email como HTML
                mMailMessage.IsBodyHtml = BodyHtml;
                //Define a prioridade da mensagem como normal
                mMailMessage.Priority = MailPriority.Normal;
                // Cria uma instância de SmtpClient - Nota - Define qual o host a ser usado para envio 
                // de mensagens, no local de smtp.server.com use o nome do SEU servidor
                //SmtpClient mSmtpClient = new SmtpClient("10.200.48.120", 25);
                SmtpClient mSmtpClient = new SmtpClient("10.200.48.120", 25);

                //NetworkCredential mailAuthentication = new NetworkCredential();
                //mailAuthentication.UserName = "recuperacoes@algartech.com";
                //mailAuthentication.Password = "engeset2013";
                //Enable SSL
                mSmtpClient.EnableSsl = false;
                //obriga a passa senha e usuario
                mSmtpClient.UseDefaultCredentials = false;
                //Utiliza os dados de usuario e senha
                //mSmtpClient.Credentials = mailAuthentication;
                //Envia o email
                mSmtpClient.Send(mMailMessage);

                //limpa o objeto
                mSmtpClient.Dispose();
                mMailMessage.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public ICollection<string> GetEmailAddressesAll(int codEleicao)
        {
            Eleicao eleicao = db.Eleicoes.Find(codEleicao);
            if (eleicao == null) throw new EleicaoNaoEncontradaException();

            return eleicao.Funcionarios.Select(x => x.Email).ToList();
        }

        public ICollection<string> GetEmailAddressesCandidatos(int codEleicao)
        {
            Eleicao eleicao = db.Eleicoes.Find(codEleicao);
            if (eleicao == null) throw new EleicaoNaoEncontradaException();

            return eleicao.Candidatos.Select(x => x.Funcionario.Email).ToList();
        }


        //public static EmailDTO EmailCronogramaSindicato(Eleicao eleicao, Usuario user)
        //{
        //    EmailDTO email = new EmailDTO();
        //    email = new EmailDTO();
        //    string cronograma = "";
        //    string hoje = DateTime.Today.Day + " de " + NomesMesesService.GetNomeMes(DateTime.Today.Month) + " de " + DateTime.Today.Year;

        //    foreach (PrazoEtapa p in eleicao.PrazosEtapas)
        //    {
        //        cronograma += "<strong>" + p.DataProposta.Value.ToString("dd/MM/yyyy") + "</strong> - " + p.Etapa.NomeEtapa + ";<br>";
        //    }

        //    email.To = new[] { eleicao.Sindicato.Email };
        //    email.Bcc.Add(Emails.EmailEndereco);
        //    email.Subject = "Comunicação de eleições para CIPA";
        //    email.Message = string.Format(Emails.EmailSindicato, eleicao.Unidade.Cidade, hoje, eleicao.Sindicato.Nome,
        //        eleicao.Unidade.RazaoSocial, eleicao.Unidade.Estabelecimento, eleicao.Unidade.Cidade, cronograma,
        //        user.Nome, user.Cargo, user.DRT, eleicao.Sindicato.Responsavel, eleicao.Sindicato.Endereco, eleicao.Sindicato.Cidade);

        //    return email;
        //}

        //public static EmailDTO EmailConviteCandidatura(Eleicao eleicao, Usuario user, PrazoEtapa proximaEtapa)
        //{
        //    EmailDTO email = new EmailDTO();
        //    email = new EmailDTO();
        //    string hoje = DateTime.Today.Day + " de " + NomesMesesService.GetNomeMes(DateTime.Today.Month) + " de " + DateTime.Today.Year;

        //    email.Bcc = eleicao.Funcionarios.Select(x => x.Email).ToList();
        //    email.Bcc.Add(Emails.EmailEndereco);
        //    email.Subject = "Início das Inscrições para eleição da CIPA";
        //    email.Message = string.Format(Emails.EmailInscricao, eleicao.Unidade.Cidade, eleicao.Gestao, hoje, eleicao.Unidade.RazaoSocial,
        //        eleicao.Unidade.Estabelecimento, DateTime.Today.ToString("dd/MM/yy"), proximaEtapa.DataProposta.Value.Date.ToString("dd/MM/yy"), Emails.LinkSistema,
        //        user.Nome, user.Cargo, user.DRT);

        //    return email;
        //}

        //public static EmailDTO EmailConviteVotacao(Eleicao eleicao, Usuario user, PrazoEtapa proximaEtapa)
        //{
        //    EmailDTO email = new EmailDTO();
        //    email = new EmailDTO();
        //    string hoje = DateTime.Today.Day + " de " + NomesMesesService.GetNomeMes(DateTime.Today.Month) + " de " + DateTime.Today.Year;

        //    email.Bcc = eleicao.Funcionarios.Select(x => x.Email).ToList();
        //    email.Bcc.Add(Emails.EmailEndereco);
        //    email.Subject = "Início da Votação para eleição da CIPA";
        //    email.Message = string.Format(Emails.EmailVotacao, eleicao.Unidade.Cidade, eleicao.Gestao, hoje, eleicao.Unidade.RazaoSocial,
        //        eleicao.Unidade.Estabelecimento, DateTime.Today.ToString("dd/MM/yy"), proximaEtapa.DataProposta.Value.ToString("dd/MM/yy"), Emails.LinkSistema,
        //        user.Nome, user.Cargo, user.DRT);

        //    return email;
        //}

        //public static EmailDTO EmailApuracao(Eleicao eleicao, Usuario user)
        //{
        //    EmailDTO email = new EmailDTO();
        //    VotosService votosService = new VotosService();
        //    email = new EmailDTO();
        //    string hoje = DateTime.Today.Day + " de " + NomesMesesService.GetNomeMes(DateTime.Today.Month) + " de " + DateTime.Today.Year;

        //    string efetivos = "<h4>Membros Efetivos:</h4><ol>";
        //    string suplentes = "<h4>Membros Suplentes:</h4><ol>";

        //    ResultadoDTO resultado = votosService.GetResultado(eleicao.Codigo);

        //    foreach (CandidatoEleitoDTO c in resultado.Efetivos)
        //    {
        //        efetivos += "<li><p style=\"margin: 3px 0;\">" + c.Nome + " - <strong>" + c.QtdaVotos + " votos</strong>"
        //            + "</p><div style=\"font - size: 12px; color: #888;\">"
        //            + "Cargo: " + c.Cargo + "<br>"
        //            + "Área: " + c.Area
        //            + "</div></li>";
        //    }
        //    efetivos += "</ol>";

        //    foreach (CandidatoEleitoDTO c in resultado.Suplentes)
        //    {
        //        suplentes += "<li><p style=\"margin: 3px 0;\">" + c.Nome + " - <strong>" + c.QtdaVotos + " votos</strong>"
        //            + "</p><div style=\"font - size: 12px; color: #888;\">"
        //            + "Cargo: " + c.Cargo + "<br>"
        //            + "Área: " + c.Area
        //            + "</div></li>";
        //    }
        //    suplentes += "</ol>";

        //    email.Bcc = eleicao.Funcionarios.Select(x => x.Email).ToList();
        //    email.Bcc.Add(Emails.EmailEndereco);
        //    email.Subject = "Início da Votação para eleição da CIPA";
        //    email.Message = string.Format(Emails.EmailApuracao, eleicao.Unidade.Cidade, eleicao.Gestao, hoje, eleicao.Unidade.RazaoSocial,
        //        eleicao.Unidade.Estabelecimento, efetivos + suplentes, Emails.LinkSistema,
        //        user.Nome, user.Cargo, user.DRT);

        //    return email;
        //}

        //public static EmailDTO EmailRelacaoCandidatos(Eleicao eleicao, Usuario user)
        //{
        //    EmailDTO email = new EmailDTO();
        //    email = new EmailDTO();
        //    string hoje = DateTime.Today.Day + " de " + NomesMesesService.GetNomeMes(DateTime.Today.Month) + " de " + DateTime.Today.Year;

        //    string candidatos = "<ul>";
        //    foreach (Candidato c in eleicao.Candidatos)
        //    {
        //        candidatos += "<li><p style=\"margin: 3px 0;\">" + c.Funcionario.Nome 
        //            + "</p><div style=\"font - size: 12px; color: #888;\">"
        //            + "Cargo: " + c.Funcionario.Cargo + "<br>" 
        //            + "Área: " + c.Funcionario.Area
        //            + "</div></li>";
        //    }
        //    candidatos += "</ul>";

        //    email.Bcc = eleicao.Funcionarios.Select(x => x.Email).ToList();
        //    email.Copy.Add(Emails.EmailEndereco);
        //    email.Subject = "Relação de Candidatos da CIPA";
        //    email.Message = string.Format(Emails.EmailCandidatos, eleicao.Unidade.Cidade, eleicao.Gestao, eleicao.Unidade.RazaoSocial,
        //        eleicao.Unidade.Estabelecimento, candidatos, Emails.LinkSistema,
        //        user.Nome, user.Cargo, user.DRT);

        //    return email;
        //}

        //public static EmailDTO EmailEditalFuncionarios(Eleicao eleicao, Usuario user)
        //{
        //    return EmailEdital(eleicao, user, eleicao.Funcionarios.Select(x => x.Email).Distinct().ToList());
        //}

        //public static EmailDTO EmailEdital(Eleicao eleicao, Usuario user, ICollection<string> bcc)
        //{
        //    EmailDTO email = new EmailDTO
        //    {
        //        Bcc = bcc
        //    };

        //    email.Bcc.Add(Emails.EmailEndereco);
        //    email.Copy.Add(eleicao.Sindicato.Email);

        //    string data = "";
        //    DateTime? inicioInscricao = eleicao.PrazosEtapas.Where(x => x.CodigoEtapa == 4).FirstOrDefault().DataProposta;
        //    DateTime? fimInscricao = eleicao.PrazosEtapas.Where(x => x.CodigoEtapa == 5).FirstOrDefault().DataProposta;
        //    DateTime? inicioVotacao = eleicao.PrazosEtapas.Where(x => x.CodigoEtapa == 9).FirstOrDefault().DataProposta;
        //    DateTime? fimVotacao = eleicao.PrazosEtapas.Where(x => x.CodigoEtapa == 10).FirstOrDefault().DataProposta;

        //    string hoje = DateTime.Today.Day + " de " + NomesMesesService.GetNomeMes(DateTime.Today.Month) + " de " + DateTime.Today.Year;

        //    if (eleicao.DataInicio.Day == 1)
        //    {
        //        data = "Ao 01º dia do mês de " + NomesMesesService.GetNomeMes(eleicao.DataInicio.Month) + " de " + eleicao.DataInicio.Year;
        //    }
        //    else
        //    {
        //        data = "Aos " + eleicao.DataInicio.Day + " dias do mês de " + NomesMesesService.GetNomeMes(eleicao.DataInicio.Month) + " de " + eleicao.DataInicio.Year;
        //    }

        //    email.Subject = "Abertura do processo de Eleição da CIPA - Gestão " + eleicao.Gestao;
        //    email.Message = string.Format(Emails.EmailEdital, data, eleicao.Unidade.RazaoSocial,
        //        eleicao.Unidade.Estabelecimento, eleicao.Unidade.Cidade,
        //        inicioInscricao.Value.ToString("dd/MM/yy"), fimInscricao.Value.ToString("dd/MM/yy"),
        //        Emails.LinkSistema, inicioVotacao.Value.ToString("dd/MM/yy"),
        //        fimVotacao.Value.ToString("dd/MM/yy"), hoje, user.Nome, user.Cargo, user.DRT);

        //    return email;
        //}
    }
}