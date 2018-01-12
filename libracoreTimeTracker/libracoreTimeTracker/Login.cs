using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERPNextSharp;
using ERPNextSharp.Data;

namespace libracoreTimeTracker
{
    public partial class Login : Form
    {
        
        #region global variables
        private ERPNextClient client;
        private Config config;
        private enum ConnectionState { Disconnected, Connected, Initialising };
        #endregion

        #region Button handler
        private void btnLogin_Click(object sender, EventArgs e)
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
                    showConnected(ConnectionState.Connected);
                    Main.MainVars.Server = txtServer.Text;
                    Main.MainVars.Username = txtUsername.Text;
                    Main.MainVars.Password = txtPassword.Text;
                    Main.MainVars.LoginSuccess = true;
                    client.Dispose();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to connect.");
                }
            }
        }
        #endregion

        #region Functions
        private void Client_HasError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public Login()
        {
            InitializeComponent();
            loadConfig();
        }
        #endregion
    }
}
