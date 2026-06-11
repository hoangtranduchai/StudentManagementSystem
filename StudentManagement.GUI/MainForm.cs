using StudentManagement.BLL;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadClassRooms();
            LoadSortComboBox();
            RefreshGrid(0, "");
        }

        private void LoadClassRooms()
        {
            cboClassRooms.Items.Clear();
            cboClassRooms.Items.Add(new ComboboxItem { Value = 0, Text = "All" });
            cboClassRooms.Items.AddRange(StudentBll.Instance.GetClassRoomComboboxItems().ToArray());
            cboClassRooms.SelectedIndex = 0;
        }

        private void LoadSortComboBox()
        {
            cboSort.Items.Clear();
            cboSort.Items.AddRange(new string[]
            {
                "StudentId", "FullName", "Gpa"
            });
            cboSort.SelectedIndex = 0;
        }

        private void RefreshGrid(int classRoomId, string keyword)
        {
            dgvStudents.DataSource = StudentBll.Instance.GetStudentViews(classRoomId, keyword);
        }

        private void OnDataSaved(int classRoomId, string keyword)
        {
            txtSearch.Text = keyword;

            foreach (ComboboxItem item in cboClassRooms.Items)
            {
                if (item.Value == classRoomId)
                {
                    cboClassRooms.SelectedItem = item;
                    break;
                }
            }

            RefreshGrid(classRoomId, keyword);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int classRoomId = ((ComboboxItem)cboClassRooms.SelectedItem).Value;
            RefreshGrid(classRoomId, txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (DetailForm detailForm = new DetailForm(null))
            {
                detailForm.DataSaved += new DetailForm.RefreshGridDelegate(OnDataSaved);
                detailForm.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 1)
            {
                string studentId = dgvStudents.SelectedRows[0].Cells["StudentId"].Value.ToString();
                using (DetailForm detailForm = new DetailForm(studentId))
                {
                    detailForm.DataSaved += new DetailForm.RefreshGridDelegate(OnDataSaved);
                    detailForm.ShowDialog();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete the selected students?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    List<string> selectedStudentId = new List<string>();
                    foreach (DataGridViewRow row in dgvStudents.SelectedRows)
                    {
                        selectedStudentId.Add(row.Cells["StudentId"].Value.ToString());
                    }
                    StudentBll.Instance.DeleteStudent(selectedStudentId);
                    RefreshGrid(0, "");
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int classRoomId = ((ComboboxItem)cboClassRooms.SelectedItem).Value;
            string sortBy = cboSort.SelectedItem.ToString();
            dgvStudents.DataSource = StudentBll.Instance.GetSortedStudentViews(classRoomId, txtSearch.Text.Trim(), sortBy);
        }
    }
}
