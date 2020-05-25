using System;
using System.Collections.Generic;
using System.Text;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Model_Folder
{
    class PlaceholderPostReplyDatabase
    {
        List<IPost> records;
        public PlaceholderPostReplyDatabase()
        {
            records = new List<IPost>();

            records.Add(new PostReply(1, 2, DateTime.Now.AddMinutes(5), "Aenean vitae libero consectetur, tincidunt lacus in, ornare justo. Duis placerat ullamcorper turpis, vel lacinia sem aliquet ut. Curabitur at ultrices purus."));
        }
    }
}
