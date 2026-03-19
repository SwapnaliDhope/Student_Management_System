namespace SMS_PROJECT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.studentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rdomale = new System.Windows.Forms.RadioButton();
            this.rdofemale = new System.Windows.Forms.RadioButton();
            this.dtpdob = new System.Windows.Forms.DateTimePicker();
            this.txtmono = new System.Windows.Forms.TextBox();
            this.txtadhar = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.cmbcaste = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rtxtadd = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCastechk = new System.Windows.Forms.ComboBox();
            this.rdoFemalechk = new System.Windows.Forms.RadioButton();
            this.rdoMalechk = new System.Windows.Forms.RadioButton();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.cmbex = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.cmbname = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 42);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(125, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "STUDENT REGISTRATION FORM";
            // 
            // studentBindingSource1
            // 
            this.studentBindingSource1.DataMember = "Student";
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "STUDENT NAME :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(108, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "GENDER :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(146, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "DOB :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(91, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "ADDRESS :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(104, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 22);
            this.label8.TabIndex = 6;
            this.label8.Text = "EMAIL ID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(413, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "CASTE :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(85, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 22);
            this.label9.TabIndex = 8;
            this.label9.Text = "ADHAR NO :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(80, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 22);
            this.label10.TabIndex = 9;
            this.label10.Text = "MOBILE NO :";
            // 
            // rdomale
            // 
            this.rdomale.AutoSize = true;
            this.rdomale.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdomale.Location = new System.Drawing.Point(284, 118);
            this.rdomale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdomale.Name = "rdomale";
            this.rdomale.Size = new System.Drawing.Size(87, 26);
            this.rdomale.TabIndex = 12;
            this.rdomale.Text = "MALE";
            this.rdomale.UseVisualStyleBackColor = true;
            this.rdomale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdomale_KeyPress);
            // 
            // rdofemale
            // 
            this.rdofemale.AutoSize = true;
            this.rdofemale.Checked = true;
            this.rdofemale.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdofemale.Location = new System.Drawing.Point(478, 114);
            this.rdofemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdofemale.Name = "rdofemale";
            this.rdofemale.Size = new System.Drawing.Size(112, 26);
            this.rdofemale.TabIndex = 13;
            this.rdofemale.TabStop = true;
            this.rdofemale.Text = "FEMALE";
            this.rdofemale.UseVisualStyleBackColor = true;
            this.rdofemale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdofemale_KeyPress);
            // 
            // dtpdob
            // 
            this.dtpdob.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdob.Location = new System.Drawing.Point(224, 146);
            this.dtpdob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpdob.Name = "dtpdob";
            this.dtpdob.Size = new System.Drawing.Size(163, 29);
            this.dtpdob.TabIndex = 2;
            this.dtpdob.ValueChanged += new System.EventHandler(this.dtpdob_ValueChanged);
            this.dtpdob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpdob_KeyPress);
            // 
            // txtmono
            // 
            this.txtmono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmono.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmono.Location = new System.Drawing.Point(267, 182);
            this.txtmono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtmono.MaxLength = 10;
            this.txtmono.Name = "txtmono";
            this.txtmono.Size = new System.Drawing.Size(120, 29);
            this.txtmono.TabIndex = 3;
            this.txtmono.Text = "9766749496";
            this.txtmono.TextChanged += new System.EventHandler(this.txtmono_TextChanged);
            this.txtmono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmono_KeyPress);
            this.txtmono.Leave += new System.EventHandler(this.txtmono_Leave);
            // 
            // txtadhar
            // 
            this.txtadhar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtadhar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadhar.Location = new System.Drawing.Point(224, 326);
            this.txtadhar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtadhar.MaxLength = 12;
            this.txtadhar.Name = "txtadhar";
            this.txtadhar.Size = new System.Drawing.Size(228, 29);
            this.txtadhar.TabIndex = 7;
            this.txtadhar.Enter += new System.EventHandler(this.txtadhar_Enter);
            this.txtadhar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtadhar_KeyDown);
            this.txtadhar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtadhar_KeyPress);
            this.txtadhar.Leave += new System.EventHandler(this.txtadhar_Leave);
            // 
            // txtemail
            // 
            this.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtemail.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtemail.Location = new System.Drawing.Point(224, 219);
            this.txtemail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(277, 29);
            this.txtemail.TabIndex = 4;
            this.txtemail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtemail_KeyPress);
            // 
            // cmbcaste
            // 
            this.cmbcaste.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcaste.FormattingEnabled = true;
            this.cmbcaste.Location = new System.Drawing.Point(507, 163);
            this.cmbcaste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcaste.Name = "cmbcaste";
            this.cmbcaste.Size = new System.Drawing.Size(147, 30);
            this.cmbcaste.TabIndex = 6;
            this.cmbcaste.SelectedIndexChanged += new System.EventHandler(this.cmbcaste_SelectedIndexChanged);
            this.cmbcaste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbcaste_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 647);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 51);
            this.panel2.TabIndex = 21;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Green;
            this.button5.Location = new System.Drawing.Point(11, 5);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 39);
            this.button5.TabIndex = 4;
            this.button5.Text = "&NEW";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button4.Location = new System.Drawing.Point(283, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 39);
            this.button4.TabIndex = 3;
            this.button4.Text = "&EDIT";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Blue;
            this.button3.Location = new System.Drawing.Point(552, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "E&XIT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(413, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "&DELETE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(149, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "&SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtxtadd
            // 
            this.rtxtadd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtadd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtadd.Location = new System.Drawing.Point(224, 256);
            this.rtxtadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtadd.Name = "rtxtadd";
            this.rtxtadd.Size = new System.Drawing.Size(429, 63);
            this.rtxtadd.TabIndex = 5;
            this.rtxtadd.Text = "";
            this.rtxtadd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtadd_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 410);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(671, 230);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtExt
            // 
            this.txtExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExt.Enabled = false;
            this.txtExt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExt.Location = new System.Drawing.Point(224, 182);
            this.txtExt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExt.MaxLength = 10;
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(43, 29);
            this.txtExt.TabIndex = 26;
            this.txtExt.Text = "+91";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbCastechk);
            this.groupBox2.Controls.Add(this.rdoFemalechk);
            this.groupBox2.Controls.Add(this.rdoMalechk);
            this.groupBox2.Controls.Add(this.rdoSearch);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Location = new System.Drawing.Point(7, 359);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(665, 49);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // cmbCastechk
            // 
            this.cmbCastechk.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCastechk.FormattingEnabled = true;
            this.cmbCastechk.Items.AddRange(new object[] {
            "General",
            "OBC",
            "SBC",
            "ST",
            "SC",
            "NT"});
            this.cmbCastechk.Location = new System.Drawing.Point(553, 15);
            this.cmbCastechk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCastechk.Name = "cmbCastechk";
            this.cmbCastechk.Size = new System.Drawing.Size(97, 30);
            this.cmbCastechk.TabIndex = 31;
            this.cmbCastechk.SelectedIndexChanged += new System.EventHandler(this.cmbCastechk_SelectedIndexChanged);
            // 
            // rdoFemalechk
            // 
            this.rdoFemalechk.AutoSize = true;
            this.rdoFemalechk.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFemalechk.Location = new System.Drawing.Point(448, 18);
            this.rdoFemalechk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoFemalechk.Name = "rdoFemalechk";
            this.rdoFemalechk.Size = new System.Drawing.Size(91, 26);
            this.rdoFemalechk.TabIndex = 36;
            this.rdoFemalechk.Text = "Female";
            this.rdoFemalechk.UseVisualStyleBackColor = true;
            this.rdoFemalechk.CheckedChanged += new System.EventHandler(this.rdoFemalechk_CheckedChanged);
            // 
            // rdoMalechk
            // 
            this.rdoMalechk.AutoSize = true;
            this.rdoMalechk.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMalechk.Location = new System.Drawing.Point(356, 18);
            this.rdoMalechk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoMalechk.Name = "rdoMalechk";
            this.rdoMalechk.Size = new System.Drawing.Size(73, 26);
            this.rdoMalechk.TabIndex = 35;
            this.rdoMalechk.Text = "Male";
            this.rdoMalechk.UseVisualStyleBackColor = true;
            this.rdoMalechk.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rdoSearch.Location = new System.Drawing.Point(13, 18);
            this.rdoSearch.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSearch.Name = "rdoSearch";
            this.rdoSearch.Size = new System.Drawing.Size(183, 26);
            this.rdoSearch.TabIndex = 34;
            this.rdoSearch.TabStop = true;
            this.rdoSearch.Text = "Search Stud.Name";
            this.rdoSearch.UseVisualStyleBackColor = true;
            this.rdoSearch.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(217, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.MaxLength = 12;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(126, 29);
            this.txtSearch.TabIndex = 32;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.GhostWhite;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.Location = new System.Drawing.Point(478, 329);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(177, 38);
            this.button6.TabIndex = 9;
            this.button6.Text = "&Refresh";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // cmbex
            // 
            this.cmbex.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbex.FormattingEnabled = true;
            this.cmbex.Items.AddRange(new object[] {
            "Gmail.com",
            "Yahoo.com",
            "hotmail.com",
            "outlook.com",
            "rediffmail.com",
            "zohomail.com",
            "email.com"});
            this.cmbex.Location = new System.Drawing.Point(507, 218);
            this.cmbex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbex.Name = "cmbex";
            this.cmbex.Size = new System.Drawing.Size(147, 30);
            this.cmbex.TabIndex = 31;
            this.cmbex.SelectedIndexChanged += new System.EventHandler(this.cmbex_SelectedIndexChanged);
            this.cmbex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbex_KeyPress);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Snow;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.Location = new System.Drawing.Point(569, 597);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 38);
            this.button7.TabIndex = 32;
            this.button7.Text = "CLEAR";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // cmbname
            // 
            this.cmbname.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbname.FormattingEnabled = true;
            this.cmbname.Location = new System.Drawing.Point(224, 74);
            this.cmbname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbname.Name = "cmbname";
            this.cmbname.Size = new System.Drawing.Size(429, 30);
            this.cmbname.TabIndex = 33;
            this.cmbname.SelectionChangeCommitted += new System.EventHandler(this.cmbname_SelectionChangeCommitted);
            this.cmbname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbname_KeyPress);
            this.cmbname.Leave += new System.EventHandler(this.cmbname_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(398, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 22);
            this.label12.TabIndex = 35;
            this.label12.Text = "COURSE :";
            // 
            // cmbCourse
            // 
            this.cmbCourse.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(506, 26);
            this.cmbCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(147, 30);
            this.cmbCourse.TabIndex = 34;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            this.cmbCourse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCourse_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(92, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 22);
            this.label13.TabIndex = 38;
            this.label13.Text = "ACA YEAR :";
            // 
            // cmbyear
            // 
            this.cmbyear.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbyear.FormattingEnabled = true;
            this.cmbyear.Location = new System.Drawing.Point(224, 30);
            this.cmbyear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(147, 30);
            this.cmbyear.TabIndex = 39;
            this.cmbyear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbyear_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cmbyear);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbCourse);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbname);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.cmbex);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtExt);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.rtxtadd);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.cmbcaste);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.txtadhar);
            this.groupBox1.Controls.Add(this.txtmono);
            this.groupBox1.Controls.Add(this.dtpdob);
            this.groupBox1.Controls.Add(this.rdofemale);
            this.groupBox1.Controls.Add(this.rdomale);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(680, 700);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Information";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 40;
            this.textBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 742);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        //private SMS_DatabaseDataSet sMS_DatabaseDataSet;
        private System.Windows.Forms.BindingSource studentBindingSource;
        //private SMS_DatabaseDataSetTableAdapters.StudentTableAdapter studentTableAdapter;
        //private SMS_DatabaseDataSet1 sMS_DatabaseDataSet1;
        private System.Windows.Forms.BindingSource studentBindingSource1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdomale;
        private System.Windows.Forms.RadioButton rdofemale;
        private System.Windows.Forms.DateTimePicker dtpdob;
        private System.Windows.Forms.TextBox txtmono;
        private System.Windows.Forms.TextBox txtadhar;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.ComboBox cmbcaste;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtxtadd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtExt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCastechk;
        private System.Windows.Forms.RadioButton rdoFemalechk;
        private System.Windows.Forms.RadioButton rdoMalechk;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cmbex;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox cmbname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbyear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        //private SMS_DatabaseDataSet1TableAdapters.StudentTableAdapter studentTableAdapter1;
    }
}

