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
            getActivityTypes();
            getCompanies();
            getUserID();
            getProject();
            getTask();
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

        private void getActivityTypes()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.ActivityType);

                cbActivity_Type.Items.Clear();
                foreach (ERPObject a in si)
                {
                    ERPObject obj = client.GetObject(DocType.ActivityType, a.Name);
                    ActivityType activityType = new ActivityType(obj);
                    if (activityType.disabled == 0)
                    {
                        cbActivity_Type.Items.Add(a.Name);
                        cbActivityType1.Items.Add(a.Name);
                    }
                }
                cbActivity_Type.Text = cbActivity_Type.Items[0].ToString();
            }
        }

        private void getUserID()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Employee);

                foreach (ERPObject a in si)
                {
                    cbEmployee.Items.Add(a.Name);
                    cbEmployee1.Items.Add(a.Name);
                }
                if(cbEmployee.Items.Count > 0)
                {
                    cbEmployee.Text = cbEmployee.Items[0].ToString();
                }
            }
        }

        private void getProject()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Project);

                foreach (ERPObject a in si)
                {
                    cbProject.Items.Add(a.Name);
                    cbProject1.Items.Add(a.Name);
                }
                if(cbProject.Items.Count > 0)
                {
                    cbProject.Text = cbProject.Items[0].ToString();
                }
            }
        }

        private void getTask()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Task);

                foreach (ERPObject a in si)
                {
                    cbTask1.Items.Add(a.Name);
                }
            }
        }

        private void getCompanies()
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Company);

                cbCompany.Items.Clear();
                foreach (ERPObject a in si)
                {
                    cbCompany.Items.Add(a.Name);
                    cbCompany1.Items.Add(a.Name);
                }
                cbCompany.Text = cbCompany.Items[0].ToString();
            }
        }

        private void listTimeSheets_DoubleClick(object sender, EventArgs e)
        {
            if (listTimeSheets.SelectedItem != null)
            {
                string TimesheetName = listTimeSheets.SelectedItem.ToString();

                cbActivityType1.Text="";
                txtHour.Clear();
                dtStart_Detail.Value = DateTime.Now;
                dtEnd_Detail.Value = DateTime.Now;
                cbProject1.Text="";
                cbTask1.Text="";
                getTimesheetInfo(TimesheetName);
            }
        }

        private void getTimesheetInfo(string TimesheetName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.Timesheet, TimesheetName);
                Timesheet timesheet = new Timesheet(obj);

                cbCompany1.Text = timesheet.company;
                try
                {
                    cbEmployee1.Text = timesheet.employee;
                    txtEmployeeName.Text = timesheet.employee_name;
                }
                catch
                {
                    cbEmployee1.Text = "n/a";
                    txtEmployeeName.Text = "n/a";
                }
                cbStatus.Text = timesheet.status;
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

                cbActivityType1.Text = timesheetDetail.activity_type;
                txtHour.Text = timesheetDetail.hours.ToString();
                dtStart_Detail.Value = Convert.ToDateTime(timesheetDetail.from_time);
                
                try
                {
                    cbProject1.Text = timesheetDetail.project;
                }
                catch
                {
                    cbProject1.Text = "n/a";
                }
                try
                {
                    cbTask1.Text = timesheetDetail.task;
                }
                catch
                {
                    cbTask1.Text = "n/a";
                }
                try
                {
                    dtEnd_Detail.Value = Convert.ToDateTime(timesheetDetail.to_time);
                    dtEnd_Detail.Visible = true;
                    label18.Visible = true;
                }
                catch
                {
                    dtEnd_Detail.Visible = false;
                    label18.Visible = false;
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SaveAsDraft();
        }

        private void SaveAsDraft()
        {
            Timesheet timesheet = new Timesheet();
            TimesheetDetail timesheetdetail = new TimesheetDetail();
            List<TimesheetDetail> entryTimeLogs = new List<TimesheetDetail>();

            timesheetdetail.activity_type = cbActivity_Type.Text;
            if (txtHours.Text != "")
            {
                timesheetdetail.hours = Convert.ToDouble(txtHours.Text);
            }
            else
            {
                timesheetdetail.hours = 1;
            }
            timesheetdetail.from_time = dtFromTime.Value;
            timesheetdetail.project = cbProject.Text;
            timesheetdetail.task = cbTask.Text;
            entryTimeLogs.Add(timesheetdetail);

            timesheet.time_logs = entryTimeLogs.ToArray();
            timesheet.company = cbCompany.Text;
            timesheet.employee = cbEmployee.Text;
            timesheet.note = txtNote2.Text.Replace(Environment.NewLine, "<br>");

            ERPObject obj = timesheet.Object;
            client.InsertObject(obj);

            MessageBox.Show("Saved as Draft!", "Well done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SaveAsSubmitted()
        {
            Timesheet timesheet = new Timesheet();
            TimesheetDetail timesheetdetail = new TimesheetDetail();
            List<TimesheetDetail> entryTimeLogs = new List<TimesheetDetail>();

            timesheetdetail.activity_type = cbActivity_Type.Text;
            if (txtHours.Text != "")
            {
                timesheetdetail.hours = Convert.ToDouble(txtHours.Text);
            }
            else
            {
                timesheetdetail.hours = 1;
            }
            timesheetdetail.from_time = dtFromTime.Value;
            timesheetdetail.project = cbProject.Text;
            timesheetdetail.task = cbTask.Text;
            entryTimeLogs.Add(timesheetdetail);

            timesheet.time_logs = entryTimeLogs.ToArray();
            timesheet.company = cbCompany.Text;
            timesheet.employee = cbEmployee.Text;
            timesheet.note = txtNote2.Text.Replace(Environment.NewLine, "<br>");
            timesheet.docstatus = 1;

            ERPObject obj = timesheet.Object;
            client.InsertObject(obj);

            MessageBox.Show("Saved and Submitted!", "Well done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            dtFromTime.Value = DateTime.Now;
        }

        private void cbProject_SelectedValueChanged(object sender, EventArgs e)
        {
            if (client != null)
            {
                List<ERPObject> si = client.ListObjects(DocType.Task);
                cbTask.Items.Clear();
                foreach (ERPObject a in si)
                {
                    ERPObject obj = client.GetObject(DocType.Task, a.Name);
                    ERPNextSharp.DocTypes.Stock.Task task = new ERPNextSharp.DocTypes.Stock.Task(obj);
                    if (task.project == cbProject.Text)
                    {
                        cbTask.Items.Add(a.Name);
                    }
                }
                if (cbTask.Items.Count > 0)
                {
                    cbTask.Text = cbTask.Items[0].ToString();
                }
                else
                {
                    cbTask.Text = "";
                }
            }
        }

        private void btnCreateSubmit_Click(object sender, EventArgs e)
        {
            SaveAsSubmitted();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(listTimeSheets.SelectedItem != null)
            {
                if (cbStatus.Text == "Submitted" || cbStatus.Text == "Cancelled")
                {
                    MessageBox.Show("Submitted and/or Cancelled Timesheets can not be modifiet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cbCompany1.Enabled = true;
                    cbStatus.Enabled = true;
                    cbEmployee1.Enabled = true;
                    txtEmployeeName.Text = "";
                    txtNote.Enabled = true;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    btnAddTimeLog.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select first a Timesheet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddTimeLog_Click(object sender, EventArgs e)
        {
            if (listTimeSheets.SelectedItem != null)
            {
                if (cbStatus.Text == "Submitted" || cbStatus.Text == "Cancelled")
                {
                    MessageBox.Show("Submitted and/or Cancelled Timesheets can not be modifiet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cbActivityType1.Text = cbActivityType1.Items[0].ToString();
                    cbActivityType1.Enabled = true;
                    txtHour.Text = "";
                    txtHour.Enabled = true;
                    cbProject1.Text = cbProject1.Items[0].ToString();
                    cbProject1.Enabled = true;
                    cbTask1.Text = cbTask1.Items[0].ToString();
                    cbTask1.Enabled = true;
                    dtStart_Detail.Value = DateTime.Now;
                    dtStart_Detail.Enabled = true;
                    label18.Visible = false;
                    dtEnd_Detail.Visible = false;
                    btnAdd.Visible = true;
                    btnAddTimeLog.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select first a Timesheet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TimesheetDetail timesheetdetail = new TimesheetDetail();

            timesheetdetail.activity_type = cbActivityType1.Text;
            if (txtHour.Text != "")
            {
                timesheetdetail.hours = Convert.ToInt32(txtHour.Text);
            }
            else
            {
                timesheetdetail.hours = 1;
            }
            timesheetdetail.from_time = dtStart_Detail.Value;
            timesheetdetail.project = cbProject1.Text;
            timesheetdetail.task = cbTask1.Text;
            timesheetdetail.parent = listTimeSheets.SelectedItem.ToString();
            timesheetdetail.parentfield = "time_logs";
            timesheetdetail.parenttype = "Timesheet";
            timesheetdetail.idx = listTimetables.Items.Count + 1;

            ERPObject obj = timesheetdetail.Object;
            client.InsertObject(obj);

            List<ERPObject> si = client.ListObjects(DocType.TimesheetDetail);

            listTimetables.Items.Clear();
            foreach (ERPObject a in si)
            {
                ERPObject obj1 = client.GetObject(DocType.TimesheetDetail, a.Name);
                TimesheetDetail timesheetDetail = new TimesheetDetail(obj1);
                if (timesheetDetail.parent == listTimeSheets.SelectedItem.ToString())
                {
                    listTimetables.Items.Add(a.Name);
                }

            }

            cbActivityType1.Enabled = false;
            txtHour.Enabled = false;
            cbProject1.Enabled = false;
            cbTask1.Enabled = false;
            dtStart_Detail.Enabled = false;
            label18.Visible = true;
            dtEnd_Detail.Visible = true;
            btnAdd.Visible = false;
            btnAddTimeLog.Enabled = true;
            btnEdit.Enabled = true;
            
            cbActivityType1.Text = "";
            txtHour.Clear();
            dtStart_Detail.Value = DateTime.Now;
            dtEnd_Detail.Value = DateTime.Now;
            cbProject1.Text = "";
            cbTask1.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Timesheet timesheet = new Timesheet();
            timesheet.company = cbCompany1.Text;
            if (cbEmployee1.Text != "n/a")
            {
                timesheet.employee = cbEmployee1.Text;
            }
            timesheet.note = txtNote.Text.Replace(Environment.NewLine, "<br>");
            if (cbStatus.Text != "Draft")
            {
                if (cbStatus.Text != "Submitted")
                {
                    timesheet.docstatus = 1;
                }
                else
                {
                    if (cbStatus.Text != "Cancelled")
                    {
                        timesheet.docstatus = 2;
                    }
                }
            }

            ERPObject obj = timesheet.Object;
            client.UpdateObject(DocType.Timesheet, listTimeSheets.SelectedItem.ToString(), obj);

            cbCompany1.Enabled = false;
            cbStatus.Enabled = false;
            cbEmployee1.Enabled = false;
            txtNote.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnAddTimeLog.Enabled = true;

            string TimesheetName = listTimeSheets.SelectedItem.ToString();

            cbActivityType1.Text = "";
            txtHour.Clear();
            dtStart_Detail.Value = DateTime.Now;
            dtEnd_Detail.Value = DateTime.Now;
            cbProject1.Text = "";
            cbTask1.Text = "";
            getTimesheetInfo(TimesheetName);
        }
    }
}
