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

namespace Tests
{
    public partial class MainForm : Form
    {
        #region global variables
        private ERPNextClient client;

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
            /* use this to preconfigure the form */
            txtServer.Text   = "";
            txtUsername.Text = "";
            txtPassword.Text = "";

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
                }
                else
                {
                    MessageBox.Show("Unable to connect.");
                }
            }

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
                foreach (ERPObject o in customers)
                {
                    listCustomers.Items.Add(o.Name);
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
                ERPCustomer customer = new ERPCustomer(obj);

                txtCustomerName.Text = customer.CustomerName;
                txtCustomerGroup.Text = customer.CustomerGroup;
                txtCustomerStatus.Text = customer.Status.ToString();
                txtCustomerTerritory.Text = customer.Territory;
                txtCustomerType.Text = customer.CustomerType.ToString();
                txtCustomerWebsite.Text = customer.Website;
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
                ERPCustomer customer = getCustomerFromForm();
                ERPObject obj = customer.Object;
                client.UpdateObject(DocType.Customer, customerName, obj);
            }    
        }

        private ERPCustomer getCustomerFromForm()
        {
            ERPCustomer customer = new ERPCustomer();
            customer.CustomerName = txtCustomerName.Text;
            customer.CustomerGroup = txtCustomerGroup.Text;
            customer.Territory = txtCustomerTerritory.Text;
            customer.Website = txtCustomerWebsite.Text;
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
                ERPCustomer customer = getCustomerFromForm();
                ERPObject obj = customer.Object;
                client.InsertObject(obj);

                getCustomerList();
            }
        }
        #endregion
    }
}
