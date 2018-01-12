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
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        #region global variables
        public ERPNextClient client { get; set; }
        #endregion

        #region Functions
        private void showTree()
        {
            TreeNode projectsNode = new TreeNode();
            projectsNode.Name = "Projects";
            projectsNode.Text = "Projects";
            
            List<ERPObject> timesheetsdetails = client.ListObjects(DocType.TimesheetDetail);
            foreach (ERPObject timesheetsdetailRaw in timesheetsdetails)
            {
                ERPObject obj = client.GetObject(DocType.TimesheetDetail, timesheetsdetailRaw.Name);
                TimesheetDetail timesheetdetail = new TimesheetDetail(obj);
                try
                {
                    if (!projectsNode.Nodes.ContainsKey(timesheetdetail.project))
                    {
                        TreeNode projectNode = new TreeNode();
                        projectNode.Name = timesheetdetail.project;
                        projectNode.Text = timesheetdetail.project;

                        TreeNode timesheetNode = new TreeNode();
                        timesheetNode.Name = timesheetdetail.parent;
                        timesheetNode.Text = timesheetdetail.parent;

                        TreeNode timelogNode = new TreeNode();
                        timelogNode.Name = timesheetdetail.Name;
                        timelogNode.Text = timesheetdetail.Name;

                        timesheetNode.Nodes.Add(timelogNode);

                        projectNode.Nodes.Add(timesheetNode);

                        projectsNode.Nodes.Add(projectNode);
                    }
                    else
                    {
                        if (!projectsNode.Nodes[timesheetdetail.project].Nodes.ContainsKey(timesheetdetail.parent))
                        {
                            TreeNode timesheetNode = new TreeNode();
                            timesheetNode.Name = timesheetdetail.parent;
                            timesheetNode.Text = timesheetdetail.parent;

                            TreeNode timelogNode = new TreeNode();
                            timelogNode.Name = timesheetdetail.Name;
                            timelogNode.Text = timesheetdetail.Name;

                            timesheetNode.Nodes.Add(timelogNode);

                            projectsNode.Nodes[timesheetdetail.project].Nodes.Add(timesheetNode);
                        }
                        else
                        {
                            if (!projectsNode.Nodes[timesheetdetail.project].Nodes[timesheetdetail.parent].Nodes.ContainsKey(timesheetdetail.Name))
                            {
                                TreeNode timelogNode = new TreeNode();
                                timelogNode.Name = timesheetdetail.Name;
                                timelogNode.Text = timesheetdetail.Name;
                                

                                projectsNode.Nodes[timesheetdetail.project].Nodes[timesheetdetail.parent].Nodes.Add(timelogNode);
                            }
                        }
                    }
                }
                catch
                {

                }

            }
            
            foreach (TreeNode node in projectsNode.Nodes)
            {
                if (node.Name.Length == 0)
                {
                    node.Text = "Timesheets without Project";
                }
            }

            treeView1.Nodes.Add(projectsNode);
            treeView1.Nodes["Projects"].Expand();
        }
        #endregion

        #region Event handler
        private void Viewer_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This modul is under construction!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            showTree();
            this.Width = 303;
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode.Text.Substring(0, 2) == "TS")
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                                
                if (treeView1.SelectedNode.Parent.Text == "Timesheets without Project")
                {
                    groupBox3.Visible = false;
                }
                else
                {
                    groupBox3.Visible = true;
                }
                this.Width = 765;
            }
            else
            {
                try
                {
                    if (treeView1.SelectedNode.Parent.Text.Substring(0, 2) == "TS")
                    {
                        groupBox2.Visible = true;
                        if (treeView1.SelectedNode.Parent.Parent.Text == "Timesheets without Project")
                        {
                            groupBox3.Visible = false;
                        }
                        else
                        {
                            groupBox3.Visible = true;
                        }
                        this.Width = 765;
                    }
                    else
                    {
                        if(treeView1.SelectedNode.Text == "Timesheets without Project")
                        {
                            groupBox1.Visible = false;
                            groupBox2.Visible = false;
                            groupBox3.Visible = false;
                            this.Width = 303;
                        }
                        else
                        {
                            groupBox1.Visible = false;
                            groupBox2.Visible = false;
                            groupBox3.Visible = true;
                            this.Width = 765;
                        }
                    }
                }
                catch
                {
                    groupBox3.Visible = false;
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    this.Width = 303;
                }
            }
        }
        #endregion


    }
}

