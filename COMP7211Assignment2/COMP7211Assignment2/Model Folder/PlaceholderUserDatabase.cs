﻿using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{
    //Code by Min 30003457
    class PlaceholderUserDatabase
    {
        public List<User> records = new List<User>();

        public PlaceholderUserDatabase()
        {
            records.Add(new User("Bob", "Smith", 00000001, false));
            records.Add(new User("Jack", "Johnson", 12341234, false));
            records.Add(new User("Michael", "Jordan", 45677654, false));
            records.Add(new User("Jack", "McConnell", 86544444, true));
            records.Add(new User("Jim", "Carrey", 34569876, false));
        }
    }
}