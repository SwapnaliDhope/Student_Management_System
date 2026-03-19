using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SMS_PROJECT
{
    public partial class exammaster : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        public exammaster()
        {
            InitializeComponent();
        }
        //private void getid()
        //{
        //    cmd = new OleDbCommand("select max(exam_id) from ExamMaster ", con);
        //    int count = Convert.ToInt32(cmd.ExecuteScalar());
        //    if (count == 0)
        //    {
        //        textBox1.Text = "1";



        //    }
        //    else
        //    {
        //        textBox1.Text = (count + 1).ToString();
        //    }



        //}


        private void button3_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text == "" )
            {
                MessageBox.Show("Please fill exam type and exam name both ");
                return;
            }
            OleDbCommand cmd2 = new OleDbCommand("select count(*) from ExamMaster where exam_type='" + comboBox1.Text + "' and status=true", con);
            int c = Convert.ToInt32(cmd2.ExecuteScalar());
            if (c > 0)
            {
                MessageBox.Show("Exam type already exists");
                return;
            }

            cmd = new OleDbCommand("insert into ExamMaster (exam_type) values(?)", con);

            cmd.Parameters.AddWithValue("?", comboBox1.Text);
            //cmd.Parameters.AddWithValue("?", comboBox2.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Data added successfully"); show();
            comboBox1.Text = ""; GENERATEID();

        }
        public void GENERATEID()
        {
            cmd = new OleDbCommand("SELECT MAX(exam_id)  FROM ExamMaster ", con);
            object RESULT = cmd.ExecuteScalar();
            if (RESULT == DBNull.Value)
            {
                textBox1.Text = "1";
            }
            else
            {
                int newid = Convert.ToInt32(RESULT) + 1;
                textBox1.Text = newid.ToString();
            }
        }

        private void exammaster_Load(object sender, EventArgs e)
        {
            con.Open(); show(); GENERATEID();
        }
        private void show()
        {
            adr = new OleDbDataAdapter("select exam_id, exam_type,status from ExamMaster where status=true and exam_type is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["exam_id"].Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("update ExamMaster set exam_type='" + comboBox1.Text + "'  where exam_id=" + textBox1.Text + "", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data Updated Successfully");  show();
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("do you want to delete this exam ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update ExamMaster set status=false where exam_id=" + textBox1.Text + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data deleted successfully"); show(); GENERATEID();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("do you want to delete All  Exams ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update ExamMaster set status=false ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data deleted successfully"); show(); GENERATEID();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {  if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    textBox1.Text = row.Cells["exam_id"].Value.ToString();
                    comboBox1.Text = row.Cells["exam_type"].Value.ToString();
                   // comboBox2.Text = row.Cells["exam_name"].Value.ToString();

                
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = ""; GENERATEID();
        }
    }
}
