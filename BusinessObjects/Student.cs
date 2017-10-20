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
        private string _birthday;


        public int Matric
        {
            get { return _matricNo; }
            set
            {
                if (value > 10001 || value > 50000)
                {
                    throw new Exception("Please, insert a number between 10001 and 5000");
                }
                _matricNo = value;
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Please, write the name");
                }
                _firstName = value;
            } 
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Please, write the surname");
                }
                _surname = value;
            }
        }

        public string Birthday
        {
            get { return _birthday; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Please, pick a birthday date");
                }
                _birthday = value;
            }
        }

        public double CourseMark
        {
            get { return _courseMark; }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new Exception("Please, insert a number between 0 and 20");
                }
                _courseMark = value;
            }
        }

        public double ExamMark
        {
            get { return _examMark; }
            set
            {
                if (value < 0 || value > 40)
                {
                    throw new Exception("Please, insert a number between 0 and 20");
                }
                _examMark = value;
            }
        }

        public int getMark()
        {
            return (int)Math.Round((((_courseMark / 20f) + (_examMark / 40f)) / 2f) * 100f);
        }
    }
}
