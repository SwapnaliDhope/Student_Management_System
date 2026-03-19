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

    public partial class rpt_roll_no : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rpt_roll_no()
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
            if (cmbAll.SelectedValue == null || cmbAll.SelectedValue is DataRowView) return;
            adr = new OleDbDataAdapter("select  sem,sem_id from semester where  course_id=" + cmbAll.SelectedValue + " ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsem.DataSource = dt;
            cmbsem.DisplayMember = "sem";
            cmbsem.ValueMember = "sem_id";

        }

        private void rpt_roll_no_Load(object sender, EventArgs e)
        {
            con.Open();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            showyear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            showcourse(); showsem();
        }

        private void cmbsem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && cmbsem.SelectedIndex == -1)
            {
                MessageBox.Show("Please select any  filter type you want to sort students out ");
                return;
            } if (radioButton2.Checked)
            {
                if (cmbsem.SelectedIndex == -1)
                {

                    adr = new OleDbDataAdapter("select s.stud_name,r.roll_no,r.AcaYear,c.course_name,sem.sem from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where r.course_id=" + cmbAll.SelectedValue + "", con); dt = new DataTable();
                    adr.Fill(dt);

                    dataGridView1.DataSource = dt;
                    label4.Text = dt.Rows.Count.ToString(); label4.Visible = true;

                }
                else
                {
                    adr = new OleDbDataAdapter("select  s.stud_name,r.roll_no,r.AcaYear,c.course_name,sem.sem from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where r.course_id=" + cmbAll.SelectedValue + " and r.sem_id=" + cmbsem.SelectedValue + "", con); dt = new DataTable();
                    dt = new DataTable();
                    adr.Fill(dt);
                    dataGridView1.DataSource = dt;

                    label4.Text = dt.Rows.Count.ToString(); label4.Visible = true;
                }
            }
            else if (radioButton1.Checked)
            {
                adr = new OleDbDataAdapter("select  s.stud_name,r.roll_no,r.AcaYear,c.course_name,sem.sem from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where r.Acayear='" + cmbAll.SelectedValue + "'", con); dt = new DataTable();
                dt = new DataTable();
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.DataSource = dt;

                label4.Text = dt.Rows.Count.ToString();
                label4.Visible = true;

            }
            if (textBox1.SelectedText != "")
            { search(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void search()
        {
            adr = new OleDbDataAdapter("select  s.stud_name,r.roll_no,r.AcaYear,c.course_name,sem.sem from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where s.stud_name like ?", con); dt = new DataTable();
            adr.SelectCommand.Parameters.AddWithValue("?", "%" + textBox1.Text.Trim() + "%");
            dt = new DataTable();
            adr.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Record Found");
                dataGridView1.DataSource = null;
                label4.Text = "0";
                return;
            }
            
                dataGridView1.DataSource = dt;
                label4.Text = dt.Rows.Count.ToString();
                
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
