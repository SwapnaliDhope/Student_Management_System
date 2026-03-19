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
    public partial class rptadmitedstudent : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rptadmitedstudent()
        {
            InitializeComponent();
        }
        private void showcastea()
        {
            adr = new OleDbDataAdapter("select distinct caste from student where caste is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "caste";
            CMBALL.ValueMember = "caste";

        }
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select  Course_id,Course_name from course where course_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "Course_name";
            CMBALL.ValueMember = "Course_id";

        }
        private void showcgender()
        {
            adr = new OleDbDataAdapter("select  distinct gender from student where gender is not null  ", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "gender";
            CMBALL.ValueMember = "gender";

        }
        private void showyear()
        {
            adr = new OleDbDataAdapter("select  distinct aca_year from admission_confirmed where aca_year is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "aca_year";
            CMBALL.ValueMember = "aca_year";

        }
       

        private void rptadmitedstudent_Load(object sender, EventArgs e)
        {
            con.Open();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            showcastea();
        }

        private void rdocourse_CheckedChanged(object sender, EventArgs e)
        {
            showcourse();
        }

        private void radioButton3_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            showcgender();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            showyear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!rdocourse.Checked && !radioButton1.Checked && !radioButton3.Checked && !radioButton2.Checked )
            {
                MessageBox.Show("Please select any  filter type you want to sort students out ");
                return;
            }
            if (rdocourse.Checked)
            {
                adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,r.AcaYear,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where r.course_id=" + CMBALL.SelectedValue + " and r.status='" + "Active" + "'", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;

                label3.Text = dt.Rows.Count.ToString();

            }
            else if (radioButton1.Checked)
            {
                adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,r.AcaYear,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where s.caste='" + CMBALL.SelectedValue + "' and r.status='" + "Active" + "'", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                label3.Text = dt.Rows.Count.ToString();
            }
            else if (radioButton3.Checked)
            {
                adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,r.AcaYear,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where s.gender='" + CMBALL.SelectedValue + "' and r.status='" + "Active" + "'", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                label3.Text = dt.Rows.Count.ToString();
            }
            else if (radioButton2.Checked)
            {
                adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,r.AcaYear,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where r.acayear='" + CMBALL.SelectedValue + "' and r.status='" + "Active" + "'", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                label3.Text = dt.Rows.Count.ToString();

            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
