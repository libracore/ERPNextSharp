using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
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
        //public string user_id
        //{
        //    get { return data.prefered_email; }
        //    set { data.prefered_email = value; }
        //}

        #endregion
    }
}