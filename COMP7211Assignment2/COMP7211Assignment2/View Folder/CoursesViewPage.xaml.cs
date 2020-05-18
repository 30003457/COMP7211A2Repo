using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using COMP7211Assignment2.View_Folder;
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
        //PlaceholderDatabase db = new PlaceholderDatabase();
        //CourseDetector cd;
        //StackLayout masterStackLayout;
        //PlaceholderUserDatabase userDb;
        Course selectedCourse;
        //PageManager pm;
        public CoursesViewPage()
        {
            //masterStackLayout = new StackLayout();
            InitializeComponent();
            PageData.PManager = new PageManager();
            //PageData.PManager.PostRecords = pm.PostRecords;
            //userDb = new PlaceholderUserDatabase();
            PageData.PManager.CDetector = new CourseDetector(PageData.PManager.UserRecords[2].StudentID);
            BindingContext = PageData.PManager.CDetector;

            TESTER.RandomVotes(); //add random votes
            //CreateHeaderView();
            //CreateCourseCardsView();
            
            //Content = masterStackLayout;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedCourse = (Course)e.Item;
            PageData.PManager.CurrentTitle = selectedCourse.IDName;
            PageData.PManager.CurrentCourseID = selectedCourse.ID;
            PageData.PManager.CurrentSubtext = selectedCourse.Name;

            await Navigation.PushAsync(new PostsViewPage());
        }

        //private void CreateHeaderView()
        //{
        //    Grid headerGrid = new Grid();
        //    headerGrid.ColumnDefinitions.Add(new ColumnDefinition());
        //    headerGrid.ColumnDefinitions.Add(new ColumnDefinition());
        //    headerGrid.ColumnDefinitions.Add(new ColumnDefinition());
        //    var midCol = new Label {
        //        Text = "Courses", HorizontalTextAlignment = TextAlignment.Center,
        //        Padding = new Thickness(0,20,0,0), FontSize = 24, TextColor = Color.Black};
        //    var rightCol = new Button
        //    {
        //        TranslationY = 12,
        //        TranslationX = -10,
        //        WidthRequest = 100,
        //        HorizontalOptions = LayoutOptions.End,
        //        Text = "LOGOUT"
        //    };
        //    headerGrid.Children.Add(midCol, 1, 0);
        //    headerGrid.Children.Add(rightCol, 2, 0);

        //    //masterStackLayout.Children.Add(headerGrid);
        //    StackLayout headerStackLayout = new StackLayout();
        //    headerStackLayout.Children.Add(headerGrid);
        //    masterStackLayout.Children.Add(headerStackLayout);
        //}

        //private void CreateCourseCardsView()
        //{
        //    StackLayout stackLayout = CreateCourseCardRow();

        //    ScrollView scrollView = new ScrollView();
        //    scrollView.Content = stackLayout;
        //    masterStackLayout.Children.Add(scrollView);
        //    //Content = scrollView;
        //}

        //private StackLayout CreateCourseCardRow()
        //{
        //    //initial stacklayout
        //    StackLayout stackLayout = new StackLayout();
        //    stackLayout.TranslationY = 20;

        //    SimulateLoginUser();

        //    //collection of course cards as stacklayouts
        //    List<StackLayout> courseCards = new List<StackLayout>();

        //    //create course card layout
        //    Grid courseCardRow = new Grid();
        //    courseCardRow.ColumnDefinitions.Add(new ColumnDefinition());
        //    courseCardRow.ColumnDefinitions.Add(new ColumnDefinition());

        //    //variables to create 2 columns
        //    bool isLeftSide = true;
        //    int rowCounter = 0;
        //    //int row = 0;

        //    //StackLayout rowStackLayout = new StackLayout();

        //    for (int i = 0; i < cd.ReturnCourses().Count; i++)
        //    {
        //        courseCards.Add(new StackLayout
        //        {
        //            BackgroundColor = Color.Gray,
        //            WidthRequest = 200,
        //            HeightRequest = 200
        //        });

        //        //add to grid to split columns
        //        if (isLeftSide == true)
        //        {
        //            courseCardRow.Children.Add(courseCards[i], 0, 0);
        //            courseCardRow.HorizontalOptions = LayoutOptions.End;
        //            isLeftSide = false;
        //            rowCounter++;
        //        }
        //        else
        //        {
        //            courseCardRow.Children.Add(courseCards[i], 1, 0);
        //            courseCardRow.HorizontalOptions = LayoutOptions.Start;
        //            isLeftSide = true;
        //            rowCounter++;
        //        }

        //        //for the text within each course card
        //        Grid courseCardTextLayout = new Grid();
        //        courseCardTextLayout.RowDefinitions.Add(new RowDefinition());
        //        courseCardTextLayout.RowDefinitions.Add(new RowDefinition());

        //        //insert tap gesture recognizer here
        //        var tapGestureRecognizer = new TapGestureRecognizer();
        //        tapGestureRecognizer.Tapped += (s, e) =>
        //        {
        //            // handle the tap

        //        };

        //        //course card in the form of an image
        //        Image courseCardBg = new Image();
        //        courseCardBg.GestureRecognizers.Add(tapGestureRecognizer);

        //        courseCardTextLayout.Children.Add(courseCardBg);

        //        //text for each course card
        //        StackLayout childStackLayout = new StackLayout { Padding = 10 };
        //        childStackLayout.Children.Add(new Label { Text = $"COMP{cd.ReturnCourses()[i].ID}", FontSize = 24, TextColor = Color.White, InputTransparent = true });
        //        childStackLayout.Children.Add(new Label { Text = cd.ReturnCourses()[i].Name, TextColor = Color.White, InputTransparent = true });



        //        //order of xaml elements
        //        courseCardTextLayout.Children.Add(childStackLayout);
        //        courseCards[i].Children.Add(courseCardTextLayout);
        //        courseCardRow.Children.Add(courseCards[i]);
        //        //separate rows
        //        if (rowCounter >= 2)
        //        {
        //            stackLayout.Children.Add(courseCardRow);
        //            //row++;
        //            rowCounter = 0;
        //        }
        //        //stackLayout.Children.Add(courseCardRow);
        //    }

        //    return stackLayout;
        //}

        //private void SimulateLoginUser()
        //{
        //    cd = new CourseDetector(45677654);
        //}
    }
}