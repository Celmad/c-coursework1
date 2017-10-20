using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModuleList store = new ModuleList();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Adding student
        private void Btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            Student aStudent = new Student();
            string errorMsg = "";

            try
            {
                aStudent.FirstName = txtName.Text;
            }
            catch (Exception exception)
            {
                errorMsg += exception.Message + "\n";
            }

            try
            {
                aStudent.Surname = txtSurname.Text;
            }
            catch (Exception exception)
            {
                errorMsg += exception.Message + "\n";
            }

            try
            {
                aStudent.Birthday = txtBirthday.Text;
            }
            catch (Exception exception)
            {
                errorMsg += exception.Message + "\n";
            }

            try
            {
                aStudent.Matric = Int32.Parse(txtMatric.Text);
            }
            catch (Exception exception)
            {
                errorMsg += exception.Message + "\n";
            }

            try
            {
                List_Students.Items.Add(aStudent.Matric);
            }
            catch { }

            txtName.Clear();
            txtSurname.Clear();
            txtMatric.Clear();
        }

        Student selectedStudent;
        int studentMark;

        private void Btn_Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedStudent = store.find(int.Parse(txtStudentNo.Text));
                lbl_Name.Content = selectedStudent.FirstName;
            }
            catch
            {
                MessageBox.Show("Ops, something went wrong, try different student matriculation number");
            }
            try
            {
                studentMark = selectedStudent.getMark();
                lbl_TotalMark.Content = studentMark + "%";
            }
            catch
            {
                MessageBox.Show("Ops, seems like the student didn't the coursework or the exam");
            }

            txtStudentNo.Clear();
        }

        private void Btn_CourseMark_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";

            try
            {
                selectedStudent.CourseMark = Int32.Parse(txtCourseMark.Text);
            }
            catch (Exception exception)
            {
                errorMsg += exception.Message + "\n";
            }

            txtCourseMark.Clear();
        }

        private void Btn_ExamMark_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";

            try
            {
                selectedStudent.ExamMark = Int32.Parse(txtExamMark.Text);
            }
            catch (Exception exception)
            {
                errorMsg += exception.Message + "\n";
                throw;
            }

            txtExamMark.Clear();

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // store.delete(selectedStudent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void List_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStudentNo.Text = List_Students.SelectedItem.ToString();
        }
    }
}
