using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Project
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
        public string description
        {
            get { return data.description; }
            set { data.description = value; }
        }
        public string subject
        {
            get { return data.subject; }
            set { data.subject = value; }
        }
        #endregion
    }
}