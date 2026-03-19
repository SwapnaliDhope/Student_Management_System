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
    public partial class rpt_Teacher : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rpt_Teacher()
        {
            InitializeComponent();
        }
       
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select  Course_id,Course_name from course where course_name is not null  ", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "Course_name";
            CMBALL.ValueMember = "Course_id";

        }
        private void showcgender()
        {
            adr = new OleDbDataAdapter("select  distinct gender from teacher where gender is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "gender";
            CMBALL.ValueMember = "gender";

        }
        private void showsub()
        {
            adr = new OleDbDataAdapter("select  sub_name,sub_id from subject where  sub_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "sub_name";
            CMBALL.ValueMember = "sub_id";

        }
        private void showdept()
        {
            adr = new OleDbDataAdapter("select  dept_id,dept_name from Department where dept_name is not null ", con);
            dt = new DataTable();
            adr.Fill(dt);
            CMBALL.DataSource = dt;
            CMBALL.DisplayMember = "dept_name";
            CMBALL.ValueMember = "dept_id";

        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (!rdocourse.Checked && !radioButton5.Checked && !radioButton3.Checked && !radioButton1.Checked )
            {
                MessageBox.Show("Please select any  filter type you want to sort students out ");
                return;
            } 
            if (rdocourse.Checked)
            {
                    adr = new OleDbDataAdapter("select t.teach_name,t.gender,t.email,t.mo_no,c.course_name,d.dept_name from ((teacher t inner join course c on t.course_id=c.course_id) inner join department d on t.dept_id=d.dept_id) where t.course_id=" + CMBALL.SelectedValue + "  and isactive=True  ", con); dt = new DataTable();
                    dt = new DataTable();
                    adr.Fill(dt);
                    dataGridView1.DataSource = dt;

                    label2.Text = dt.Rows.Count.ToString(); label2.Visible = true;

            }
            else if (radioButton1.Checked)
            {

                adr = new OleDbDataAdapter("select s.sub_name,t.teach_name,t.gender,t.email,t.mo_no,c.course_name from ((subject s inner join course c on s.course_id=c.course_id) inner join teacher t on s.teach_id=t.teach_id) where  sub_name='" + CMBALL.Text + "' and isactive=True ", con); dt = new DataTable();
                adr.Fill(dt);

                dataGridView1.DataSource = dt;
                label2.Text = dt.Rows.Count.ToString(); label2.Visible = true;

            }
            else if (radioButton3.Checked)
            {

                adr = new OleDbDataAdapter("select t.teach_name,t.gender,t.email,t.mo_no,c.course_name,d.dept_name from ((teacher t inner join course c on t.course_id=c.course_id) inner join department d on t.dept_id=d.dept_id) where t.gender='" + CMBALL.Text + "' and isactive=True  ", con); dt = new DataTable();
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;

                label2.Text = dt.Rows.Count.ToString(); label2.Visible = true;

            }
            else if (radioButton5.Checked)
            {

                adr = new OleDbDataAdapter("select t.teach_name,t.gender,t.email,t.mo_no,c.course_name,d.dept_name from ((teacher t inner join course c on t.course_id=c.course_id) inner join department d on t.dept_id=d.dept_id) where t.dept_id=" + CMBALL.SelectedValue + " and isactive=True  ", con); dt = new DataTable();
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;

                label2.Text = dt.Rows.Count.ToString(); label2.Visible = true;

            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            showdept();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rpt_Teacher_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void rdocourse_CheckedChanged(object sender, EventArgs e)
        {
            showcourse(); 
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            showcgender();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adr = new OleDbDataAdapter("select s.sub_name,t.teach_name,t.gender,t.email,t.mo_no,c.course_name from ((subject s inner join course c on s.course_id=c.course_id) inner join teacher t on s.teach_id=t.teach_id) where  isactive=False ", con); 
            dt = new DataTable();

            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;

            label2.Text = dt.Rows.Count.ToString(); label2.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            showsub();
        }
    }
}
