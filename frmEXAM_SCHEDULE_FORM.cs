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
    public partial class frmEXAM_SCHEDULE_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt; int esc;
        public frmEXAM_SCHEDULE_FORM()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            String ename = cmbename.Text;
            int cid = Convert.ToInt32(cmbcourse.SelectedValue);
            int etype = Convert.ToInt32(comboBox1.SelectedValue);
            int sem = Convert.ToInt32(cmbsem.SelectedValue);
             //OleDbCommand cmd2=new OleDbCommand("select exam_name from Exam_schedule where exam_name='"+ename+"' and course_id="+cid+" and sem_id="+sem+" and aca_year="
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                string examtime = "";

                if (row.Cells["exam_time"].Value != null)
                {
                     examtime = row.Cells["exam_time"].Value.ToString();
                } 
               
                if (row.IsNewRow)
                    continue;
                if (row.Cells["exam_date"].Value == null || row.Cells["exam_time"].Value == null)
                {
                    MessageBox.Show("Enter exam date and time");
                    return;
                }
                int sibid = Convert.ToInt32(row.Cells["sub_id"].Value);
                DateTime examdate = Convert.ToDateTime(row.Cells["exam_date"].Value);
                 examtime = row.Cells["exam_time"].Value.ToString();

                cmd = new OleDbCommand("insert into Exam_schedule (exam_name,exam_id,sub_id,sem_id,exam_date,exam_time,course_id) values(?,?,?,?,?,?,?)", con);
                cmd.Parameters.AddWithValue("?", ename);
                cmd.Parameters.AddWithValue("?", etype);
                cmd.Parameters.AddWithValue("?", sibid);
                cmd.Parameters.AddWithValue("?", sem);
                cmd.Parameters.AddWithValue("?", examdate);
                cmd.Parameters.AddWithValue("?", examtime);
                cmd.Parameters.AddWithValue("?", cid);

                cmd.ExecuteNonQuery();
              
            }
            MessageBox.Show("Time Tbale Saved Successfully");
            getdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("update Exam_schedule set  sem_id=" + cmbsem.SelectedValue + ",course_id=" + cmbcourse.SelectedValue + ",exam_id=" + comboBox1.SelectedValue + " where exam_sc_id=" + textBox2.Text + "", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data updated successfully");


            getdata();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmEXAM_SCHEDULE_FORM_Load(object sender, EventArgs e)
        {
            con.Open();
            
           getdata();
           getcourse(); getexamNAME(); sem(); //getexamname();
           
        

        }
        private void sem()
        {
            adr=new OleDbDataAdapter("Select sem_id,sem from semester where course_id="+cmbcourse.SelectedValue+" and status=true",con);
            dt=new DataTable();
            adr.Fill(dt);
            cmbsem.DataSource=dt;
            cmbsem.DisplayMember="sem";
            cmbsem.ValueMember="sem_id";
        }

      
        public void getdata()
        {
            dataGridView1.Visible=true;
            dataGridView2.Visible=false;
            adr = new OleDbDataAdapter("select es.exam_sc_id,e.exam_id,e.exam_type,es.exam_name,s.sub_name,sem.sem,es.exam_date,es.exam_time,c.course_name from (((Exam_schedule es inner join  ExamMaster e on es.exam_id=e.exam_id)inner join subject s on es.sub_id=s.sub_id)inner join semester sem on es.sem_id=sem.sem_id)inner join course c on es.course_id=c.course_id where es.status=true;", con);

            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
          
            dataGridView1.Columns["exam_sc_id"].Visible = false;
            dataGridView1.Columns["exam_id"].Visible = false; 

        }
      
        public void getcourse()
        {

            adr = new OleDbDataAdapter("select  course_id,course_name from course where  status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
           DataRow row = dt.NewRow();
           
            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "course_name";
            cmbcourse.ValueMember = "course_id";
        }
        private void getexamNAME()
        {
            int cid = Convert.ToInt32(cmbcourse.SelectedValue);
            adr = new OleDbDataAdapter("select Distinct exam_type ,exam_id from ExamMaster where status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "exam_type";
            comboBox1.ValueMember = "exam_id";
        }
       
      
        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcourse.SelectedIndex == -1|| cmbcourse.SelectedValue is DataRowView) return;

            sem();
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmbename.SelectedIndex == null)
            {
                MessageBox.Show("Fill exam name ");
                return; cmbename.Focus();
            }
            else {
            DialogResult ans = MessageBox.Show("Do you want to delete this records?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update Exam_schedule set status=false where exam_sc_id=" + textBox1.Text + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Successfully"); getdata();

            }
            } 
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            adr = new OleDbDataAdapter("select * from exam_schedule", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                cmbename.Text = row.Cells["exam_name"].Value.ToString();
                cmbsem.Text = row.Cells["sem"].Value.ToString();
                textBox2.Text = row.Cells["exam_sc_id"].Value.ToString();
                cmbcourse.Text = row.Cells["course_name"].Value.ToString();
                comboBox1.Text = row.Cells["exam_type"].Value.ToString();
               
            }
        }

        private void cmbename_KeyPress(object sender, KeyPressEventArgs e)
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
                cmbsem.Focus();
            }
        }

        private void cmbsub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
               // dtpdate.Focus();
            }
        }

        private void dtpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //txttime.Focus();
            }
        }

        private void txttime_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txttime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
        }

        private void cmbsem_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void CREATE_Click(object sender, EventArgs e)
        {
           
            dataGridView1.Visible=false;
            dataGridView2.Visible=true;
            if (cmbcourse.SelectedIndex == -1 || cmbsem.SelectedIndex == -1 || cmbename.Text ==""||comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("select course,semester,exam type and enter exam name first"); return;
            }
            int cid = Convert.ToInt32(cmbcourse.SelectedValue);
            int sem = Convert.ToInt32(cmbsem.SelectedValue);
            adr = new OleDbDataAdapter("select sub_id,sub_name,course_id,sem_id from subject   where course_id=" + cmbcourse.SelectedValue + " and sem_id=" + cmbsem.SelectedValue + " and status='"+"Active"+"'", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView2.DataSource = dt;
            if (!dataGridView2.Columns.Contains("exam_date"))
                dataGridView2.Columns.Add("Exam_Date", "Exam Date");
            if (!dataGridView2.Columns.Contains("exam_time"))
                dataGridView2.Columns.Add("EXAM_TIME", "Exam Time");
            dataGridView2.Columns["course_id"].Visible = false;
            dataGridView2.Columns["sem_id"].Visible = false;
            dataGridView2.Columns["sub_id"].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
               // esc = Convert.ToInt32(row.Cells["exam_sc_id"].Value);
                //cmbename.SelectedValue = row.Cells["exam_id"].Value;
                //cmbsub_KeyPress.SelectedValue = row.Cells["sub_id"].Value;
                cmbcourse.SelectedValue = row.Cells["course_id"].Value;
                cmbsem.SelectedValue = row.Cells["sem_id"].Value;
               



            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            getdata();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            cmbcourse.SelectedIndex = -1;
            cmbsem.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            cmbename.Text = "";
        }
    }
}
