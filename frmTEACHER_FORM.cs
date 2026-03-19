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
using System.Text.RegularExpressions;

namespace SMS_PROJECT
{
    public partial class frmTEACHER_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt = null;
        public frmTEACHER_FORM()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private Boolean noduplicate()
        {
            cmd = new OleDbCommand("select count(*) from teacher where teach_name='" + txttname.Text + "' and course_id=" + cmbcourse.SelectedValue + "", con);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txttname.Text == "")
            {
                MessageBox.Show("Please Enter teacher name");
                return;
                txttname.Focus();
            }
            else if (txtemail.Text == "")
            {
                MessageBox.Show("Please enter email id");
                return; txtemail.Focus();
            }
            else if (txtmono.Text == "")
            {
                MessageBox.Show("Please enter mobile number "); return; txtmono.Focus();
            }
            else if (cmbdept.SelectedIndex == -1)
            {
                MessageBox.Show("Please select department you want to enter"); return; cmbdept.Focus();
            }
            else if (cmbcourse.SelectedIndex == -1) { MessageBox.Show("Please select course you want to add to"); return; cmbcourse.Focus(); }
            else if (noduplicate())
            {
                MessageBox.Show("This Teacher already exists"); return; txttname.Focus();
            }
            else if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select a gender");

            }
            else
            {
                string mobno =  txtmono.Text;
                string email = txtemail.Text.Trim();

                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Enter valid email address");
                    txtemail.Focus();
                    return;
                }
                string s = "insert into Teacher(teach_name,GENDER,email,mo_no,dept_id,course_id) values('" + txttname.Text + "','" + (radioButton1.Checked ? "Male" : "Female") + "','" + txtemail.Text + "','" + mobno + "'," + cmbdept.SelectedValue + "," + cmbcourse.SelectedValue + ")";
                //MessageBox.Show(s);
                cmd = new OleDbCommand(s, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Submitted successfully"); showtable();
                txttname.Text = "";
                txtemail.Text = "";
                txtmono.Text = "";
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mobno = txtext.Text + txtmono.Text;
            cmd = new OleDbCommand("update Teacher set GENDER='" + (radioButton1.Checked ? "Male" : "Female") + "',email='" + txtemail.Text + "',mo_no='" + mobno + "',dept_id=" + cmbdept.SelectedValue + ",course_id='" + cmbcourse.SelectedValue + "' where  teach_name='" + txttname.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data Updated successfully"); showtable();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show(" Do you want to delete this Teacher", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {

                cmd = new OleDbCommand("update Teacher set isactive = false  where teach_name='" + txttname.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Teacher Deleted successfully"); showtable();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmTEACHER_FORM_Load(object sender, EventArgs e)
        {
            con.Open();
           
            showDEPT(); showtable();
        }
        public void showtable()
        {
            adr = new OleDbDataAdapter("select t.teach_name,t.GENDER,d.dept_name,c.course_name,t.email,right(t.mo_no,10)as mo_no from ((teacher t inner join course c on t.course_id=c.course_id)inner join department d on t.dept_id=d.dept_id) where t.isactive ", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;


        }


        public void showcourse()
        {
           cmbcourse.SelectedIndex=-1;
            adr = new OleDbDataAdapter("select course_name,course_id from course where dept_id="+cmbdept.SelectedValue+" and status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "Course_name";
            cmbcourse.ValueMember = "course_id";
        }
        public void showDEPT()
        {
            adr = new OleDbDataAdapter("select dept_id ,dept_name from department where trim(dept_name)<>'' and status=true ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbdept.DataSource = dt;
            cmbdept.DisplayMember = "dept_name";
            cmbdept.ValueMember = "dept_id";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Do you want to clear all records?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {

                cmd = new OleDbCommand("delete from Teacher", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("All courses are cleared now"); showtable();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtmono_Leave(object sender, EventArgs e)
        {

        }

        private void txtmono_KeyPress(object sender, KeyPressEventArgs e)
        {
          
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
                    cmbdept.Focus();
                }

                e.Handled = true; 
            }
        }
        private void txttname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true; 
            }
            if (e.KeyChar == 13)
            {
                radioButton1.Focus();
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {

           


        }

        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtemail.Focus();
            }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtemail.Text, pattern))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    //txtemail.Text = ""; 
                    txtemail.Focus();

                }
                else
                {
                    txtmono.Focus();
                }

            }
        }

        private void cmbdept_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbcourse.Focus();
            }
        }

        private void cmbcourse_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbcourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
        }

        private void txtmono_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txttname.Text = row.Cells["teach_name"].Value.ToString();

                txtemail.Text = row.Cells["email"].Value.ToString();
                cmbcourse.Text = row.Cells["course_name"].Value.ToString();
                cmbdept.Text = row.Cells["dept_name"].Value.ToString();
                txtemail.Text = row.Cells["email"].Value.ToString();
                //cmbstatus.Text = row.Cells["isactive"].Value.ToString();
                string gender = row.Cells["gender"].Value.ToString();
                if (gender == "Male")
                { radioButton1.Checked = true; }
                else if (gender == "Female")
                { radioButton2.Checked = true; }


                string mob = row.Cells["mo_no"].Value.ToString();
                if (mob.Length > 10)
                {
                    mob = mob.Substring(mob.Length - 10);
                }
                txtmono.Text = mob;
            }
        }

        private void cmbdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbdept.SelectedIndex == -1 || cmbdept.SelectedValue is DataRowView) return;
            showcourse();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            txttname.Text = ""; txtemail.Text = ""; txtmono.Text = ""; cmbdept.SelectedIndex = -1; cmbcourse.SelectedIndex = -1;

        }

    }
}
