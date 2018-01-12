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

namespace libracoreTimeTracker
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region global variables
        private ERPNextClient client;
        public class MainVars
        {
            public static string Server = string.Empty;
            public static string Username = string.Empty;
            public static string Password = string.Empty;
            public static Boolean LoginSuccess = false;
        }
        #endregion

        #region Event handler
        private void Main_Load(object sender, EventArgs e)
        {
            LoginHooks();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Help;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Button handler
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            Create create = new Create();
            create.client = client;
            create.method = "create";
            create.ShowDialog();
            Cursor = Cursors.Default;
        }
        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            Create create = new Create();
            create.client = client;
            create.method = "add";
            create.ShowDialog();
            Cursor = Cursors.Default;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            Viewer viewer = new Viewer();
            viewer.client = client;
            viewer.ShowDialog();
            Cursor = Cursors.Default;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://libracore.com");
        }
        #endregion

        #region Functions
        private void postLogin()
        {
            client = new ERPNextClient(MainVars.Server, MainVars.Username, MainVars.Password);
            client.HasError += Client_HasError;

            if (client.IsLoggedIn)
            {
                //successfull login
            }
            else
            {
                MessageBox.Show("Unable to connect.");
                MainVars.LoginSuccess = false;
                LoginHooks();
            }
        }
        private void Client_HasError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void LoginHooks()
        {
            Login login = new Login();
            login.ShowDialog();
            if (MainVars.LoginSuccess == true)
            {
                postLogin();
            }
            else
            {
                this.Close();
            }
        }

        #endregion

        

        
    }
}
