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
using ERPNextSharp.DocTypes.Stock;
using System.IO;
using System.Text.RegularExpressions;

namespace ItemImporter
{
    public partial class Importer : Form
    {

        #region global variables
        private ERPNextClient client;
        private Config config;
        private List<Warehouse> warehouses;
        private List<Item> items;
        private enum ConnectionState { Disconnected, Connected, Initialising };
        #endregion

        #region constructor
        public Importer()
        {
            InitializeComponent();
        }

        private void ItemImporter_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            
            warehouses = new List<Warehouse>();
            items = new List<Item>();
        }

        private void ItemImporter_Shown(object sender, EventArgs e)
        {
            showConnected(ConnectionState.Disconnected);

            loadConfig();
        }

        private void ItemImporter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                client.Dispose();
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                showConnected(ConnectionState.Disconnected);
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
                    MessageBox.Show("Succesfully logged in", "Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to connect.");
                }
            }
        }

        private void Client_HasError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Extend here the functions to be executed after login
        /// </summary>
        private void postLoginHooks()
        {
            showConnected(ConnectionState.Initialising);
            Application.DoEvents();
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

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Dispose();
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            showConnected(ConnectionState.Disconnected);
        }
        #endregion

        #region get/update items
        private void getItemsList()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Item);

                listItems.Items.Clear();
                foreach (ERPObject a in si)
                {
                    listItems.Items.Add(a.Name);
                }
            }
        }

        private void btnGetItemsList_Click(object sender, EventArgs e)
        {
            getItemsList();
        }
        

        private void listItems_DoubleClick(object sender, EventArgs e)
        {
            if (listItems.SelectedItem != null)
            {
                string ItemName = listItems.SelectedItem.ToString();

                getItemInfo(ItemName);
            }
        }

        private void getItemInfo(string ItemName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.Item, ItemName);
                Item item = new Item(obj);

                txtItemName.Text = item.ItemName;
                txtItemCode.Text = item.ItemCode;
            }
        }
        #endregion

        #region import standard items
        private void btnClipboardImport_Click(object sender, EventArgs e)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows.Clear();

                if (dataGridView1.ColumnCount > 0)
                    dataGridView1.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                int j = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView1.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGridView1.Rows.Add();
                    int myRowIndex = dataGridView1.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dataGridView1.Rows[j])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                    j++;
                }
            }
        }

        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                CheckColumns();
            }
            else
            {
                MessageBox.Show("Please insert first an item table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckColumns()
        {
            int anz_col = dataGridView1.ColumnCount;
            Boolean check_Item_code = false;
            Boolean check_Item_name = false;
            for (int i = 0; i <= anz_col - 1; i++)
            {
                if (dataGridView1.Columns[i].HeaderText == "Item_code")
                {
                    check_Item_code = true;
                }
                if (dataGridView1.Columns[i].HeaderText == "Item_name")
                {
                    check_Item_name = true;
                }
            }

            if (!check_Item_code || !check_Item_name)
            {
                MessageBox.Show("Die Tabelle muss mindestens folgende Spalten aufweisen:" + Environment.NewLine
                    + "Item_code, Item_name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                insertItem();
            }
        }

        private void insertItem()
        {
            if (client != null)
            {
                int anz_rows = dataGridView1.RowCount;
                int anz_col = dataGridView1.ColumnCount;
                for (int i = 0; i <= anz_rows - 2; i++)
                {
                    Item item = new Item();

                    for (int y = 0; y <= anz_col - 1; y++)
                    {
                        if (dataGridView1.Columns[y].HeaderText == "Item_code")
                        {
                            item.ItemCode = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Item_name")
                        {
                            item.ItemName = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Item_group")
                        {
                            item.ItemGroup = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Variant_of")
                        {
                            item.VariantOf = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Barcode")
                        {
                            item.Barcode = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "UOM")
                        {
                            item.UnitOfMeasure = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Description")
                        {
                            item.Description = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Default_warehouse")
                        {
                            item.DefaultWarehouse = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Default_supplier")
                        {
                            item.DefaultSupplier = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Customer_item_name")
                        {
                            item.CustomerItemName = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "Default_material_request_type")
                        {
                            item.DefaultMaterialRequestType = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "has_batch_no")
                        {
                            item.has_batch_no = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "create_new_batch")
                        {
                            item.create_new_batch = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "has_expiry_date")
                        {
                            item.has_expiry_date = dataGridView1[y, i].Value.ToString();
                        }
                        if (dataGridView1.Columns[y].HeaderText == "publish_in_hub")
                        {
                            item.publish_in_hub = dataGridView1[y, i].Value.ToString();
                        }
                    }

                    ERPObject obj = item.Object;
                    client.InsertObject(obj);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                MessageBox.Show("Import done", "Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please login first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        
        #region import item price
        private void btnClipboardImport2_Click(object sender, EventArgs e)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView2.RowCount > 0)
                    dataGridView2.Rows.Clear();

                if (dataGridView2.ColumnCount > 0)
                    dataGridView2.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                int j = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView2.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGridView2.Rows.Add();
                    int myRowIndex = dataGridView2.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dataGridView2.Rows[j])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                    j++;
                }
            }
        }

        private void btnInsertPrice_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                CheckColumnsPrice();
            }
            else
            {
                MessageBox.Show("Please insert first an price table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckColumnsPrice()
        {
            int anz_col = dataGridView2.ColumnCount;
            Boolean check_Price_list = false;
            Boolean check_Item_code = false;
            Boolean check_rate = false;
            for (int i = 0; i <= anz_col - 1; i++)
            {
                if (dataGridView2.Columns[i].HeaderText == "Price_list")
                {
                    check_Price_list = true;
                }
                if (dataGridView2.Columns[i].HeaderText == "Item_code")
                {
                    check_Item_code = true;
                }
                if (dataGridView2.Columns[i].HeaderText == "Rate")
                {
                    check_rate = true;
                }
            }

            if (!check_Price_list || !check_Item_code || !check_rate)
            {
                MessageBox.Show("Die Tabelle muss mindestens folgende Spalten aufweisen:" + Environment.NewLine
                    + "Price_list, Item_code, Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                insertPrice();
            }
        }

        private void insertPrice()
        {
            if (client != null)
            {
                int anz_rows = dataGridView2.RowCount;
                int anz_col = dataGridView2.ColumnCount;
                for (int i = 0; i <= anz_rows - 2; i++)
                {
                    ItemPrice price = new ItemPrice();

                    for (int y = 0; y <= anz_col - 1; y++)
                    {
                        if (dataGridView2.Columns[y].HeaderText == "Item_code")
                        {
                            price.ItemCode = dataGridView2[y, i].Value.ToString();
                        }
                        if (dataGridView2.Columns[y].HeaderText == "Price_list")
                        {
                            price.PriceList = dataGridView2[y, i].Value.ToString();
                        }
                        if (dataGridView2.Columns[y].HeaderText == "Rate")
                        {
                            price.Rate = dataGridView2[y, i].Value.ToString();
                        }
                    }

                    ERPObject obj = price.Object;
                    client.InsertObject(obj);
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                MessageBox.Show("Import done", "Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please login first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region import price rule
        private void btnClipboardImport3_Click(object sender, EventArgs e)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView3.RowCount > 0)
                    dataGridView3.Rows.Clear();

                if (dataGridView3.ColumnCount > 0)
                    dataGridView3.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                int j = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView3.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGridView3.Rows.Add();
                    int myRowIndex = dataGridView3.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dataGridView3.Rows[j])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                    j++;
                }
            }
        }

        private void btnInsertPriceRule_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                CheckColumnsPriceRule();
            }
            else
            {
                MessageBox.Show("Please insert first an price rule table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckColumnsPriceRule()
        {
            int anz_col = dataGridView3.ColumnCount;
            Boolean check_Title = false;
            Boolean check_Item_code = false;
            Boolean check_selling_buying = false;
            Boolean check_min_qty = false;
            Boolean check_PriceOrDiscount = false;
            Boolean check_price = false;
            for (int i = 0; i <= anz_col - 1; i++)
            {
                if (dataGridView3.Columns[i].HeaderText == "Title")
                {
                    check_Title = true;
                }
                if (dataGridView3.Columns[i].HeaderText == "Item_code")
                {
                    check_Item_code = true;
                }
                if (dataGridView3.Columns[i].HeaderText == "Selling" || dataGridView3.Columns[i].HeaderText == "Buying")
                {
                    check_selling_buying = true;
                }
                if (dataGridView3.Columns[i].HeaderText == "Min_qty")
                {
                    check_min_qty = true;
                }
                if (dataGridView3.Columns[i].HeaderText == "Price_or_discount")
                {
                    check_PriceOrDiscount = true;
                }
                if (dataGridView3.Columns[i].HeaderText == "Price")
                {
                    check_price = true;
                }
            }

            if (!check_Title || !check_Item_code || !check_selling_buying || !check_min_qty || !check_PriceOrDiscount || !check_price)
            {
                MessageBox.Show("Die Tabelle muss mindestens folgende Spalten aufweisen:" + Environment.NewLine
                    + "Title, Item_code, Selling or Buying, Min_qty, Price_or_discount, Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                insertPriceRule();
            }
        }

        private void insertPriceRule()
        {
            if (client != null)
            {
                int anz_rows = dataGridView3.RowCount;
                int anz_col = dataGridView3.ColumnCount;
                for (int i = 0; i <= anz_rows - 2; i++)
                {
                    PricingRule pricerule = new PricingRule();

                    for (int y = 0; y <= anz_col - 1; y++)
                    {
                        if (dataGridView3.Columns[y].HeaderText == "Title")
                        {
                            pricerule.Title = dataGridView3[y, i].Value.ToString();
                        }
                        if (dataGridView3.Columns[y].HeaderText == "Item_code")
                        {
                            pricerule.ItemCode = dataGridView3[y, i].Value.ToString();
                        }
                        if (dataGridView3.Columns[y].HeaderText == "Selling")
                        {
                            pricerule.Selling = dataGridView3[y, i].Value.ToString();
                        }
                        if (dataGridView3.Columns[y].HeaderText == "Buying")
                        {
                            pricerule.Buying = dataGridView3[y, i].Value.ToString();
                        }
                        if (dataGridView3.Columns[y].HeaderText == "Min_qty")
                        {
                            pricerule.MinQTY = dataGridView3[y, i].Value.ToString();
                        }
                        if (dataGridView3.Columns[y].HeaderText == "Max_qty")
                        {
                            pricerule.MaxQTY = dataGridView3[y, i].Value.ToString();
                        }
                        if (dataGridView3.Columns[y].HeaderText == "Price_or_discount")
                        {
                            pricerule.PriceOrDiscount = dataGridView3[y, i].Value.ToString();
                        }
                        if (dataGridView3.Columns[y].HeaderText == "Price")
                        {
                            pricerule.Price = dataGridView3[y, i].Value.ToString();
                        }
                    }

                    ERPObject obj = pricerule.Object;
                    client.InsertObject(obj);
                    dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                MessageBox.Show("Import done", "Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please login first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
