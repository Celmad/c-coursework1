using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Student
    {
        private int _matricNo;
        private string firstName;
        private string surname;
        private int courseMark;
        private int examMark;
        private DateTime birtday;


        public int Matric
        {
            get
            {
                return _matricNo;
            }
            set
            {
                _matricNo = value;
            }
        }

        public void getMark()
        {

        }
    }
}
