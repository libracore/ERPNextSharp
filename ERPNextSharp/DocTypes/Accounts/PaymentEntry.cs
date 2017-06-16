using ERPNextSharp.Data;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ERPNext.DocTypes.Accounts
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/accounts/payment_entry
    /// </summary>
    public class PaymentEntry : ERPNextObjectBase
    { 
        #region constructor
        public PaymentEntry() 
            : this(new ERPObject(DocType.PaymentEntry))
        { }

        public PaymentEntry(ERPObject obj) 
            : base(obj)
        { }

        /// <summary>
        /// Creates a new instance of a payment entry with minimal values to insert
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="type">Payment type</param>
        /// <param name="company">Transaction entity</param>
        /// <param name="paidFromAccount">Source account</param>
        /// <param name="paidToAccount">Destination account</param>
        /// <param name="currency">Currency</param>
        /// <param name="amount">Amount transferred</param>
        /// <param name="partyType">Party type (customer, supplier, ...)</param>
        /// <param name="party">Party name (customer, ...)</param>
        /// <param name="referenceNo">Unique ID</param>
        public PaymentEntry(DateTime date, PaymentTypes type, string company, 
            string paidFromAccount, string paidToAccount, string currency, double amount,
            string partyType, string party, string referenceNo) 
            : this(new ERPObject(DocType.PaymentEntry))
        {
            PaymentType = type;
            SetDate(date);
            Company = company;
            AccountPaidFrom = paidFromAccount;
            AccountPaidTo = paidToAccount;
            data.paid_from_account_currency = currency;
            data.paid_to_account_currency = currency;
            PaidAmount = amount;
            ReceivedAmount = amount;
            PartyType = partyType;
            Party = party;
            ReferenceNo = referenceNo;
        }
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
        /// Amount that was received
        /// </summary>
        public double ReceivedAmount
        {
            get { return data.received_amount; }
            set { data.received_amount = value; }
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
            get
            {
                DateTime date = DateTime.Now;
                try
                {
                    date = Convert.ToDateTime(data.reference_date);
                }
                catch { }
                return date;
            }
            set { data.reference_date = value.ToString("yyyy-MM-dd"); }
        }

        public DateTime PostingDate
        {
            get
            {
                DateTime date = DateTime.Now;
                try
                {
                    date = Convert.ToDateTime(data.posting_date);
                }
                catch { }
                return date;
            }
            set { data.posting_date = value.ToString("yyyy-MM-dd"); }
        }

        /// <summary>
        /// Simplified function to write posting and reference date at once
        /// </summary>
        /// <param name="date"></param>
        public void SetDate(DateTime date)
        {
            PostingDate = date;
            ReferenceDate = date;
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
        /// Company (booking entity)
        /// </summary>
        public string Company
        {
            get { return data.company; }
            set { data.company = value; }
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
        /// Account element that sent the payment
        /// </summary>
        public string AccountPaidFrom
        {
            get { return data.paid_from; }
            set { data.paid_from = value; }
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

        /// <summary>
        /// Payment type
        /// </summary>
        public PaymentTypes PaymentType
        {
            get
            {
                PaymentTypes t = PaymentTypes.Receive;
                if (data.payment_type == "Pay")
                {
                    t = PaymentTypes.Pay;
                }
                else if (data.payment_type == "Internal Transfer")
                {
                    t = PaymentTypes.InternalTransfer;
                }
                else
                {
                    t = PaymentTypes.Receive;
                }
                return t;
            }
            set
            {
                switch (value)
                {
                    case PaymentTypes.Receive: data.payment_type = "Receive"; break;
                    case PaymentTypes.Pay: data.payment_type = "Pay"; break;
                    default: data.payment_type = "Internal Transfer"; break;
                }
                data.payment_type = value.ToString();
            }
        }

        public void SetPaymentType(string type)
        {
            data.payment_type = type;
        }

        public PaymentEntryReference[] References
        {
            get
            {
                List<PaymentEntryReference> references = new List<PaymentEntryReference>();
                for (int i = 0; i < data.references.Count; i++)
                {
                    references.Add(new PaymentEntryReference(data.references[i]));

                }
                return references.ToArray();
            }
        }

        /// <summary>
        /// DocStatus
        /// </summary>
        public DocStatus DocStatus
        {
            get { return (DocStatus)data.docstatus; }
            set { data.docstatus = (byte)value; }
        }
        #endregion
    }

    #region payment data types
    public enum PaymentTypes
    {
        Receive,
        Pay,
        InternalTransfer
    }
    #endregion
}