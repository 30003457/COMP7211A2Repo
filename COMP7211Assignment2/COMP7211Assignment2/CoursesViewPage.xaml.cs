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
        StackLayout masterStackLayout;
        public CoursesViewPage()
        {
            masterStackLayout = new StackLayout();

            InitializeComponent();
            CreateHeaderView();
            CreateCourseCardsView();
            
            Content = masterStackLayout;
        }

        private void CreateHeaderView()
        {
            Grid headerGrid = new Grid();
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            var midCol = new Label {
                Text = "Courses", HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(0,20,0,0), FontSize = 24, TextColor = Color.Black};
            var rightCol = new Button
            {
                TranslationY = 12,
                TranslationX = -10,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.End,
                Text = "LOGOUT"
            };
            headerGrid.Children.Add(midCol, 1, 0);
            headerGrid.Children.Add(rightCol, 2, 0);
            masterStackLayout.Children.Add(headerGrid);
        }

        private void CreateCourseCardsView()
        {
            StackLayout stackLayout = new StackLayout();
            stackLayout.TranslationY = 20;

            SimulateLoginUser();

            List<StackLayout> courseCards = new List<StackLayout>();

            for (int i = 0; i < cd.ReturnCourses().Count; i++)
            {
                courseCards.Add(new StackLayout
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

                StackLayout childStackLayout = new StackLayout { Padding = new Thickness(10, 10, 10, 15) };
                childStackLayout.Children.Add(new Label { Text = $"COMP{cd.ReturnCourses()[i].ID}", FontSize = 36, TextColor = Color.White });
                childStackLayout.Children.Add(new Label { Text = cd.ReturnCourses()[i].Name, TextColor = Color.White });
                courseCards[i].Children.Add(childStackLayout);
                grid.Children.Add(childStackLayout);
                courseCards[i].Children.Add(grid);
                stackLayout.Children.Add(courseCards[i]);
            }

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            masterStackLayout.Children.Add(scrollView);
            //Content = scrollView;
        }

        private void SimulateLoginUser()
        {
            cd = new CourseDetector(45677654);
        }
    }
}