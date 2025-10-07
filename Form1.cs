using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using StudentsFormApp.Dto;
using StudentsFormApp.Services;

namespace StudentsFormApp
{
    public partial class Form1 : Form
    {
        private readonly IStudentService studentService;
        int currentStudentId = 0;
        ErrorProvider errorProvider;
        public Form1(IStudentService _studentService)
        {
           studentService = _studentService;
            errorProvider = new ErrorProvider();

        

            InitializeComponent();
           

        }


 

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void buttonLayout_Paint(object sender, PaintEventArgs e)
        {

        }


        private void savebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameText.Text))
            {
                MessageBox.Show("Name is required");
                return;

            }
            if (string.IsNullOrEmpty(fatherText.Text))
            {
                MessageBox.Show("fatherName is required");
                return;

            }
        
            if (string.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address is required");
                return;

            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("cource is required");
                return;

            }
            if (!male.Checked && !female.Checked)
            {
                MessageBox.Show("Select gender");
                return;
            }
            if(Convert.ToInt32( ageNumeric.Text ) <= 0)
            {
                MessageBox.Show("Select Age");
                return;
            }
            Students student = new Students
            {
                Id=currentStudentId,
                Name = nameText.Text,
                Age = (int)ageNumeric.Value,
                Address = addressTextBox.Text,
                FatherName = fatherText.Text,
                Course = comboBox1.Text,
                Gender = male.Checked ? "Male" : "Female"
            };
            if (currentStudentId == 0)
            {
                bool numberOfRowAffected = studentService.InsertStudent(student);
                if (numberOfRowAffected)
                {
                    MessageBox.Show("new Student is Added");
                    clearField();
                    loadData();
                }
                else
                {
                    MessageBox.Show("something wrong");
                }
            }else if (currentStudentId > 0)
            {
                bool numberOfRowAffected = studentService.updateStudent(student);
                if (numberOfRowAffected)
                {
                    MessageBox.Show(" Student is updated");
                    clearField();
                    loadData();
                }
                else
                {
                    MessageBox.Show("something wrong");
                }
            }
       
            

        }
        public void loadData()
        {
            var students=studentService.getAllStudents();
            studentsList.DataSource = students;
          

        }
    
        private void fatherText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fatherText.Text))
            {
                errorProvider.SetError(fatherText, "Father Name is required");
            }
        }

        private void nameText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameText.Text))
            {
                errorProvider.SetError(nameText, " Name is required");
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            clearField();
        }
       
        public void clearField()
        {
            comboBox1.Text = "";
            male.Checked = false;
            female.Checked = false;
            ageNumeric.ResetText();
            fatherText.Clear();
            addressTextBox.Clear();
            nameText.Clear();
            currentStudentId = 0;
            savebtn.Text = "Save";
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            loadData();
            if (!studentsList.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                deleteColumn.Name = "Delete";
                deleteColumn.HeaderText = "Delete";
                deleteColumn.Text = "Delete";
                deleteColumn.UseColumnTextForButtonValue = true;

                studentsList.Columns.Add(deleteColumn);
            }
            if (!studentsList.Columns.Contains("Update"))
            {
                DataGridViewButtonColumn updateColumn =new DataGridViewButtonColumn();
                updateColumn.Name = "Update";
                updateColumn.Text = "Update";
                updateColumn.HeaderText = "Update";
                updateColumn.UseColumnTextForButtonValue= true;
                studentsList.Columns.Add(updateColumn);

            }
          
        }
        
        private void studentsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( studentsList.Columns[e.ColumnIndex].Name=="Delete")
            {
                int studentId = Convert.ToInt32(studentsList.Rows[e.RowIndex].Cells["Id"].Value);
                bool deleted = studentService.deleteStudent(studentId);
                if (deleted)
                {
                    MessageBox.Show("student data deleted");
                    loadData();
                }
                else
                {
                    MessageBox.Show("something wrong while deleting");
                }
            }
            if( studentsList.Columns[e.ColumnIndex].Name == "Update")
            {
                int studentId = Convert.ToInt32(studentsList.Rows[e.RowIndex].Cells["Id"].Value);
                updateStudents(studentId);

            }
        }
        public void updateStudents(int id)
        {
            var student=studentService.getStudentById(id);
            if (student != null)
            {
                nameText.Text = student.Name;
                addressTextBox.Text = student.Address;
                fatherText.Text = student.FatherName;
                ageNumeric.Text = student.Age.ToString();
                currentStudentId = id;
                savebtn.Text = "SaveUpdate";
                comboBox1.Text= student.Course;
                if (student.Gender == "Male")
                {
                    male.Checked = true;
                }
                else
                {
                    female.Checked = true;
                }


            }
        }

     
    }
}   
