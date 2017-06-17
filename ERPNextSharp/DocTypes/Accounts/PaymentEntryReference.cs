using ERPNextSharp.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERPNextSharp.DocTypes.Accounts
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/accounts/payment_entry_reference
    /// </summary>
    public class PaymentEntryReference : ERPNextObjectBase
    { 
        #region constructor
        public PaymentEntryReference() 
            : this(new ERPObject(DocType.PaymentEntryReference))
        {
            // apply standard values for hardcoded fields
            ParentType = "Payment Entry";
            ParentField = "references";
        }

        public PaymentEntryReference(ERPObject obj) 
            : base(obj)
        { }

        public PaymentEntryReference(IDictionary<string, object> vals)
            : this(new ERPObject(DocType.PaymentEntryReference))
        {
            try
            {
                Name = vals.First(x => x.Key == "name").Value.ToString();
                ReferenceName = vals.First(x => x.Key == "reference_name").Value.ToString();
                DueDate = Convert.ToDateTime(vals.First(x => x.Key == "due_date").Value);
                ReferenceDocType = vals.First(x => x.Key == "reference_doctype").Value.ToString();
                TotalAmount = Convert.ToDouble(vals.First(x => x.Key == "total_amount").Value.ToString());
                OutstandingAmount = Convert.ToDouble(vals.First(x => x.Key == "outstanding_amount").Value.ToString());
                AllocatedAmount = Convert.ToDouble(vals.First(x => x.Key == "allocated_amount").Value.ToString());
                ExchangeRate = Convert.ToDouble(vals.First(x => x.Key == "exchange_rate").Value.ToString());
                Parent = vals.First(x => x.Key == "parent").Value.ToString();
                ParentType = vals.First(x => x.Key == "parenttype").Value.ToString();
                ParentField = vals.First(x => x.Key == "parentfield").Value.ToString();
            }
            catch
            {
                // invalid or empty entry
            }
        }
        #endregion

        #region variable access
        /// <summary>
        /// Currency name
        /// </summary>
        public string ReferenceName
        {
            get { return data.reference_name; }
            set { data.reference_name = value; }
        }

        /// <summary>
        /// Due date
        /// </summary>
        public DateTime DueDate
        {
            get
            {
                DateTime date = DateTime.Now;
                try
                {
                    date = Convert.ToDateTime(data.due_date);
                }
                catch { }
                return date;
            }
            set { data.due_date = value.ToString("yyyy-MM-dd"); }
        }

        /// <summary>
        /// Reference DocType, e.g. Sales Invoice
        /// </summary>
        public string ReferenceDocType
        {
            get { return data.reference_doctype; }
            set { data.reference_doctype = value; }
        }

        /// <summary>
        /// Total amount
        /// </summary>
        public double TotalAmount
        {
            get { return data.total_amount; }
            set { data.total_amount = value; }
        }

        /// <summary>
        /// Outstanding amount
        /// </summary>
        public double OutstandingAmount
        {
            get { return data.outstanding_amount; }
            set { data.outstanding_amount = value; }
        }

        /// <summary>
        /// Allocated amount
        /// </summary>
        public double AllocatedAmount
        {
            get { return data.allocated_amount; }
            set { data.allocated_amount = value; }
        }

        /// <summary>
        /// Exchange rate
        /// </summary>
        public double ExchangeRate
        {
            get { return data.exchange_rate; }
            set { data.exchange_rate = value; }
        }

        /// <summary>
        /// Parent object, reference to PaymentEntry (e.g. PE-00001)
        /// </summary>
        public string Parent
        {
            get { return data.parent; }
            set { data.parent = value; }
        }

        /// <summary>
        /// Parent type, typically "Payment Entry"
        /// </summary>
        public string ParentType
        {
            get { return data.parenttype; }
            set { data.parenttype = value; }
        }

        public string ParentField
        {
            get { return data.parentfield; }
            set { data.parentfield = value; }
        }

        public DocStatus DocStatus
        {
            get { return (DocStatus)data.docstatus; }
            set { data.docstatus = (byte)value; }
        }
        #endregion
    }
}