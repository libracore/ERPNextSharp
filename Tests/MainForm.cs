using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERPNextSharp;
using ERPNextSharp.Data;
using ERPNextSharp.DocTypes.Customer;
using ERPNextSharp.DocTypes.Accounts;
using System.IO;
using ERPNextSharp.DocTypes.Stock;

namespace Tests
{
    public partial class MainForm : Form
    {
        #region global variables
        private ERPNextClient client;
        private Config config;
        private List<Account> accounts;
        private List<Warehouse> warehouses;
        private enum ConnectionState { Disconnected, Connected, Initialising };

        #endregion

        #region constructor
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;

            accounts = new List<Account>();
            warehouses = new List<Warehouse>();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            showConnected(ConnectionState.Disconnected);

            loadConfig();

            cmbPaymentType.Items.Clear();
            foreach (PaymentTypes type in Enum.GetValues(typeof(PaymentTypes)))
            {
                cmbPaymentType.Items.Add(type.ToString());
            }

            cmbPaymentEntryStatus.Items.Clear();
            foreach (string s in Functions.DocStatuses())
            {
                cmbPaymentEntryStatus.Items.Add(s);
            }
        }

        private void loadConfig()
        {
            // find config file
            string appPath = (new FileInfo(Application.ExecutablePath)).DirectoryName;
            string configPath = appPath + "\\config.xml";

            // load config
            config = new Config(configPath);

            txtServer.Text = config.Server;
            txtUsername.Text = config.Username;
            txtPassword.Text = config.Password;
        }
        #endregion

