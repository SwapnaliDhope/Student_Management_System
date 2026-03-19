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
    public partial class frmDEPARTMENT_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        public frmDEPARTMENT_FORM()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showtable()
        {
            adr = new OleDbDataAdapter("select dept_id, dept_name  from Department where dept_name is not null and  status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        public void GENERATEID()
        {
            cmd = new OleDbCommand("SELECT MAX(dept_id)  FROM Department ", con);
            object RESULT = cmd.ExecuteScalar();
            if (RESULT == DBNull.Value)
            {
                txtdid.Text = "1";
            }
            else
            {
                int newid = Convert.ToInt32(RESULT) + 1;
                txtdid.Text = newid.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd2 = new OleDbCommand("select status from department where UCASE(TRIM(dept_name)) = UCASE(TRIM('"+ txtdname.Text + "'))", con);

            object result = cmd2.ExecuteScalar();

            if (result == null)
            {
                cmd = new OleDbCommand("insert into Department(dept_name,status) values('"+ txtdname.Text.Trim() + "',true)", con);

                cmd.ExecuteNonQuery();
            }
            else
            {
                bool status = Convert.ToBoolean(result);

                if (status == true)
                {
                    MessageBox.Show("Department already exists");
                    return;
                }
                else
                {
                    cmd = new OleDbCommand("update department set status=true where UCASE(TRIM(dept_name))=UCASE(TRIM('"
                    + txtdname.Text + "'))", con);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data Added Successfully");

            showtable();
            txtdname.Text = "";
            GENERATEID();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("update  Department set dept_name= '" + txtdname.Text + "' where dept_id=" + txtdid.Text + "", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated Successfully");
            showtable(); GENERATEID(); txtdname.Text = " ";

        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("are you sure you want to delete ? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update   Department set status=false where dept_id=" + txtdid.Text + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data deleted Successfully");
                showtable();
                GENERATEID();
                txtdname.Text = " ";
            }
        }
        public void previd()
        {
            adr = new OleDbDataAdapter("select max(dept_id) from department", con);
            dt = new DataTable();
            adr.Fill(dt);
            //label8.DataSourse = dt;
        }

        private void frmDEPARTMENT_FORM_Load(object sender, EventArgs e)
        {
            con.Open();
            GENERATEID();
            showtable();
            this.ActiveControl = txtdeptid;
            txtdeptid.Focus();
            txtdname.Text = " ";


        }

        private void txtdeptid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtdeptname.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //txtdid.Text = "";
            txtdname.Text = "";
            showtable();
            DialogResult ans;
            ans = MessageBox.Show("Do you want to delete all departments ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update department set status=false  ", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("All courses are cleared now"); GENERATEID(); showtable();
            }
        }

        private void txtdid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtdname.Focus();

            }
        }

        private void txtdname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtdid.Text = row.Cells[0].Value.ToString();
                txtdname.Text = row.Cells[1].Value.ToString();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            GENERATEID();
            txtdname.Text = "";
        }
    }
}
