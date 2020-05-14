﻿using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{
    //Code by Min 30003457
    class User
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int StudentID { get; set; }
        public List<Course> EnrolledCourses { get; set; }
        public bool IsRep { get; set; }
        PlaceholderCourseDatabase cdb;

        //All students enrolled in same courses for now...
        public User(string fn, string ln, int studentId, bool isRep)
        {
            cdb = new PlaceholderCourseDatabase();

            FName = fn;
            LName = ln;
            StudentID = studentId;
            EnrolledCourses = cdb.records;
            IsRep = isRep;
        }
    }
}