        #region button handlers
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == string.Empty)
            {
                txtServer.Focus();
            }
            else if (txtUsername.Text == string.Empty)
            {
                txtUsername.Focus();
            }
            else if (txtPassword.Text == string.Empty)
            {
                txtPassword.Focus();
            }
            else
            {
                client = new ERPNextClient(txtServer.Text, txtUsername.Text, txtPassword.Text);
                client.HasError += Client_HasError;

                if (client.IsLoggedIn)
                {
                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;
                    postLoginHooks();
                    showConnected(ConnectionState.Connected);
                }
                else
                {
                    MessageBox.Show("Unable to connect.");
                }
            }

        }

        /// <summary>
        /// Extend here the functions to be executed after login
        /// </summary>
        private void postLoginHooks()
        {
            showConnected(ConnectionState.Initialising);
            Application.DoEvents();
            getCustomerList();
            getPaymentEntryList();
            getPaymentPartyTypesList();
            getAccountList();
            getCompanyList();
            getSalesInvoiceList();
            getStockEntryList();
            getAddressList();
            getWarehouseList();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect_Click(sender, e);
            }
        }

        private void txtServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void showConnected(ConnectionState state)
        {
            switch (state)
            {
                case (ConnectionState.Connected):
                    statusConnected.Image = Properties.Resources.accept;
                    statusConnected.Text = "Connected";
                    break;
                case (ConnectionState.Disconnected):
                    statusConnected.Image = Properties.Resources.cancel;
                    statusConnected.Text = "Not connected";
                    break;
                default:
                    statusConnected.Image = Properties.Resources.arrow_refresh;
                    statusConnected.Text = "Initialising";
                    break;
            }
        }
        private void Client_HasError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Dispose();
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            showConnected(ConnectionState.Disconnected);
        }

        #endregion

        #region customer handler
        private void btnGetCustomers_Click(object sender, EventArgs e)
        {
            getCustomerList();
        }

        private void getCustomerList()
        {
            if (client != null)
            {
                List<ERPObject> customers = client.ListObjects(DocType.Customer);

                listCustomers.Items.Clear();
                cmbPaymentCustomer.Items.Clear();
                foreach (ERPObject o in customers)
                {
                    listCustomers.Items.Add(o.Name);
                    cmbPaymentCustomer.Items.Add(o.Name);
                }
            }
        }

        private void listCustomers_DoubleClick(object sender, EventArgs e)
        {
            if (listCustomers.SelectedItem != null)
            {
                string customerName = listCustomers.SelectedItem.ToString();

                getCustomerInfo(customerName);
            }
        }

        private void getCustomerInfo(string customerName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.Customer, customerName);
                Customer customer = new Customer(obj);

                txtCustomerName.Text = customer.CustomerName;
                txtCustomerGroup.Text = customer.CustomerGroup;
                txtCustomerStatus.Text = customer.Status.ToString();
                txtCustomerTerritory.Text = customer.Territory;
                txtCustomerType.Text = customer.CustomerType.ToString();
                txtCustomerWebsite.Text = customer.Website;
                txtCustomerOwner.Text = customer.Owner;
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (listCustomers.SelectedItem != null)
            {
                if (MessageBox.Show(string.Format("Really delete customer {0}?",
                    listCustomers.SelectedItem), "Question", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deleteCustomer(listCustomers.SelectedItem.ToString());
                }
            }
        }

        private void deleteCustomer(string customerName)
        {
            if (client != null)
            {
                client.DeleteObject(DocType.Customer, customerName);

                getCustomerList();
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (listCustomers.SelectedItem != null)
            {
                updateCustomer(listCustomers.SelectedItem.ToString());
            }
        }

        private void updateCustomer(string customerName)
        {
            if (client != null)
            {
                Customer customer = getCustomerFromForm();
                ERPObject obj = customer.Object;
                client.UpdateObject(DocType.Customer, customerName, obj);
            }
        }

        private Customer getCustomerFromForm()
        {
            Customer customer = new Customer();
            customer.CustomerName = txtCustomerName.Text;
            customer.CustomerGroup = txtCustomerGroup.Text;
            customer.Territory = txtCustomerTerritory.Text;
            customer.Website = txtCustomerWebsite.Text;
            customer.Owner = txtCustomerOwner.Text;
            if (txtCustomerType.Text == "Company")
            {
                customer.CustomerType = CustomerTypes.Company;
            }
            else
            {
                customer.CustomerType = CustomerTypes.Individual;
            }
            if (txtCustomerStatus.Text == "Active")
            {
                customer.Status = CustomerStatuses.Active;
            }
            else if (txtCustomerStatus.Text == "Dormant")
            {
                customer.Status = CustomerStatuses.Dormant;
            }
            else if (txtCustomerStatus.Text == "Open")
            {
                customer.Status = CustomerStatuses.Open;
            }
            else
            {
                customer.Status = CustomerStatuses.None;
            }
            return customer;
        }

        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != string.Empty)
            {
                insertCustomer();
            }
        }

        private void insertCustomer()
        {
            if (client != null)
            {
                Customer customer = getCustomerFromForm();
                ERPObject obj = customer.Object;
                client.InsertObject(obj);

                getCustomerList();
            }
        }
        #endregion

        #region payment entries / transactions
        private void getPaymentPartyTypesList()
        {
            if (client != null)
            {
                List<ERPObject> partyTypes = client.ListObjects(DocType.PartyType);

                cmbPaymentPartyType.Items.Clear();
                foreach (ERPObject t in partyTypes)
                {
                    cmbPaymentPartyType.Items.Add(t.Name);
                }
            }
        }

        private void getAccountList()
        {
            if (client != null)
            {
                List<ERPObject> acc = client.ListObjects(DocType.Account);

                accounts.Clear();
                cmbPaymentFromAccount.Items.Clear();
                cmbPaymentToAccount.Items.Clear();
                foreach (ERPObject a in acc)
                {
                    accounts.Add(getAccount(a.Name));

                    cmbPaymentToAccount.Items.Add(a.Name);
                    cmbPaymentFromAccount.Items.Add(a.Name);
                }

                // set defaults
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].AccountType == AccountTypes.Liability)
                    {
                        cmbPaymentFromAccount.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].AccountType == AccountTypes.Asset)
                    {
                        cmbPaymentFromAccount.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private Account getAccount(string accountName)
        {
            Account acc = new Account();
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.Account, accountName);
                acc = new Account(obj);
            }
            return acc;
        }

        private void btnGetPaymentEntries_Click(object sender, EventArgs e)
        {
            getPaymentEntryList();
        }

        private void getPaymentEntryList()
        {
            if (client != null)
            {
                List<ERPObject> payments = client.ListObjects(DocType.PaymentEntry);

                listPaymentEntries.Items.Clear();
                foreach (ERPObject o in payments)
                {
                    listPaymentEntries.Items.Add(o.Name);
                }
            }
        }

        private void getCompanyList()
        {
            if (client != null)
            {
                List<ERPObject> companies = client.ListObjects(DocType.Company);

                cmbPaymentCompany.Items.Clear();
                foreach (ERPObject c in companies)
                {
                    cmbPaymentCompany.Items.Add(c.Name);
                }
                cmbPaymentCompany.SelectedIndex = 0;
            }
        }

        private void btnInsertPaymentEntry_Click(object sender, EventArgs e)
        {
            insertPayment();
        }

        private PaymentEntry getPaymentFromForm(PaymentEntry original)
        {
            PaymentTypes type = PaymentTypes.Receive;
            switch (cmbPaymentType.SelectedItem.ToString())
            {
                case "Receive": type = PaymentTypes.Receive; break;
                case "Pay": type = PaymentTypes.Pay; break;
                default: type = PaymentTypes.InternalTransfer; break;
            }
            string paidFrom = cmbPaymentFromAccount.SelectedItem.ToString();
            string paidTo = cmbPaymentToAccount.SelectedItem.ToString();
            string partyType = cmbPaymentPartyType.SelectedItem.ToString();
            string party = cmbPaymentCustomer.SelectedItem.ToString();

            if (original == null)
            {
                original = new PaymentEntry(datePaymentDate.Value,
                    type, "OmniPro", paidFrom, paidTo, "CHF",
                    Convert.ToDouble(numPaymentAmount.Value),
                    "Customer", party, txtPaymentReference.Text);
            }
            else
            {
                original.PostingDate = datePaymentDate.Value;
                original.ReferenceDate = datePaymentDate.Value;
                original.PaymentType = type;
                original.AccountPaidFrom = paidFrom;
                original.AccountPaidTo = paidTo;
                original.PaidAmount = Convert.ToDouble(numPaymentAmount.Value);
                original.ReceivedAmount = Convert.ToDouble(numPaymentAmount.Value);
                original.Party = party;
                original.ReferenceNo = txtPaymentReference.Text;
                original.DocStatus = Functions.DocStatusFromString(cmbPaymentEntryStatus.SelectedItem.ToString());
            }
            return original;
        }

        private void insertPayment()
        {
            if (client != null)
            {
                PaymentEntry payment = getPaymentFromForm(null);
                ERPObject obj = payment.Object;
                client.InsertObject(obj);

                getPaymentEntryList();
            }
        }

        private void listPaymentEntries_DoubleClick(object sender, EventArgs e)
        {
            if (listPaymentEntries.SelectedItem != null)
            {
                string paymentName = listPaymentEntries.SelectedItem.ToString();

                getPaymentInfo(paymentName);
            }
        }

        /// <summary>
        /// Opens a payment entry
        /// </summary>
        /// <param name="paymentName">Name of the payment entry (e.g. PE-00001)</param>
        private void getPaymentInfo(string paymentName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.PaymentEntry, paymentName);
                PaymentEntry payment = new PaymentEntry(obj);

                PaymentEntryReference[] references = payment.References;
                listPaymentEntryReferences.Items.Clear();
                foreach (PaymentEntryReference r in references)
                {
                    listPaymentEntryReferences.Items.Add(r.ReferenceName);
                }

                numPaymentAmount.Value = Convert.ToDecimal(payment.PaidAmount);
                txtPaymentReference.Text = payment.ReferenceNo;
                datePaymentDate.Value = payment.ReferenceDate;

                // Customer
                for (int i = 0; i < cmbPaymentCustomer.Items.Count; i++)
                {
                    if (cmbPaymentCustomer.Items[i].ToString() == payment.Party)
                    {
                        cmbPaymentCustomer.SelectedIndex = i;
                        break;
                    }
                }

                // Party type
                for (int i = 0; i < cmbPaymentPartyType.Items.Count; i++)
                {
                    if (cmbPaymentPartyType.Items[i].ToString() == payment.PartyType)
                    {
                        cmbPaymentPartyType.SelectedIndex = i;
                        break;
                    }
                }

                // Payment type
                for (int i = 0; i < cmbPaymentType.Items.Count; i++)
                {
                    if (cmbPaymentType.Items[i].ToString() == payment.PaymentType.ToString())
                    {
                        cmbPaymentType.SelectedIndex = i;
                        break;
                    }
                }

                // From account
                for (int i = 0; i < cmbPaymentFromAccount.Items.Count; i++)
                {
                    if (cmbPaymentFromAccount.Items[i].ToString() == payment.AccountPaidFrom.ToString())
                    {
                        cmbPaymentFromAccount.SelectedIndex = i;
                        break;
                    }
                }

                // To account
                for (int i = 0; i < cmbPaymentToAccount.Items.Count; i++)
                {
                    if (cmbPaymentToAccount.Items[i].ToString() == payment.AccountPaidTo.ToString())
                    {
                        cmbPaymentToAccount.SelectedIndex = i;
                        break;
                    }
                }

                // Status
                for (int i = 0; i < cmbPaymentEntryStatus.Items.Count; i++)
                {
                    if (cmbPaymentEntryStatus.Items[i].ToString() == payment.DocStatus.ToString())
                    {
                        cmbPaymentEntryStatus.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnUpdatePaymentEntry_Click(object sender, EventArgs e)
        {
            if (listPaymentEntries.SelectedItem != null)
            {
                updatePaymentEntry(listPaymentEntries.SelectedItem.ToString());
            }
        }

        private void updatePaymentEntry(string paymentEntryName)
        {
            if (client != null)
            {
                // retrieve original entry from database (not to lose any invisible information)
                ERPObject original = client.GetObject(DocType.PaymentEntry, paymentEntryName);
                PaymentEntry payment = new PaymentEntry(original);
                ERPObject updated = payment.Object;
                client.UpdateObject(DocType.PaymentEntry, paymentEntryName, updated);
            }
        }


        private void btnAddPaymentEntryReference_Click(object sender, EventArgs e)
        {
            if ((client != null) && (listPaymentEntries.SelectedItem != null))
            {
                PaymentEntryReference r = new PaymentEntryReference();

                bool isOk = true;
                if (txtPaymentEntryReference.Text.StartsWith("SO"))
                {
                    r.ReferenceDocType = "Sales Order";
                }
                else if (txtPaymentEntryReference.Text.StartsWith("SINV"))
                {
                    r.ReferenceDocType = "Sales Invoice";
                }
                else
                {
                    MessageBox.Show("Invalid reference ID");
                    txtPaymentEntryReference.Focus();
                    isOk = false;

                }

                if (isOk)
                {
                    r.Parent = listPaymentEntries.SelectedItem.ToString();
                    r.ReferenceName = txtPaymentEntryReference.Text;
                    r.TotalAmount = Convert.ToDouble(numPaymentAmount.Value);
                    r.OutstandingAmount = Convert.ToDouble(numPaymentAmount.Value);
                    r.AllocatedAmount = Convert.ToDouble(numPaymentAmount.Value);

                    ERPObject obj = r.Object;
                    client.InsertObject(obj);

                    getPaymentInfo(listPaymentEntries.SelectedItem.ToString());
                }
            }
        }
        #endregion

        #region sales invoices
        private void getSalesInvoiceList()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.SalesInvoice);

                listSalesInvoices.Items.Clear();
                foreach (ERPObject a in si)
                {
                    listSalesInvoices.Items.Add(a.Name);
                }
            }
        }
        #endregion

        #region stock
        private void btnGetStockEntries_Click(object sender, EventArgs e)
        {
            getStockEntryList();
        }

        private void getStockEntryList()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.StockEntry);

                listStockEntries.Items.Clear();
                foreach (ERPObject a in si)
                {
                    listStockEntries.Items.Add(a.Name);
                }
            }
        }

        private void getWarehouseList()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Warehouse);

                warehouses.Clear();
                cmbStockFromWarehouse.Items.Clear();
                cmbStockToWarehouse.Items.Clear();
                foreach (ERPObject a in si)
                {

                    warehouses.Add(getWarehouse(a.Name));
                    cmbStockFromWarehouse.Items.Add(a.Name);
                    cmbStockToWarehouse.Items.Add(a.Name);
                }
                cmbStockFromWarehouse.SelectedIndex = 0;
                cmbStockToWarehouse.SelectedIndex = 0;
            }
        }

        private Warehouse getWarehouse(string warehouseName)
        {
            Warehouse wh = new Warehouse();
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.Warehouse, warehouseName);
                wh = new Warehouse(obj);
            }
            return wh;
        }

        private void btnAddStockEntry_Click(object sender, EventArgs e)
        {
            addStockEntry();
        }

        private void addStockEntry()
        {
            if (client != null)
            {
                StockEntry se = getStockEntryFromForm(null);
                ERPObject obj = se.Object;
                client.InsertObject(obj);

                getPaymentEntryList();
            }
        }

        private StockEntry getStockEntryFromForm(StockEntry original)
        {
            if (original == null)
            {
                original = new StockEntry();
            }
            else
            {
                original.FromWarehouse = cmbStockFromWarehouse.SelectedItem.ToString();
                original.ToWarehouse = cmbStockToWarehouse.SelectedItem.ToString();

            }
            return original;
        }


        #endregion

        #region addresses
        private void btnGetAddressList_Click(object sender, EventArgs e)
        {
            getAddressList();
        }

        private void getAddressList()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Address);

                listAddresses.Items.Clear();
                foreach (ERPObject a in si)
                {
                    listAddresses.Items.Add(a.Name);
                }
            }
        }
        #endregion
    }
}
