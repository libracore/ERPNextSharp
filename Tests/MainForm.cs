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
        #endregion

        #region constructor
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
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
                    showConnected(true);
                    postLoginHooks();
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
            getCustomerList();
            getPaymentEntryList();

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

        private void showConnected(bool isConnected)
        {
            if (isConnected)
            {
                statusConnected.Image = Properties.Resources.accept;
                statusConnected.Text = "Connected";
            }
            else
            {
                statusConnected.Image = Properties.Resources.cancel;
                statusConnected.Text = "Not connected";
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
            showConnected(false);
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
        private void btnGetPaymentEntries_Click(object sender, EventArgs e)
        {
            getPaymentEntryList();
        }

        private void getPaymentEntryList()
        {
            if (client != null)
            {
                List<ERPObject> paymnets = client.ListObjects(DocType.PaymentEntry);

                listPaymentEntries.Items.Clear();
                foreach (ERPObject o in paymnets)
                {
                    listPaymentEntries.Items.Add(o.Name);
                }
            }
        }

        private void btnInsertPaymentEntry_Click(object sender, EventArgs e)
        {
            insertPayment();
        }

        private PaymentEntry getPaymentFromForm()
        {
            PaymentEntry payment = new PaymentEntry();
            payment.PartyType = txtPaymentPartyType.Text;
            payment.PaidAmount = Convert.ToDouble(numPaymentAmount.Value);
            payment.ReferenceNo = txtPaymentReference.Text;
            payment.ReferenceDate = datePaymentDate.Value;
            payment.Party = cmbPaymentCustomer.SelectedItem.ToString();
            payment.SetPaymentType(cmbPaymentType.SelectedItem.ToString());
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

                txtPaymentPartyType.Text = payment.PartyType;
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
