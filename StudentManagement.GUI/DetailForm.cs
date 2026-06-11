using StudentManagement.BLL;
using StudentManagement.DTO.Entities;
using StudentManagement.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.GUI
{
    public partial class DetailForm : Form
    {
        public delegate void RefreshGridDelegate(int classRoomId, string keyword);
        public RefreshGridDelegate DataSaved { get; set; }

        private string _studentId;
        private bool _isAddMode;
        public DetailForm(string studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            _isAddMode = (string.IsNullOrWhiteSpace(studentId));
            InitFormView();
        }

        private void InitFormView()
        {
            cboClassRooms.Items.AddRange(StudentBll.Instance.GetClassRoomComboboxItems().ToArray());
            if (cboClassRooms.Items.Count > 0) cboClassRooms.SelectedIndex = 0;

            if (!_isAddMode)
            {
                txtStudentId.Enabled = false;
                var student = StudentBll.Instance.GetStudentByStudentId(_studentId);
                if (student != null)
                {
                    txtStudentId.Text = student.StudentId;
                    txtFullName.Text = student.FullName;
                    if (student.Gender)
                    {
                        rdoMale.Checked = true;
                    }
                    else
                    {
                        rdoFemale.Checked = true;
                    }
                    dtpDateOfBirth.Value = student.DateOfBirth;
                    txtGpa.Text = student.Gpa.ToString();
                    foreach (ComboboxItem item in cboClassRooms.Items)
                    {
                        if (item.Value == student.ClassRoomId)
                        {
                            cboClassRooms.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(txtGpa.Text.Trim(), out double gpaValue))
                {
                    MessageBox.Show("GPA must be a valid number!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGpa.Focus();
                    return;
                }

                var student = new Student
                {
                    StudentId = txtStudentId.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Gender = rdoMale.Checked,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Gpa = gpaValue,
                    ClassRoomId = ((ComboboxItem)cboClassRooms.SelectedItem).Value
                };
                StudentBll.Instance.ExecuteSave(student, _isAddMode);

                MessageBox.Show("Student information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int classRoomId = ((ComboboxItem)cboClassRooms.SelectedItem).Value;
                
                if (DataSaved != null)
                {
                    DataSaved(classRoomId, "");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
