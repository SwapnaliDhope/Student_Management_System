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
    public partial class marksfill : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        bool editmode = false;
        public marksfill()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void marksfill_Load(object sender, EventArgs e)
        {
            con.Open(); getcourse(); showyearadmitted();
            cmbename.DataSource = null;
            cmbename.Items.Clear();

            if (cmbcourse.SelectedIndex == -1 || cmbcourse.SelectedValue is DataRowView) return;

            sem(); exam(); sub(); examtype();
        }

        public void showyearadmitted()
        {
            adr = new OleDbDataAdapter("select distinct(Aca_Year) from Admission_confirmed where aca_year is not null", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbyear.DataSource = dt;
            cmbyear.DisplayMember = "Aca_Year";
            cmbyear.ValueMember = "Aca_Year";
        }

        private void exam()
        {
            if (cmbcourse.SelectedValue == null || cmbcourse.SelectedValue is DataRowView) return;
            //int cid = Convert.ToInt32(cmbcourse.SelectedIndex);
            adr = new OleDbDataAdapter("select exam_name,exam_sc_id from Exam_schedule where course_id=" + cmbcourse.SelectedValue + "               ", con);

            //adr = new OleDbDataAdapter("select exam_name,min(exam_sc_id) as exam_sc_id from Exam_schedule where status=true and course_id=" + cmbcourse.SelectedValue + " and exam_name<>'' group by exam_name ", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbename.DataSource = dt;
            cmbename.DisplayMember = "exam_name";
            cmbename.ValueMember = "exam_sc_id";
        }
        private void examtype()
        {
            //int cid = Convert.ToInt32(cmbcourse.SelectedIndex);
            adr = new OleDbDataAdapter("select exam_id,exam_type from ExamMaster where status=true  and exam_type<>'' group by exam_type,exam_id ", con);
            dt = new DataTable();
            adr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "exam_type";
            comboBox1.ValueMember = "exam_id";
        }

        private void cmbsub_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void sub()
        {
            int cid = Convert.ToInt32(cmbcourse.SelectedValue);
            adr = new OleDbDataAdapter("Select sub_id,sub_name from subject where course_id=" + cid + "", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsub.DataSource = dt;
            cmbsub.DisplayMember = "sub_name";
            cmbsub.ValueMember = "sub_id";
        }
        private void sem()
        {
            adr = new OleDbDataAdapter("Select sem_id,sem from semester where  course_id=" + cmbcourse.SelectedValue + " and status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsem.DataSource = dt;
            cmbsem.DisplayMember = "sem";
            cmbsem.ValueMember = "sem_id";
        }
        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbcourse.SelectedIndex == -1 || cmbcourse.SelectedValue is DataRowView) return;

            exam(); sub(); sem(); examtype();


        }
        public void getcourse()
        {

            adr = new OleDbDataAdapter("select  course_id,course_name from course where status=true", con);
            dt = new DataTable();
            adr.Fill(dt);
            DataRow row = dt.NewRow();

            cmbcourse.DataSource = dt;
            cmbcourse.DisplayMember = "course_name";
            cmbcourse.ValueMember = "course_id";
        }

        private void cmbsem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsem.SelectedIndex == -1 || cmbsem.SelectedValue is DataRowView) return;

            adr = new OleDbDataAdapter("select sub_id,sub_name from subject where course_id=? and sem_id=?", con);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbcourse.SelectedValue);
            adr.SelectCommand.Parameters.AddWithValue("?", cmbsem.SelectedValue);
            dt = new DataTable();
            adr.Fill(dt);
            cmbsub.DataSource = dt;
            cmbsub.DisplayMember = "sub_name";
            cmbsub.ValueMember = "sub_id";

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editmode) return;
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Internal" || dataGridView1.Columns[e.ColumnIndex].Name == "External" || dataGridView1.Columns[e.ColumnIndex].Name == "Theory")
            {
                int row = e.RowIndex;
                int internalm = 0;
                int externalM = 0;
                int TheoryM = 0;
                int.TryParse(Convert.ToString(dataGridView1.Rows[row].Cells["Internal"].Value), out internalm);
                int.TryParse(Convert.ToString(dataGridView1.Rows[row].Cells["External"].Value), out externalM);
                int.TryParse(Convert.ToString(dataGridView1.Rows[row].Cells["Theory"].Value), out TheoryM);

                if (internalm > 20)
                {
                    MessageBox.Show("Internal marks cannot be greater then 20");
                    dataGridView1.Rows[row].Cells["Internal"].Value = "";
                    return;
                } if (externalM > 30)
                {
                    MessageBox.Show("Exaternal marks cannot be greater then 30");
                    dataGridView1.Rows[row].Cells["External"].Value = "";
                    return;
                } if (TheoryM > 50)
                {
                    MessageBox.Show("Theory marks cannot be greater then 50");
                    dataGridView1.Rows[row].Cells["Theory"].Value = "";
                    return;
                }




                dataGridView1.Rows[row].Cells["Total"].Value = internalm + externalM + TheoryM;


                int total = internalm + externalM + TheoryM;
                if (total > 100)
                {
                    MessageBox.Show("Total marks cannot exceed 100");
                    dataGridView1.Rows[row].Cells["Total"].Value = "";
                    return;
                }

                dataGridView1.Rows[row].Cells["Total"].Value = total;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                OleDbCommand cmd3 = new OleDbCommand(
                "select count(*) from marks where sr_no=? and sub_id=? and exam_id=? and exam_sc_id=?", con);
                if (row.Cells["sr_no"].Value == null) continue;
                cmd3.Parameters.AddWithValue("?", row.Cells["sr_no"].Value);
                cmd3.Parameters.AddWithValue("?", cmbsub.SelectedValue);
                cmd3.Parameters.AddWithValue("?", comboBox1.SelectedValue);
                cmd3.Parameters.AddWithValue("?", cmbename.SelectedValue);

                int count = Convert.ToInt32(cmd3.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Marks already entered for this subject");
                    return;
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Internal"].Value != null)
                {
                    cmd = new OleDbCommand("INSERT INTO marks (sr_no, exam_id,exam_sc_id,sub_id, internal_M, external_M, theory, total) VALUES (?,?, ?, ?, ?, ?, ?, ?)", con);

                    cmd.Parameters.AddWithValue("?", row.Cells["sr_no"].Value);
                    //cmd.Parameters.AddWithValue("?", row.Cells["sr_no"].Value);
                    cmd.Parameters.AddWithValue("?", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("?", cmbename.SelectedValue);

                    cmd.Parameters.AddWithValue("?", cmbsub.SelectedValue);

                    cmd.Parameters.AddWithValue("?", row.Cells["Internal"].Value);
                    cmd.Parameters.AddWithValue("?", row.Cells["External"].Value);
                    cmd.Parameters.AddWithValue("?", row.Cells["Theory"].Value);
                    cmd.Parameters.AddWithValue("?", row.Cells["Total"].Value);

                    cmd.ExecuteNonQuery();
                }

            } MessageBox.Show("Marks Saved Successfully");
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            if (cmbcourse.SelectedIndex == -1)
            {
                MessageBox.Show("select course");
                return; cmbcourse.Focus();
            }
            else if (cmbsem.SelectedIndex == -1)
            {
                MessageBox.Show("select semester");
                return; cmbcourse.Focus();
            }
            else if (cmbsub.SelectedIndex == -1)
            {
                MessageBox.Show("select subject");
                return; cmbcourse.Focus();
            }
            else
            {
                adr = new OleDbDataAdapter("select r.sr_no,s.stud_id ,r.roll_no,s.stud_name from RNO_Creation r inner join student s on r.stud_id=s.stud_id where r.course_id=" + cmbcourse.SelectedValue + " and r.sem_id=" + cmbsem.SelectedValue + " and r.status='" + "Active" + "' and r.acayear='" + cmbyear.Text + "'", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dt;
                if (!dataGridView1.Columns.Contains("Internal"))
                {
                    dataGridView1.Columns.Add("Internal", "Internal marks");
                    dataGridView1.Columns.Add("External", "External marks");
                    dataGridView1.Columns.Add("Theory", "Theory marks");
                    dataGridView1.Columns.Add("Total", "Total marks");
                    //dataGridView1.Columns.Add("percentage", "Percentage");
                }
                dataGridView1.Columns["stud_id"].Visible = false;
                dataGridView1.Columns["sr_no"].Visible = false;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmbyear.SelectedIndex == -1 || cmbcourse.SelectedIndex == -1 || cmbsem.SelectedIndex == -1 || comboBox1.SelectedIndex == -1 || cmbename.SelectedIndex == -1)
            {
                MessageBox.Show("select course, acayear,exam name ,exam type and semester to view the result");
                return;
            }




            dataGridView1.Visible = false;
            dataGridView2.Visible = true;

            adr = new OleDbDataAdapter("select r.sr_no,r.roll_no,s.stud_name,sum(m.total) as Total_Marks, sum(iif(m.total < 40,1,0)) as failcount from  (marks m inner join RNO_Creation r on m.sr_no=r.sr_no)inner join student s on r.stud_id=s.stud_id where  r.course_id=" + cmbcourse.SelectedValue + " and r.sem_id=" + cmbsem.SelectedValue + " and m.exam_sc_id=" + cmbename.SelectedValue + " and acayear='" + cmbyear.Text + "' and m.exam_id=" + comboBox1.SelectedValue + " group by r.sr_no, r.roll_no,s.stud_name", con);
            dt = new DataTable();
            adr.Fill(dt);

            OleDbCommand cmd2 = new OleDbCommand("select count(*) from subject  where course_id=" + cmbcourse.SelectedValue + " and sem_id=" + cmbsem.SelectedValue + " and aca_year='" + cmbyear.Text + "' and status='Active'", con);
            int sub = Convert.ToInt32(cmd2.ExecuteScalar());

            foreach (DataRow dr in dt.Rows)
            {
                OleDbCommand cmd3 = new OleDbCommand("select count(*) from(select distinct sub_id from marks where sr_no=? )", con);
                cmd3.Parameters.AddWithValue("?", dr["sr_no"]);

                //cmd3.Parameters.AddWithValue("?", cmbcourse.SelectedValue);
                //cmd3.Parameters.AddWithValue("?", cmbsem.SelectedValue);
                int filled = Convert.ToInt32(cmd3.ExecuteScalar());

                if (filled < sub)
                {
                    MessageBox.Show(" all subject marks are not filled  for roll no:" + dr["roll_no"]);
                    return;
                }
            }
            if (!dt.Columns.Contains("Percentage"))
                dt.Columns.Add("Percentage", typeof(double));
            if (!dt.Columns.Contains("grade"))
                dt.Columns.Add("grade", typeof(string));
            if (!dt.Columns.Contains("Result"))
                dt.Columns.Add("Result", typeof(string));

            dataGridView2.DataSource = dt;
            OleDbCommand cmdsub = new OleDbCommand("select count(*) from subject where course_id=" + cmbcourse.SelectedValue + " and sem_id=" + cmbsem.SelectedValue, con);

            int subcount = Convert.ToInt32(cmdsub.ExecuteScalar());
            int overall = subcount * 100;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Total_Marks"] != DBNull.Value)
                {
                    int Total = Convert.ToInt32(row["Total_Marks"]);
                    int failcount = Convert.ToInt32(row["failcount"]);
                    string grade;
                    double per = Math.Round((Total * 100.0) / overall, 2);
                    row["Percentage"] = per;
                    if (failcount > 0)
                    {
                        row["Result"] = "FAIL"; grade = "FAIL";
                    }
                    else
                    {
                        row["Result"] = "PASS";
                        if (per >= 90) grade = "O";
                        else if (per >= 85) grade = "A+";
                        else if (per >= 70)
                            grade = "A";
                        else if (per >= 60)
                            grade = "B+";
                        else if (per >= 50)
                            grade = "B";
                        else if (per >= 40)
                            grade = "C";
                        else grade = "FAIL";
                    }
                    row["grade"] = grade;
                    dataGridView2.Columns["sr_no"].Visible = false;
                }
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
         
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No result data to save.");
                return;
            }


            OleDbCommand cmdsub = new OleDbCommand("select count(*) from subject where course_id=" + cmbcourse.SelectedValue + " and sem_id=" + cmbsem.SelectedValue, con);

            int subcount = Convert.ToInt32(cmdsub.ExecuteScalar());
            int overall = subcount * 100;

            foreach (DataRow row in dt.Rows)
            {
                OleDbCommand check = new OleDbCommand(
"select count(*) from Result where sr_no=? and exam_id=? and exam_sc_id=? and sem_id=? and aca_year=?", con);

                check.Parameters.AddWithValue("?", row["sr_no"]);
                check.Parameters.AddWithValue("?", comboBox1.SelectedValue);
                check.Parameters.AddWithValue("?", cmbename.SelectedValue);
                check.Parameters.AddWithValue("?", cmbsem.SelectedValue);
                check.Parameters.AddWithValue("?", cmbyear.Text);

                int count = Convert.ToInt32(check.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Result already stored for Roll No: " + row["sr_no"]);
                    return;
                }
                if (row["Total_Marks"] == DBNull.Value)
                    continue;

                int total = Convert.ToInt32(row["Total_Marks"]);
                int failcount = Convert.ToInt32(row["failcount"]);

                double per = (total * 100.0) / overall;
                // string result = failcount > 0 ? "FAIL" : "PASS";

                string grade;
                if (failcount > 0)
                {
                    row["Result"] = "FAIL"; grade = "FAIL";
                }
                else
                {
                    row["Result"] = "PASS";
                    if (per >= 85) grade = "O";
                    else if (per >= 70)
                        grade = "A";
                    else if (per >= 60)
                        grade = "B";
                    else if (per >= 50)
                        grade = "C";
                    else if (per >= 40)
                        grade = "D";
                    else grade = "FAIL";
                }



                OleDbCommand insert = new OleDbCommand(
                    "INSERT INTO Result(course_id,sr_no,exam_id,exam_sc_id,sem_id,percentage,out_of,grade,result_status,aca_year) VALUES (?,?,?,?,?,?,?,?,?,?)",
                    con);

                insert.Parameters.AddWithValue("?", cmbcourse.SelectedValue);
                insert.Parameters.AddWithValue("?", row["sr_no"]);
                insert.Parameters.AddWithValue("?", comboBox1.SelectedValue);
                insert.Parameters.AddWithValue("?", cmbename.SelectedValue);
                insert.Parameters.AddWithValue("?", cmbsem.SelectedValue);
                insert.Parameters.AddWithValue("?", per);
                insert.Parameters.AddWithValue("?", overall);
                insert.Parameters.AddWithValue("?", grade);
                insert.Parameters.AddWithValue("?", row["Result"]);
                insert.Parameters.AddWithValue("?", cmbyear.Text);


                insert.ExecuteNonQuery();
            }

            MessageBox.Show("Result stored successfully !");

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            cmbyear.Text = "";
            cmbcourse.SelectedIndex = -1;
            cmbsem.SelectedIndex = -1;
            cmbsub.SelectedIndex = -1;
            cmbename.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           

          
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if (row.IsNewRow) continue;

        int internalM = Convert.ToInt32(row.Cells["Internal"].Value);
        int externalM = Convert.ToInt32(row.Cells["External"].Value);
        int theoryM = Convert.ToInt32(row.Cells["Theory"].Value);

        if (internalM > 20 || externalM >30 || theoryM > 50)
        {
            MessageBox.Show("Invalid marks found. Please correct them.internal marks should be less than 20 external marks should be less than 30 and theory marks cant exceed 50");
            return;
        }

        int total = internalM + externalM + theoryM;

        OleDbCommand cmd = new OleDbCommand(
        "UPDATE marks SET internal_M=?, external_M=?, theory=?, total=? WHERE sr_no=? AND sub_id=? AND exam_id=? AND exam_sc_id=?", con);

        cmd.Parameters.AddWithValue("?", internalM);
        cmd.Parameters.AddWithValue("?", externalM);
        cmd.Parameters.AddWithValue("?", theoryM);
        cmd.Parameters.AddWithValue("?", total);

        cmd.Parameters.AddWithValue("?", row.Cells["sr_no"].Value);
        cmd.Parameters.AddWithValue("?", cmbsub.SelectedValue);
        cmd.Parameters.AddWithValue("?", comboBox1.SelectedValue);
        cmd.Parameters.AddWithValue("?", cmbename.SelectedValue);

        cmd.ExecuteNonQuery();
    }

    MessageBox.Show("Marks Updated Successfully");

    calculateResult();

            

           

        }
        private void calculateResult()
        {
            OleDbDataAdapter adr = new OleDbDataAdapter(
            "select sr_no, sum(total) as TotalMarks, sum(iif(total<40,1,0)) as failcount from marks group by sr_no", con);

            DataTable dtr = new DataTable();
            adr.Fill(dtr);

            foreach (DataRow row in dtr.Rows)
            {
                int total = Convert.ToInt32(row["TotalMarks"]);
                int failcount = Convert.ToInt32(row["failcount"]);

                // subject count
                OleDbCommand cmdsub = new OleDbCommand(
                "select count(*) from subject where course_id=" + cmbcourse.SelectedValue +
                " and sem_id=" + cmbsem.SelectedValue, con);

                int subcount = Convert.ToInt32(cmdsub.ExecuteScalar());
                int overall = subcount * 100;

                double per = Math.Round((total * 100.0) / overall, 2);

                string grade;
                string status;

                if (failcount > 0)
                {
                    status = "FAIL";
                    grade = "FAIL";
                }
                else
                {
                    status = "PASS";

                    if (per >= 85) grade = "O";
                    else if (per >= 70) grade = "A";
                    else if (per >= 60) grade = "B";
                    else if (per >= 50) grade = "C";
                    else if (per >= 40) grade = "D";
                    else grade = "FAIL";
                }

                OleDbCommand cmd = new OleDbCommand(
                "UPDATE Result SET percentage=?,grade=?,result_status=? WHERE sr_no=?", con);

                cmd.Parameters.AddWithValue("?", per);
                cmd.Parameters.AddWithValue("?", grade);
                cmd.Parameters.AddWithValue("?", status);
                cmd.Parameters.AddWithValue("?", row["sr_no"]);

                cmd.ExecuteNonQuery();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            editmode = true;
          
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;

            adr = new OleDbDataAdapter(
 "SELECT m.sr_no, r.roll_no, s.stud_name, " +
 "m.internal_M AS [Internal], " +
 "m.external_M AS [External], " +
 "m.theory AS [Theory], " +
 "m.total AS [Total] " +
 "FROM ((marks m INNER JOIN RNO_Creation r ON m.sr_no = r.sr_no) " +
 "INNER JOIN student s ON r.stud_id = s.stud_id) " +
 "WHERE r.course_id=" + cmbcourse.SelectedValue +
 " AND r.sem_id=" + cmbsem.SelectedValue +
 " AND m.sub_id=" + cmbsub.SelectedValue +
 " AND m.exam_id=" + comboBox1.SelectedValue +
 " AND m.exam_sc_id=" + cmbename.SelectedValue,
 con);
            dt = new DataTable();
            adr.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
