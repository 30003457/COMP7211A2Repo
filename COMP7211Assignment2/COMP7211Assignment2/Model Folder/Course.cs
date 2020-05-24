namespace COMP7211Assignment2
{
    //By Min 30003457
    internal class Course
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
