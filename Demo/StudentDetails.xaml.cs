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
using System.Windows.Shapes;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// 
    /// Class to create the second window which will contain a grid with the items from student list
    /// </summary>
    public partial class StudentDetails : Window
    {
        // Creating a new Module List for this new window
        private ModuleList _store = new ModuleList();

        // Retreiving information from the previous created student list
        public StudentDetails(ModuleList store)
        {
            InitializeComponent();
            
            // Adding Student list items to the datagrid GUI
            datagrid_show_all.ItemsSource = _store.StudentList;
        }
    }
}
