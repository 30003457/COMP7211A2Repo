using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace COMP7211Assignment2
{
    class CourseCards
    {
        //list of rows of course cards
        public List<CourseCard> courseCards { get; set; }
        public CourseCards()
        {
            courseCards = new List<CourseCard>();
        }
    }
}
