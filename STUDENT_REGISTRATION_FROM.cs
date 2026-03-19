using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SMS_PROJECT
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public static int StudentID, cidnew;
        public static string z, zx, zy;

        public Form1()
        {
            InitializeComponent();
        }
        public void getcaste()
        {
            adr = new OleDbDataAdapter("select distinct( caste) from student", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbcaste.DataSource = dt;
            cmbcaste.DisplayMember = "caste";


        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbname.Text.Trim() == "")
                return;
            cmd = new OleDbCommand("select count(*) from student where stud_name='" + cmbname.Text + "'", con);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("Student already exixts!");
                return;
            }

            if (cmbname.Text == "")
            {
                MessageBox.Show("Plz Enter Student name..."); return;
                cmbname.Focus();

            }
            else if (txtmono.Text == "")
            {
                MessageBox.Show("Plz Enter Mobile Number...");
                return;
                txtmono.Focus();
            }
            else if (txtemail.Text == "")
            { MessageBox.Show("Plz Enter Email ID name..."); return; txtemail.Focus(); }
            else if (rtxtadd.Text == "")
            { MessageBox.Show("Plz Enter Address..."); return; rtxtadd.Focus(); }
            else if (cmbcaste.Text == "")
            { MessageBox.Show("Plz Select caste..."); return; cmbcaste.Focus(); }
            else if (txtadhar.Text == "")
            { MessageBox.Show("Plz Enter Adhar number..."); return; txtadhar.Focus(); }
            else if (cmbyear.Text == "")
            {
                MessageBox.Show("please selct academic year...");
                return;
                cmbyear.Focus();
            }
            else if (!rdomale.Checked && !rdofemale.Checked)
            {
                MessageBox.Show("Please select a gender");

            }
            else
            {
                string mobno = txtExt.Text + txtmono.Text;

                cmd = new OleDbCommand("Insert into Student(stud_name,Gender,DOB,mobileNo,EmailID,address,caste,adhar_no,course_id,aca_year) values('" + cmbname.Text + "','" + (rdomale.Checked ? "Male" : "Female") + "',#" + dtpdob.Value.ToString("dd/MM/yyyy") + "#,'" + mobno + "','" + txtemail.Text + "','" + rtxtadd.Text + "','" + cmbcaste.Text + "','" + txtadhar.Text + "'," + cidnew + ",'" + cmbyear.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data saved successfully");
                DispStudents();
                ClearData();


                cmbcaste.Refresh();
                getcaste();
            }



        }


        private void DispStudents()
        {
            try
            {
                cmd = new OleDbCommand("Select s.stud_id,s.stud_name,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no,c.course_name,s.aca_year from student s inner join course c on s.course_id=c.course_id where s.status=true order by stud_id DESC ", con);
                adr = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearData()
        {
            cmbname.Text = "";
            txtmono.Text = "";
            txtadhar.Text = "";
            txtemail.Text = "";
            rtxtadd.Text = "";
            cmbcaste.Text = "";
            cmbname.Focus();
            cmbyear.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Do You Want to Delete This record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd=new OleDbCommand("update student set status =false where  stud_name='" + cmbname.Text + "'",con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data deleted successfully"); DispStudents();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mobno = txtExt.Text + txtmono.Text;
            cmd = new OleDbCommand("update Student set stud_name='" + cmbname.Text + "', Gender='" + (rdomale.Checked ? "Male" : "Female") + "',  DOB=#" + dtpdob.Value.ToString("dd/MM/yyyy") + "# ,mobileNo='" + mobno + "' , EmailID='" + txtemail.Text + "',address='" + rtxtadd.Text + "',caste='" + cmbcaste.Text + "',adhar_no='" + txtadhar.Text + "',aca_year='" + cmbyear.Text + "',course_id=" + cidnew + " where stud_id=" + textBox1.Text + "", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated Successfully...");
              DispStudents();
            ClearData();
            cmbcaste.Refresh();
            getcaste();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            getcaste();
            //getstunames();
            getCourseName();
            showyear();
            this.ActiveControl = cmbyear;
            cmbyear.Focus(); DispStudents();


        }
        public void showyear()
        {
            for (int year = 2025; year <= 2035; year++)
            {
                cmbyear.Items.Add(year);
            }
        }




        private void txtadhar_Enter(object sender, EventArgs e)
        {
            txtadhar.BackColor = Color.Yellow;
        }

        private void txtadhar_Leave(object sender, EventArgs e)
        {



        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmd = new OleDbCommand("Select * from Student where stud_name=" + cmbname.Text + "", con);
                cmd.ExecuteNonQuery();
                OleDbDataReader odr2 = cmd.ExecuteReader();
                while (odr2.Read())
                {
                    cmbyear.Text = odr2["aca_year"].ToString();
                    cmbname.Text = odr2["stud_name"].ToString();
                    txtmono.Text = odr2["mobileNo"].ToString();
                    txtemail.Text = odr2["EmailID"].ToString();
                    rtxtadd.Text = odr2["address"].ToString();
                    cmbcaste.Text = odr2["caste"].ToString();
                    txtadhar.Text = odr2["adhar_no"].ToString();
                    dtpdob.Text = odr2["DOB"].ToString();
                    string gender = odr2["gender"].ToString();
                    if (gender == "Male")
                    { rdomale.Checked = true; }
                    else if (gender == "Female")
                    { rdofemale.Checked = true; }
                }
            }

        }
        private void dtpdob_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void txtmono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control keys (Backspace, Enter etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // First digit must be 7, 8, or 9
            if (txtmono.Text.Length == 0 && char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != '7' && e.KeyChar != '8' && e.KeyChar != '9')
                {
                    e.Handled = true;
                    return;
                }
            }

            // When Enter is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtmono.Text.Length < 10)
                {
                    MessageBox.Show("Please enter 10 digit mobile number");
                    txtmono.Focus();
                }
                else
                {
                    cmbcaste.Focus();
                }

                e.Handled = true; // stop beep sound
            }
        }

        private void txtstuname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true; prevents the character from being displayed in the text box.
            //char.IsLetter() checks if the pressed key is an alphabetic character.
            //char.IsControl() allows essential control keys like Backspace and Delete to function correctly.
            //char.IsSeparator() allows for spaces, which are generally considered "text". 
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true; // Stop the character from being entered
            }
            if (e.KeyChar == 13)
            {
                dtpdob.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void txtadhar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (char.IsDigit(e.KeyChar) && txtadhar.Text.Replace(" ", " ").Length >= 12)
            {
                e.Handled = true;
            }

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //txtid.Text = row.Cells[0].Value.ToString();
                cmbname.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells["stud_id"].Value.ToString();
                txtmono.Text = row.Cells["mobileNo"].Value.ToString();
                txtemail.Text = row.Cells["EmailID"].Value.ToString();
                rtxtadd.Text = row.Cells["address"].Value.ToString();
                cmbcaste.Text = row.Cells["caste"].Value.ToString();
                txtadhar.Text = row.Cells["adhar_no"].Value.ToString();
                dtpdob.Text = row.Cells["DOB"].Value.ToString();
                string gender = row.Cells["gender"].Value.ToString();
                cmbyear.Text = row.Cells["aca_year"].Value.ToString();
                if (gender == "Male")
                { rdomale.Checked = true; }
                else if (gender == "Female")
                { rdofemale.Checked = true; }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearData();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoSearch.Checked == true)
                {
                    cmd = new OleDbCommand("Select * from Student where stud_name like'" + txtSearch.Text + "%'", con);
                    adr = new OleDbDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    adr.Fill(myDataSet, "Student");
                    dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                    //int cnt = dataGridView1.Rows.Count; label14.Text = cnt.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (rdoMalechk.Checked == true)
                {
                    cmd = new OleDbCommand("Select * from Student where Gender like'" + rdoMalechk.Text + "%'", con);
                    adr = new OleDbDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    adr.Fill(myDataSet, "Student");
                    dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                    int cnt = dataGridView1.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdoFemalechk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoFemalechk.Checked == true)
                {
                    cmd = new OleDbCommand("Select * from Student where Gender like'" + rdoFemalechk.Text + "%'", con);
                    adr = new OleDbDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    adr.Fill(myDataSet, "Student");
                    dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                    //int cnt = dataGridView1.Rows.Count; label14.Text = cnt.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCastechk_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("Select * from Student where caste like'" + cmbCastechk.Text + "%'", con);
                adr = new OleDbDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                adr.Fill(myDataSet, "Student");
                dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                //int cnt = dataGridView1.Rows.Count; label14.Text = cnt.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //    try
            //    {
            //        cmd = new OleDbCommand("Select * from Student", con);
            //        adr = new OleDbDataAdapter(cmd);
            //        DataSet myDataSet = new DataSet();
            //        adr.Fill(myDataSet, "Student");
            //        dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
            //        //int cnt = dataGridView1.Rows.Count; label14.Text = cnt.ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbex.Focus();


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpdob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtmono.Focus();
            }

        }

        private void cmbcaste_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtemail.Focus();
            }
        }

        private void cmbext_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void rtxtadd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtadhar.Focus();
            }

        }

        private void txtstuname_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtmono_Leave(object sender, EventArgs e)
        {
            //if (txtmono.Text.Length != 10)
            //{
            //    MessageBox.Show("mobile number must be exactly 10 digits");
            //    txtmono.Focus();
            //    return;
            //}
            //string pattern = @"^[7-9][0-9]{9}$";
            //if (!Regex.IsMatch(txtmono.Text, pattern))
            //{
            //    MessageBox.Show("please enter valid mobile number");
            //    txtmono.Text="";
            //    txtmono.Focus();
            //}
        }

        private void txtadhar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string a = txtadhar.Text.Replace(" ", " ");
                if (a.Length == 12)
                {
                    if (!txtadhar.Text.Contains(" "))
                    {
                        txtadhar.Text = a.Substring(0, 4) + " " + a.Substring(4, 4) + " " + a.Substring(8, 4);
                    }
                    button1.Focus();
                }
                else
                {
                    MessageBox.Show("adhar number should contaion 12 digits");
                    txtadhar.Focus();
                }
            }
        }

        private void cmbcaste_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            DialogResult ans;
            ans = MessageBox.Show("Do You Want to Delete all non admitted students ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                //cmd = new OleDbCommand("delete from student where stud_id not in (select stud_id from admission_confirmed)", con);
                //int rows = cmd.ExecuteNonQuery();
                //MessageBox.Show(rows + " " + "Records Deleted successfully");
                //DispStudents();
                cmd = new OleDbCommand("update student set status=false ",con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data cleared successfully"); DispStudents();
            }

        }

        private void cmbex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtemail.Text.Contains("@"))
                {
                    rtxtadd.Focus();
                }

                string mail = txtemail.Text.Trim() + "@" + cmbex.Text.Trim();
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(mail, pattern))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    //txtemail.Text = ""; 
                    txtemail.Focus();

                }
                else
                {
                    txtemail.Text = mail;
                    rtxtadd.Focus();
                }

            }
        }

        private void cmbname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmd = new OleDbCommand("select count(*) from student where stud_name='" + cmbname.Text + "'", con);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("student already exists"); cmbname.Focus();

                }
                else
                {
                    rdomale.Focus();
                }


            }
        }
        //public void getstunames()
        //{
        //    adr = new OleDbDataAdapter("select stud_id,stud_name from student where stud_name is not null", con);
        //    dt = new DataTable();
        //    adr.Fill(dt);
        //    cmbname.DataSource = dt;
        //    cmbname.DisplayMember = "stud_name";
        //    cmbname.ValueMember = "stud_id";
        //}
        public void getCourseName()
        {
            adr = new OleDbDataAdapter("select Course_Name from Course where  status=true ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbCourse.DataSource = dt;
            cmbCourse.DisplayMember = "Course_Name";
        }
        private void cmbname_Leave(object sender, EventArgs e)
        {




        }

        private void cmbname_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("select course_id from course where course_name='" + cmbCourse.Text + "'", con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                cidnew = Convert.ToInt32(rdr["course_id"]);
                //label2.Text = cidnew.ToString();

            }


        }

        private void cmbCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbname.Focus();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cmbyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbCourse.Focus();
            }
        }

        private void txtmono_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdomale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtpdob.Focus();
            }
        }

        private void rdofemale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtpdob.Focus();
            }

        }
    }
}