using System;
using System.Collections.Generic;

namespace COMP7211Assignment2.Model_Folder
{
    internal class PlaceholderPostReplyDatabase
    {
        private readonly List<IPost> records;
        public PlaceholderPostReplyDatabase()
        {
            records = new List<IPost>
            {
                new PostReply(1, 2, DateTime.Now.AddMinutes(5), "Aenean vitae libero consectetur, tincidunt lacus in, ornare justo. Duis placerat ullamcorper turpis, vel lacinia sem aliquet ut. Curabitur at ultrices purus.")
            };
        }
    }
}
