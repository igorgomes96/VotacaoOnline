using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class CronogramaInconsistenteException : Exception
    {
        public PrazoEtapa EtapaAnterior { get; set; }
        public PrazoEtapa EtapaPosterior { get; set; }
        public CronogramaInconsistenteException() : base() { }
        public CronogramaInconsistenteException(string message) : base(message) { }
        public CronogramaInconsistenteException(PrazoEtapa etapaAnterior, PrazoEtapa etapaPosterior) : base()
        {
            EtapaAnterior = etapaAnterior;
            EtapaPosterior = EtapaPosterior;
        }
    }
}