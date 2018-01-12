using ERPNextSharp.Data;
using System;
using System.Collections.Generic;

namespace ERPNextSharp.DocTypes.Project
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

        #region JSON serializer
        public IDictionary<string, object> GetDictionary()
        {
            // cast to an IDictionary<string, object>
            IDictionary<string, object> dict = data;

            return dict;
        }
        #endregion

        #region variable access
        public string parent
        {
            get { return data.parent; }
            set { data.parent = value; }
        }
        public DateTime from_time
        {
            get { return Convert.ToDateTime(data.from_time); }
            set { data.from_time = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}",
                value.Year, value.Month, value.Day, 
                value.Hour, value.Minute, value.Second); }
        }
        public DateTime to_time
        {
            get { return Convert.ToDateTime(data.to_time); }
            set
            {
                data.to_time = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}",
              value.Year, value.Month, value.Day,
              value.Hour, value.Minute, value.Second);
            }
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
        public string parentfield
        {
            get { return data.parentfield; }
            set { data.parentfield = value; }
        }
        public string parenttype
        {
            get { return data.parenttype; }
            set { data.parenttype = value; }
        }
        public int idx
        {
            get { return data.idx; }
            set { data.idx = value; }
        }
        #endregion
    }
}