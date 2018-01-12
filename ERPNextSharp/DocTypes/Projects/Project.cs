using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Project
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class Project : ERPNextObjectBase
    {
        #region constructor
        public Project() : this(new ERPObject(DocType.Project))
        {
        }

        public Project(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public long project_name
        {
            get { return data.project_name; }
            set { data.project_name = value; }
        }

        #endregion
    }
}