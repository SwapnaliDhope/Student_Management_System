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
    public partial class rptadmcancel : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rptadmcancel()
        {
            InitializeComponent();
        }
        private void showyear()
        {
            adr = new OleDbDataAdapter("select  distinct aca_year from admission_confirmed where aca_year is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbAll.DataSource = dt;
            cmbAll.DisplayMember = "aca_year";
            cmbAll.ValueMember = "aca_year";

        }
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select  Course_id,Course_name from course where course_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbAll.DataSource = dt;
            cmbAll.DisplayMember = "Course_name";
            cmbAll.ValueMember = "Course_id";

        }

        private void showsem()
        {
            adr = new OleDbDataAdapter("select  sem_id,sem from semester where sem is not null and course_id=" + cmbAll.SelectedValue + " ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsem.DataSource = dt;
            cmbsem.DisplayMember = "sem";
            cmbsem.ValueMember = "sem_id";

        }




        private void rptadmcancel_Load(object sender, EventArgs e)
        {
            con.Open();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getstatus()
        {
            cmbAll.DataSource = null;
            cmbAll.Items.Clear();
            cmbAll.Items.Add("Paid");
            cmbAll.Items.Add("Due");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!rdocourse.Checked && !rdoyear.Checked && !radioButton3.Checked && cmbsem.SelectedIndex == -1)
            {
                MessageBox.Show("Please select any  filter type you want to sort students out ");
                return;
            } if (rdocourse.Checked)
            {
                if (cmbsem.SelectedIndex == -1)
                {

                    adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,ac.aca_year,ac.reason,ac.refund_status,ac.refund_amount,ac.cancel_date,ac.user_name,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from ((((Admission_cancel ac inner join student s on ac.stud_id = s.stud_id)inner join course c on ac.course_id = c.course_id)inner join semester sem on ac.sem_id = sem.sem_id)inner join RNO_Creation r on ac.sr_no = r.sr_no)where ac.course_id = " + cmbAll.SelectedValue + "", con); dt = new DataTable();
                    adr.Fill(dt);
                    dataGridView1.DataSource = dt;

                    label4.Text = dt.Rows.Count.ToString(); label4.Visible = true;

                }
                else
                {
                    adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,ac.aca_year,ac.reason,ac.refund_status,ac.refund_amount,ac.cancel_date,ac.user_name,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from ((((Admission_cancel ac inner join student s on ac.stud_id = s.stud_id)inner join course c on ac.course_id = c.course_id)inner join semester sem on ac.sem_id = sem.sem_id)inner join RNO_Creation r on ac.sr_no = r.sr_no)where ac.course_id = " + cmbAll.SelectedValue + " and ac.sem_id=" + cmbsem.SelectedValue + "", con); dt = new DataTable();
                    dt = new DataTable();
                    adr.Fill(dt);
                    dataGridView1.DataSource = dt;
                    label4.Text = dt.Rows.Count.ToString(); label4.Visible = true;
                }
            }
            else if (rdoyear.Checked)
            {
                adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,ac.aca_year,ac.reason,ac.refund_status,ac.refund_amount,ac.cancel_date,ac.user_name,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from ((((Admission_cancel ac inner join student s on ac.stud_id = s.stud_id)inner join course c on ac.course_id = c.course_id)inner join semester sem on ac.sem_id = sem.sem_id)inner join RNO_Creation r on ac.sr_no = r.sr_no)where ac.aca_year ='" + cmbAll.SelectedValue + "'", con); 
                dt = new DataTable();
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                label4.Text = dt.Rows.Count.ToString();
                label4.Visible = true;
            }
            else if (radioButton3.Checked)
            {
                adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,c.course_name,ac.aca_year,ac.reason,ac.refund_status,ac.refund_amount,ac.cancel_date,ac.user_name,sem.sem,s.Gender,s.DOB,s.mobileNo,s.EmailID,s.address,s.caste,s.adhar_no from ((((Admission_cancel ac inner join student s on ac.stud_id = s.stud_id)inner join course c on ac.course_id = c.course_id)inner join semester sem on ac.sem_id = sem.sem_id)inner join RNO_Creation r on ac.sr_no = r.sr_no)where ac.refund_status = '" + cmbAll.Text + "'", con); dt = new DataTable();
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                label4.Text = dt.Rows.Count.ToString(); label4.Visible = true;
            }
           




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rdoyear_CheckedChanged(object sender, EventArgs e)
        {
            showyear();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            showcourse(); showsem();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            getstatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
