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
using Tests;

namespace TimeTracker
{
    public partial class TimeTracker : Form
    {
        #region global variables
        private ERPNextClient client;
        private Config config;
        private enum ConnectionState { Disconnected, Connected, Initialising };
        #endregion

        public TimeTracker()
        {
            InitializeComponent();
        }

        private void TimeTracker_Load(object sender, EventArgs e)
        {
            
        }

        private void TimeTracker_Shown(object sender, EventArgs e)
        {
            showConnected(ConnectionState.Disconnected);

            loadConfig();
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

        private void Client_HasError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void postLoginHooks()
        {
            showConnected(ConnectionState.Initialising);
            Application.DoEvents();
            groupBox1.Visible = false;
            tabControl1.Visible = true;
            tabControl1.Location = new Point(1, 1);
            this.Width = 780;
            this.Height = 670;
            getTimesheets();
        }

        private void TimeTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                client.Dispose();
                btnConnect.Enabled = true;
                showConnected(ConnectionState.Disconnected);
            }
            
        }

        private void getTimesheets()
        {
            if(client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Timesheet);

                listTimeSheets.Items.Clear();
                foreach (ERPObject a in si)
                {
                    listTimeSheets.Items.Add(a.Name);
                }
            }
        }

        private void listTimeSheets_DoubleClick(object sender, EventArgs e)
        {
            if (listTimeSheets.SelectedItem != null)
            {
                string TimesheetName = listTimeSheets.SelectedItem.ToString();

                txtType.Clear();
                txtHour.Clear();
                dtStart_Detail.Value = DateTime.Now;
                dtEnd_Detail.Value = DateTime.Now;
                txtProject.Clear();
                txtTask.Clear();
                getTimesheetInfo(TimesheetName);
            }
        }

        private void getTimesheetInfo(string TimesheetName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.Timesheet, TimesheetName);
                Timesheet timesheet = new Timesheet(obj);

                txtCompany.Text = timesheet.company;
                try
                {
                    txtEmployee.Text = timesheet.employee;
                    txtEmployeeName.Text = timesheet.employee_name;
                }
                catch
                {
                    txtEmployee.Text = "n/a";
                    txtEmployeeName.Text = "n/a";
                }
                txtStatus.Text = timesheet.status;
                dtStartDate.Value = Convert.ToDateTime(timesheet.start_date);
                dtEndDate.Value = Convert.ToDateTime(timesheet.end_date);
                txtTotal.Text = timesheet.total_hours.ToString();
                txtNote.Text = timesheet.note.Replace("<br>", Environment.NewLine);

            }

            List<ERPObject> si = client.ListObjects(DocType.TimesheetDetail);

            listTimetables.Items.Clear();
            foreach (ERPObject a in si)
            {
                ERPObject obj = client.GetObject(DocType.TimesheetDetail, a.Name);
                TimesheetDetail timesheetDetail = new TimesheetDetail(obj);
                if (timesheetDetail.parent == TimesheetName)
                {
                    listTimetables.Items.Add(a.Name);
                }
                
            }
        }

        private void getTimeTableInfo(string TimeTableName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.TimesheetDetail, TimeTableName);
                TimesheetDetail timesheetDetail = new TimesheetDetail(obj);

                txtType.Text = timesheetDetail.activity_type;
                txtHour.Text = timesheetDetail.hours.ToString();
                dtStart_Detail.Value = Convert.ToDateTime(timesheetDetail.from_time);
                dtEnd_Detail.Value = Convert.ToDateTime(timesheetDetail.to_time);
                try
                {
                    txtProject.Text = timesheetDetail.project;
                    txtTask.Text = timesheetDetail.task;
                }
                catch
                {
                    txtProject.Text = "n/a";
                    txtTask.Text = "n/a";
                }
                
            }
        }

        private void listTimetables_DoubleClick(object sender, EventArgs e)
        {
            if (listTimetables.SelectedItem != null)
            {
                string TimeTableName = listTimetables.SelectedItem.ToString();

                getTimeTableInfo(TimeTableName);
            }
        }
    }
}
