using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace COMP7211Assignment2
{
    //***************
    //by Min 30003457
    //***************
    class CourseCard
    {
        public Grid rowGrid;
        StackLayout courseCardStack;
        Grid labelGrid;
        StackLayout labelStack;
        //CourseDetector courseDetector;
        Image img;

        public CourseCard()
        {
            rowGrid = new Grid();
            //columns
            rowGrid.ColumnDefinitions.Add(new ColumnDefinition());
            rowGrid.ColumnDefinitions.Add(new ColumnDefinition());

            courseCardStack = new StackLayout();
            labelGrid = new Grid();
            img = new Image();
            labelStack = new StackLayout();
            //courseDetector = new CourseDetector(PlaceholderUserDatabase.Records[0].StudentID);
        }

        public StackLayout CreateLayout(int col, string courseId, string courseName)
        {
            //course card stack
            courseCardStack.BackgroundColor = Color.Gray;

            //detect if the card is on the left column or right column
            if(col == 0)
            {
                courseCardStack.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                courseCardStack.HorizontalOptions = LayoutOptions.Start;
            }

            courseCardStack.WidthRequest = 150;
            courseCardStack.HeightRequest = 150;

            //label grid
            labelGrid.RowDefinitions.Add(new RowDefinition());
            labelGrid.RowDefinitions.Add(new RowDefinition());

            //image with recognizer - there were issues with using a button
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap

            };
            img.GestureRecognizers.Add(tapGestureRecognizer);

            //course ID
            labelStack.Children.Add(new Label
            {
                Text = $"COMP{courseId}",
                TextColor = Color.White,
                FontSize =  24
            });

            //course name
            labelStack.Children.Add(new Label
            {
                Text = courseName,
                TextColor = Color.White,
            });

            labelGrid.Children.Add(img);
            labelGrid.Children.Add(labelStack);
            courseCardStack.Children.Add(labelGrid);
            return courseCardStack;
        }
    }
}
