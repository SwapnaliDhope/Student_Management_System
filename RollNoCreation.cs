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
    public partial class RollNoCreation : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
         int sroll = 0;
        DataSet ds = new DataSet();
        public RollNoCreation()
        {
            InitializeComponent();
        }
        public void showall()
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            adr = new OleDbDataAdapter("select r.roll_no,r.AcaYear,c.course_name,s.stud_name,sem.sem from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where r.status='"+"Active"+"'", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void RollNoCreation_Load(object sender, EventArgs e)
        {
            con.Open();
            showcourse();
            //showadmid();
            showyearadmitted();
            showall(); 
            showstu();
            if (cmbcourse.SelectedValue == null || cmbcourse.SelectedValue is DataRowView)
                return;
            showcapacty(); showsem();
        }

        public void showcourse()
        {
            adr = new OleDbDataAdapter("select course_id,course_name from course where status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "course_name";
            cmbcourse.ValueMember = "course_id";
        }
        public void showsem()
        {
            adr = new OleDbDataAdapter("select sem_id,sem from semester where status=true and course_id="+cmbcourse.SelectedValue+"", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsem.DataSource = dt;
            cmbsem.DisplayMember = "sem";
            cmbsem.ValueMember = "sem_id";
        }
       
       
        public void selectedroll()
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            string q = "select r.roll_no,r.Acayear,c.course_name,s.stud_name ,sem.sem from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id= c.course_id)inner join semester sem on r.sem_id=sem.sem_id) where r.acayear='" + cmbyear.SelectedValue + "' and r.course_id=" + cmbcourse.SelectedValue + " order by r.roll_no ASC";
            adr = new OleDbDataAdapter(q, con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cmbyear.SelectedIndex == -1)
            {
                MessageBox.Show("Select academic year");
                return;
            }
            else if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("select course ");
                return;
            }
            else if (cmbsem.SelectedIndex == -1)
            {
                MessageBox.Show("select semester ");
                return;
            }
            else
            {
                string q = "select r.roll_no,s.stud_name,r.Acayear,c.course_name ,sem.sem from (((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id= c.course_id)inner join semester sem on r.sem_id=sem.sem_id)  where r.acayear='" + cmbyear.SelectedValue + "' and r.course_id=" + cmbcourse.SelectedValue + " and r.stud_id=" + cmbname.SelectedValue + " and r.sem_id="+cmbsem.SelectedValue+"";
                adr = new OleDbDataAdapter(q, con);

                dt = new DataTable();
                
                adr.Fill(dt);
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No student found");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public void showyearadmitted()
        {
            adr = new OleDbDataAdapter("select distinct(Aca_Year) from Admission_confirmed ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbyear.DataSource = dt;
            cmbyear.DisplayMember = "Aca_Year";
            cmbyear.ValueMember = "Aca_Year";
        }


        private void button1_Click(object sender, EventArgs e)
        {
          
    if (cmbyear.SelectedIndex == -1 || cmbcourse.SelectedIndex == -1 || cmbsem.SelectedIndex == -1 || txtstart.Text.Trim() == "")
    {
        MessageBox.Show("Fill all fields properly");
        return;
    }

    int courseid = Convert.ToInt32(cmbcourse.SelectedValue);
    int semid = Convert.ToInt32(cmbsem.SelectedValue);
    string year = cmbyear.Text;

    int roll = Convert.ToInt32(txtstart.Text);

    string query = @"SELECT s.stud_id, s.stud_name, a.adm_id
                     FROM Admission_confirmed a
                     INNER JOIN student s ON a.stud_id=s.stud_id
                     WHERE a.course_id=" + courseid + @"
                     AND a.aca_year='" + year + @"'
                     AND a.sem_id=" + semid + @"
                     AND a.status='Active'
                     ORDER BY s.stud_name ASC";

    cmd = new OleDbCommand(query, con);
    rdr = cmd.ExecuteReader();

    bool inserted = false;
    bool already = false;

    while (rdr.Read())
    {
        int sid = Convert.ToInt32(rdr["stud_id"]);
        int admid = Convert.ToInt32(rdr["adm_id"]);

        // check student already has roll no
        OleDbCommand checkStudent = new OleDbCommand(
        "SELECT COUNT(*) FROM RNO_Creation WHERE stud_id=" + sid +
        " AND course_id=" + courseid +
        " AND sem_id=" + semid +
        " AND AcaYear='" + year + "'", con);

        int studentExists = Convert.ToInt32(checkStudent.ExecuteScalar());

        if (studentExists == 0)
        {
            // check roll already used
            OleDbCommand checkRoll = new OleDbCommand(
            "SELECT COUNT(*) FROM RNO_Creation WHERE roll_no=" + roll +
            " AND course_id=" + courseid +
            " AND sem_id=" + semid +
            " AND AcaYear='" + year + "'", con);

            while (Convert.ToInt32(checkRoll.ExecuteScalar()) > 0)
            {
                roll++; // next roll
                checkRoll.CommandText =
                "SELECT COUNT(*) FROM RNO_Creation WHERE roll_no=" + roll +
                " AND course_id=" + courseid +
                " AND sem_id=" + semid +
                " AND AcaYear='" + year + "'";
            }

            OleDbCommand insertCmd = new OleDbCommand(
            "INSERT INTO RNO_Creation (roll_no,AcaYear,course_id,stud_id,adm_id,sem_id,status) VALUES (" +
            roll + ",'" + year + "'," + courseid + "," + sid + "," + admid + "," + semid + ",'Active')", con);

            insertCmd.ExecuteNonQuery();

            roll++;
            inserted = true;
        }
        else
        {
            already = true;
        }
    }

    rdr.Close();

    if (inserted)
        MessageBox.Show("Roll numbers allocated successfully");

    if (already)
        MessageBox.Show("Some students already had roll numbers");

    selectedroll();

        }
        

        private void button2_Click(object sender, EventArgs e)
        {




        }
        public void showstu()
        {
            adr = new OleDbDataAdapter("select stud_name,stud_ID from student order by stud_name ASC", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbname.DataSource = dt;
            cmbname.DisplayMember = "stud_name";
            cmbname.ValueMember = "stud_id";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmbname.SelectedIndex == -1)
            {
                MessageBox.Show("Enter name to delete");
                cmbname.Focus();
            }
            else if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("Select course to delete the record");
                cmbcourse.Focus();
            }
            else if (cmbyear.SelectedIndex == -1)
            {
                MessageBox.Show("select year ");
                cmbyear.Focus();
            }
            else
            {
                cmd = new OleDbCommand("update RNO_Creation set status='" + "Inactive" + "' where stud_id=" + cmbname.SelectedValue + " and course_id="+cmbcourse.SelectedValue+" and sem_id="+cmbsem.SelectedValue+" and acaYear='"+cmbyear.Text+"'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show(" Record Deleted successfully");

                 showall();
            }
          

        }

        private void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcourse.SelectedValue == null || cmbcourse.SelectedValue is DataRowView)
                return;
            showcapacty(); showsem();
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
       

        private void cmbname_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
              
               cmbcourse.Text = row.Cells["course_name"].Value.ToString();
                
                cmbyear.Text = row.Cells["acayear"].Value.ToString();
               
                cmbsem.Text = row.Cells["sem"].Value.ToString();
                cmbname.Text = row.Cells["stud_name"].Value.ToString();


            }
        }
        private void showcapacty()
        {
            if (cmbcourse.SelectedValue == null)
                return;
            if (cmbcourse.SelectedValue is DataRowView) return;
            int cid = (int)cmbcourse.SelectedValue;
            cmd = new OleDbCommand("select capacity from course where course_id=" + cid + " ", con);
            int cap = Convert.ToInt32(cmd.ExecuteScalar());
            label2.Text = cap.ToString();
            label2.Visible = true;
        }

        private void RollNoCreation_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("DO you want to delete all roll no records ", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                //cmd = new OleDbCommand("delete from RNO_Creation where roll_no not in (select roll_no from Admission_cancel)", con);

                //cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update RNO_Creation set status='" + "inactive" + "'  where  roll_no in  (select roll_no from RNO_Creation)", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data cleared successfully");

            }
            showall();

        }
         
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                cmbcourse.Text = row.Cells["course_name"].Value.ToString();

                cmbyear.Text = row.Cells["acayear"].Value.ToString();

                cmbsem.Text = row.Cells["sem"].Value.ToString();
                cmbname.Text = row.Cells["stud_name"].Value.ToString();


            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cmbyear.Text = "";
            cmbcourse.SelectedIndex = -1;
            cmbsem.SelectedIndex = -1;
            txtstart.Text = "";
        }

        }
    }

