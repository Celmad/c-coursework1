using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    /// <summary>
    /// In this file we create the Student class which will allow us to create Student object and its properties and methods.
    /// </summary>
    public class Student
    {
        // Private student properties
        private int _matricNo;
        private string _firstName;
        private string _surname;
        private double _courseMark;
        private double _examMark;
        private string _birthday;
        private double total;

        // Matriculation property
        public int Matric
        {
            get { return _matricNo; }
            set
            {
                // Validating matriculation number
                if (value < 10001 || value > 50000)
                {
                    throw new Exception("Please, insert a number between 10001 and 50000");
                }
                _matricNo = value;
            }
        }

        // First name property
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                // Checking input box is not empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Please, write the name");
                }
                _firstName = value;
            }
        }

        // Surname property
        public string Surname
        {
            get { return _surname; }
            set
            {
                // Checking input box is not empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Please, write the surname");
                }
                _surname = value;
            }
        }

        // Birthday property
        public string Birthday
        {
            get { return _birthday; }
            set
            {
                // Checking input box is not empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Please, pick a birthday date");
                }
                _birthday = value;
            }
        }

        // Course Mark property
        public double CourseMark
        {
            get { return _courseMark; }
            set
            {
                // Course Mark should be between 0 and 20
                if (value < 0 || value > 20)
                {
                    throw new Exception("Please, insert a number between 0 and 20");
                }
                _courseMark = value;
            }
        }

        // Exam Mark property
        public double ExamMark
        {
            get { return _examMark; }
            set
            {
                // Exam Mark should be between 0 and 40
                if (value < 0 || value > 40)
                {
                    throw new Exception("Please, insert a number between 0 and 40");
                }
                _examMark = value;
            }
        }

        // GetMark method to get the final Mark by using the two previous marks and weigthing them 50/50
        public int getMark()
        {
            return (int)Math.Round((((_courseMark / 20f) + (_examMark / 40f)) / 2f) * 100f);
        }

        // Get total method
        public double totall
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }
    }
}
