using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class Timesheet : ERPNextObjectBase
    {
        #region constructor
        public Timesheet() : this(new ERPObject(DocType.Timesheet))
        {
        }

        public Timesheet(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string company
        {
            get { return data.company; }
            set { data.company = value; }
        }
        public string employee
        {
            get { return data.employee; }
            set { data.employee = value; }
        }
        public string status
        {
            get { return data.status; }
            set { data.status = value; }
        }
        public string start_date
        {
            get { return data.start_date; }
            set { data.start_date = value; }
        }
        public string end_date
        {
            get { return data.end_date; }
            set { data.end_date = value; }
        }
        public string employee_name
        {
            get { return data.employee_name; }
            set { data.employee_name = value; }
        }
        public double total_hours
        {
            get { return data.total_hours; }
            set { data.total_hours = value; }
        }
        public string note
        {
            get { return data.note; }
            set { data.note = value; }
        }
        #endregion
    }
}