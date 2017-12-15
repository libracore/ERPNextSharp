namespace ItemImporter
{
    partial class Importer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Importer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabItemsList = new System.Windows.Forms.TabPage();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.btnGetItemsList = new System.Windows.Forms.Button();
            this.listItems = new System.Windows.Forms.ListBox();
            this.tabItemImportStandard = new System.Windows.Forms.TabPage();
            this.btnClipboardImport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInsertItem = new System.Windows.Forms.Button();
            this.tabItemPrice = new System.Windows.Forms.TabPage();
            this.btnInsertPrice = new System.Windows.Forms.Button();
            this.btnClipboardImport2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPriceRule = new System.Windows.Forms.TabPage();
            this.btnInsertPriceRule = new System.Windows.Forms.Button();
            this.btnClipboardImport3 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabItemsList.SuspendLayout();
            this.tabItemImportStandard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabItemPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPriceRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConnected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(776, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusConnected
            // 
            this.statusConnected.Image = global::ItemImporter.Properties.Resources.arrow_refresh;
            this.statusConnected.Name = "statusConnected";
            this.statusConnected.Size = new System.Drawing.Size(102, 17);
            this.statusConnected.Text = "Not connected";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 371);
            this.tabControl1.TabIndex = 6;
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.groupBox1);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(744, 345);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.UseVisualStyleBackColor = true;
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
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(79, 43);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(142, 20);
            this.txtUsername.TabIndex = 2;
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
            // tabItems
            // 
            this.tabItems.Controls.Add(this.tabControl2);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(744, 345);
            this.tabItems.TabIndex = 6;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabItemsList);
            this.tabControl2.Controls.Add(this.tabItemImportStandard);
            this.tabControl2.Controls.Add(this.tabItemPrice);
            this.tabControl2.Controls.Add(this.tabPriceRule);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(732, 336);
            this.tabControl2.TabIndex = 20;
            // 
            // tabItemsList
            // 
            this.tabItemsList.Controls.Add(this.txtItemName);
            this.tabItemsList.Controls.Add(this.txtItemCode);
            this.tabItemsList.Controls.Add(this.btnGetItemsList);
            this.tabItemsList.Controls.Add(this.listItems);
            this.tabItemsList.Location = new System.Drawing.Point(4, 22);
            this.tabItemsList.Name = "tabItemsList";
            this.tabItemsList.Padding = new System.Windows.Forms.Padding(3);
            this.tabItemsList.Size = new System.Drawing.Size(724, 310);
            this.tabItemsList.TabIndex = 0;
            this.tabItemsList.Text = "List / Update Items";
            this.tabItemsList.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(216, 61);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(100, 20);
            this.txtItemName.TabIndex = 19;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(216, 35);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(100, 20);
            this.txtItemCode.TabIndex = 20;
            // 
            // btnGetItemsList
            // 
            this.btnGetItemsList.Location = new System.Drawing.Point(6, 6);
            this.btnGetItemsList.Name = "btnGetItemsList";
            this.btnGetItemsList.Size = new System.Drawing.Size(120, 23);
            this.btnGetItemsList.TabIndex = 16;
            this.btnGetItemsList.Text = "Get items";
            this.btnGetItemsList.UseVisualStyleBackColor = true;
            this.btnGetItemsList.Click += new System.EventHandler(this.btnGetItemsList_Click);
            // 
            // listItems
            // 
            this.listItems.FormattingEnabled = true;
            this.listItems.Location = new System.Drawing.Point(6, 35);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(184, 173);
            this.listItems.TabIndex = 15;
            this.listItems.DoubleClick += new System.EventHandler(this.listItems_DoubleClick);
            // 
            // tabItemImportStandard
            // 
            this.tabItemImportStandard.Controls.Add(this.btnClipboardImport);
            this.tabItemImportStandard.Controls.Add(this.dataGridView1);
            this.tabItemImportStandard.Controls.Add(this.btnInsertItem);
            this.tabItemImportStandard.Location = new System.Drawing.Point(4, 22);
            this.tabItemImportStandard.Name = "tabItemImportStandard";
            this.tabItemImportStandard.Padding = new System.Windows.Forms.Padding(3);
            this.tabItemImportStandard.Size = new System.Drawing.Size(724, 310);
            this.tabItemImportStandard.TabIndex = 1;
            this.tabItemImportStandard.Text = "Import Standard Item";
            this.tabItemImportStandard.UseVisualStyleBackColor = true;
            // 
            // btnClipboardImport
            // 
            this.btnClipboardImport.Location = new System.Drawing.Point(1, 1);
            this.btnClipboardImport.Name = "btnClipboardImport";
            this.btnClipboardImport.Size = new System.Drawing.Size(151, 23);
            this.btnClipboardImport.TabIndex = 21;
            this.btnClipboardImport.Text = "Insert Table from Clipboard";
            this.btnClipboardImport.UseVisualStyleBackColor = true;
            this.btnClipboardImport.Click += new System.EventHandler(this.btnClipboardImport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(723, 280);
            this.dataGridView1.TabIndex = 20;
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.Location = new System.Drawing.Point(158, 1);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.Size = new System.Drawing.Size(120, 23);
            this.btnInsertItem.TabIndex = 19;
            this.btnInsertItem.Text = "Insert item(s) in ERP";
            this.btnInsertItem.UseVisualStyleBackColor = true;
            this.btnInsertItem.Click += new System.EventHandler(this.btnInsertItem_Click);
            // 
            // tabItemPrice
            // 
            this.tabItemPrice.Controls.Add(this.btnInsertPrice);
            this.tabItemPrice.Controls.Add(this.btnClipboardImport2);
            this.tabItemPrice.Controls.Add(this.dataGridView2);
            this.tabItemPrice.Location = new System.Drawing.Point(4, 22);
            this.tabItemPrice.Name = "tabItemPrice";
            this.tabItemPrice.Size = new System.Drawing.Size(724, 310);
            this.tabItemPrice.TabIndex = 2;
            this.tabItemPrice.Text = "Import Item Price";
            this.tabItemPrice.UseVisualStyleBackColor = true;
            // 
            // btnInsertPrice
            // 
            this.btnInsertPrice.Location = new System.Drawing.Point(158, 1);
            this.btnInsertPrice.Name = "btnInsertPrice";
            this.btnInsertPrice.Size = new System.Drawing.Size(120, 23);
            this.btnInsertPrice.TabIndex = 23;
            this.btnInsertPrice.Text = "Insert Price(s) in ERP";
            this.btnInsertPrice.UseVisualStyleBackColor = true;
            this.btnInsertPrice.Click += new System.EventHandler(this.btnInsertPrice_Click);
            // 
            // btnClipboardImport2
            // 
            this.btnClipboardImport2.Location = new System.Drawing.Point(1, 1);
            this.btnClipboardImport2.Name = "btnClipboardImport2";
            this.btnClipboardImport2.Size = new System.Drawing.Size(151, 23);
            this.btnClipboardImport2.TabIndex = 22;
            this.btnClipboardImport2.Text = "Insert Table from Clipboard";
            this.btnClipboardImport2.UseVisualStyleBackColor = true;
            this.btnClipboardImport2.Click += new System.EventHandler(this.btnClipboardImport2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(724, 280);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPriceRule
            // 
            this.tabPriceRule.Controls.Add(this.btnInsertPriceRule);
            this.tabPriceRule.Controls.Add(this.btnClipboardImport3);
            this.tabPriceRule.Controls.Add(this.dataGridView3);
            this.tabPriceRule.Location = new System.Drawing.Point(4, 22);
            this.tabPriceRule.Name = "tabPriceRule";
            this.tabPriceRule.Size = new System.Drawing.Size(724, 310);
            this.tabPriceRule.TabIndex = 3;
            this.tabPriceRule.Text = "Import Price Rule";
            this.tabPriceRule.UseVisualStyleBackColor = true;
            // 
            // btnInsertPriceRule
            // 
            this.btnInsertPriceRule.Location = new System.Drawing.Point(158, 1);
            this.btnInsertPriceRule.Name = "btnInsertPriceRule";
            this.btnInsertPriceRule.Size = new System.Drawing.Size(150, 23);
            this.btnInsertPriceRule.TabIndex = 25;
            this.btnInsertPriceRule.Text = "Insert Price Rule(s) in ERP";
            this.btnInsertPriceRule.UseVisualStyleBackColor = true;
            this.btnInsertPriceRule.Click += new System.EventHandler(this.btnInsertPriceRule_Click);
            // 
            // btnClipboardImport3
            // 
            this.btnClipboardImport3.Location = new System.Drawing.Point(1, 1);
            this.btnClipboardImport3.Name = "btnClipboardImport3";
            this.btnClipboardImport3.Size = new System.Drawing.Size(151, 23);
            this.btnClipboardImport3.TabIndex = 24;
            this.btnClipboardImport3.Text = "Insert Table from Clipboard";
            this.btnClipboardImport3.UseVisualStyleBackColor = true;
            this.btnClipboardImport3.Click += new System.EventHandler(this.btnClipboardImport3_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1, 30);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(723, 280);
            this.dataGridView3.TabIndex = 0;
            // 
            // Importer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 408);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Importer";
            this.Text = "ERPnext Importer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemImporter_FormClosing);
            this.Load += new System.EventHandler(this.ItemImporter_Load);
            this.Shown += new System.EventHandler(this.ItemImporter_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabItems.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabItemsList.ResumeLayout(false);
            this.tabItemsList.PerformLayout();
            this.tabItemImportStandard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabItemPrice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPriceRule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusConnected;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.Button btnGetItemsList;
        private System.Windows.Forms.ListBox listItems;
        private System.Windows.Forms.Button btnInsertItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabItemsList;
        private System.Windows.Forms.TabPage tabItemImportStandard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClipboardImport;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TabPage tabItemPrice;
        private System.Windows.Forms.Button btnClipboardImport2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnInsertPrice;
        private System.Windows.Forms.TabPage tabPriceRule;
        private System.Windows.Forms.Button btnInsertPriceRule;
        private System.Windows.Forms.Button btnClipboardImport3;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}

