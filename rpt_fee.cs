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
    public partial class rpt_fee : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rpt_fee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select any  filter type you want to sort students out ");
                return;
            }
            if (radioButton1.Checked)
            {
                adr = new OleDbDataAdapter("select c.course_name,e.total,e.adm_fee,e.clg_Exam_fee,e.tution_fee,e.library_fee,e.form_fee from Fees e inner join course c on e.course_id=c.course_id where e.aca_year='" + comboBox1.Text + "'", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;

               
            }
            if (radioButton2.Checked)
            {
                adr = new OleDbDataAdapter("select e.aca_year,e.adm_fee,e.clg_Exam_fee,e.tution_fee,e.library_fee,e.form_fee,e.total from Fees e where course_id=" + comboBox1.SelectedValue + "", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;

               

            }
        }

        private void rpt_fee_Load(object sender, EventArgs e)
        {
            con.Open();
        }
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select  Course_id,Course_name from course where course_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Course_name";
            comboBox1.ValueMember = "Course_id";

        }
        private void showyear()
        {
            comboBox1.DataSource = null;

            for (int year = 2025; year <= 2035; year++)
            {
                comboBox1.Items.Add(year);
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            showyear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            showcourse();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
