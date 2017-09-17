using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingConnector
{
    public partial class MainForm : Form
    {
        #region global variables
        // thread safe delegate to update status bar
        delegate void SetTextCallback(string s);

        #endregion

        #region constructor
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setConnectionStatus("Not connected");

        }

        #endregion

        #region support functions
        private void setConnectionStatus(string s)
        {
            if (statusStrip1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setConnectionStatus);
                Invoke(d, new object[] { s });
            }
            else
            {
                statusConnection.Text = s;
            }
        }
        #endregion

    }
}
