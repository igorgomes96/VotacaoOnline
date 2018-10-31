using CIPAOnLine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class ConfirmacaoEmailsException : Exception
    {
        public IEnumerable<EmailDTO> Emails { get; set; }

        public ConfirmacaoEmailsException(IEnumerable<EmailDTO> emails) : base()
        {
            Emails = emails;
        }
    }
}