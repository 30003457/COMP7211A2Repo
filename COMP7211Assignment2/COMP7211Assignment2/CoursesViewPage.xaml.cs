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
        }

        private void CreateCourseCards()
        {
            StackLayout stackLayout = new StackLayout();
            stackLayout.TranslationY = 20;

            SimulateLoginUser();

            List<StackLayout> CourseCards = new List<StackLayout>();

            for (int i = 0; i < cd.ReturnCourses().Count; i++)
            {
                StackLayout childStackLayout = new StackLayout
                {
                    BackgroundColor = Color.Gray,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 300,
                    HeightRequest = 100
                };

                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.Children.Add(new Image());

                childStackLayout.Children.Add(grid);

                CourseCards.Add(new StackLayout { Padding = 10 });
                CourseCards[i].Children.Add(new Label {Text = $"COMP{cd.ReturnCourses()[i].ID}", FontSize = 36, TextColor = Color.White });
                CourseCards[i].Children.Add(new Label { Text = cd.ReturnCourses()[i].Name, TextColor = Color.White });
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