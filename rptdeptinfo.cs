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
    public partial class rptdeptinfo : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public rptdeptinfo()
        {
            InitializeComponent();
        }

        private void rptcourse_Load(object sender, EventArgs e)
        {
            con.Open(); showdept(); showdeptcount(); showAll(); showcourse();
            cmbdept.SelectedIndex = -1;
            cmbcourses.SelectedValue = -1;
        }
        //private void cousecount()
        //{
        //    if(cmbdept.SelectedIndex==-1 )
        //    {
        //        return;
        //    }
        //    cmd=new OleDbCommand("select count(*) from course ",con);
        //    int count=Convert.ToInt32(cmd.ExecuteScalar());
        //    label4.Text = count.ToString();

        //}
        private void stuperdept()
        {
            if (cmbdept.SelectedValue == null)
            {
                return;
            }
            cmd = new OleDbCommand("select count(course_id) from course where dept_id=" + cmbdept.SelectedValue + "", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            label4.Text = count.ToString();

        }
        private void showdept()
        {
            adr = new OleDbDataAdapter("select dept_name ,dept_id from department  where dept_name is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbdept.DataSource = dt;
            cmbdept.DisplayMember = "Dept_name";
            cmbdept.ValueMember = "dept_id";
        }
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select course_name ,course_id from course  where status=true ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbcourses.DataSource = dt;
            cmbcourses.DisplayMember = "course_name";
            cmbcourses.ValueMember = "course_id";
        }
        private void showdeptcount()
        {
            cmd = new OleDbCommand("select count(*) from department where dept_name is not null ", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            label6.Text = count.ToString();
        }
        private void showAll()
        {
            adr = new OleDbDataAdapter("select * from department where dept_name is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbdept.SelectedValue == null && cmbdept.SelectedValue is DataRowView && cmbcourses.SelectedIndex == -1)
            {
                MessageBox.Show("Select any filter first");
                return;
            }  

            if (cmbdept.SelectedIndex != -1)
            {
                adr = new OleDbDataAdapter(
                    "select d.dept_name,c.course_name,c.capacity from course c inner join department d on c.dept_id=d.dept_id where c.dept_id=?",
                    con);

                adr.SelectCommand.Parameters.AddWithValue("?", cmbdept.SelectedValue);

                dt = new DataTable();
                adr.Fill(dt);

                dataGridView1.DataSource = dt;
                cmd = new OleDbCommand("select count(course_id) from course where dept_id=?", con);
                cmd.Parameters.AddWithValue("?", cmbdept.SelectedValue);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                label4.Text = count.ToString();
                label4.Visible = true;
             
            }
            else if (cmbcourses.SelectedIndex != -1)
            {


                adr = new OleDbDataAdapter("select d.dept_name ,c.course_name,count(s.sem) as NO_Of_Semester from (( course c inner join department d on c.dept_id=d.dept_id)inner join semester s on c.course_id=s.course_id)where c.course_id=" + cmbcourses.SelectedValue + " group by d.dept_name ,c.course_name", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                OleDbCommand cmd2 = new OleDbCommand("select capacity from course where course_id=" + cmbcourses.SelectedValue + "", con);
                int c = Convert.ToInt32(cmd2.ExecuteScalar());
                label9.Text = c.ToString(); label9.Visible = true;
             
            } cmbdept.SelectedIndex = -1;
            cmbcourses.SelectedValue = -1;
            } 
           

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }


    }
}
