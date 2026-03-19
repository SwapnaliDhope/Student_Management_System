using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
namespace SMS_PROJECT
{
    public partial class frmRESULT : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");

        OleDbCommand cmd;
        OleDbDataReader rdr, rdr2;
        OleDbDataAdapter adr;
        DataTable dt;

        public frmRESULT()
        {
            InitializeComponent();
        }

        private void frmRESULT_Load(object sender, EventArgs e)
        {
            con.Open();

            loadcourse();
            year();
            dataGridView1.Visible = true;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            cmbcourse.SelectedIndex = -1;

        }

        private void year()
        {
            for (int year = 2025; year <= 2040; year++)
            {
                cmbyear.Items.Add(year);
            }
        }
        private void loadcourse()
        {
            adr = new OleDbDataAdapter("select course_id,course_name from course where status=true", con);

            dt = new DataTable();
            adr.Fill(dt);
            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "course_name";
            cmbcourse.ValueMember = "course_id";
        }
        private void sem()
        {
            if (cmbcourse.SelectedIndex == -1)
                return;

            adr = new OleDbDataAdapter("SELECT sem_id, sem FROM semester WHERE course_id=? AND status=true", con);

            adr.SelectCommand.Parameters.AddWithValue("?", cmbcourse.SelectedValue);

            dt = new DataTable();
            adr.Fill(dt);

            cmbsem.DataSource = dt;
            cmbsem.DisplayMember = "sem";
            cmbsem.ValueMember = "sem_id";
        }
        private void showroll()
        {
            
            adr = new OleDbDataAdapter("select sr_no, roll_no from RNO_Creation where course_id=" + cmbcourse.SelectedValue + " and sem_id=" + cmbsem.SelectedValue + " and acayear='" + cmbyear.Text + "' and status='Active'", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "roll_no";
            comboBox1.ValueMember = "sr_no";

            
        }

        private void exam()
        {
            //int cid = Convert.ToInt32(cmbcourse.SelectedIndex);
            adr = new OleDbDataAdapter("select exam_name,min(exam_sc_id) as exam_sc_id from Exam_schedule where status=true and course_id=" + cmbcourse.SelectedValue + " and exam_name<>'' group by exam_name ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbexam.DataSource = dt;
            cmbexam.DisplayMember = "exam_name";
            cmbexam.ValueMember = "exam_sc_id";
        }
        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcourse.SelectedIndex == -1 || cmbcourse.SelectedValue is DataRowView)
                return;

            sem(); exam(); examtype(); showroll();
        }
        private void examtype()
        {
            //int cid = Convert.ToInt32(cmbcourse.SelectedIndex);
            adr = new OleDbDataAdapter("select exam_id,exam_type from ExamMaster where status=true  and exam_type<>'' group by exam_type,exam_id ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "exam_type";
            comboBox2.ValueMember = "exam_id";
        }
        private void cmbsem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcourse.SelectedValue == null || cmbsem.SelectedValue == null)
                return;

            if (cmbcourse.SelectedValue is DataRowView || cmbsem.SelectedValue is DataRowView)
                return;

