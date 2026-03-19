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
    public partial class frmLOGIN_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        public frmLOGIN_FORM()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void insertbtn()
        {
            if (txtuname.Text == "")
            {
                MessageBox.Show("enter username Please");
                return;
                txtuname.Focus();
            }
            else if (txtpass.Text == "") { MessageBox.Show("Password is requqired"); return; txtpass.Focus(); }
            else if (cmbrole.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select the role"); return; cmbrole.Focus();

            }
            else
            {
                cmd = new OleDbCommand("insert into Login (user_name,[password],[role])values('" + txtuname.Text + "','" + txtpass.Text + "','" + cmbrole.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("sign in completed");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("select count(*) from Login where user_name='" + txtuname.Text + "' ", con);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("Username already exists "); button1.Focus();

            }
            else
            {
                insertbtn();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("select count(*) from Login where user_name='" + txtuname.Text + "' ", con);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("welcome !");
                MDIParent1 m = new MDIParent1();
                m.loggeduser = txtuname.Text;
                m.loggedusertype = cmbrole.Text;
                m.Show();
                this.Hide();
            }
            else
            {
                DialogResult ans;
                ans = MessageBox.Show("Login failed!... Do you want to register", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    insertbtn();

                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

             Application.Exit();

        }

        private void frmLOGIN_FORM_Load(object sender, EventArgs e)
        {
            con.Open();
            this.ActiveControl = txtuname;
            txtuname.Focus();
            dataGridView1.Visible = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (txtuname.Text == "")
            {
                MessageBox.Show("Select user first");
                return;
            }

            DialogResult ans = MessageBox.Show(
            "Do you want to delete this user?",
            "Message",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update login set status=false where user_name=?", con);

                cmd.Parameters.AddWithValue("?", txtuname.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User deleted successfully");

                show();




            }
        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void cmbrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtuname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpass.Focus();
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbrole.Focus();
            }
        }

        private void cmbrole_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2.Focus();
            }
        }
        private void show()
        {
            adr = new OleDbDataAdapter("select user_name ,[password],[role] from login where status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
            dataGridView1.Columns["Password"].Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            show();

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (txtuname.Text == "")
            {
                MessageBox.Show("enter username First");
                return;
                txtuname.Focus();
            }
            else if (txtpass.Text == "")
            {
                MessageBox.Show("enter new  password ");
                return;
                txtpass.Focus();
            }
            else if (cmbrole.SelectedIndex == -1)
            {
                MessageBox.Show("select  role  of user  ");
                return;
                cmbrole.Focus();
            }


            else
            {

                DialogResult ans;
                ans = MessageBox.Show(" Do you want to reset your password", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    if (txtpass.Text == "") { MessageBox.Show("Enter new password"); return; txtpass.Focus(); }
                    cmd = new OleDbCommand("update [login] set [password]='" + txtpass.Text + "',[role]='" + cmbrole.Text + "' where [user_name]='" + txtuname.Text + "'", con);
                    cmd.ExecuteNonQuery(); MessageBox.Show(" password udated successfully"); show();

                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //    //txtadmid.Text = row.Cells["adm_id"].Value.ToString();
            //    // txtfee.Text = row.Cells["fee_paid"].Value.ToString();
            //    txtuname.Text = row.Cells["user_name"].Value.ToString();
            //    //cmbstu.SelectedValue = row.Cells["stud_id"].Value;
            //    cmbrole.Text = row.Cells["role"].Value.ToString();
            //    txtpass.Text = row.Cells["password"].Value.ToString();

            //}
        }

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtuname.Text = row.Cells["user_name"].Value.ToString();
                cmbrole.Text = row.Cells["role"].Value.ToString();
                txtpass.Text = row.Cells["password"].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtuname.Text = "";
            txtpass.Text = "";
            cmbrole.Text = "";
        }
    }
}
