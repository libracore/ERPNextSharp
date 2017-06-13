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
using ERPNext.DocTypes.Customer;
using ERPNext.DocTypes.Accounts;
using System.IO;

namespace Tests
{
    public partial class MainForm : Form
    {
        #region global variables
        private ERPNextClient client;
        private Config config;
        private List<Account> accounts;
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

        private PaymentEntry getPaymentFromForm()
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

            PaymentEntry payment = new PaymentEntry(datePaymentDate.Value,
                type, "OmniPro", paidFrom, paidTo, "CHF", 
                Convert.ToDouble(numPaymentAmount.Value),
                "Customer", party, txtPaymentReference.Text);

            return payment;
        }

        private void insertPayment()
        {
            if (client != null)
            {
                PaymentEntry payment = getPaymentFromForm();
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

        private void getPaymentInfo(string paymentName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.PaymentEntry, paymentName);
                PaymentEntry payment = new PaymentEntry(obj);

                numPaymentAmount.Value = Convert.ToDecimal(payment.PaidAmount);
                txtPaymentReference.Text = payment.ReferenceNo;
                datePaymentDate.Value = payment.ReferenceDate;

                for (int i = 0; i < cmbPaymentCustomer.Items.Count; i++)
                {
                    if (cmbPaymentCustomer.Items[i].ToString() == payment.Party)
                    {
                        cmbPaymentCustomer.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbPaymentPartyType.Items.Count; i++)
                {
                    if (cmbPaymentPartyType.Items[i].ToString() == payment.PartyType)
                    {
                        cmbPaymentPartyType.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbPaymentType.Items.Count; i++)
                {
                    if (cmbPaymentType.Items[i].ToString() == payment.PaymentType.ToString())
                    {
                        cmbPaymentType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #endregion

    }
}
