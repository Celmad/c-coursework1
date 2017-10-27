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
    /// 
    /// Form handlers. Methods that will communicate between GUI, Student class and ModuleList class.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creating a list to store students from the ModuleList class
        private ModuleList store = new ModuleList();

        // Creating a student at a time
        Student aStudent = new Student();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Adding student
        private void Btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {

            // Create string to save the existing errors
            string errorMsg = "";

            // Adding Name property for current student
            try
            {
                aStudent.FirstName = txtName.Text;
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            // Adding Surname property for current student
            try
            {
                aStudent.Surname = txtSurname.Text;
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            // Adding Date of Birth for current student
            try
            {
                aStudent.Birthday = txtBirthday.Text;
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            // Adding Matriculation number for current student
            try
            {
                aStudent.Matric = int.Parse(txtMatric.Text);

                // Add the matriculation number of current student to a ListBox of the main Form
                List_Students.Items.Add(aStudent.Matric);
            }
            catch (Exception except)
            {
                errorMsg += except.Message + "\n";
            }

            // Checking if there are error messages, if so, show them to the user
            if (!String.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }
            else
            {
                // if there is no errors, add the created student to the Store list and clean the boxes of the form
                store.add(aStudent);
                txtName.Clear();
                txtSurname.Clear();
                txtMatric.Clear();
                txtBirthday.Text = "";
            }
        }

        // Creating a student variable to save selected student
        Student selectedStudent;

        // Creating student mark variable to store its final mark and be able to use it later
        int studentMark;


        // Button to Find a student from a given matriculation number and show part of its information
        private void Btn_Find_Click(object sender, RoutedEventArgs e)
        {
            // Looking for student and adding its name to a Name label
            try
            {
                // Take input number and parse it. The result into the find method, which return its student if matriculation number is found
                selectedStudent = store.find(int.Parse(txtStudentNo.Text));
                lbl_Name.Content = selectedStudent.FirstName + " " + selectedStudent.Surname;
            }
            catch
            {
                MessageBox.Show("Ops, something went wrong, try different student matriculation number");
            }

            // Get mark of student using the 'getMark' method. Show the result in a label
            try
            {
                studentMark = selectedStudent.getMark();
                lbl_TotalMark.Content = studentMark + "%";
            }
            catch
            {
                MessageBox.Show("Ops, seems like the student didn't the coursework or the exam");
            }

            // Clear the text box to look for another student
            txtStudentNo.Clear();
        }


        // Button to give the selected student its CourseMark
        private void Btn_CourseMark_Click(object sender, RoutedEventArgs e)
        {
            // Created and initialized -empty- string to store errors
            string errorMsg = "";

            // Once we have selected an existing student, we mark the course of the student and update its label
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

            // Give feedback to user when validation hasn't been achieved
            if (!String.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }

            // Clear the textbox for the courseMark
            txtCourseMark.Clear();

            // Get total after adding course mark
            selectedStudent.totall = selectedStudent.getMark();
        }

        
        // Button to give the selected student its ExamMark
        private void Btn_ExamMark_Click(object sender, RoutedEventArgs e)
        {
            // Created and initialized -empty- string to store errors
            string errorMsg = "";

            // Once we have selected an existing student, we mark the exam of the student and update its label
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

            // Give feedack to user when validation hasn't been achieved
            if (!String.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }

            // Clear the textbox for the courseMark
            txtExamMark.Clear();

            // Get total after adding exam mark
            selectedStudent.totall = selectedStudent.getMark();

        }
        // Button to delete selected student from the store list and clear labels of selected student
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            store.delete(selectedStudent.Matric);
            lbl_Name.Content = "";
            lbl_TotalMark.Content = "";
            // List_Students.UnselectAll();
            // List_Students.Items.Remove(List_Students.SelectedItem);
        }

        // Selecting student from the ListBox in the main form will write its number in the search box of the Find method
        private void List_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStudentNo.Text = List_Students.SelectedItem.ToString();
        }

        // Student Matriculation number should have a max length of 5 digits
        private void txtMatric_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtMatric.MaxLength = 5;
        }

        // Button to open new page with student information, passing store information to the new page
        private void Btn_SeeAll_Click(object sender, RoutedEventArgs e)
        {
            StudentDetails studentDetails = new StudentDetails(store);
            studentDetails.Show();
        }
    }
}
