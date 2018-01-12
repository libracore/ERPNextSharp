using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Project
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class ActivityType : ERPNextObjectBase
    {
        #region constructor
        public ActivityType() : this(new ERPObject(DocType.ActivityType))
        {
        }

        public ActivityType(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public long disabled
        {
            get { return data.disabled; }
            set { data.disabled = value; }
        }

        #endregion
    }
}