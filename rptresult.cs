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
    public partial class rptresult : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        public rptresult()
        {
            InitializeComponent();
        }
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select  Course_id,Course_name from course where course_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Course_name";
            comboBox3.ValueMember = "Course_id";

        }
        private void showyear()
        {
            comboBox1.DataSource = null;

            for (int year = 2025; year <= 2035; year++)
            {
                comboBox1.Items.Add(year);
            }


        }
        private void showsem()
        {
            if (comboBox3.SelectedValue == null)
                return;

            if (comboBox3.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            adr = new OleDbDataAdapter("select sem_id,sem from semester where sem is not null and course_id=" + comboBox3.SelectedValue, con);

            dt = new DataTable();
            adr.Fill(dt);

            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "sem";
            comboBox4.ValueMember = "sem_id";
        }
        private void showexam()
        {
            adr = new OleDbDataAdapter("select  exam_id, exam_type from examMaster where exam_type is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "exam_type";
            comboBox2.ValueMember = "exam_id";

        }
       
        private void rptresult_Load(object sender, EventArgs e)
        {
            con.Open(); showcourse(); showyear(); showexam(); showsem();
            comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1; comboBox4.SelectedIndex = -1;
            dataGridView1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select academic year");
                return;
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Select Exam name");
                return;
            }
            else if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Select Course name");
                return;
            }
            else if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Select Semester");
                return;
            }
            else
            {
                adr = new OleDbDataAdapter(
    "SELECT rr.roll_no, s.stud_name, SUM(m.total) AS MarksObtained, r.out_of, r.percentage, r.grade, r.result_status " +
    "FROM ((((result r " +
    "INNER JOIN RNO_Creation rr ON r.sr_no = rr.sr_no) " +
    "INNER JOIN student s ON rr.stud_id = s.stud_id) " +
    "INNER JOIN marks m ON r.sr_no = m.sr_no) " +
    "INNER JOIN examMaster e ON r.exam_id = e.exam_id) " +
    "WHERE r.course_id=? AND r.sem_id=? AND r.exam_id=? AND r.aca_year=? " +
    "GROUP BY rr.roll_no, s.stud_name, r.out_of, r.percentage, r.grade, r.result_status",
    con);

                adr.SelectCommand.Parameters.AddWithValue("?", comboBox3.SelectedValue);
                adr.SelectCommand.Parameters.AddWithValue("?", comboBox4.SelectedValue);
                adr.SelectCommand.Parameters.AddWithValue("?", comboBox2.SelectedValue);
                adr.SelectCommand.Parameters.AddWithValue("?", comboBox1.Text);

                dt = new DataTable();
                adr.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            if (comboBox1.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Select Year Course and Semester");
                return;
            }

            OleDbDataAdapter da = new OleDbDataAdapter(
            "SELECT m.mark_id,r.roll_no,r.acayear,c.course_name,s.sem,m.total " +
            "FROM (((marks m INNER JOIN RNO_Creation r ON m.sr_no=r.sr_no) " +
            "INNER JOIN course c ON r.course_id=c.course_id) " +
            "INNER JOIN semester s ON r.sem_id=s.sem_id) " +
            "WHERE r.acayear='" + comboBox1.Text + "' " +
            "AND r.course_id=" + comboBox3.SelectedValue + " " +
            "AND r.sem_id=" + comboBox4.SelectedValue+" and m.sr_no="+comboBox5.SelectedValue+" ", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            dataGridView2.DataSource = dt2;
            adr = new OleDbDataAdapter(
            "select r.out_of, sum(m.total) as total_marks, r.percentage, r.grade, r.result_status " +
            "from result r inner join marks m on r.sr_no=m.sr_no " +
            "where aca_year='" + comboBox1.Text + "' and course_id=" + comboBox3.SelectedValue +
            " and sem_id=" + comboBox4.SelectedValue +
            " and r.status=true and m.sr_no=" + comboBox5.SelectedValue + " group by r.out_of, r.percentage, r.grade, r.result_status", con); dt = new DataTable();
            adr.Fill(dt);
            dataGridView3.DataSource = dt;

           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue == null || comboBox4.SelectedValue == null)
                return;

            if (comboBox3.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            getroll(); showsem();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue == null || comboBox4.SelectedValue == null)
                return;

            if (comboBox4.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            getroll();
          
        }
        public void getroll()
        {
            string s = "select roll_no ,sr_no from RNO_Creation where course_id="+comboBox3.SelectedValue+" and sem_id="+comboBox4.SelectedValue+"";
            adr = new OleDbDataAdapter(s, con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox5.DataSource = dt;
            comboBox5.DisplayMember = "roll_no";
            comboBox5.ValueMember = "sr_no";

        }
    }
}
