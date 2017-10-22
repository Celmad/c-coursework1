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
    /// </summary>
    public partial class StudentDetails : Window
    {
        private ModuleList _store;

        public StudentDetails(ModuleList store)
        {
            InitializeComponent();
            _store = store;

            foreach (Student s in _store)
            {
                List_StudentDetails.Items.Add(s);
            }
        }
    }
}
