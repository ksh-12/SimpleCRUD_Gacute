namespace SimpleCRUD_Gacute
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
            panel1 = new Panel();
            lblTitle = new Label();
            dgvStudents = new DataGridView();
            txtStudentId = new TextBox();
            lblStudentId = new Label();
            btnInsert = new Button();
            panel2 = new Panel();
            btnDisplay = new Button();
            btnExit = new Button();
            btnDelete = new Button();
            btnRead = new Button();
            btnUpdate = new Button();
            btnSearch = new Button();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblYearLevel = new Label();
            txtYearLevel = new TextBox();
            cmbCourse = new ComboBox();
            cmbStatus = new ComboBox();
            lblCourse = new Label();
            lblStatus = new Label();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaGreen;
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1759, 98);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(623, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(505, 49);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Students Information System";
            // 
            // dgvStudents
            // 
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(793, 255);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.Size = new Size(917, 437);
            dgvStudents.TabIndex = 3;
            dgvStudents.CellClick += dgvStudents_CellClick;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            dgvStudents.KeyDown += dgvStudents_KeyDown;
            // 
            // txtStudentId
            // 
            txtStudentId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStudentId.Location = new Point(322, 203);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(388, 39);
            txtStudentId.TabIndex = 5;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentId.Location = new Point(322, 171);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(117, 29);
            lblStudentId.TabIndex = 6;
            lblStudentId.Text = "Student ID";
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.Honeydew;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnInsert.Location = new Point(0, 116);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(271, 45);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Honeydew;
            panel2.Controls.Add(btnDisplay);
            panel2.Controls.Add(btnExit);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnRead);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(btnInsert);
            panel2.Location = new Point(0, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 683);
            panel2.TabIndex = 8;
            // 
            // btnDisplay
            // 
            btnDisplay.BackColor = Color.Honeydew;
            btnDisplay.FlatStyle = FlatStyle.Flat;
            btnDisplay.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnDisplay.Location = new Point(0, 40);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(271, 45);
            btnDisplay.TabIndex = 22;
            btnDisplay.Text = "Display All";
            btnDisplay.UseVisualStyleBackColor = false;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnExit.Location = new Point(61, 485);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(139, 45);
            btnExit.TabIndex = 11;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Honeydew;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnDelete.Location = new Point(0, 344);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(271, 45);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRead
            // 
            btnRead.BackColor = Color.Honeydew;
            btnRead.FlatStyle = FlatStyle.Flat;
            btnRead.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnRead.Location = new Point(0, 268);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(271, 45);
            btnRead.TabIndex = 9;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = false;
            btnRead.Click += btnRead_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Honeydew;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(0, 193);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(271, 45);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.MediumSeaGreen;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(1593, 167);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(117, 45);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFullName.Location = new Point(322, 271);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(113, 29);
            lblFullName.TabIndex = 14;
            lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(322, 303);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(388, 39);
            txtFullName.TabIndex = 13;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYearLevel.Location = new Point(322, 373);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(111, 29);
            lblYearLevel.TabIndex = 16;
            lblYearLevel.Text = "Year Level";
            // 
            // txtYearLevel
            // 
            txtYearLevel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtYearLevel.Location = new Point(322, 405);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.Size = new Size(388, 39);
            txtYearLevel.TabIndex = 15;
            // 
            // cmbCourse
            // 
            cmbCourse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Items.AddRange(new object[] { "BS Hospitality Management (BSHM)", "BS Tourism Management (BSTM)", "Bachelor of Elementary Education (BEEd)", "Bachelor of Secondary Education (BSEd)", "BS Information Technology (BSIT)", "BS Computer Engineering (BSCpE)", "BS Accountancy (BSA)", "BS Entrepreneurship (BSEntrep)" });
            cmbCourse.Location = new Point(322, 506);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(392, 40);
            cmbCourse.TabIndex = 17;
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "enrolled", "unenrolled", "incomplete", "drop" });
            cmbStatus.Location = new Point(322, 603);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(388, 40);
            cmbStatus.TabIndex = 18;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCourse.Location = new Point(322, 474);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(173, 29);
            lblCourse.TabIndex = 19;
            lblCourse.Text = "Course/Program";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(322, 571);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(74, 29);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Status";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(808, 169);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(757, 39);
            txtSearch.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1753, 776);
            Controls.Add(txtSearch);
            Controls.Add(lblStatus);
            Controls.Add(lblCourse);
            Controls.Add(cmbStatus);
            Controls.Add(cmbCourse);
            Controls.Add(lblYearLevel);
            Controls.Add(txtYearLevel);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(btnSearch);
            Controls.Add(panel2);
            Controls.Add(lblStudentId);
            Controls.Add(txtStudentId);
            Controls.Add(dgvStudents);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private DataGridView dgvStudents;
        private TextBox txtStudentId;
        private Label lblStudentId;
        private Button btnInsert;
        private Panel panel2;
        private Button btnExit;
        private Button btnDelete;
        private Button btnRead;
        private Button btnUpdate;
        private Button btnSearch;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblYearLevel;
        private TextBox txtYearLevel;
        private ComboBox cmbCourse;
        private ComboBox cmbStatus;
        private Label lblCourse;
        private Label lblStatus;
        private TextBox txtSearch;
        private Button btnDisplay;
    }
}