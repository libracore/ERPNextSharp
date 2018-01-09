using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class Task : ERPNextObjectBase
    {
        #region constructor
        public Task() : this(new ERPObject(DocType.Task))
        {
        }

        public Task(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string project
        {
            get { return data.project; }
            set { data.project = value; }
        }

        #endregion
    }
}