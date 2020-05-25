using System;
using System.Collections.Generic;
using System.Text;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Model_Folder
{
    class PlaceholderPostDatabase
    {
        public List<Post> records;
        public PlaceholderPostDatabase()
        {
            records = new List<Post>();

            records.Add(new Post(1, 7211, DateTime.Now, "Lorem ipsum dolor sit amet", "Donec nunc sapien, mollis quis purus a, gravida tincidunt velit. Maecenas id dictum lectus, eget luctus risus. Mauris sed imperdiet lorem."));
            records.Add(new Post(2, 7212, DateTime.Now.AddHours(-1), "Integer tristique nunc dignissim dui aliquet", "Cras lacinia convallis felis, eget finibus diam gravida eget. Phasellus nunc lectus, tempor sodales auctor eget, placerat sed dui."));
            records.Add(new Post(3, 6201, DateTime.Now.AddMinutes(-30), "Morbi feugiat mi sed diam congue tincidunt", "Vivamus vitae dolor ut libero facilisis pellentesque eu eget nunc. Ut nec arcu a sapien efficitur semper. Praesent vitae nisl quam."));
        }
    }
}
