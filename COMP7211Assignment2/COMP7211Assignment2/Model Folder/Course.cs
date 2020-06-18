//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    public class Course
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
