using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesViewPage : ContentPage
    {
        PlaceholderDatabase db = new PlaceholderDatabase();
        CourseDetector cd;
        public CoursesViewPage()
        {
            InitializeComponent();
            CreateCourseCards();
        }

        private void CreateCourseCards()
        {
            StackLayout stackLayout = new StackLayout();
            stackLayout.TranslationY = 20;

            SimulateLoginUser();

            List<StackLayout> CourseCards = new List<StackLayout>();

            for (int i = 0; i < cd.ReturnCourses().Count; i++)
            {
                CourseCards.Add(new StackLayout
                {
                    BackgroundColor = Color.Gray,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 300,
                    HeightRequest = 100
                });

                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.Children.Add(new Image());

                CourseCards[i].Children.Add(grid);

                StackLayout childStackLayout = new StackLayout { Padding = 10 };
                childStackLayout.Children.Add(new Label { Text = $"COMP{cd.ReturnCourses()[i].ID}", FontSize = 36, TextColor = Color.White });
                childStackLayout.Children.Add(new Label { Text = cd.ReturnCourses()[i].Name, TextColor = Color.White });
                CourseCards[i].Children.Add(childStackLayout);
                
                stackLayout.Children.Add(CourseCards[i]);
            }

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
        }

        private void SimulateLoginUser()
        {
            cd = new CourseDetector(45677654);
        }
    }
}