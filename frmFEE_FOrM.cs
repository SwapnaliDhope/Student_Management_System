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
    public partial class frmFEE_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        public frmFEE_FORM()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmFEE_FORM_Load(object sender, EventArgs e)
        {
            con.Open();
            getcourses();
           getyear();  display();

        }
        public void getcourses()
        {
            adr = new OleDbDataAdapter("select course_id,course_name from course where status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "course_name";
            cmbcourse.ValueMember = "course_id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show(" Please select course "); return; cmbcourse.Focus();

            }
            else if (cmbyear.Text == "")
            {
                MessageBox.Show(" Please selecct academic year "); return; cmbyear.Focus();

            }
            else if (txtadmfee.Text == "")
            {
                MessageBox.Show(" Please enter admission fee "); return; txtadmfee.Focus();

            }
            else if (txtecharge.Text == "")
            {
                MessageBox.Show(" Please enter clg fee "); return; txtecharge.Focus();

            }
            else if (txttfee.Text == "")
            {
                MessageBox.Show(" Please enter tution fee "); return; txttfee.Focus();

            }

            else if (txtffee.Text == "")
            {
                MessageBox.Show(" Please enter form fee "); return; txtffee.Focus();

            }
            else if (noduplicate())
            {
                MessageBox.Show("the fee for this course is already allocated Please select another course");
                return;
                cmbcourse.Focus();

            }
            else
            {

                string s = "insert into fees(course_id,Aca_Year,adm_fee,clg_Exam_fee,tution_fee,library_fee,form_fee,total) values(" + cmbcourse.SelectedValue + ",'" + cmbyear.Text + "'," + txtadmfee.Text + "," + txtecharge.Text + "," + txttfee.Text + "," + txtlfee.Text + "," + txtffee.Text + "," + txttotal.Text + ")";
                //MessageBox.Show(s);
                cmd = new OleDbCommand(s, con);
                // cmd = new OleDbCommand("insert into fees values(" + txtfid.Text + "," + cmbcourse.SelectedValue + ",'" + cmbyear.Text + "'," + txtadmfee.Text + "," + txtecharge.Text + "," + txttfee.Text + "," + cmbs.SelectedValue + "," + txtlfee.Text + "," + txtffee.Text + "," + txttotal.Text + ")", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data entered successfully");

                display();//cmd=new OleDbCommand("insert into fees values("+txtfid.Text+","+cmbcourse.SelectedValue+",'"+txtacayear.Text+"',"+txtadmfee.Text+","+txticharge.Text+","txtecharge.Text+","+txttfee.Text+","+txtstuin.Text+",
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("select course"); return; cmbcourse.Focus();
            }
            DialogResult ans;
            ans = MessageBox.Show("do you want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("Delete * from fees where course_id=" + cmbcourse.SelectedValue + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data cleared successfully");
                // DispStudents();
                display();
                //con.Close();
            }
        }
        public void getyear()
        {
            for (int year = 2025; year <= 2035; year++)
            {
                cmbyear.Items.Add(year);

            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("do you want to clear all records?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("Delete * from Fees", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data cleared successfully"); display();
            }
        }
      
      
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //    txtfid.Text = row.Cells["fee_id"].Value.ToString();
            //    cmbcourse.Text = row.Cells["course_id"].Value.ToString();
            //    txttotal.Text = row.Cells["total"].Value.ToString();
            //    cmbs.SelectedValue = row.Cells["scholar_id"].Value.ToString();
            //    cmbyear.Text = row.Cells["aca_year"].Value.ToString();

            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           if(txtadmfee.Text==""||txtffee.Text==""||txttotal.Text=="")
           {
               MessageBox.Show("please fill all fee fileds");
                   return;
           }
            cmd=new OleDbCommand("update fees set Aca_Year=?,adm_fee=?,clg_Exam_fee=?,tution_fee=?,library_fee=?,form_fee=?,total=? where course_id=?",con);
            cmd.Parameters.AddWithValue("@p1", cmbyear.Text);
            cmd.Parameters.AddWithValue("@p2", txtadmfee.Text);
            cmd.Parameters.AddWithValue("@p3", txtecharge.Text);
            cmd.Parameters.AddWithValue("@p4", txttfee.Text);
            cmd.Parameters.AddWithValue("@p5", txtlfee.Text);
            cmd.Parameters.AddWithValue("@p6", txtffee.Text);
            cmd.Parameters.AddWithValue("@p7", txttotal.Text);
            cmd.Parameters.AddWithValue("@p8", cmbcourse.SelectedValue);

            cmd.ExecuteNonQuery();
            MessageBox.Show("data updated successfully"); display();



        }
        private bool noduplicate()
        {
            cmd = new OleDbCommand(" select count(*) from fees where course_id=" + cmbcourse.SelectedValue + " and aca_year='"+cmbyear.Text+"'", con);
            int  r = (int)cmd.ExecuteScalar();
            return r > 0;
        }
        public void total()
        {
            double total = 0;
            double adm_fee = 0; double clgfee = 0; double tutionfee = 0; double libraryfee = 0; double formfee = 0;

          
          double.TryParse(txtadmfee.Text,out adm_fee);
            double.TryParse(txtecharge.Text, out clgfee);
            double.TryParse(txttfee.Text, out tutionfee);
             double.TryParse(txtlfee.Text, out libraryfee);
             double.TryParse(txtffee.Text, out formfee);
            total = adm_fee + clgfee+tutionfee + libraryfee + formfee;
            txttotal.Text = total.ToString();
        }
        public void display()
        {
            adr = new OleDbDataAdapter("select * FROM fee_list", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["course_id"].Visible = false;
            dataGridView1.Columns["fee_id"].Visible = false;


        }

        private void txtadmfee_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void txtecharge_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void txttfee_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void txtlfee_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void txtffee_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                
                cmbcourse.Text = row.Cells["course_name"].Value.ToString();
                cmbyear.Text = row.Cells["aca_year"].Value.ToString();
                txttotal.Text = row.Cells["total"].Value.ToString();
                txtadmfee.Text = row.Cells["adm_fee"].Value.ToString();
                txtecharge.Text = row.Cells["clg_Exam_fee"].Value.ToString();
                txttfee.Text = row.Cells["tution_fee"].Value.ToString();
                txtlfee.Text = row.Cells["library_fee"].Value.ToString();
                txtffee.Text = row.Cells["form_fee"].Value.ToString();
            }
        }

        private void cmbcourse_Leave(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbcourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbyear.Focus();
            }
        }

        private void cmbyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtadmfee.Focus();
            }
        }

        private void txtadmfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtecharge.Focus();
            }
        }

        private void txtecharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txttfee.Focus();
            }
        }

        private void txttfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtlfee.Focus();
            }
        }

        private void txtlfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtffee.Focus();
            }
        }

        private void txtffee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txttotal.Focus();
            }
        }

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cmbcourse.SelectedIndex = -1;
            cmbyear.Text = "";
            txtadmfee.Text = "";
            txtecharge.Text = "";
            txtffee.Text = "";
            txtlfee.Text = "";
            txtlfee.Text = "";
            txttotal.Text = "";

        }
    }
}
