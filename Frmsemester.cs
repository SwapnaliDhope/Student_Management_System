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
    public partial class Frmsemester : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        string[] roman = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII" };
        public Frmsemester()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void load()
        {

            adr = new OleDbDataAdapter(
            "select s.sem_id, c.course_name, s.sem from semester s " + "inner join course c on s.course_id=c.course_id where s.status=true", con);
            dt = new DataTable();
            adr.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["sem_id"].Visible = false;

        }

        private void Frmsemester_Load(object sender, EventArgs e)
        {
            con.Open(); showcourse(); showyear(); load();
        }
        private void showcourse()
        {
            adr = new OleDbDataAdapter("select  Course_id,Course_name from course where status=true  ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "Course_name";
            cmbcourse.ValueMember = "Course_id";

        }
        private void showyear()
        {
            for (int sem = 1; sem <= 10; sem++)
            {
                cmbsemcount.Items.Add(sem);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (cmbcourse.SelectedIndex == -1 || cmbsemcount.SelectedIndex == -1)
            {
                MessageBox.Show("Select Course and Semester Count");
                return;
            }

            if (cmbsemcount.SelectedIndex == -1)
            {
                MessageBox.Show("Please select no of semesterd you want to add");
                return;
            }
            int semcount = Convert.ToInt32(cmbsemcount.Text);

            // duplicate check
            cmd = new OleDbCommand("select count(*) from semester where course_id=" + cmbcourse.SelectedValue + " and status=true", con);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Semester already created for this course");
                return;
            }

            for (int i = 0; i < semcount; i++)
            {
                cmd = new OleDbCommand("insert into semester(sem,course_id) values('" + roman[i] + "'," + cmbcourse.SelectedValue + ")", con);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Semester inserted successfully");

            load();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (cmbcourse.SelectedIndex == -1 || cmbsemcount.SelectedIndex == -1)
            {
                MessageBox.Show("Select Course and Semester Count");
                return;
            }

            int totalSem = Convert.ToInt32(cmbsemcount.Text);

            cmd = new OleDbCommand(
            "update semester set status=false where course_id=" + cmbcourse.SelectedValue, con);

            cmd.ExecuteNonQuery();

            for (int i = 0; i < totalSem; i++)
            {
                cmd = new OleDbCommand("insert into semester(sem,course_id,status) values('"+ roman[i] + "'," + cmbcourse.SelectedValue + ",true)", con);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Semester Updated Successfully");

            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                cmbcourse.Text = row.Cells["course_name"].Value.ToString();
                cmbsemcount.Text = row.Cells["sem"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Do you wnat to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                cmd = new OleDbCommand("update semester set status=false ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("All records deleted");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmbsemcount.Text = ""; cmbcourse.SelectedIndex = -1;

        }
    }
}
