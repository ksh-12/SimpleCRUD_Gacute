using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimpleCRUD_Gacute
{
    public partial class Form1 : Form
    {
        Students student = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvStudents.DataSource = student.GetAllStudents();
        }

        private bool ValidateInput()
        {
            //Check for empty fields
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtYearLevel.Text) ||
                string.IsNullOrWhiteSpace(cmbCourse.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("⚠️ Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Full Name: only letters and spaces
            if (!Regex.IsMatch(txtFullName.Text.Trim(), @"^[A-Za-z\s]+$"))
            {
                MessageBox.Show("Full Name must contain only letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Year Level: must be in the format "1st Year", "2nd Year", etc.
            if (!Regex.IsMatch(txtYearLevel.Text.Trim(), @"^(1st|2nd|3rd|4th|5th)\s+[Yy]ear$"))
            {
                MessageBox.Show("Year Level must be in this format: '1st Year', '2nd Year', '3rd Year', etc.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Student ID: must contain both letters and numbers
            if (!Regex.IsMatch(txtStudentId.Text.Trim(), @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$"))
            {
                MessageBox.Show("Student ID must contain both letters and numbers (e.g. STU101, 2025A, A123).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Auto-format fields
            txtStudentId.Text = txtStudentId.Text.Trim().ToUpper();
            txtFullName.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFullName.Text.Trim().ToLower());
            txtYearLevel.Text = txtYearLevel.Text.Trim();

            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                student.InsertStudent(txtStudentId.Text, txtFullName.Text, txtYearLevel.Text, cmbCourse.Text, cmbStatus.Text);
                MessageBox.Show("✅ Record inserted successfully!");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                //Check if a student row is selected
                if (dgvStudents.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "⚠️ Please select a student row to update from the table.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                //Get the original Student ID from the selected row (even if user changed the textbox)
                string originalStudentId = dgvStudents.SelectedRows[0].Cells["Student_ID"].Value.ToString();

                // Load current database record for comparison
                DataTable dt = student.SearchByStudentId(originalStudentId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "⚠️ Student not found in the database. Please reselect the record.",
                        "Update Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                DataRow oldData = dt.Rows[0];
                string oldId = oldData["Student_ID"].ToString();
                string oldName = oldData["FullName"].ToString();
                string oldYear = oldData["Year_Level"].ToString();
                string oldCourse = oldData["Course"].ToString();
                string oldStatus = oldData["Status"].ToString();

                // Compare old and new values
                bool hasChanged =
                    oldId != txtStudentId.Text.Trim() ||
                    oldName != txtFullName.Text.Trim() ||
                    oldYear != txtYearLevel.Text.Trim() ||
                    oldCourse != cmbCourse.Text.Trim() ||
                    oldStatus != cmbStatus.Text.Trim();

                if (!hasChanged)
                {
                    MessageBox.Show(
                        "⚠️ No changes detected. Please modify some fields before updating.",
                        "No Changes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                //Ask for confirmation
                DialogResult confirm = MessageBox.Show(
                    "⚠️ Are you sure you want to update this student’s record?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.No)
                    return;

                //Call update method that includes Student ID changes
                student.UpdateStudentAllFields(
                    originalStudentId, // old Student ID (for WHERE clause)
                    txtStudentId.Text.Trim(), // new Student ID
                    txtFullName.Text.Trim(),
                    txtYearLevel.Text.Trim(),
                    cmbCourse.Text.Trim(),
                    cmbStatus.Text.Trim()
                );

                MessageBox.Show(
                    "✅ Student record updated successfully!",
                    "Update Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Update Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("⚠️ Please select a Student ID to delete.");
                return;
            }

            if (MessageBox.Show("⚠️ Are you sure you want to delete this student?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    student.DeleteStudent(txtStudentId.Text);
                    MessageBox.Show("🗑️ Record deleted successfully!");
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "⚠️ Delete Error");
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dgvStudents.SelectedRows.Count == 0)
                {
                    MessageBox.Show("⚠️ Please select a student from the table first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Get the selected student row
                DataGridViewRow selectedRow = dgvStudents.SelectedRows[0];

                // Extract student data safely
                string studentId = selectedRow.Cells["Student_ID"].Value?.ToString() ?? "";
                string fullName = selectedRow.Cells["FullName"].Value?.ToString() ?? "";
                string yearLevel = selectedRow.Cells["Year_Level"].Value?.ToString() ?? "";
                string course = selectedRow.Cells["Course"].Value?.ToString() ?? "";
                string status = selectedRow.Cells["Status"].Value?.ToString() ?? "";

                //Build and display formatted info
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("📋 STUDENT INFORMATION");
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"🎓 Student ID: {studentId}");
                sb.AppendLine($"👤 Full Name:  {fullName}");
                sb.AppendLine($"📘 Year Level: {yearLevel}");
                sb.AppendLine($"💻 Course: {course}");
                sb.AppendLine($"📖 Status: {status}");
                sb.AppendLine("------------------------------------------------");

                MessageBox.Show(sb.ToString(), "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error displaying student info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            //Validate input
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("⚠️ Please enter a Student ID to search.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //Search by Student_ID only
                DataTable result = student.SearchByStudentId(keyword);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show($"❌ No student found with Student ID: {keyword}", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvStudents.DataSource = null; // clear grid if not found
                    return;
                }

                //Display result in DataGridView
                dgvStudents.DataSource = result;

                //Build message for single record
                DataRow row = result.Rows[0];
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("📋 STUDENT INFORMATION");
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"🎓 Student ID: {row["Student_ID"]}");
                sb.AppendLine($"👤 Full Name:  {row["FullName"]}");
                sb.AppendLine($"📘 Year Level: {row["Year_Level"]}");
                sb.AppendLine($"💻 Course:     {row["Course"]}");
                sb.AppendLine($"📖 Status:     {row["Status"]}");
                sb.AppendLine("------------------------------------------------");

                MessageBox.Show(sb.ToString(), "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudents.Rows[e.RowIndex];
                txtStudentId.Text = row.Cells["Student_ID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtYearLevel.Text = row.Cells["Year_Level"].Value.ToString();
                cmbCourse.Text = row.Cells["Course"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtYearLevel.Clear();
            cmbCourse.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit application?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void dgvStudents_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Delete key was pressed
            if (e.KeyCode == Keys.Delete)
            {
                // Check if any row is selected
                if (dgvStudents.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvStudents.SelectedRows[0];
                    string studentId = selectedRow.Cells["Student_ID"].Value.ToString();

                    DialogResult confirm = MessageBox.Show(
                        $"Are you sure you want to delete Student ID: {studentId}?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            student.DeleteStudent(studentId);
                            MessageBox.Show($"Student {studentId} deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Refresh DataGridView
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //Prevent the DataGridView from trying to remove the row itself (since we control deletion)
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Please select a student row to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve all student records from the database
                DataTable dt = student.GetAllStudents();

                //Check if there are any records
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("⚠️ No student records found in the database.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvStudents.DataSource = null; // clear the grid
                    return;
                }

                //Display all students in DataGridView
                dgvStudents.DataSource = dt;

                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MessageBox.Show($"✅ {dt.Rows.Count} student record(s) displayed successfully.",
                    "Display All", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student information: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
