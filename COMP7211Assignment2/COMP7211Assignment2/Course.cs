using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{
    //By Min 30003457
    class Course
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public Course(string n, int id)
        {
            Name = n;
            ID = $"COMP{id}";
        }
    }
}