            showroll();

        }

        private void cmbroll_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {


        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select roll no first");
                return;
            }
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            adr = new OleDbDataAdapter(
"SELECT   rr.roll_no,s.stud_name, SUM(m.total) AS MarksObtained, r.out_of, r.percentage, r.grade, r.result_status ,r.aca_year , r.sr_no,c.course_name, ee.exam_name,e.exam_type, sem.sem " +
" FROM (((((((Result r " +
"INNER JOIN RNO_Creation rr ON r.sr_no = rr.sr_no) " +
"INNER JOIN course c ON r.course_id = c.course_id) " +
"INNER JOIN semester sem ON r.sem_id = sem.sem_id) " +
"INNER JOIN Exam_schedule ee ON r.exam_sc_id = ee.exam_sc_id) " +
"INNER JOIN ExamMaster e ON r.exam_id = e.exam_id) " +
"INNER JOIN student s ON rr.stud_id = s.stud_id) " +
"INNER JOIN marks m ON r.sr_no = m.sr_no) " +
"WHERE r.course_id=? AND r.sem_id=? AND r.exam_sc_id=? and r.exam_id=? AND r.aca_year=? AND rr.status='Active' AND r.status=True and r.sr_no=? " +
"GROUP BY s.stud_name, c.course_name, rr.roll_no, ee.exam_name,e.exam_type ,sem.sem, r.percentage, r.out_of, r.grade, r.sr_no, r.result_status,r.aca_year,r.sr_no",
con);

            adr.SelectCommand.Parameters.AddWithValue("?", cmbcourse.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbsem.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbexam.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", comboBox2.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbyear.Text);
            adr.SelectCommand.Parameters.AddWithValue("?", comboBox1.SelectedValue);
            dt = new DataTable();
            adr.Fill(dt);

            dataGridView2.DataSource = dt;


            dataGridView2.Visible = true;
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.DefaultCellStyle.BackColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
          
        
        
        }
        

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void show()
        {
            if (cmbyear.SelectedIndex == -1 || cmbcourse.SelectedIndex == -1 || cmbsem.SelectedIndex == -1 || cmbexam.SelectedIndex == -1)
            {
                MessageBox.Show("Select academic year , course,exam name and exam type to see the result "); return;
            }
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            adr = new OleDbDataAdapter(
"SELECT   rr.roll_no,s.stud_name, SUM(m.total) AS MarksObtained, r.out_of, r.percentage, r.grade, r.result_status ,r.aca_year , r.sr_no,c.course_name, ee.exam_name,e.exam_type, sem.sem " +
" FROM (((((((Result r " +
"INNER JOIN RNO_Creation rr ON r.sr_no = rr.sr_no) " +
"INNER JOIN course c ON r.course_id = c.course_id) " +
"INNER JOIN semester sem ON r.sem_id = sem.sem_id) " +
"INNER JOIN Exam_schedule ee ON r.exam_sc_id = ee.exam_sc_id) " +
"INNER JOIN ExamMaster e ON r.exam_id = e.exam_id) " +
"INNER JOIN student s ON rr.stud_id = s.stud_id) " +
"INNER JOIN marks m ON r.sr_no = m.sr_no) " +
"WHERE r.course_id=? AND r.sem_id=? AND r.exam_sc_id=? and r.exam_id=? AND r.aca_year=? AND rr.status='Active' AND r.status=True " +
"GROUP BY s.stud_name, c.course_name, rr.roll_no, ee.exam_name,e.exam_type ,sem.sem, r.percentage, r.out_of, r.grade, r.sr_no, r.result_status,r.aca_year",
con);

            adr.SelectCommand.Parameters.AddWithValue("?", cmbcourse.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbsem.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbexam.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", comboBox2.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbyear.Text);

            dt = new DataTable();
            adr.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["sr_no"].Visible = false;
            dataGridView1.Columns["aca_year"].Visible = false;
            dataGridView1.Columns["course_name"].Visible = false;
            dataGridView1.Columns["exam_name"].Visible = false;
            dataGridView1.Columns["sem"].Visible = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {


            show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                cmbnaem.Text = row.Cells["stud_name"].Value.ToString();
                cmbcourse.Text = row.Cells["course_name"].Value.ToString();
                cmbyear.Text = row.Cells["aca_year"].Value.ToString();
                cmbper.Text = row.Cells["percentage"].Value.ToString();
                cmbtotal.Text = row.Cells["MarksObtained"].Value.ToString();
                cmbgrade.Text = row.Cells["grade"].Value.ToString();
                cmbsatus.Text = row.Cells["result_status"].Value.ToString();
                cmbsem.Text = row.Cells["sem"].Value.ToString();
                cmbexam.Text = row.Cells["exam_name"].Value.ToString();
                //label12.Text = row.Cells["roll_no"].Value.ToString();
                //label13.Text = row.Cells["sr_no"].Value.ToString();
                //comboBox1.Text = row.Cells["roll_no"].Value.ToString();
            }
            //comboBox1.Visible = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dt.Rows.Count > 0)
            {
                cmbnaem.Text = dt.Rows[0]["stud_name"].ToString();
                //comboBox1.Text = dt.Rows[0]["roll_no"].ToString();
                cmbtotal.Text = dt.Rows[0]["MarksObtained"].ToString();
                //cmbtotal.Text = dt.Rows[0]["out_of"].ToString();
                cmbper.Text = dt.Rows[0]["percentage"].ToString();
                cmbgrade.Text = dt.Rows[0]["grade"].ToString();
                cmbsatus.Text = dt.Rows[0]["result_status"].ToString();
            }
        }


        private void cmbexam_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


    }
}