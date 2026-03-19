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
    public partial class rptexam : Form
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rptexam()
        {
            InitializeComponent();
        }

        private void rptexam_Load(object sender, EventArgs e)
        {
            con.Open();

        }
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select  Course_id,Course_name from course where course_name is not null  ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Course_name";
            comboBox1.ValueMember = "Course_id";

        }
        private void showexam()
        {
            adr = new OleDbDataAdapter("select  distinct exam_name from Exam_schedule where exam_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "exam_name";
            comboBox1.ValueMember = "exam_name";

        }
        private void showexamtype()
        {
            adr = new OleDbDataAdapter("select  distinct exam_type,exam_id from ExamMaster where exam_type is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "exam_type";
            comboBox1.ValueMember = "exam_id";

        }
     
        private void showsem()
        {

            if (comboBox1.SelectedValue == null || comboBox1.SelectedValue is DataRowView)
                return;
            adr = new OleDbDataAdapter("select  sem_id,sem from semester where course_id="+comboBox1.SelectedValue+"  ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "sem";
            comboBox2.ValueMember = "sem_id";
            comboBox2.SelectedIndex = -1;
        }
        private void showsub()
        {
            adr = new OleDbDataAdapter("select  sub_id,sub_name from subject where sub_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "sub_name";
            comboBox1.ValueMember = "sub_id";

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            showcourse(); showsem();  label4.Visible = true; comboBox2.Visible = true;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            showexam();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            showexamtype();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            showsub();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked &&   !radioButton5.Checked)
            {

                MessageBox.Show("Please select any filter");
                return;


            }

            if (radioButton1.Checked)
            {
                adr = new OleDbDataAdapter("select es.exam_name, e.exam_type, es.exam_date,  s.sub_name,es.exam_time,c.course_name from (((Exam_schedule es inner join examMaster e on es.exam_id=e.exam_id)inner join subject s on es.sub_id=s.sub_id)inner join course c on es.course_id=c.course_id) where exam_name='" + comboBox1.SelectedValue + "'", con);
            }

            else if (radioButton3.Checked)  
            {
                if (comboBox2.SelectedIndex == -1)
                {
                  
                    adr = new OleDbDataAdapter("select es.exam_name,e.exam_type,es.exam_date,s.sub_name,es.exam_time,c.course_name " +
                    "from (((Exam_schedule es inner join examMaster e on es.exam_id=e.exam_id) " +
                    "inner join subject s on es.sub_id=s.sub_id) " +
                    "inner join course c on es.course_id=c.course_id) " +
                    "where es.course_id=" + comboBox1.SelectedValue, con);
                }
                else
                {
                    adr = new OleDbDataAdapter(
                    "select es.exam_name,e.exam_type,es.exam_date,s.sub_name,es.exam_time,c.course_name " +
                    "from (((Exam_schedule es inner join examMaster e on es.exam_id=e.exam_id) " +
                    "inner join subject s on es.sub_id=s.sub_id) " +
                    "inner join course c on es.course_id=c.course_id) " +
                    "where es.course_id=" + comboBox1.SelectedValue +
                    " and es.sem_id=" + comboBox2.SelectedValue, con);
                    comboBox2.SelectedIndex = -1;
                }
            }


            else if (radioButton2.Checked)
            {
                adr = new OleDbDataAdapter("select es.exam_name, e.exam_type, es.exam_date,  s.sub_name,es.exam_time, c.course_name from ( ((Exam_schedule es inner join examMaster e on es.exam_id=e.exam_id)inner join subject s on es.sub_id=s.sub_id)inner join course c on es.course_id=c.course_id) where es.exam_id=" + comboBox1.SelectedValue + "", con);
            }

            else if (radioButton5.Checked)
            {
                adr = new OleDbDataAdapter("select es.exam_name, e.exam_type, es.exam_date,  s.sub_name ,es.exam_time ,c.course_name from ( ((Exam_schedule es inner join examMaster e on es.exam_id=e.exam_id)inner join subject s on es.sub_id=s.sub_id)inner join course c on es.course_id=c.course_id) where es.sub_id=" + comboBox1.SelectedValue + "", con);
            }

            dt = new DataTable();
            adr.Fill(dt);

            dataGridView1.DataSource = dt;
            label3.Text = dt.Rows.Count.ToString(); 
            label3.Visible = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
