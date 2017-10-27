using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class ModuleList
    {
        /// <summary>
        /// Main list class, with its methods which will be accesible through new lists creating from this class.
        /// </summary>
        
        // Creating new List
        private static List<Student> _list = new List<Student>();

        // Get list information method
        public List<Student> StudentList
        {
            get
            {
                return _list;
            }
        }
        // Add method to add each student from the Student class
        public void add(Student newStudent)
        {
            _list.Add(newStudent);
        }

        //Find method to find students by checking if their matriculation number exists
        public Student find(int matric)
        {
            foreach (Student p in _list)
            {
                if (matric == p.Matric)
                {
                    return p;
                }
            }

            return null;

        }

        // Delete method to delete students from the list given a matriculation number
        public void delete(int matric)
        {
            Student p = this.find(matric);
            if (p != null)
            {
                _list.Remove(p);
            }

        }

        // New List to save matriculation numbers only 
        public List<int> matrics
        {
            get
            {
               List<int> res = new List<int>();
               foreach(Student p in _list)
                   res.Add(p.Matric);
                return res;
            }
           
        }
    }
}
