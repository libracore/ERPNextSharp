using System.Collections.Generic;

namespace ERPNextSharp.Data
{
    internal class DocRawList
    {
        public List<Dictionary<string, object>> data { get; set; }
    }

    internal class DocRaw
    {
        public Dictionary<string, object> data { get; set; }
    }
}
