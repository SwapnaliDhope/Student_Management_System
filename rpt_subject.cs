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
    public partial class rpt_subject : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rpt_subject()
        {
            InitializeComponent();
        }

        private void rpt_subject_Load(object sender, EventArgs e)
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
        private void showsem()
        {
            if (comboBox1.SelectedValue == null || comboBox1.SelectedValue is DataRowView) return;
            adr = new OleDbDataAdapter("select  sem,sem_id from semester where  course_id=" + comboBox1.SelectedValue + " ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "sem";
            comboBox2.ValueMember = "sem_id";

        }
        private void showyear()
        {
            comboBox1.DataSource = null;

            for (int year = 2025; year <= 2035; year++)
            {
                comboBox1.Items.Add(year);
            }

            comboBox1.Visible = true;
        }
       
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            showcourse(); showsem();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            showyear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
    if (!radioButton1.Checked && !radioButton3.Checked)
    {
        MessageBox.Show("Please select filter type");
        return;
    }

    dt = new DataTable();

    if (radioButton1.Checked) // Course filter
    {
        if (comboBox2.SelectedIndex != -1)
        {
            adr = new OleDbDataAdapter(
            "select c.course_name,s.sub_name,t.teach_name,s.aca_year,sem.sem " +
            "from (((subject s inner join course c on s.course_id=c.course_id) " +
            "inner join semester sem on s.sem_id=sem.sem_id) " +
            "inner join teacher t on s.teach_id=t.teach_id) " +
            "where s.course_id=" + comboBox1.SelectedValue +
            " and s.sem_id=" + comboBox2.SelectedValue, con);
        }
        else
        {
            adr = new OleDbDataAdapter(
            "select c.course_name,s.sub_name,t.teach_name,s.aca_year,sem.sem " +
            "from (((subject s inner join course c on s.course_id=c.course_id) " +
            "inner join semester sem on s.sem_id=sem.sem_id) " +
            "inner join teacher t on s.teach_id=t.teach_id) " +
            "where s.course_id=" + comboBox1.SelectedValue, con);
        }

        adr.Fill(dt);
        dataGridView1.DataSource = dt;

        label3.Text = dt.Rows.Count.ToString();
    }

    else if (radioButton3.Checked) // Year filter
    {
        adr = new OleDbDataAdapter(
        "select c.course_name,s.sub_name,t.teach_name,s.aca_year,sem.sem " +
        "from (((subject s inner join course c on s.course_id=c.course_id) " +
        "inner join semester sem on s.sem_id=sem.sem_id) " +
        "inner join teacher t on s.teach_id=t.teach_id) " +
        "where s.aca_year='" + comboBox1.Text + "'", con);

        adr.Fill(dt);

        dataGridView1.DataSource = dt;

        label3.Text = dt.Rows.Count.ToString();
    }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

      
    }
}
