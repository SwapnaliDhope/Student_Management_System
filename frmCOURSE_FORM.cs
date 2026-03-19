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

namespace SMS_PROJECT
{
    public partial class frmCOURSE_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;


        public void showdeptinfo()
        {
            adr = new OleDbDataAdapter("select dept_id ,dept_name from department where trim(dept_name)<>'' and status=true ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbdept.DataSource = dt;
            cmbdept.DisplayMember = "dept_name";
            cmbdept.ValueMember = "dept_id";
        }
        private void clear()
        {
            txtcname.Text = "";
            txtcdur.Text = "";
            cmbdept.SelectedIndex = -1;
            txtcapacity.Text = "";
        }

        public void showtable()
        {
            adr = new OleDbDataAdapter("select c.course_name,d.dept_name,c.duration,c.capacity,c.course_id from course c inner join department d on c.dept_id=d.dept_id where c.status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns["dept_id"].Visible = false;
            dataGridView1.Columns["course_id"].Visible = false;


        }

        public frmCOURSE_FORM()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void frmCOURSE_FORM_Load(object sender, EventArgs e)
        {
            con.Open();

            showdeptinfo();
            showtable();



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Do you want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("delete * from Course where course_name=" + txtcname.Text + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted successfully");
                showtable();
            }
        }

        private void cmbdept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbdept_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtcname.Text = row.Cells["course_name"].Value.ToString();
                txtcdur.Text = row.Cells["duration"].Value.ToString();
                textBox1.Text = row.Cells["course_id"].Value.ToString();
                cmbdept.Text = row.Cells["dept_name"].Value.ToString();
                txtcapacity.Text = row.Cells["capacity"].Value.ToString();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Do you want to delete all courses ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update  course set status=false", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("All courses are cleared !");
                showtable();
            }
        }

        private void txtcid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcname.Focus();
            }
        }

        private void txtcname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcdur.Focus();
            }
        }

        private void txtcdur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbdept.Focus();
            }
        }

        private void cmbdept_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcapacity.Focus();
            }
        }

        private void txtcapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only  numbers allowed");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ( txtcname.Text.Trim() == ""  )
            {
                MessageBox.Show("Enter course name ");
                return;
            }
            else if (txtcdur.Text.Trim() == "")
            {
                MessageBox.Show("Enter Duration ");
                return;
            }
            else if (cmbdept.SelectedIndex == -1)
            {
                MessageBox.Show("Select Department  ");
                return;
            }
            else
            {
                int cap;
                if(!int.TryParse(txtcapacity.Text,out cap))
                {
                    MessageBox.Show("Enter Numeric Capacity");return;
                }
                OleDbCommand cmd2 = new OleDbCommand("select  count(*) from course where course_name='" + txtcname.Text.Trim() + "' and status=true", con);
                int count = Convert.ToInt32(cmd2.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("course already exists ");
                    txtcname.Focus();
                    return;
                }
            cmd = new OleDbCommand("insert into Course(course_name,duration,dept_id,capacity) values('" + txtcname.Text + "','" + txtcdur.Text + "'," + cmbdept.SelectedValue + "," + txtcapacity.Text + ")", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data saved successfully");
            showtable(); clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtcname.Text.Trim() == "")
            {
                MessageBox.Show("Enter course name ");
                return;
            }
            else if (txtcdur.Text.Trim() == "")
            {
                MessageBox.Show("Enter Duration ");
                return;
            }
            else if (cmbdept.SelectedIndex == -1)
            {
                MessageBox.Show("Select Department  ");
                return;
            }
            else
            {
                string s = "update Course set course_name='" + txtcname.Text + "', duration='" + txtcdur.Text + "',dept_id=" + cmbdept.SelectedValue + ",capacity=" + txtcapacity.Text + " where course_id=" + textBox1.Text + "";

                cmd = new OleDbCommand(s, con);
                //cmd = new OleDbCommand("update Course set course_name='" + txtcname.Text + "',duration='" + txtcdur.Text + "',dept_id=" + cmbdept.SelectedValue + ",capacity=" + txtcapacity.Text + " where course_id=" + txtcid.Text + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully");
                showtable(); clear();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {

            DialogResult ans;
            ans = MessageBox.Show("Do you wnat to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("Update  Course set status=false where course_id=" + textBox1.Text + " ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted successfully");
                showtable();
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            txtcname.Text = ""; txtcdur.Text = ""; cmbdept.SelectedIndex = -1; txtcapacity.Text = "";

        }
    }
}
