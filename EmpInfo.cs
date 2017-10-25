using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystemFinal
{
    
    public partial class EmpInfo : Form
    {
        Timer t = new Timer();
        public  EmployeeInfoEdit objEmployeeInfoEdit;
        public DataTable dtEmpInfo;
        public EmpInfo()
        {
            InitializeComponent();
            
        }
        #region "Custom Method"
        public void DesignGrid()
        {
            dGVEmployee.Columns["firstName"].HeaderText = "First Name";
            dGVEmployee.Columns["middleName"].HeaderText = "Middle Name";
            dGVEmployee.Columns["lasttName"].HeaderText = "Last Name";
            dGVEmployee.Columns["dateOfBirth"].HeaderText = "Date Of Birth";
            dGVEmployee.Columns["dateOfBirth"].Width = 180;
            dGVEmployee.Columns["email"].HeaderText = "Email";
            dGVEmployee.Columns["email"].Width = 150;
            dGVEmployee.Columns["mobileNumber"].HeaderText = "Mobile Number";
            dGVEmployee.Columns["mobileNumber"].Width = 150;
            dGVEmployee.Columns["homePhoneNumber"].HeaderText = "HomePhone Number";
            dGVEmployee.Columns["temporaryCountry"].HeaderText = "Temporary Country";
            dGVEmployee.Columns["temporaryCity"].HeaderText = "Temporary  City";
            dGVEmployee.Columns["temporaryArea"].HeaderText = "Temporary  Area";
            dGVEmployee.Columns["PermanentCountry"].HeaderText = "Permanent Country";
            dGVEmployee.Columns["permanentCity"].HeaderText = "Permanent City";
            dGVEmployee.Columns["permanentArea"].HeaderText = "Permanent Area";
            dGVEmployee.Columns["bachelorUniversity"].HeaderText = "Bachelor University";
            dGVEmployee.Columns["collegeName"].HeaderText = "College Name";
            dGVEmployee.Columns["schoolName"].HeaderText = "School Name";
            dGVEmployee.Columns["idImage"].HeaderText = "ID_Image";
           
            dGVEmployee.RowTemplate.Height = 120;
            foreach (DataGridViewColumn column in dGVEmployee.Columns)
            {
                column.ReadOnly = true;
            }
        }

        public void LoadGridView()
        {
               dGVEmployee.DataSource = dtEmpInfo;
        }
        #endregion
        private void btnNew_Click(object sender, EventArgs e)
        {
            
            objEmployeeInfoEdit = new EmployeeInfoEdit();
            objEmployeeInfoEdit.dtEmployeeInfoEdit = dtEmpInfo;
            objEmployeeInfoEdit.strFormMode = "NEW";
            objEmployeeInfoEdit.ShowDialog();
            dtEmpInfo = objEmployeeInfoEdit.dtEmployeeInfoEdit;
            dGVEmployee.DataSource = dtEmpInfo;
        }

        private void EmpInfo_Load(object sender, EventArgs e)
        {
            dtEmpInfo = new DataTable();
            dtEmpInfo.Columns.Add("firstName");
            dtEmpInfo.Columns.Add("middleName");
            dtEmpInfo.Columns.Add("lasttName");
            dtEmpInfo.Columns.Add("dateOfBirth");
            dtEmpInfo.Columns.Add("email");
            dtEmpInfo.Columns.Add("mobileNumber");
            dtEmpInfo.Columns.Add("homePhoneNumber");
            dtEmpInfo.Columns.Add("temporaryCountry", typeof(string));
            dtEmpInfo.Columns.Add("temporaryCity", typeof(string));
            dtEmpInfo.Columns.Add("temporaryArea", typeof(string));
            dtEmpInfo.Columns.Add("PermanentCountry", typeof(string));
            dtEmpInfo.Columns.Add("permanentCity", typeof(string));
            dtEmpInfo.Columns.Add("permanentArea", typeof(string));
            dtEmpInfo.Columns.Add("bachelorUniversity", typeof(string));
            dtEmpInfo.Columns.Add("collegeName", typeof(string));
            dtEmpInfo.Columns.Add("schoolName", typeof(string));
            dtEmpInfo.Columns.Add("idImage");
            LoadGridView();
            DesignGrid();
            t.Interval = 1000;//milliseconds
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
        }
        EmployeeInfoEdit objfrmEmployeeInfoEdit;
    private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dGVEmployee.SelectedRows.Count == 0 || dGVEmployee.SelectedCells[0].RowIndex == -1)
                {
                    return;
                 }
             objfrmEmployeeInfoEdit = new EmployeeInfoEdit();
             objfrmEmployeeInfoEdit.dtEmployeeInfoEdit = dtEmpInfo;
             objfrmEmployeeInfoEdit.strFormMode = "EDIT";
             objfrmEmployeeInfoEdit.SetSelectedRecord(dGVEmployee.SelectedCells[0].RowIndex);
             objfrmEmployeeInfoEdit.ShowDialog();
             dtEmpInfo = objfrmEmployeeInfoEdit.dtEmployeeInfoEdit;
             dGVEmployee.DataSource = dtEmpInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             }
        }
         private void dGVEmployee_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MessageBox.Show("Double click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataView dVEmpInfo = dtEmpInfo.DefaultView;
            dVEmpInfo.RowFilter = "firstName like'" + firstNameSearch.Text + "%' AND lasttName like '" + lastNameSearch.Text + "%'" + " AND " + "(DateOfBirth >= #" +
                                  Convert.ToDateTime(dateTPSearch.Value).ToString("MM/dd/yyyy") + "# And DateOfBirth <= #" +
                                  Convert.ToDateTime(dateTP2Search.Value).ToString("MM/dd/yyyy") +"# ) ";
            dGVEmployee.DataSource = dVEmpInfo.ToTable();
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
         
            firstNameSearch.Text = "";
            lastNameSearch.Text = "";

            DataView dVEmpInfo = dtEmpInfo.DefaultView;
            dVEmpInfo.RowFilter = "firstName like '" + firstNameSearch.Text + "%' AND lasttName like '" + lastNameSearch.Text + "%'";
           dGVEmployee.DataSource = dVEmpInfo.ToTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Do You Want To Remove This Row", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dia == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dGVEmployee.SelectedRows)
                {
                    dGVEmployee.Rows.RemoveAt(item.Index);
                }
                MessageBox.Show("Deleted", "Confirmation");
             }
            else if (dia == DialogResult.Yes)
            {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void t_Tick_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                //get current time
                int hh = DateTime.Now.Hour;
                int mm = DateTime.Now.Minute;
                int ss = DateTime.Now.Second;

                //time
                string time = "";

                //padding leading zero
                if (hh < 10)
                {
                    time += "0" + hh;
                }
                else
                {
                    time += hh;
                }
                time += ":";

                if (mm < 10)
                {
                    time += "0" + mm;
                }
                else
                {
                    time += mm;
                }
                time += ":";

                if (ss < 10)
                {
                    time += "0" + ss;
                }
                else
                {
                    time += ss;
                }

                //update label
                labelDigitalClock.Text = time;
            }
        }
    }
}
