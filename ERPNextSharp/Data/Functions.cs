using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNextSharp.Data
{
    public static class Functions
    {
        /// <summary>
        /// Converts a status string into the corresponding DocStatus
        /// </summary>
        /// <param name="s">String doc status</param>
        /// <returns>DocStatus</returns>
        public static DocStatus DocStatusFromString(string s)
        {
            DocStatus status = DocStatus.Draft;
            if (s == DocStatus.Draft.ToString())
            {
                status = DocStatus.Draft;
            }
            else if (s == DocStatus.Submitted.ToString())
            {
                status = DocStatus.Submitted;
            }
            else
            {
                status = DocStatus.Cancelled;
            }
            return status;
        }

        /// <summary>
        /// Returns a list of DocStatus values
        /// </summary>
        /// <returns>List of DocStatus</returns>
        public static string[] DocStatuses()
        {
            return Enum.GetNames(typeof(DocStatus)).ToArray();
        }
    }
}
