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
    public partial class MDIParent1 : Form
    {OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMS_PROJECT\SMS_Database.accdb");
        OleDbCommand cmd = null;
        OleDbCommand cmd1 = null;
        OleDbDataReader rdr = null;
        OleDbDataAdapter adr = null;
        DataTable dt;
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }
        public string loggeduser
        {
           set
            {
                lblUser.Text=" User Name : "+ value+ " "+" | ";
             
            }
          
        }
        public string loggedusertype
        {
            set
            {
                lblUsertype.Text = "Logged in as : " + value +" "+" | ";

            }

        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = openFileDialog.FileName;
            //}
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void Class_Click(object sender, EventArgs e)
        {
            //frmCLASS_FORM c = new frmCLASS_FORM();
            //c.Show();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
           
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void admissionEnqueryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {
          DialogResult ans;
                ans = MessageBox.Show(" Do you want to reset your password", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

        private void admissionEnqueryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void admissionConfirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSTUDENT_ADMISSION_FORM eq = new frmSTUDENT_ADMISSION_FORM();
            eq.Show();
        }

        private void studentEnquryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptStudentEnquert rt = new rptStudentEnquert();
            rt.Show();
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDEPARTMENT_FORM dept = new frmDEPARTMENT_FORM();
            dept.Show();

        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCOURSE_FORM c = new frmCOURSE_FORM();
            c.Show();
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSUBJECT_FORM sub = new frmSUBJECT_FORM();
            sub.Show();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTEACHER_FORM t = new frmTEACHER_FORM();
            t.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLOGIN_FORM user = new frmLOGIN_FORM();
            user.Show();
        }

        private void newAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSTUDENT_ADMISSION_FORM adm = new frmSTUDENT_ADMISSION_FORM();
            adm.Show();
          
        }

        private void rollNOCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RollNoCreation r = new RollNoCreation();
            r.Show();
        }

        private void cancelAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmADMISSION_CANCEL admc = new frmADMISSION_CANCEL();
            admc.Show();
        }

        private void examToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    frmEXAM_FORM ef = new frmEXAM_FORM();
        //    ef.Show();
            exammaster em = new exammaster();
            em.Show();
        }

        private void examScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEXAM_SCHEDULE_FORM es = new frmEXAM_SCHEDULE_FORM();
            es.Show();

        }

        private void marksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marksfill mf = new marksfill();
            mf.Show();

        }
       

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRESULT r = new frmRESULT();
            r.Show();
           
        }

        private void feeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFEE_FORM f = new frmFEE_FORM();
            f.Show();

        }
        private void load()
        {
            //adr=new OleDbDataAdapter("select 
        }
        private void MDIParent1_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dataGridView1.Left = (this.ClientSize.Width - dataGridView1.Width) / 2;

            dataGridView1.Top = (this.ClientSize.Height - dataGridView1.Height) / 2;



        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void classwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void studentEnquiryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptStudentEnquert se = new rptStudentEnquert();
            se.Show();
        }

        private void admissionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptadmitedstudent sd = new rptadmitedstudent();
            sd.Show();
        }

        private void semesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmsemester sem = new Frmsemester();
            sem.Show();
        }

        private void examToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmEXAM_FORM e1 = new frmEXAM_FORM();
            //e1.Show();
            exammaster e2 = new exammaster();
            e2.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLOGIN_FORM l = new frmLOGIN_FORM();
            l.Show();
        }

        private void examinationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptexam re = new rptexam();
            re.Show();
        }

        private void feesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpt_fee rf = new rpt_fee();
            rf.Show();
                
        }

        private void courseWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void departmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptdeptinfo d = new rptdeptinfo();
            d.Show();
        }

        private void teachersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpt_Teacher t = new rpt_Teacher();
            t.Show();

        }

        private void subjectReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpt_subject s = new rpt_subject();
            s.Show();
        }

        private void resultReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptresult rr = new rptresult();
            rr.Show();
        }

        private void examTimeTableReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptexam e2 = new rptexam();
            e2.Show();
        }

        private void marksReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptresult r = new rptresult(); r.Show();
        }

        private void rollNumberReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpt_roll_no r = new rpt_roll_no();
               r.Show();

        }

        private void admissionCancelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           rptadmcancel ac=new rptadmcancel();
            ac.Show();
        }

        private void seeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == true)
            {
                dataGridView1.Visible = false;
                seeReportToolStripMenuItem.Text = "View Data";
            }
            else
            {
                string year = DateTime.Now.Year.ToString();
                adr = new OleDbDataAdapter("select s.stud_name,c.course_name,sem.sem,r.roll_no,s.gender,s.mobileNo,a.fee_paid,s.address,s.caste,s.adhar_no,s.DOB,a.adm_date,r.status from ((((RNO_Creation r inner join student s on r.stud_id=s.stud_id)inner join course c on r.course_id=c.course_Id)inner join semester sem on r.sem_id=sem.sem_id)inner join admission_confirmed a on r.adm_id=a.adm_id)", con);
                dt = new DataTable();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Visible = true;
                seeReportToolStripMenuItem.Text = "Hide Data";
            }
        }

        private void studentEnquaryDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 stu = new Form1();
            stu.Show();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    if (row.Cells["status"].Value.ToString() == "Inactive")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
       



    }
}
