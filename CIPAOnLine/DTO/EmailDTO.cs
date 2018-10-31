using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CIPAOnLine.Models;
using CIPAOnLine.Resources;

namespace CIPAOnLine.DTO
{
    public class EmailDTO
    {

        public EmailDTO() {
            To = new List<string>();
            Copy = new List<string>();
            Bcc = new List<string>();
        }

        public ICollection<string> To { get; set; }
        public ICollection<string> Copy { get; set; }
        public ICollection<string> Bcc { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}