using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class ResourceNotFoundException : ExcelException
    {
        public string Resource { get; set; }
        public ResourceNotFoundException(string aba, int linha, string resource) : base(aba, linha)
        {
            Resource = resource;
        }

    }
}