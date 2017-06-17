namespace Tests
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetCustomers = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.txtCustomerOwner = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustomerWebsite = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnInsertCustomer = new System.Windows.Forms.Button();
            this.txtCustomerStatus = new System.Windows.Forms.TextBox();
            this.txtCustomerTerritory = new System.Windows.Forms.TextBox();
            this.txtCustomerType = new System.Windows.Forms.TextBox();
            this.txtCustomerGroup = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listCustomers = new System.Windows.Forms.ListBox();
            this.tabTransaction = new System.Windows.Forms.TabPage();
            this.cmbPaymentEntryStatus = new System.Windows.Forms.ComboBox();
            this.txtPaymentEntryReference = new System.Windows.Forms.TextBox();
            this.btnAddPaymentEntryReference = new System.Windows.Forms.Button();
            this.btnUpdatePaymentEntry = new System.Windows.Forms.Button();
            this.listPaymentEntryReferences = new System.Windows.Forms.ListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbPaymentCompany = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbPaymentToAccount = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbPaymentFromAccount = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbPaymentPartyType = new System.Windows.Forms.ComboBox();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbPaymentCustomer = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numPaymentAmount = new System.Windows.Forms.NumericUpDown();
            this.datePaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPaymentReference = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnInsertPaymentEntry = new System.Windows.Forms.Button();
            this.listPaymentEntries = new System.Windows.Forms.ListBox();
            this.btnGetPaymentEntries = new System.Windows.Forms.Button();
            this.tabSalesInvoice = new System.Windows.Forms.TabPage();
            this.listSalesInvoices = new System.Windows.Forms.ListBox();
            this.btnGetSalesInvoices = new System.Windows.Forms.Button();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.btnAddStockEntry = new System.Windows.Forms.Button();
            this.listStockEntries = new System.Windows.Forms.ListBox();
            this.btnGetStockEntries = new System.Windows.Forms.Button();
            this.tabAddress = new System.Windows.Forms.TabPage();
            this.listAddresses = new System.Windows.Forms.ListBox();
            this.btnGetAddressList = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbStockFromWarehouse = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbStockToWarehouse = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tabCustomer.SuspendLayout();
            this.tabTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPaymentAmount)).BeginInit();
            this.tabSalesInvoice.SuspendLayout();
            this.tabStock.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(79, 17);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(142, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServer_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(102, 103);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(21, 103);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(79, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(142, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(79, 43);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(142, 20);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // btnGetCustomers
            // 
            this.btnGetCustomers.Location = new System.Drawing.Point(20, 21);
            this.btnGetCustomers.Name = "btnGetCustomers";
            this.btnGetCustomers.Size = new System.Drawing.Size(120, 23);
            this.btnGetCustomers.TabIndex = 2;
            this.btnGetCustomers.Text = "Get customers";
            this.btnGetCustomers.UseVisualStyleBackColor = true;
            this.btnGetCustomers.Click += new System.EventHandler(this.btnGetCustomers_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Controls.Add(this.tabCustomer);
            this.tabControl1.Controls.Add(this.tabTransaction);
            this.tabControl1.Controls.Add(this.tabSalesInvoice);
            this.tabControl1.Controls.Add(this.tabStock);
            this.tabControl1.Controls.Add(this.tabAddress);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 311);
            this.tabControl1.TabIndex = 3;
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.groupBox1);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(581, 285);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.txtCustomerOwner);
            this.tabCustomer.Controls.Add(this.label10);
            this.tabCustomer.Controls.Add(this.txtCustomerWebsite);
            this.tabCustomer.Controls.Add(this.label9);
            this.tabCustomer.Controls.Add(this.btnDeleteCustomer);
            this.tabCustomer.Controls.Add(this.btnUpdateCustomer);
            this.tabCustomer.Controls.Add(this.btnInsertCustomer);
            this.tabCustomer.Controls.Add(this.txtCustomerStatus);
            this.tabCustomer.Controls.Add(this.txtCustomerTerritory);
            this.tabCustomer.Controls.Add(this.txtCustomerType);
            this.tabCustomer.Controls.Add(this.txtCustomerGroup);
            this.tabCustomer.Controls.Add(this.txtCustomerName);
            this.tabCustomer.Controls.Add(this.label8);
            this.tabCustomer.Controls.Add(this.label7);
            this.tabCustomer.Controls.Add(this.label6);
            this.tabCustomer.Controls.Add(this.label5);
            this.tabCustomer.Controls.Add(this.label4);
            this.tabCustomer.Controls.Add(this.listCustomers);
            this.tabCustomer.Controls.Add(this.btnGetCustomers);
            this.tabCustomer.Location = new System.Drawing.Point(4, 22);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomer.Size = new System.Drawing.Size(581, 285);
            this.tabCustomer.TabIndex = 1;
            this.tabCustomer.Text = "Customer";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // txtCustomerOwner
            // 
            this.txtCustomerOwner.Location = new System.Drawing.Point(292, 190);
            this.txtCustomerOwner.Name = "txtCustomerOwner";
            this.txtCustomerOwner.Size = new System.Drawing.Size(228, 20);
            this.txtCustomerOwner.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Owner";
            // 
            // txtCustomerWebsite
            // 
            this.txtCustomerWebsite.Location = new System.Drawing.Point(292, 164);
            this.txtCustomerWebsite.Name = "txtCustomerWebsite";
            this.txtCustomerWebsite.Size = new System.Drawing.Size(228, 20);
            this.txtCustomerWebsite.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Website";
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(148, 21);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteCustomer.TabIndex = 5;
            this.btnDeleteCustomer.Text = "Delete customer";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(274, 21);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(120, 23);
            this.btnUpdateCustomer.TabIndex = 15;
            this.btnUpdateCustomer.Text = "Update customer";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnInsertCustomer
            // 
            this.btnInsertCustomer.Location = new System.Drawing.Point(400, 21);
            this.btnInsertCustomer.Name = "btnInsertCustomer";
            this.btnInsertCustomer.Size = new System.Drawing.Size(120, 23);
            this.btnInsertCustomer.TabIndex = 14;
            this.btnInsertCustomer.Text = "Insert customer";
            this.btnInsertCustomer.UseVisualStyleBackColor = true;
            this.btnInsertCustomer.Click += new System.EventHandler(this.btnInsertCustomer_Click);
            // 
            // txtCustomerStatus
            // 
            this.txtCustomerStatus.Location = new System.Drawing.Point(292, 138);
            this.txtCustomerStatus.Name = "txtCustomerStatus";
            this.txtCustomerStatus.Size = new System.Drawing.Size(228, 20);
            this.txtCustomerStatus.TabIndex = 13;
            // 
            // txtCustomerTerritory
            // 
            this.txtCustomerTerritory.Location = new System.Drawing.Point(292, 115);
            this.txtCustomerTerritory.Name = "txtCustomerTerritory";
            this.txtCustomerTerritory.Size = new System.Drawing.Size(228, 20);
            this.txtCustomerTerritory.TabIndex = 12;
            // 
            // txtCustomerType
            // 
            this.txtCustomerType.Location = new System.Drawing.Point(292, 93);
            this.txtCustomerType.Name = "txtCustomerType";
            this.txtCustomerType.Size = new System.Drawing.Size(228, 20);
            this.txtCustomerType.TabIndex = 11;
            // 
            // txtCustomerGroup
            // 
            this.txtCustomerGroup.Location = new System.Drawing.Point(292, 69);
            this.txtCustomerGroup.Name = "txtCustomerGroup";
            this.txtCustomerGroup.Size = new System.Drawing.Size(228, 20);
            this.txtCustomerGroup.TabIndex = 10;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(292, 47);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(228, 20);
            this.txtCustomerName.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Territory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name";
            // 
            // listCustomers
            // 
            this.listCustomers.FormattingEnabled = true;
            this.listCustomers.Location = new System.Drawing.Point(20, 50);
            this.listCustomers.Name = "listCustomers";
            this.listCustomers.Size = new System.Drawing.Size(184, 121);
            this.listCustomers.TabIndex = 3;
            this.listCustomers.DoubleClick += new System.EventHandler(this.listCustomers_DoubleClick);
            // 
            // tabTransaction
            // 
            this.tabTransaction.Controls.Add(this.cmbPaymentEntryStatus);
            this.tabTransaction.Controls.Add(this.txtPaymentEntryReference);
            this.tabTransaction.Controls.Add(this.btnAddPaymentEntryReference);
            this.tabTransaction.Controls.Add(this.btnUpdatePaymentEntry);
            this.tabTransaction.Controls.Add(this.listPaymentEntryReferences);
            this.tabTransaction.Controls.Add(this.label20);
            this.tabTransaction.Controls.Add(this.cmbPaymentCompany);
            this.tabTransaction.Controls.Add(this.label19);
            this.tabTransaction.Controls.Add(this.cmbPaymentToAccount);
            this.tabTransaction.Controls.Add(this.label18);
            this.tabTransaction.Controls.Add(this.cmbPaymentFromAccount);
            this.tabTransaction.Controls.Add(this.label17);
            this.tabTransaction.Controls.Add(this.cmbPaymentPartyType);
            this.tabTransaction.Controls.Add(this.cmbPaymentType);
            this.tabTransaction.Controls.Add(this.label16);
            this.tabTransaction.Controls.Add(this.cmbPaymentCustomer);
            this.tabTransaction.Controls.Add(this.label15);
            this.tabTransaction.Controls.Add(this.numPaymentAmount);
            this.tabTransaction.Controls.Add(this.datePaymentDate);
            this.tabTransaction.Controls.Add(this.label14);
            this.tabTransaction.Controls.Add(this.txtPaymentReference);
            this.tabTransaction.Controls.Add(this.label13);
            this.tabTransaction.Controls.Add(this.label12);
            this.tabTransaction.Controls.Add(this.label11);
            this.tabTransaction.Controls.Add(this.btnInsertPaymentEntry);
            this.tabTransaction.Controls.Add(this.listPaymentEntries);
            this.tabTransaction.Controls.Add(this.btnGetPaymentEntries);
            this.tabTransaction.Location = new System.Drawing.Point(4, 22);
            this.tabTransaction.Name = "tabTransaction";
            this.tabTransaction.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransaction.Size = new System.Drawing.Size(581, 285);
            this.tabTransaction.TabIndex = 2;
            this.tabTransaction.Text = "Transaction";
            this.tabTransaction.UseVisualStyleBackColor = true;
            // 
            // cmbPaymentEntryStatus
            // 
            this.cmbPaymentEntryStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentEntryStatus.FormattingEnabled = true;
            this.cmbPaymentEntryStatus.Items.AddRange(new object[] {
            "Draft",
            "Submitted",
            "Cancelled"});
            this.cmbPaymentEntryStatus.Location = new System.Drawing.Point(422, 71);
            this.cmbPaymentEntryStatus.Name = "cmbPaymentEntryStatus";
            this.cmbPaymentEntryStatus.Size = new System.Drawing.Size(98, 21);
            this.cmbPaymentEntryStatus.TabIndex = 39;
            // 
            // txtPaymentEntryReference
            // 
            this.txtPaymentEntryReference.Location = new System.Drawing.Point(101, 175);
            this.txtPaymentEntryReference.Name = "txtPaymentEntryReference";
            this.txtPaymentEntryReference.Size = new System.Drawing.Size(71, 20);
            this.txtPaymentEntryReference.TabIndex = 38;
            // 
            // btnAddPaymentEntryReference
            // 
            this.btnAddPaymentEntryReference.Image = global::Tests.Properties.Resources.add;
            this.btnAddPaymentEntryReference.Location = new System.Drawing.Point(178, 173);
            this.btnAddPaymentEntryReference.Name = "btnAddPaymentEntryReference";
            this.btnAddPaymentEntryReference.Size = new System.Drawing.Size(22, 23);
            this.btnAddPaymentEntryReference.TabIndex = 37;
            this.btnAddPaymentEntryReference.UseVisualStyleBackColor = true;
            this.btnAddPaymentEntryReference.Click += new System.EventHandler(this.btnAddPaymentEntryReference_Click);
            // 
            // btnUpdatePaymentEntry
            // 
            this.btnUpdatePaymentEntry.Location = new System.Drawing.Point(268, 16);
            this.btnUpdatePaymentEntry.Name = "btnUpdatePaymentEntry";
            this.btnUpdatePaymentEntry.Size = new System.Drawing.Size(120, 23);
            this.btnUpdatePaymentEntry.TabIndex = 3;
            this.btnUpdatePaymentEntry.Text = "Update payment entry";
            this.btnUpdatePaymentEntry.UseVisualStyleBackColor = true;
            this.btnUpdatePaymentEntry.Click += new System.EventHandler(this.btnUpdatePaymentEntry_Click);
            // 
            // listPaymentEntryReferences
            // 
            this.listPaymentEntryReferences.FormattingEnabled = true;
            this.listPaymentEntryReferences.Location = new System.Drawing.Point(16, 200);
            this.listPaymentEntryReferences.Name = "listPaymentEntryReferences";
            this.listPaymentEntryReferences.Size = new System.Drawing.Size(184, 69);
            this.listPaymentEntryReferences.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(22, 176);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "References";
            // 
            // cmbPaymentCompany
            // 
            this.cmbPaymentCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentCompany.FormattingEnabled = true;
            this.cmbPaymentCompany.Location = new System.Drawing.Point(292, 254);
            this.cmbPaymentCompany.Name = "cmbPaymentCompany";
            this.cmbPaymentCompany.Size = new System.Drawing.Size(228, 21);
            this.cmbPaymentCompany.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(223, 257);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "Company";
            // 
            // cmbPaymentToAccount
            // 
            this.cmbPaymentToAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentToAccount.FormattingEnabled = true;
            this.cmbPaymentToAccount.Location = new System.Drawing.Point(292, 227);
            this.cmbPaymentToAccount.Name = "cmbPaymentToAccount";
            this.cmbPaymentToAccount.Size = new System.Drawing.Size(228, 21);
            this.cmbPaymentToAccount.TabIndex = 27;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(223, 230);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Paid to";
            // 
            // cmbPaymentFromAccount
            // 
            this.cmbPaymentFromAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentFromAccount.FormattingEnabled = true;
            this.cmbPaymentFromAccount.Location = new System.Drawing.Point(292, 200);
            this.cmbPaymentFromAccount.Name = "cmbPaymentFromAccount";
            this.cmbPaymentFromAccount.Size = new System.Drawing.Size(228, 21);
            this.cmbPaymentFromAccount.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(223, 203);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Paid from";
            // 
            // cmbPaymentPartyType
            // 
            this.cmbPaymentPartyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentPartyType.FormattingEnabled = true;
            this.cmbPaymentPartyType.Location = new System.Drawing.Point(292, 45);
            this.cmbPaymentPartyType.Name = "cmbPaymentPartyType";
            this.cmbPaymentPartyType.Size = new System.Drawing.Size(228, 21);
            this.cmbPaymentPartyType.TabIndex = 20;
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(292, 173);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(228, 21);
            this.cmbPaymentType.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(223, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Payment type";
            // 
            // cmbPaymentCustomer
            // 
            this.cmbPaymentCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentCustomer.FormattingEnabled = true;
            this.cmbPaymentCustomer.Location = new System.Drawing.Point(292, 146);
            this.cmbPaymentCustomer.Name = "cmbPaymentCustomer";
            this.cmbPaymentCustomer.Size = new System.Drawing.Size(228, 21);
            this.cmbPaymentCustomer.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(223, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Customer";
            // 
            // numPaymentAmount
            // 
            this.numPaymentAmount.DecimalPlaces = 2;
            this.numPaymentAmount.Location = new System.Drawing.Point(292, 72);
            this.numPaymentAmount.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numPaymentAmount.Name = "numPaymentAmount";
            this.numPaymentAmount.Size = new System.Drawing.Size(124, 20);
            this.numPaymentAmount.TabIndex = 21;
            this.numPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // datePaymentDate
            // 
            this.datePaymentDate.Location = new System.Drawing.Point(292, 120);
            this.datePaymentDate.Name = "datePaymentDate";
            this.datePaymentDate.Size = new System.Drawing.Size(228, 20);
            this.datePaymentDate.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(223, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Date";
            // 
            // txtPaymentReference
            // 
            this.txtPaymentReference.Location = new System.Drawing.Point(292, 97);
            this.txtPaymentReference.Name = "txtPaymentReference";
            this.txtPaymentReference.Size = new System.Drawing.Size(228, 20);
            this.txtPaymentReference.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(223, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Reference";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(223, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Party type";
            // 
            // btnInsertPaymentEntry
            // 
            this.btnInsertPaymentEntry.Location = new System.Drawing.Point(142, 16);
            this.btnInsertPaymentEntry.Name = "btnInsertPaymentEntry";
            this.btnInsertPaymentEntry.Size = new System.Drawing.Size(120, 23);
            this.btnInsertPaymentEntry.TabIndex = 2;
            this.btnInsertPaymentEntry.Text = "Insert payment entry";
            this.btnInsertPaymentEntry.UseVisualStyleBackColor = true;
            this.btnInsertPaymentEntry.Click += new System.EventHandler(this.btnInsertPaymentEntry_Click);
            // 
            // listPaymentEntries
            // 
            this.listPaymentEntries.FormattingEnabled = true;
            this.listPaymentEntries.Location = new System.Drawing.Point(16, 45);
            this.listPaymentEntries.Name = "listPaymentEntries";
            this.listPaymentEntries.Size = new System.Drawing.Size(184, 121);
            this.listPaymentEntries.TabIndex = 10;
            this.listPaymentEntries.DoubleClick += new System.EventHandler(this.listPaymentEntries_DoubleClick);
            // 
            // btnGetPaymentEntries
            // 
            this.btnGetPaymentEntries.Location = new System.Drawing.Point(16, 16);
            this.btnGetPaymentEntries.Name = "btnGetPaymentEntries";
            this.btnGetPaymentEntries.Size = new System.Drawing.Size(120, 23);
            this.btnGetPaymentEntries.TabIndex = 1;
            this.btnGetPaymentEntries.Text = "Get payment entries";
            this.btnGetPaymentEntries.UseVisualStyleBackColor = true;
            this.btnGetPaymentEntries.Click += new System.EventHandler(this.btnGetPaymentEntries_Click);
            // 
            // tabSalesInvoice
            // 
            this.tabSalesInvoice.Controls.Add(this.listSalesInvoices);
            this.tabSalesInvoice.Controls.Add(this.btnGetSalesInvoices);
            this.tabSalesInvoice.Location = new System.Drawing.Point(4, 22);
            this.tabSalesInvoice.Name = "tabSalesInvoice";
            this.tabSalesInvoice.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalesInvoice.Size = new System.Drawing.Size(581, 285);
            this.tabSalesInvoice.TabIndex = 3;
            this.tabSalesInvoice.Text = "Sales invoice";
            this.tabSalesInvoice.UseVisualStyleBackColor = true;
            // 
            // listSalesInvoices
            // 
            this.listSalesInvoices.FormattingEnabled = true;
            this.listSalesInvoices.Location = new System.Drawing.Point(6, 41);
            this.listSalesInvoices.Name = "listSalesInvoices";
            this.listSalesInvoices.Size = new System.Drawing.Size(184, 121);
            this.listSalesInvoices.TabIndex = 7;
            // 
            // btnGetSalesInvoices
            // 
            this.btnGetSalesInvoices.Enabled = false;
            this.btnGetSalesInvoices.Location = new System.Drawing.Point(6, 12);
            this.btnGetSalesInvoices.Name = "btnGetSalesInvoices";
            this.btnGetSalesInvoices.Size = new System.Drawing.Size(120, 23);
            this.btnGetSalesInvoices.TabIndex = 6;
            this.btnGetSalesInvoices.Text = "Get sales invoices";
            this.btnGetSalesInvoices.UseVisualStyleBackColor = true;
            // 
            // tabStock
            // 
            this.tabStock.Controls.Add(this.cmbStockToWarehouse);
            this.tabStock.Controls.Add(this.label22);
            this.tabStock.Controls.Add(this.cmbStockFromWarehouse);
            this.tabStock.Controls.Add(this.label21);
            this.tabStock.Controls.Add(this.btnAddStockEntry);
            this.tabStock.Controls.Add(this.listStockEntries);
            this.tabStock.Controls.Add(this.btnGetStockEntries);
            this.tabStock.Location = new System.Drawing.Point(4, 22);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabStock.Size = new System.Drawing.Size(581, 285);
            this.tabStock.TabIndex = 4;
            this.tabStock.Text = "Stock";
            this.tabStock.UseVisualStyleBackColor = true;
            // 
            // btnAddStockEntry
            // 
            this.btnAddStockEntry.Location = new System.Drawing.Point(132, 11);
            this.btnAddStockEntry.Name = "btnAddStockEntry";
            this.btnAddStockEntry.Size = new System.Drawing.Size(120, 23);
            this.btnAddStockEntry.TabIndex = 13;
            this.btnAddStockEntry.Text = "Add stock entry";
            this.btnAddStockEntry.UseVisualStyleBackColor = true;
            this.btnAddStockEntry.Click += new System.EventHandler(this.btnAddStockEntry_Click);
            // 
            // listStockEntries
            // 
            this.listStockEntries.FormattingEnabled = true;
            this.listStockEntries.Location = new System.Drawing.Point(6, 40);
            this.listStockEntries.Name = "listStockEntries";
            this.listStockEntries.Size = new System.Drawing.Size(184, 121);
            this.listStockEntries.TabIndex = 12;
            // 
            // btnGetStockEntries
            // 
            this.btnGetStockEntries.Location = new System.Drawing.Point(6, 11);
            this.btnGetStockEntries.Name = "btnGetStockEntries";
            this.btnGetStockEntries.Size = new System.Drawing.Size(120, 23);
            this.btnGetStockEntries.TabIndex = 11;
            this.btnGetStockEntries.Text = "Get stock entries";
            this.btnGetStockEntries.UseVisualStyleBackColor = true;
            this.btnGetStockEntries.Click += new System.EventHandler(this.btnGetStockEntries_Click);
            // 
            // tabAddress
            // 
            this.tabAddress.Controls.Add(this.listAddresses);
            this.tabAddress.Controls.Add(this.btnGetAddressList);
            this.tabAddress.Location = new System.Drawing.Point(4, 22);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddress.Size = new System.Drawing.Size(581, 285);
            this.tabAddress.TabIndex = 5;
            this.tabAddress.Text = "Address";
            this.tabAddress.UseVisualStyleBackColor = true;
            // 
            // listAddresses
            // 
            this.listAddresses.FormattingEnabled = true;
            this.listAddresses.Location = new System.Drawing.Point(16, 42);
            this.listAddresses.Name = "listAddresses";
            this.listAddresses.Size = new System.Drawing.Size(184, 121);
            this.listAddresses.TabIndex = 14;
            // 
            // btnGetAddressList
            // 
            this.btnGetAddressList.Location = new System.Drawing.Point(16, 13);
            this.btnGetAddressList.Name = "btnGetAddressList";
            this.btnGetAddressList.Size = new System.Drawing.Size(120, 23);
            this.btnGetAddressList.TabIndex = 13;
            this.btnGetAddressList.Text = "Get addresses";
            this.btnGetAddressList.UseVisualStyleBackColor = true;
            this.btnGetAddressList.Click += new System.EventHandler(this.btnGetAddressList_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConnected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(613, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusConnected
            // 
            this.statusConnected.Image = global::Tests.Properties.Resources.arrow_refresh;
            this.statusConnected.Name = "statusConnected";
            this.statusConnected.Size = new System.Drawing.Size(102, 17);
            this.statusConnected.Text = "Not connected";
            // 
            // cmbStockFromWarehouse
            // 
            this.cmbStockFromWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockFromWarehouse.FormattingEnabled = true;
            this.cmbStockFromWarehouse.Location = new System.Drawing.Point(304, 40);
            this.cmbStockFromWarehouse.Name = "cmbStockFromWarehouse";
            this.cmbStockFromWarehouse.Size = new System.Drawing.Size(228, 21);
            this.cmbStockFromWarehouse.TabIndex = 26;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(213, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "From warehouse";
            // 
            // cmbStockToWarehouse
            // 
            this.cmbStockToWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockToWarehouse.FormattingEnabled = true;
            this.cmbStockToWarehouse.Location = new System.Drawing.Point(304, 67);
            this.cmbStockToWarehouse.Name = "cmbStockToWarehouse";
            this.cmbStockToWarehouse.Size = new System.Drawing.Size(228, 21);
            this.cmbStockToWarehouse.TabIndex = 28;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(213, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "To warehouse";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 360);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ERPNextSharp Tests";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabCustomer.ResumeLayout(false);
            this.tabCustomer.PerformLayout();
            this.tabTransaction.ResumeLayout(false);
            this.tabTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPaymentAmount)).EndInit();
            this.tabSalesInvoice.ResumeLayout(false);
            this.tabStock.ResumeLayout(false);
            this.tabStock.PerformLayout();
            this.tabAddress.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetCustomers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabCustomer;
        private System.Windows.Forms.ListBox listCustomers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusConnected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerStatus;
        private System.Windows.Forms.TextBox txtCustomerTerritory;
        private System.Windows.Forms.TextBox txtCustomerType;
        private System.Windows.Forms.TextBox txtCustomerGroup;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnInsertCustomer;
        private System.Windows.Forms.TextBox txtCustomerWebsite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabTransaction;
        private System.Windows.Forms.TextBox txtCustomerOwner;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listPaymentEntries;
        private System.Windows.Forms.Button btnGetPaymentEntries;
        private System.Windows.Forms.NumericUpDown numPaymentAmount;
        private System.Windows.Forms.DateTimePicker datePaymentDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPaymentReference;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnInsertPaymentEntry;
        private System.Windows.Forms.ComboBox cmbPaymentCustomer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbPaymentPartyType;
        private System.Windows.Forms.ComboBox cmbPaymentToAccount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbPaymentFromAccount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbPaymentCompany;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListBox listPaymentEntryReferences;
        private System.Windows.Forms.TabPage tabSalesInvoice;
        private System.Windows.Forms.ListBox listSalesInvoices;
        private System.Windows.Forms.Button btnGetSalesInvoices;
        private System.Windows.Forms.Button btnUpdatePaymentEntry;
        private System.Windows.Forms.Button btnAddPaymentEntryReference;
        private System.Windows.Forms.TextBox txtPaymentEntryReference;
        private System.Windows.Forms.ComboBox cmbPaymentEntryStatus;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.ListBox listStockEntries;
        private System.Windows.Forms.Button btnGetStockEntries;
        private System.Windows.Forms.Button btnAddStockEntry;
        private System.Windows.Forms.TabPage tabAddress;
        private System.Windows.Forms.ListBox listAddresses;
        private System.Windows.Forms.Button btnGetAddressList;
        private System.Windows.Forms.ComboBox cmbStockToWarehouse;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbStockFromWarehouse;
        private System.Windows.Forms.Label label21;
    }
}

