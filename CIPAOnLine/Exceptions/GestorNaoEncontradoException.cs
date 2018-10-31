using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class GestorNaoEncontradoException : Exception
    {
        public string NomeGestor { get; set; }
        public GestorNaoEncontradoException(): base()
        {

        }

        public GestorNaoEncontradoException(string nomeGestor): base(string.Format("O gestor {0} não foi encontrado na base!", nomeGestor))
        {
            NomeGestor = nomeGestor;
        }


    }
}