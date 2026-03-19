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
    public partial class frmADMISSION_CANCEL : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        DataSet ds = new DataSet();
        public frmADMISSION_CANCEL()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
       


        public void getroll()
        {
            string s = "select roll_no ,sr_no from RNO_Creation where roll_no is not null";
            adr = new OleDbDataAdapter(s, con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbrno.DataSource = dt;
            cmbrno.DisplayMember = "roll_no";
            cmbrno.ValueMember = "sr_no";

        }
        public void paidfee()
        {
            if (cmbrno.SelectedValue == null || cmbrno.SelectedValue is DataRowView)
            {
                return;
            }
            string s = "select fee_paid from Admission_confirmed a inner join RNO_Creation r on a.adm_id=r.adm_id where r.sr_no=" + cmbrno.SelectedValue + "";
            cmd = new OleDbCommand(s, con);
            object r = cmd.ExecuteScalar();
            if (r == null)
            {
                txtfee.Text = "0";
            }
            else
            {

                txtfee.Text = r.ToString();
            }
        }
        public void getcount()
        {
            cmd = new OleDbCommand("select count(*) from Admission_cancel", con);
            object r = cmd.ExecuteScalar();
            label12.Text = r.ToString();
            label12.Visible = true;

        }
        private void frmADMISSION_CANCEL_Load(object sender, EventArgs e)
        {
            con.Open();
            getroll();
            getcourse();
            getusername();
            getstudent();
            getcount(); year(); getsem();
            //admitted();
            getadm();



        }
        private void admitted()
        {
            if (cmbyear.Text == "")
            {
                MessageBox.Show("select academic year"); return;
            }
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            adr = new OleDbDataAdapter("select r.sr_no,r.roll_no,a.adm_id, s.stud_name,c.course_name,sem.sem,a.fee_paid,a.adm_date,a.aca_year from ((((RNO_Creation r inner join  student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_id)inner join admission_confirmed a on r.adm_id=a.adm_id)inner join semester sem on r.sem_id=sem.sem_id) where r.status='" + "Active" + "' and r.AcaYear='" + cmbyear.Text + "' ", con);
            dt = new DataTable();
            adr.Fill(dt);

            dataGridView2.DataSource = dt;
            dataGridView2.Columns["sr_no"].Visible = false;
            dataGridView2.Columns["adm_id"].Visible = false; label12.Text = dt.Rows.Count.ToString(); label12.Visible = true;
        }
        private void getadm()
        {
            adr = new OleDbDataAdapter("select adm_id from admission_confirmed", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbadmid.DataSource = dt;
            cmbadmid.DisplayMember = "adm_id";
            cmbadmid.ValueMember = "adm_id";

        }
        public void getstudent()
        {
            adr = new OleDbDataAdapter("select stud_id,stud_name from student where stud_name is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbstuname.DataSource = dt;
            cmbstuname.DisplayMember = "stud_name";
            cmbstuname.ValueMember = "stud_id";
        }
        public void getsem()
        {
            adr = new OleDbDataAdapter("select sem_id,sem from semester where  course_id=" + cmbCourse.SelectedValue + "", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsem.DataSource = dt;
            cmbsem.DisplayMember = "sem";
            cmbsem.ValueMember = "sem_id";
        }

        public void getcourse()
        {
            adr = new OleDbDataAdapter("select course_id,course_name from course where course_name is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbCourse.DataSource = dt;
            cmbCourse.DisplayMember = "course_name";
            cmbCourse.ValueMember = "course_id";
        }
        public void getusername()
        {
            adr = new OleDbDataAdapter("select user_name from Login where user_name is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbuser.DataSource = dt;
            cmbuser.DisplayMember = "user_name";
            cmbuser.ValueMember = "user_name";
        }



        private void button1_Click(object sender, EventArgs e)
        {


        }
        private void year()
        {
            adr = new OleDbDataAdapter("select distinct aca_year from admission_confirmed ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbyear.DataSource = dt;
            cmbyear.DisplayMember = "aca_year";
            cmbyear.ValueMember = "aca_year";

        }
        public void showcancelledstudent()
        {

            if (cmbyear.Text == "")
            {
                MessageBox.Show("Select  academic year");
                return;
            }
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            adr = new OleDbDataAdapter("select r.roll_no,sem.sem_id ,s.stud_name,c.course_name,sem.sem,can.cancel_date,can.reason,can.aca_year,can.user_name,can.refund_amount,can.refund_status,can.fee_paid from ((((Admission_cancel can inner join  student s on can.stud_id=s.stud_id)inner join course c on can.course_id=c.course_id)inner join semester sem on can.sem_id=sem.sem_id)inner join rNo_creation r on can.sr_no=r.sr_no) where can.aca_year='" + cmbyear.Text + "'", con);
            dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt; label12.Text = dt.Rows.Count.ToString(); label12.Visible = true; dataGridView1.Columns["sem_id"].Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                cmbstuname.Text = row.Cells["stud_name"].Value.ToString();

                cmbsem.Text = row.Cells["sem"].Value.ToString();

                cmbCourse.Text = row.Cells["course_name"].Value.ToString();

                if (row.Cells["fee_paid"].Value != null)
                {
                    txtfee.Text = row.Cells["fee_paid"].Value.ToString();
                }

                cmbrno.Text = row.Cells["roll_no"].Value.ToString();

                cmbrefund.Text = row.Cells["refund_status"].Value.ToString();
                rtxtreason.Text = row.Cells["reason"].Value.ToString();
                txtamt.Text = row.Cells["refund_amount"].Value.ToString();

                dtpcdate.Text = row.Cells["cancel_date"].Value.ToString();

                cmbuser.Text = row.Cells["user_name"].Value.ToString();

                cmbyear.Text = row.Cells["aca_year"].Value.ToString();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dtpcdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void cmbrno_SelectedIndexChanged(object sender, EventArgs e)
        {
            paidfee();
        }

        private void cmbstudname_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtamt_Leave(object sender, EventArgs e)
        {






        }

        private void txtcancelid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbsem.Focus();
            }

        }

        private void cmbstudname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbCourse.Focus();
            }
        }

        private void cmbCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbrno.Focus();
            }
        }

        private void cmbrno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtreason.Focus();
            }
        }

        private void rtxtreason_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbrefund.Focus();
            }
        }

        private void cmbrefund_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtamt.Focus();
            }
        }

        private void txtamt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dtpcdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtfee.Focus();
            }
        }

        private void txtfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbuser.Focus();
            }
        }

        private void cmbuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button5.Focus();
            }
            else
                MessageBox.Show("record not found");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            showcancelledstudent();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            admitted();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                cmbCourse.Text = row.Cells["course_name"].Value.ToString();
                cmbstuname.Text = row.Cells["stud_name"].Value.ToString();
                cmbsem.Text = row.Cells["sem"].Value.ToString();
                cmbrno.SelectedValue = row.Cells["sr_no"].Value;
                txtfee.Text = row.Cells["fee_paid"].Value.ToString();
                cmbadmid.SelectedValue = row.Cells["adm_id"].Value;
                 cmbrno.Text = row.Cells["roll_no"].Value.ToString();
                cmbyear.Text = row.Cells["aca_year"].Value.ToString();
              
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (rtxtreason.Text == "")
            {
                MessageBox.Show("ENter the Reason For Cancellation");
                return;

            }
            else if (cmbsem.SelectedIndex == -1)
            {
                MessageBox.Show("enter Student name ");
                return;

            }
            else if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Choose the course ");
                return;

            }
            else if (cmbrno.SelectedIndex == -1)
            {
                MessageBox.Show("Enter Roll no of the student ");
                return;

            }
            else if (cmbrefund.SelectedIndex == -1)
            {
                MessageBox.Show("Please Enter Refund Status ");
                return;

            }
            else if (txtamt.Text == "")
            {

                MessageBox.Show("enter the amount refunded to the student");
                return;

            }

            else if (cmbuser.SelectedValue == null)
            {
                MessageBox.Show("Enter username please");
                return;

            }
            else
            {
                //DateTime admdate;

                string q = "select adm_date from admission_confirmed where adm_id=" + cmbadmid.SelectedValue;
                OleDbCommand cmd2 = new OleDbCommand(q, con);

                object r = cmd2.ExecuteScalar();

                if (r != DBNull.Value && r != null)
                {
                    DateTime admdate = Convert.ToDateTime(r);

                    DateTime lastDate = admdate.AddMonths(3);

                    if (dtpcdate.Value.Date > lastDate.Date)
                    {
                        MessageBox.Show("Admission cannot be cancelled after 3 months");
                        return;
                    }
                }



                cmd = new OleDbCommand("update RNO_Creation set  status=?  where sr_no=?", con);
                cmd.Parameters.AddWithValue("?", "Inactive");
                cmd.Parameters.AddWithValue("?", cmbrno.SelectedValue);


                //MessageBox.Show("sr_no=" + cmbrno.SelectedValue);


                OleDbCommand cmd4 = new OleDbCommand("update admission_confirmed set status=?  where adm_id=?", con);
                cmd4.Parameters.AddWithValue("?", "Inactive");
                cmd4.Parameters.AddWithValue("?", Convert.ToInt32(cmbadmid.SelectedValue));




                string q1 = "insert into admission_cancel (aca_year,reason,stud_id,course_id,sem_id,sr_no,refund_status,refund_amount,cancel_date,fee_paid,user_name) values('" + cmbyear.Text + "','" + rtxtreason.Text + "'," + cmbstuname.SelectedValue + "," + cmbCourse.SelectedValue + "," + cmbsem.SelectedValue + "," + cmbrno.SelectedValue + ",'" + cmbrefund.Text + "'," + txtamt.Text + ",#" + dtpcdate.Value.ToString("MM/dd/yyyy") + "#," + txtfee.Text + ",'" + cmbuser.Text + "')";
                OleDbCommand cmd3 = new OleDbCommand(q1, con);
                cmd.ExecuteNonQuery(); cmd4.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                admitted();
                showcancelledstudent();
                getcount();
                MessageBox.Show("Admission deleted successfully");
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtamt_TextChanged(object sender, EventArgs e)
        {
            decimal feepaid = 0;
            if (!string.IsNullOrEmpty(txtfee.Text))
            {

                 feepaid = Convert.ToDecimal(txtfee.Text);
            }
            decimal refund = feepaid * 0.5m;
            int stu = Convert.ToInt32(cmbsem.SelectedValue);


            txtamt.Text = refund.ToString();

            dtpcdate.Focus();
        }

        private void txtfee_TextChanged(object sender, EventArgs e)
        {


            decimal feepaid = 0;
            if (!string.IsNullOrEmpty(txtfee.Text))
            {

                feepaid = Convert.ToDecimal(txtfee.Text);
            } decimal refund = feepaid * 0.5m;
            int stu = Convert.ToInt32(cmbsem.SelectedValue);


            txtamt.Text = refund.ToString();

            dtpcdate.Focus();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmbsem.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            txtfee.Text = ""; cmbstuname.Text = ""; rtxtreason.Text = ""; cmbrefund.Text = ""; txtamt.Text = "";
            cmbyear.Text = ""; cmbrno.SelectedIndex = -1;
            cmbuser.SelectedIndex = -1;
        }
    }
}
