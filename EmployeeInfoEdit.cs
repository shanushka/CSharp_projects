using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;


namespace EmployeeManagementSystemFinal
{
    public partial class EmployeeInfoEdit : Form
    {
        
        public EmployeeInfoEdit()
        {
            InitializeComponent();
            comboCall();
            txtFirstName.Select();
        }
        public string strName;
        public DataTable dtEmployeeInfoEdit = new DataTable();
        public String firstName;
        public String lasttName;
        public String middleName;
        public string dateOfBirth;
        public String email;
        public String mobileNumber;
        public String homePhoneNumber;
        public String permanentCountry;
        public String permanentCity;
        public String permanentArea;
        public String temporaryCountry;
        public String temporaryCity;
        public String temporaryArea;
        public String bachelorUniversity;
        public String collegeName;
        public String schoolName;
        public string strFormMode;
        private int selectedRowIndex;
        private void btnSave_Click(object sender, EventArgs e)
        {
            var message = string.Empty;
            Regex pattern = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            //Regex number = new Regex(@"^9+([7-8][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]+)$");
            DialogResult D1 = MessageBox.Show("Are You Sure You Want To Save", "Confiramtion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (D1 == DialogResult.Yes)
            {
               if (txtFirstName.Text == string.Empty)
                {
                    message += ("enter your first Name\n");
                }
                if (txtLastName.Text == string.Empty)
                {
                    message += "enter your last Name\n";
                }
                if (txtEmail.Text == string.Empty)
                {
                    message += ("enter your email\n");
                }
                else
                {
                    if (!pattern.IsMatch(txtEmail.Text))
                    {
                        message += ("Enter Valid Email\n");
                    }
                }
                if (txtHomePhoneNumber.Text == string.Empty)
                {
                    message += "enter your home phone Number\n";
                }

                if (txtMobileNumber.Text == string.Empty)
                {
                    message += "enter your mobile Number\n";
                }
             

                if (message != string.Empty)
                {
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Ok");
                try
                {
                    firstName = txtFirstName.Text;
                    middleName = txtMiddleName.Text;
                    lasttName = txtLastName.Text;
                    dateOfBirth = dTPDateOfBirth.Text;
                    email = txtEmail.Text;
                    mobileNumber = comboBoxMobileNo.Text + txtMobileNumber.Text;
                    homePhoneNumber = txtHomePhoneNumber.Text;
                    temporaryCountry = comboBoxTemporaryCountry.Text;
                    temporaryCity = txtTemporaryCity.Text;
                    temporaryArea = txtTemporaryArea.Text;
                    permanentCountry = comboBoxPermanentCountry.Text;
                    permanentCity = txtPermanentCity.Text;
                    permanentArea = txtPermanentArea.Text;
                    if (comboBoxBachelorUniversity.SelectedValue == string.Empty)
                    {
                        bachelorUniversity = string.Empty;
                    }
                    else
                    {
                        bachelorUniversity = comboBoxBachelorUniversity.SelectedValue.ToString();
                    }
                    if (comboUnderGraduateCollege.SelectedValue == string.Empty)
                    {
                        collegeName = string.Empty;
                    }
                    else
                    {
                        collegeName = comboUnderGraduateCollege.SelectedValue.ToString();
                    }
                    if (comboBoxSchool.SelectedValue == string.Empty)
                    {
                        schoolName = string.Empty;
                    }
                    else
                    {
                        schoolName = comboUnderGraduateCollege.SelectedValue.ToString();
                    }

                    //  MemoryStream ms = new MemoryStream();
                    //pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    // byte[] img = ms.ToArray();
                    Bitmap img = (Bitmap)pictureBox1.Image;

                    //byte[] img = ms.ToArray();
                    if (this.strFormMode == "NEW")



                    {

                        dtEmployeeInfoEdit.Rows.Add(firstName, middleName, lasttName, dateOfBirth, email, mobileNumber, homePhoneNumber, temporaryCountry, temporaryCity, temporaryArea, permanentCountry, permanentCity, permanentArea, bachelorUniversity, collegeName, schoolName, img.ToString());


                    }


                    else
                    {
                        if (selectedRowIndex != -1)
                        {
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["firstName"] = txtFirstName.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["middleName"] = txtMiddleName.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["lasttName"] = txtLastName.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["dateOfBirth"] = dTPDateOfBirth.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["email"] = txtEmail.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["mobileNumber"] = txtMobileNumber.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["homePhoneNumber"] = txtHomePhoneNumber.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["temporaryCountry"] = comboBoxTemporaryCountry.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["temporaryCity"] = txtTemporaryCity.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["temporaryArea"] = txtTemporaryArea.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["permanentCountry"] = comboBoxPermanentCountry.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["permanentCity"] = txtPermanentCity.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["permanentArea"] = txtPermanentArea.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["bachelorUniversity"] = comboBoxBachelorUniversity.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["collegeName"] = comboUnderGraduateCollege.Text;
                            dtEmployeeInfoEdit.Rows[selectedRowIndex]["schoolName"] = comboBoxSchool.Text;
                        }
                    }
                }



                catch (Exception ex)
                {
                    Console.Error.Write("input:");
                    Console.Error.WriteLine("Input error: the exception message :{0}", ex.Message);

                }
                    this.Close();
                }



            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        #region"Custom Method"
        public void comboCall()
        {
            DataTable dt = Class_files.sqlhelper.LoadEducationLevel();
            comboBoxBachelorUniversity.DataSource = dt;
            comboBoxBachelorUniversity.BindingContext = this.BindingContext;
            comboBoxBachelorUniversity.DisplayMember = "Education level";
            comboBoxBachelorUniversity.ValueMember = "Education level";
            DataTable dt1 = Class_files.sqlhelper.LoadUnderGraduateLevel();
            comboUnderGraduateCollege.DataSource = dt1;
            comboUnderGraduateCollege.BindingContext = this.BindingContext;
            comboUnderGraduateCollege.DisplayMember = "UnderGraduate College";
            comboUnderGraduateCollege.ValueMember = "UnderGraduate College";
            DataTable dt2 = Class_files.sqlhelper.LoadSchoolName();
            comboBoxSchool.DataSource = dt2;
            comboBoxSchool.BindingContext = this.BindingContext;
            comboBoxSchool.DisplayMember = "School Name";
            comboBoxSchool.ValueMember = "School Name";
        }

        public void SetSelectedRecord(int rowIndex)
        {
            if (rowIndex != -1)
            {
                selectedRowIndex = rowIndex;
                txtFirstName.Text = dtEmployeeInfoEdit.Rows[rowIndex]["firstName"].ToString();
                txtMiddleName.Text = dtEmployeeInfoEdit.Rows[rowIndex]["middleName"].ToString();
                txtLastName.Text = dtEmployeeInfoEdit.Rows[rowIndex]["lasttName"].ToString();
                dTPDateOfBirth.Text = dtEmployeeInfoEdit.Rows[rowIndex]["dateOfBirth"].ToString();
                txtEmail.Text = dtEmployeeInfoEdit.Rows[rowIndex]["email"].ToString();
                txtMobileNumber.Text = dtEmployeeInfoEdit.Rows[rowIndex]["mobileNumber"].ToString();
                txtHomePhoneNumber.Text = dtEmployeeInfoEdit.Rows[rowIndex]["homePhoneNumber"].ToString();
                comboBoxTemporaryCountry.Text = dtEmployeeInfoEdit.Rows[rowIndex]["temporaryCountry"].ToString();
                txtTemporaryCity.Text = dtEmployeeInfoEdit.Rows[rowIndex]["temporaryCity"].ToString();
                txtTemporaryArea.Text = dtEmployeeInfoEdit.Rows[rowIndex]["temporaryArea"].ToString();
                comboBoxPermanentCountry.Text = dtEmployeeInfoEdit.Rows[rowIndex]["permanentCountry"].ToString();
                txtPermanentCity.Text = dtEmployeeInfoEdit.Rows[rowIndex]["permanentCity"].ToString();
                txtPermanentArea.Text = dtEmployeeInfoEdit.Rows[rowIndex]["permanentArea"].ToString();

                //comboBoxBachelorUniversity.Text = dtEmployeeInfoEdit.Rows[rowIndex]["bachelorUniversity"].ToString();
                //comboUnderGraduateCollege.Text = dtEmployeeInfoEdit.Rows[rowIndex]["collegeName"].ToString();
                //comboBoxSchool.Text = dtEmployeeInfoEdit.Rows[rowIndex]["schoolName"].ToString();
            }

        }



        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtMobileNumber.Text = "";
            txtHomePhoneNumber.Text = "";
            txtMobileNumber.Text = "";
            txtEmail.Text = "";
            comboBoxPermanentCountry.Text = "";
            txtPermanentArea.Text = "";
            txtPermanentCity.Text = "";
            comboBoxTemporaryCountry.Text = "";
            txtTemporaryCity.Text = "";
            txtTemporaryArea.Text = "";
            comboBoxBachelorUniversity.Text = "";
            comboUnderGraduateCollege.Text = "";
            comboBoxSchool.Text = "";


        }

        private void txtMobileNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtHomePhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHomePhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images| *.JPG; *.PNG; *.GJF"; // you can add any other image type 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void EmployeeInfoEdit_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
    }

  
    
    

