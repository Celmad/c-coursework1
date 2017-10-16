using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Student
    {
        private int _matricNo;
        private string _firstName;
        private string _surname;
        private double _courseMark;
        private double _examMark;
        private DateTime _birthday;


        public int Matric
        {
            get { return _matricNo; }
            set { _matricNo = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; } 
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public double CourseMark
        {
            get { return _courseMark; }
            set { _courseMark = value; }
        }

        public double ExamMark
        {
            get { return _examMark; }
            set { _examMark = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public void getMark()
        {

        }
    }
}
