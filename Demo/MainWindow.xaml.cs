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

        private void Btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            Student aStudent = new Student();
            store.add(aStudent);

            try
            {

            }
            catch
            {

            }
        }

        string selectedStudent;

        private void Btn_Find_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_CourseMark_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ExamMark_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
