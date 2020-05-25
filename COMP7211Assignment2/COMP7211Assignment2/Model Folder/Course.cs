using System;
using System.Collections.Generic;
using System.Text;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    class Course
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string IDName { get; set; }

        public Course(string n, int id)
        {
            Name = n;
            ID = id;
            IDName = $"COMP{id}";
        }
    }
}
