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
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            try
            {
                aStudent.Surname = txtSurname.Text;
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            try
            {
                aStudent.Birthday = txtBirthday.Text;
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            try
            {
                aStudent.Matric = int.Parse(txtMatric.Text);
                List_Students.Items.Add(aStudent.Matric);
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            if (!String.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }
            else
            {
                store.add(aStudent);
                txtName.Clear();
                txtSurname.Clear();
                txtMatric.Clear();
                txtBirthday.Text = "";
            }
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
                selectedStudent.CourseMark = int.Parse(txtCourseMark.Text);

                studentMark = selectedStudent.getMark();
                lbl_TotalMark.Content = studentMark + "%";
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            if (!String.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }

            txtCourseMark.Clear();
        }

        private void Btn_ExamMark_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";

            try
            {
                selectedStudent.ExamMark = int.Parse(txtExamMark.Text);

                studentMark = selectedStudent.getMark();
                lbl_TotalMark.Content = studentMark + "%";
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            if (!String.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }

            txtExamMark.Clear();

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            List_Students.Items.Remove(selectedStudent.Matric);
            store.delete(selectedStudent.Matric);
            lbl_Name.Content = "";
            lbl_TotalMark.Content = "";

        }

        private void List_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStudentNo.Text = List_Students.SelectedItem.ToString();
        }

        private void txtMatric_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtMatric.MaxLength = 5;
        }
    }
}
