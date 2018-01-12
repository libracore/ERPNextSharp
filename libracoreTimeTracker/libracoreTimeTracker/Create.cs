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
using ERPNextSharp.DocTypes.HR;
using ERPNextSharp.DocTypes.Project;

namespace libracoreTimeTracker
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        #region global variables
        public ERPNextClient client { get; set; }
        public string method { get; set; }
        #endregion

        #region Event handler
        private void Create_Load(object sender, EventArgs e)
        {
            getCompanys();
            getEmployees();
            getActivityTypes();
            getProject();
            if (method == "add")
            {
                groupBox1.Text = "Timesheet";
                cbTimesheet.Visible = true;
                label4.Visible = true;
                txtTotalHours.Visible = true;
                groupBox2.Text = "New Time Log";
                checkBox1.Text = "Add new Time Log";
                getFilteredTimesheets();
                getTimesheetDetails(cbTimesheet.Text);
            }
        }
        private void cbEmployee_TextChanged(object sender, EventArgs e)
        {
            getEmployeeName(cbEmployee.Text);
            if (method == "add")
            {
                getFilteredTimesheets();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox2.Enabled)
            {
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
            }

        }
        private void cbTask_TextChanged(object sender, EventArgs e)
        {
            getTaskDetails(cbTask.Text);
        }
        private void cbProject_TextChanged(object sender, EventArgs e)
        {
            getFilteredTasks(cbProject.Text);
        }
        private void dtFromTime_ValueChanged(object sender, EventArgs e)
        {
            setHour();
        }
        private void dtToTime_ValueChanged(object sender, EventArgs e)
        {
            setHour();
        }
        private void cbTimesheet_TextChanged(object sender, EventArgs e)
        {
            if (method == "add")
            {
                getTimesheetDetails(cbTimesheet.Text);
            }
        }
        #endregion

        #region Functions
        private void getCompanys()
        {
            if (client != null)
            {
                List<ERPObject> companys = client.ListObjects(DocType.Company);

                foreach (ERPObject company in companys)
                {
                    cbCompany.Items.Add(company.Name);
                }
                if (cbCompany.Items.Count > 0)
                {
                    cbCompany.Text = cbCompany.Items[0].ToString();
                }
            }
        }
        private void getEmployees()
        {
            if (client != null)
            {
                List<ERPObject> employees = client.ListObjects(DocType.Employee);

                foreach (ERPObject employee in employees)
                {
                    cbEmployee.Items.Add(employee.Name);
                }
                if (cbEmployee.Items.Count > 0)
                {
                    cbEmployee.Text = cbEmployee.Items[0].ToString();
                }
            }
        }
        private void getActivityTypes()
        {
            if (client != null)
            {
                List<ERPObject> Activitys = client.ListObjects(DocType.ActivityType);

                foreach (ERPObject Activity in Activitys)
                {
                    cbActivityType.Items.Add(Activity.Name);
                }
                if (cbActivityType.Items.Count > 0)
                {
                    cbActivityType.Text = cbActivityType.Items[0].ToString();
                }
            }
        }
        private void getProject()
        {
            if (client != null)
            {
                List<ERPObject> projects = client.ListObjects(DocType.Project);

                foreach (ERPObject project in projects)
                {
                    cbProject.Items.Add(project.Name);
                }
                if (cbProject.Items.Count > 0)
                {
                    cbProject.Text = cbProject.Items[0].ToString();
                }
            }
        }
        private void getEmployeeName(string employeeName)
        {
            if (client != null)
            {
                ERPObject obj = client.GetObject(DocType.Employee, employeeName);
                Employee employee = new Employee(obj);
                txtEmployee.Text = employee.Employee_name;
            }
        }
        private void getTaskDetails(string taskName)
        {
            if (cbTask.Text!="")
            {
                ERPObject obj = client.GetObject(DocType.Task, taskName);
                ERPNextSharp.DocTypes.Project.Task task = new ERPNextSharp.DocTypes.Project.Task(obj);
                txtTask.Text = task.subject+Environment.NewLine+
                    task.description.Replace("<br>", Environment.NewLine);
            }
            else
            {
                txtTask.Text = "";
            }
        }
        private void getTimesheetDetails(string timesheetName)
        {
            ERPObject obj = client.GetObject(DocType.Timesheet, timesheetName);
            Timesheet timesheet = new Timesheet(obj);
            txtNote.Text = timesheet.note.Replace("<br>", Environment.NewLine);
            cbCompany.Text = timesheet.company;
            cbStatus.Text = timesheet.status;
            txtTotalHours.Text = timesheet.total_hours.ToString();
        }
        private void getFilteredTasks(string projectName)
        {
            List<ERPObject> tasks = client.ListObjects(DocType.Task);
            cbTask.Items.Clear();
            foreach (ERPObject taskRaw in tasks)
            {
                ERPObject obj = client.GetObject(DocType.Task, taskRaw.Name);
                ERPNextSharp.DocTypes.Project.Task task = new ERPNextSharp.DocTypes.Project.Task(obj);
                if (task.project==cbProject.Text)
                {
                    cbTask.Items.Add(taskRaw.Name);
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
        private void getFilteredTimesheets()
        {
            List<ERPObject> timesheets = client.ListObjects(DocType.Timesheet);
            cbTimesheet.Items.Clear();
            foreach (ERPObject timesheetRaw in timesheets)
            {
                try
                {
                    ERPObject obj = client.GetObject(DocType.Timesheet, timesheetRaw.Name);
                    Timesheet timesheet = new Timesheet(obj);
                    if (timesheet.employee == cbEmployee.Text)
                    {
                        cbTimesheet.Items.Add(timesheetRaw.Name);
                    }
                }
                catch
                {

                }
            }
            if (cbTimesheet.Items.Count > 0)
            {
                cbTimesheet.Text = cbTimesheet.Items[0].ToString();
            }
            else
            {
                cbTimesheet.Text = "";
            }
        }
        private void setHour()
        {
            TimeSpan Stunden = dtToTime.Value - dtFromTime.Value;
            decimal stunden = Convert.ToDecimal(Stunden.TotalHours);
            txtHour.Text = Math.Round(stunden, 2).ToString();
        }
        private void checkHour()
        {
            if (checkBox1.Checked == true)
            {
                if (txtHour.Text != "")
                {
                    if (txtHour.Text.Substring(0, 1) != "-")
                    {
                        Save();
                    }
                    else
                    {
                        MessageBox.Show("Check your times!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Check your times!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Save();
            }
        }
        private void Save()
        {
            if (method == "create")
            {
                if (checkBox1.Checked == true)
                {
                    save_create();
                }
                else
                {
                    MessageBox.Show("For new timesheets, at least one time log is mandatory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (method == "add")
                {
                    save_add();
                }
            }

            
        }
        private void save_create()
        {
            Timesheet timesheet = new Timesheet();

            TimesheetDetail timesheetdetail = new TimesheetDetail();
            List<TimesheetDetail> entryTimeLogs = new List<TimesheetDetail>();

            timesheetdetail.activity_type = cbActivityType.Text;
            if (txtHour.Text != "")
            {
                timesheetdetail.hours = Convert.ToDouble(txtHour.Text);
            }
            else
            {
                timesheetdetail.hours = 1;
            }
            timesheetdetail.from_time = dtFromTime.Value;
            timesheetdetail.to_time = dtToTime.Value;
            timesheetdetail.project = cbProject.Text;
            timesheetdetail.task = cbTask.Text;
            entryTimeLogs.Add(timesheetdetail);
            timesheet.time_logs = entryTimeLogs.ToArray();

            timesheet.company = cbCompany.Text;
            timesheet.employee = cbEmployee.Text;
            timesheet.note = txtNote.Text.Replace(Environment.NewLine, "<br>");

            if (cbStatus.Text == "Draft")
            {
                timesheet.docstatus = 0;
            }
            if (cbStatus.Text == "Submitted")
            {
                timesheet.docstatus = 1;
            }
            ERPObject obj = timesheet.Object;
            client.InsertObject(obj);

            this.Close();
        }
        private int timelogIDX(string timesheet)
        {
            int count = 0;
            List<ERPObject> timelogs = client.ListObjects(DocType.TimesheetDetail);

            foreach (ERPObject timelogRaw in timelogs)
            {
                ERPObject obj = client.GetObject(DocType.TimesheetDetail, timelogRaw.Name);
                TimesheetDetail timelog = new TimesheetDetail(obj);
                if (timelog.parent == timesheet)
                {
                    count++;
                }
            }
            return count + 1;
        }
        private void save_add()
        {
            Timesheet timesheet = new Timesheet();
            if (checkBox1.Checked == true)
            {
                TimesheetDetail timesheetdetail = new TimesheetDetail();

                timesheetdetail.activity_type = cbActivityType.Text;
                timesheetdetail.from_time = dtFromTime.Value;
                timesheetdetail.to_time = dtToTime.Value;
                timesheetdetail.hours = Convert.ToDouble(txtHour.Text);
                timesheetdetail.project = cbProject.Text;
                timesheetdetail.task = cbTask.Text;
                timesheetdetail.parent = cbTimesheet.Text;
                timesheetdetail.parentfield = "time_logs";
                timesheetdetail.parenttype = "Timesheet";
                timesheetdetail.idx = timelogIDX(cbTimesheet.Text);

                ERPObject timelog = timesheetdetail.Object;
                client.InsertObject(timelog);
            }

            timesheet.company = cbCompany.Text;
            timesheet.employee = cbEmployee.Text;
            timesheet.note = txtNote.Text.Replace(Environment.NewLine, "<br>");

            if (cbStatus.Text == "Draft")
            {
                timesheet.docstatus = 0;
            }
            if (cbStatus.Text == "Submitted")
            {
                timesheet.docstatus = 1;
            }
            ERPObject obj = timesheet.Object;
            client.UpdateObject(DocType.Timesheet, cbTimesheet.Text, obj);

            this.Close();
        }
        #endregion
        
        #region Button handler
        private void btnNowFrom_Click(object sender, EventArgs e)
        {
            dtFromTime.Value = DateTime.Now;
        }
        private void btnNow_Click(object sender, EventArgs e)
        {
            dtToTime.Value = DateTime.Now;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            checkHour();
        }
        #endregion
        
    }
}
