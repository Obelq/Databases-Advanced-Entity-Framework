using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPerson
{
    class Student
    {
        public string name;
        public static int counter = 0;

        public Student(string name)
        {
            this.name = name;
            counter++;
        }
        
    }
}
