using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class PaginationInfoDTO
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}