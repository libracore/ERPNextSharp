using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.HR
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class Employee : ERPNextObjectBase
    {
        #region constructor
        public Employee() : this(new ERPObject(DocType.Employee))
        {
        }

        public Employee(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string Employee_name
        {
            get { return data.employee_name; }
            set { data.employee_name = value; }
        }

        #endregion
    }
}