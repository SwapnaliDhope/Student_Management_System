using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace SMS_PROJECT
{
    public partial class frmSTUDENT_ADMISSION_FORM : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        public frmSTUDENT_ADMISSION_FORM()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }




        private void frmSTUDENT_ADMISSION_FORM_Load(object sender, EventArgs e)
        {
            con.Open();

            getyear();
            showstudents();
            getcoursename();
            showusers(); 

            dataGridView2.Visible = false;
            dataGridView1.Visible = true;

            adr = new OleDbDataAdapter("select * from registration_list", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["stud_id"].Visible = false;
            dataGridView1.Columns["course_id"].Visible = false;


        }
        public void showfee()
        {
            if (cmbcourse.SelectedIndex == -1 || cmbyear.SelectedIndex == -1)
            {
                return;
            }
            if (cmbcourse.SelectedValue is DataRowView)
            {
                return;
            }
            int courseid = Convert.ToInt32(cmbcourse.SelectedValue);
            string aca_year = cmbyear.SelectedItem.ToString();

            cmd = new OleDbCommand("select total from fees where course_id=" + courseid + " and aca_year='" + aca_year + "'", con);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                label6.Text = result.ToString();
                label6.Visible = true;
            }
            else
            {
                label6.Text = "0";
                label6.Visible = true;

            }
        }


        public void showsem()
        {
            if (cmbcourse.SelectedIndex == -1)
                return;
            if (!(cmbcourse.SelectedValue is int))
                return;
            adr = new OleDbDataAdapter("select sem_id,sem from semester where  course_id=" + cmbcourse.SelectedValue + " and status=true ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsem.DataSource = dt;
            cmbsem.DisplayMember = "sem";
            cmbsem.ValueMember = "sem_id";


        }
        public void showstudents()
        {
            adr = new OleDbDataAdapter("select stud_id,stud_name from student where stud_name is not null order by stud_name ASC ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbstu.DataSource = dt;
            cmbstu.DisplayMember = "Stud_name";
            cmbstu.ValueMember = "stud_id";
            cmbstu.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbstu.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        public void showusers()
        {
            adr = new OleDbDataAdapter("select user_name from Login where status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbuser.DataSource = dt;
            cmbuser.DisplayMember = "user_name";
            cmbuser.ValueMember = "user_name";

        }
        public void getyear()
        {

            for (int year = 2025; year <= 2035; year++)
            {
                cmbyear.Items.Add(year);
            }


        }

        public void getcoursename()
        {
            adr = new OleDbDataAdapter("select course_id,course_name from course where course_name is not null and status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "course_name";
            cmbcourse.ValueMember = "course_id";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {

            cmbstu.Text = "";
            cmbcourse.Text = "";
            txtfee.Text = "";

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbstu.SelectedIndex == -1)
            {
                MessageBox.Show("please enter Student name ");
                cmbstu.Focus();

            }
            else if (dtpdate.Text == "")
            {
                MessageBox.Show("please enter admission date "); return;
                dtpdate.Focus();

            }
            else if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("please select course "); return;
                cmbcourse.Focus();

            }

            else if (txtfee.Text == "")
            {
                MessageBox.Show("please enter submitted fee "); txtfee.Focus();

            }
            else if (cmbyear.SelectedIndex == -1)
            {
                MessageBox.Show("please enter Academic year "); return;
                cmbyear.Focus();

            }
            else if (cmbuser.SelectedIndex == -1)
            {
                MessageBox.Show("please enter user name "); return; cmbuser.Focus();

            }

            else
            {

                

                cmd = new OleDbCommand("select count(*) from admission_confirmed where course_id=" + cmbcourse.SelectedValue + " ", con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                label13.Text = count.ToString();

                cmd = new OleDbCommand("select capacity from course where course_id=" + cmbcourse.SelectedValue + "", con);
                int cap = Convert.ToInt32(cmd.ExecuteScalar());
                if (count >= cap)
                {
                    MessageBox.Show("seat full! admission not allowed");
                    button1.Enabled = false;

                }
                else
                {
                    cmd = new OleDbCommand("select count(*) from admission_confirmed where course_id=" + cmbcourse.SelectedValue + "  and Aca_Year='" + cmbyear.Text + "' and stud_id=" + cmbstu.SelectedValue + "", con);
                    int c = Convert.ToInt32(cmd.ExecuteScalar());
                    if (c > 0) { MessageBox.Show("Student already admistted "); return; }




                    string s = "insert into admission_confirmed(adm_date,stud_id,course_id,fee_paid,Aca_Year,user_name,status,sem_id) values(#" + dtpdate.Text + "#," + cmbstu.SelectedValue + "," + cmbcourse.SelectedValue + "," + txtfee.Text + ",'" + cmbyear.Text + "','" + cmbuser.Text + "','" + "Active" + "'," + cmbsem.SelectedValue + ")";

                    cmd = new OleDbCommand(s, con);
                    cmd.ExecuteNonQuery();
                    //showrecords();
                    Showremainingfee();
                    showcount();
                    //OleDbCommand cmd2 = new OleDbCommand("update admission_confirmed set status='" + "Active" + "'", con);
                    //cmd2.ExecuteNonQuery();
                    MessageBox.Show("Student has been admitted  successfully");

                    show();


                }



            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (cmbstu.SelectedIndex == -1)
            {
                MessageBox.Show("please enter Student name ");
                cmbstu.Focus();

            }
            else if (dtpdate.Text == "")
            {
                MessageBox.Show("please enter admission date "); return;
                dtpdate.Focus();

            }
            else if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("please select course "); return;
                cmbcourse.Focus();

            }

            else if (txtfee.Text == "")
            {
                MessageBox.Show("please enter submitted fee "); txtfee.Focus();

            }
            else if (cmbyear.SelectedIndex == -1)
            {
                MessageBox.Show("please enter Academic year "); return;
                cmbyear.Focus();

            }
            else if (cmbuser.SelectedIndex == -1)
            {
                MessageBox.Show("please enter user name "); return; cmbuser.Focus();

            }
            else
            {
                cmd = new OleDbCommand("update Admission_confirmed set adm_date=#" + dtpdate.Value.ToString("MM/dd/yyyy") + "#,course_id=" + cmbcourse.SelectedValue + ",fee_paid=" + txtfee.Text + ",Aca_Year='" + cmbyear.Text + "',user_name='" + cmbuser.Text + "',sem_id=" + cmbsem.SelectedValue + " where adm_id=" + textBox1.Text + "", con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Data updated successfully");


                show();
                Showremainingfee();
            }
        }
        private void cmbstu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click_1(object sender, EventArgs e)
        {

            DialogResult ans;

            ans = MessageBox.Show("do you want to cancel any admission ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                if (cmbcourse.SelectedIndex == -1 || cmbsem.SelectedIndex == -1 || cmbyear.SelectedIndex == -1 || cmbstu.SelectedIndex == -1)
                {
                    MessageBox.Show("feel  all values"); return;
                }
                cmd = new OleDbCommand("select count(*) from RNO_Creation where  stud_id=? and course_id=? and sem_id=?and AcaYear=?", con);
                cmd.Parameters.AddWithValue("?", Convert.ToInt32(cmbstu.SelectedValue));
                cmd.Parameters.AddWithValue("?", Convert.ToInt32(cmbcourse.SelectedValue));
                cmd.Parameters.AddWithValue("?", Convert.ToInt32(cmbsem.SelectedValue));
                cmd.Parameters.AddWithValue("?", cmbyear.Text);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show(" count=" + count);

                if (count > 0)
                {
                    frmADMISSION_CANCEL adm = new frmADMISSION_CANCEL();
                    adm.Show();
                    show();

                }

                else
                {

                    OleDbCommand cmd2 = new OleDbCommand("update admission_confirmed set status=?  where adm_id=? and course_id=? and sem_id=? and aca_year=?", con);

                    cmd2.Parameters.AddWithValue("?", "Inactive");
                    int admid;

                    if (!int.TryParse(textBox1.Text, out admid))
                    {
                        MessageBox.Show("Invalid Admission ID");
                        return;
                    }
                    cmd2.Parameters.AddWithValue("?", admid);
                    cmd2.Parameters.AddWithValue("?", Convert.ToInt32(cmbcourse.SelectedValue));
                    cmd2.Parameters.AddWithValue("?", Convert.ToInt32(cmbsem.SelectedValue));
                    cmd2.Parameters.AddWithValue("?", cmbyear.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Admission deleted successfully");

                    show();
                }
            }



            //}
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Do you want to clear all records?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {

                cmd = new OleDbCommand(" update  Admission_confirmed set status='" + "Inactive" + "' ", con);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("all students has been deleted ");

                show(); 


            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            cmbstu.SelectedIndex = -1;
            cmbcourse.SelectedIndex = -1;
            txtfee.Text = "";
            cmbyear.SelectedIndex = -1; cmbsem.SelectedIndex = -1;
            cmbuser.SelectedIndex = -1;
            adr = new OleDbDataAdapter("select * from registration_list", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["stud_id"].Visible = false;
            dataGridView1.Columns["course_id"].Visible = false;

        }
        public void showregisteredstu()
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            if (cmbcourse.SelectedIndex == -1)
                return;
            if (!(cmbcourse.SelectedValue is int))
                return;
            if (cmbyear.SelectedItem == null)
            {
                return;
            }
            else
            {
                int cid = (int)cmbcourse.SelectedValue;
                string year = cmbyear.SelectedItem.ToString();
                cmd = new OleDbCommand("select count(*) from student where course_id=" + cid + " and aca_year='" + year + "'", con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                label14.Text = count.ToString();
                label14.Visible = true;

                cmd = new OleDbCommand("select capacity from course where course_id=" + cid + " ", con);
                int cap = Convert.ToInt32(cmd.ExecuteScalar());
                label18.Text = cap.ToString();
                label18.Visible = true;

            }

        }
        public void showcount()
        {
            if (cmbcourse.SelectedIndex == -1)
                return;
            if (!(cmbcourse.SelectedValue is int))
                return;
            if (cmbyear.SelectedItem == null)
            {
                return;
            }
            else
            {
                int cid = (int)cmbcourse.SelectedValue;
                string year = cmbyear.SelectedItem.ToString();
                cmd = new OleDbCommand("select count(*) from admission_confirmed where course_id=" + cid + " and aca_year='" + year + "' and status='" + "Active" + "'", con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                label13.Text = count.ToString();
                label13.Visible = true;

                cmd = new OleDbCommand("select capacity from course where course_id=" + cid + "", con);
                int cap = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > cap)
                {
                    MessageBox.Show("seat full! admission not allowed");
                    button1.Enabled = false;

                }
                else
                {
                    button1.Enabled = true;

                }

            }
        }
        public void showregistered()
        {
            cmd = new OleDbCommand("select count(*) from student", con);
            object r = cmd.ExecuteScalar();
            label14.Text = Convert.ToInt32(r).ToString();



        }
        private void button7_Click(object sender, EventArgs e)
        {
            show();


        }

        private void show()
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = true;

            if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please selct course first");
                return;
            }
            else if (cmbyear.Text == "")
            {
                MessageBox.Show("Select year ");
                return; cmbyear.Focus();
            }
            int courseid = Convert.ToInt32(cmbcourse.SelectedValue);
            adr = new OleDbDataAdapter("select a.adm_id, a.course_id,a.stud_id,a.sem_id,s.stud_name,c.course_name,a.fee_paid,a.aca_year,a.user_name,sem.sem from (((admission_confirmed a inner join student s on a.stud_id=s.stud_id)inner join course c on a.course_id=c.course_id)inner join semester sem on a.sem_id=sem.sem_id) where a.course_id=" + courseid + " and a.Aca_Year='" + cmbyear.Text + "' and a.status='" + "Active" + "'", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView2.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("no record found");
            }
            dataGridView2.Columns["course_id"].Visible = false;
            dataGridView2.Columns["stud_id"].Visible = false;
            dataGridView2.Columns["sem_id"].Visible = false; dataGridView2.Columns["adm_id"].Visible = false;

        }
        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {

         
            showsem();
            showfee();
            showcount();
            showregisteredstu();


        }


        private void txtfee_TextChanged(object sender, EventArgs e)
        {




        }

        private void txtyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            showsem();
            showfee();
            showcount();
            showregisteredstu();

        }
        public void Showremainingfee()
        {
            decimal totalfee = 0;
            decimal paidfee = 0;
            decimal.TryParse(label6.Text, out totalfee);
            decimal.TryParse(txtfee.Text, out paidfee);
            label11.Text = (totalfee - paidfee).ToString();
            label11.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //txtadmid.Text = row.Cells["adm_id"].Value.ToString();
                // txtfee.Text = row.Cells["fee_paid"].Value.ToString();
                cmbcourse.SelectedValue = row.Cells["course_id"].Value;
                //cmbstu.SelectedValue = row.Cells["stud_id"].Value;
                cmbyear.Text = row.Cells["aca_year"].Value.ToString();

                cmbstu.SelectedValue = Convert.ToInt32(row.Cells["stud_id"].Value);
                Showremainingfee();
            }

        }

        private void txtadmid_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtadmid_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                cmbstu.Focus();
            }
        }

        private void cmbstu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtpdate.Focus();
            }

        }

        private void dtpdate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbcourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtfee.Focus();
            }

        }

        private void dtpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbyear.Focus();
            }

        }

        private void txtfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbsem.Focus();
            }
        }

        private void cmbyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbcourse.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtfee_Leave(object sender, EventArgs e)
        {
            decimal totalfee = 0;
            decimal paidfee = 0;
            if (!decimal.TryParse(label6.Text, out totalfee))
            {
                MessageBox.Show("invalid course fee");
                return;
            }
            if (!decimal.TryParse(txtfee.Text, out paidfee))
            {
                MessageBox.Show("invalid amount ");
                return;
            }

            if (paidfee > totalfee)
            {
                MessageBox.Show("invalid payment ! paid fee cannot be greater than course fee");
                txtfee.Clear();
                txtfee.Focus();


            }
            else
            {
                Showremainingfee();
            }
        }

        private void frmSTUDENT_ADMISSION_FORM_Shown(object sender, EventArgs e)
        {

        }

        private void cmbuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
        }

        private void cmbuser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please selct course first");
                return;
            }
            else if (cmbyear.Text == "")
            {
                MessageBox.Show("Select year ");
                return;
            }
            adr = new OleDbDataAdapter("select * from  registration_list  where aca_year='" + cmbyear.Text + "' and course_id=" + cmbcourse.SelectedValue + "", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["stud_id"].Visible = false;
            dataGridView1.Columns["course_id"].Visible = false;

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox1.Text = row.Cells["adm_id"].Value.ToString();
                cmbstu.SelectedValue = row.Cells["stud_id"].Value.ToString();
                txtfee.Text = row.Cells["fee_paid"].Value.ToString();
                cmbuser.SelectedValue = row.Cells["user_name"].Value.ToString();
                txtfee.Text = row.Cells["fee_paid"].Value.ToString();
                cmbcourse.Text = row.Cells["course_name"].Value.ToString();
              

                if (row.Cells["aca_year"].Value != null)
                {
                    cmbyear.Text = row.Cells["aca_year"].Value.ToString();
                }
               
                Showremainingfee();
            }

        }

        private void cmbsem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbuser.Focus();
            }
        }
    }
}

