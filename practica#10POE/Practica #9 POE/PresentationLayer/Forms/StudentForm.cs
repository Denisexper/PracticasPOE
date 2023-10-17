using BusinessLayer.CRUD;
using CommonLayer;
using FluentValidation.Results;
using PresentationLayer.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            LoadStudentsData();
        }

        private void LoadStudentsData()
        {
            StudentBusiness studentBusiness = new StudentBusiness();
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = studentBusiness.GetStudents();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            StudentBusiness studentBusiness = new StudentBusiness();
            Student student = new Student();

            student.name = txtNombreAlumno.Text;
            student.code = txtCodigoAlumno.Text;
            student.numberphone = txtTelefonoAlumno.Text;
            student.city = txtCiudadAlumno.Text;

            StudentValidator studentValidator = new StudentValidator(); 
            ValidationResult result = studentValidator.Validate(student);

            if (!result.IsValid)
            {
                foreach(var fairule in result.Errors)
                {
                    MessageBox.Show("Error: " + fairule);
                }

            }
            else
            {
                studentBusiness.AddStudents(student);
                LoadStudentsData();
            }
            studentBusiness.AddStudents(student);

            LoadStudentsData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            StudentBusiness studentBusiness = new StudentBusiness();
            Student student = new Student();

            if (dgvStudents.SelectedRows.Count > 0)
            {
                student.id = int.Parse(dgvStudents.CurrentRow.Cells[0].Value.ToString());

                studentBusiness.DeleteStudents(student);

                LoadStudentsData();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de eliminar");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
