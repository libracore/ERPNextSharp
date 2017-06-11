using ERPNextSharp.Data;
using System;

namespace ERPNext.DocTypes.Accounts
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/accounts/payment_entry
    /// </summary>
    public class PaymentEntry : ERPNextObjectBase
    { 
        #region constructor
        public PaymentEntry() : this(new ERPObject(DocType.Customer))
        { }

        public PaymentEntry(ERPObject obj) : base(obj)
        { }
        #endregion

        #region variable access
        /// <summary>
        /// Amount that was paid
        /// </summary>
        public double PaidAmount
        {
            get { return data.paid_amount; }
            set { data.paid_amount = value; }
        }

        /// <summary>
        /// Unique transaction reference (required)
        /// </summary>
        public string ReferenceNo
        {
            get { return data.reference_no; }
            set { data.reference_no = value; }
        }

        /// <summary>
        /// Transaction reference date (required)
        /// </summary>
        public DateTime ReferenceDate
        {
            get { return data.reference_date; }
            set { data.reference_date = value; }
        }

        /// <summary>
        /// Remarks field
        /// </summary>
        public string Remarks
        {
            get { return data.remarks; }
            set { data.remarks = value; }
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return data.title; }
            set { data.title = value; }
        }

        /// <summary>
        /// Account element that received the payment (required)
        /// </summary>
        public string AccountPaidTo
        {
            get { return data.paid_to; }
            set { data.paid_to = value; }
        }

        /// <summary>
        /// Mode of payment (referenced)
        /// </summary>
        public string ModeOfPayment
        {
            get { return data.mode_of_payment; }
            set { data.mode_of_payment = value; }
        }
        
        /// <summary>
        /// Type of party involved in transaction (customer, supplier)
        /// </summary>
        public string PartyType
        {
            get { return data.party_type; }
            set { data.party_type = value; }
        }

        /// <summary>
        /// Customer reecord of the involved party
        /// </summary>
        public string Party
        {
            get { return data.party; }
            set { data.party = value; }
        }
        #endregion
    }

}