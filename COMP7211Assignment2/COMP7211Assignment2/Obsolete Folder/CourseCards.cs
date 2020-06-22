using System.Collections.Generic;

namespace COMP7211Assignment2
{
    internal class CourseCards
    {
        //list of rows of course cards
        public List<CourseCard> courseCards { get; set; }
        public CourseCards()
        {
            courseCards = new List<CourseCard>();
        }
    }
}
