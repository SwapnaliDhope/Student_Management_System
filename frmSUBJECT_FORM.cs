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
    public partial class frmSUBJECT_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        public frmSUBJECT_FORM()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private Boolean noduplicate()
        {
            cmd = new OleDbCommand("select count(*) from subject where sub_name='" + txtsubname.Text + "' and course_id="+cmbcourse.SelectedValue+" and sem_id="+cmbsem.SelectedValue+"", con);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;

        }

        private void frmSUBJECT_FORM_Load(object sender, EventArgs e)
        {
            con.Open(); getyear(); getcourse(); showdata(); getteacher(); sem();

        }
      
      
        private void getyear()
        {
            for (int year = 2025; year <= 2036; year++)
            {
                cmbyaer.Items.Add(year); getteacher();
            }
        }
          private void getcourse()
          {
              adr=new OleDbDataAdapter("select course_id,course_name from  course where status=true",con);
              dt=new DataTable();
                  adr.Fill(dt);
              cmbcourse.DataSource=dt;
              cmbcourse.DisplayMember="course_name";
              cmbcourse.ValueMember="course_id";
          }
          private void sem()
          {
              if (cmbcourse.SelectedValue == null)
                  return;
              adr = new OleDbDataAdapter("Select sem_id,sem from semester where status=true and course_id=" + cmbcourse.SelectedValue + "", con);
              dt = new DataTable();
              adr.Fill(dt);
              cmbsem.DataSource = dt;
              cmbsem.DisplayMember = "sem";
              cmbsem.ValueMember = "sem_id";
          }

          private void getteacher()
          {
              adr = new OleDbDataAdapter("select teach_id,teach_name from  teacher where isactive=true", con);
              dt = new DataTable();
              adr.Fill(dt);
              cmbteacher.DataSource = dt;
              cmbteacher.DisplayMember = "teach_name";
              cmbteacher.ValueMember = "teach_id";
          }




          private void button5_Click(object sender, EventArgs e)
          {
              DialogResult ans;
              ans = MessageBox.Show("do you want to delete this subject ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (ans == DialogResult.Yes)
              {
                  cmd=new OleDbCommand("update subject set status='"+"inactive"+"'",con);
                  cmd.ExecuteNonQuery();

                  MessageBox.Show("All records are cleared "); showdata();
              }
          }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            cmd = new OleDbCommand("update subject set sub_name=?, course_id=?,teach_id=?,aca_year=?,sem_id=? where sub_id=?", con);
            cmd.Parameters.AddWithValue("@p1", txtsubname.Text);
            cmd.Parameters.AddWithValue("@p2", cmbcourse.SelectedValue);
            cmd.Parameters.AddWithValue("@p3", cmbteacher.SelectedValue);
            cmd.Parameters.AddWithValue("@p4", cmbyaer.Text);
            cmd.Parameters.AddWithValue("@p5", cmbsem.SelectedValue);
            cmd.Parameters.AddWithValue("@p6", textBox1.Text); 
         
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data updated successfully"); showdata();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtsubname.Text == "")
            {
                MessageBox.Show("Enter Subject name ");
                return;
                txtsubname.Focus();
            }
            else if (cmbteacher.SelectedIndex == -1)
            {
                MessageBox.Show("select teacher for the subject ");
                return;
                cmbteacher.Focus();
            }
            else if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("Select course you want to add subject in to"); return; cmbcourse.Focus();
            }
            else if (cmbyaer.Text == "")
            {
                MessageBox.Show("Select academic year you want to add subject for");
                return;
                cmbyaer.Focus();
            }
            else if (cmbsem.SelectedIndex == -1)
            {
                MessageBox.Show("Select semester you want to add subject for");
                return;
                cmbsem.Focus();
            }
            else if (noduplicate())
            {
                MessageBox.Show("you already added this subject into this course ");
                return;
                txtsubname.Focus();
            }
            else
            {

                cmd = new OleDbCommand("insert into subject (sub_name,course_id,teach_id,aca_year,sem_id,status) values(?,?,?,?,?,'Active')", con);
                cmd.Parameters.AddWithValue("@p1", txtsubname.Text);
                cmd.Parameters.AddWithValue("@p2", cmbcourse.SelectedValue);
                cmd.Parameters.AddWithValue("@p3", cmbteacher.SelectedValue);
                cmd.Parameters.AddWithValue("@p4", cmbyaer.Text);
                cmd.Parameters.AddWithValue("@p5", cmbsem.SelectedValue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved successfully"); showdata();
                txtsubname.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        { DialogResult ans;
            ans = MessageBox.Show("do you want to delete this subject ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update  subject set status='" + "Inactive" + "' where sub_name='" + txtsubname.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Subject  deleted successfully"); showdata();
            }
            else
            {
                MessageBox.Show("Subject not found");
            }
        }
        public void showdata()
        {
            adr = new OleDbDataAdapter("select s.sub_id,s.sub_name,c.course_name,t.teach_name,s.aca_year,sem.sem,s.status from((subject s inner join course c on s.course_id=c.course_id)inner join teacher t on s.teach_id=t.teach_id)inner join semester sem on s.sem_id=sem.sem_id where s.status='"+"Active"+"'", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["sub_id"].Visible = false;

        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtsubname.Text = row.Cells["sub_name"].Value.ToString();
                cmbcourse.Text = row.Cells["course_name"].Value.ToString();
                cmbteacher.Text = row.Cells["teach_name"].Value.ToString();
                cmbyaer.Text = row.Cells["aca_year"].Value.ToString();
                cmbsem.Text = row.Cells["sem"].Value.ToString();
                textBox1.Text = row.Cells["sub_id"].Value.ToString();

               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtsubname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbcourse.Focus();
            }
        }

        private void cmbcourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbteacher.Focus();
            }
        }

        private void cmbteacher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbyaer.Focus();
            }
        }

        private void cmbyaer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbsem.Focus();
            }
        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        { if (cmbcourse.SelectedIndex == -1|| cmbcourse.SelectedValue is DataRowView) return;
        sem();
        }

        private void cmbsem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtsubname.Text = ""; cmbyaer.Text = ""; cmbteacher.SelectedIndex = -1; cmbcourse.SelectedIndex = -1; cmbsem.SelectedIndex = -1;

        }
    }
}
