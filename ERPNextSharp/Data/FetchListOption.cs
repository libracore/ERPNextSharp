using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNextSharp.Data
{
    public class FetchListOption
    {
        public List<ERPFilter> Filters { get; set; } = new List<ERPFilter>();

        public List<string> IncludedFields = new List<string>();

        public int PageSize { get; set; }
        public int PageStartIndex { get; set; }
    }
}
