using ERPNextSharp.Data;
using System.Collections.Generic;

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
        public int docstatus
        {
            get { return data.docstatus; }
            set { data.docstatus = value; }
        }

        public TimesheetDetail[] time_logs
        {
            get
            {
                List<TimesheetDetail> time_logs = new List<TimesheetDetail>();
                for (int i = 0; i < data.items.Count; i++)
                {
                    time_logs.Add(new TimesheetDetail(data.time_logs[i]));

                }
                return time_logs.ToArray();
            }
            set
            {
                data.time_logs = new IDictionary<string, object>[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    data.time_logs[i] = value[i].GetDictionary();
                }
            }
        }
        #endregion
    }
}