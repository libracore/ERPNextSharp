using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class TimesheetDetail : ERPNextObjectBase
    {
        #region constructor
        public TimesheetDetail() : this(new ERPObject(DocType.TimesheetDetail))
        {
        }

        public TimesheetDetail(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string parent
        {
            get { return data.parent; }
            set { data.parent = value; }
        }
        public string from_time
        {
            get { return data.from_time; }
            set { data.from_time = value; }
        }
        public string to_time
        {
            get { return data.to_time; }
            set { data.to_time = value; }
        }
        public double hours
        {
            get { return data.hours; }
            set { data.hours = value; }
        }
        public string project
        {
            get { return data.project; }
            set { data.project = value; }
        }
        public string task
        {
            get { return data.task; }
            set { data.task = value; }
        }
        public string activity_type
        {
            get { return data.activity_type; }
            set { data.activity_type = value; }
        }
        #endregion
    }
}