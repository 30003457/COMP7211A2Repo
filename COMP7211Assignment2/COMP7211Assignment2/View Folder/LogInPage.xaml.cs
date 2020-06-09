using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

//********************
//Code by Min 30003457
//********************
namespace COMP7211Assignment2
{
    //Code by Lewis Evans 27033957

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        Validator vd;
        ValidateLoginData Validator;
        public LogInPage()
        {
            InitializeComponent();
            vd = new Validator();
            Validator = new ValidateLoginData();

            PageData.PManager = new PageManager(); //initiate page manager

            //responsive ui event
            this.SizeChanged += LogInPage_SizeChanged;
        }

        private void LogInPage_SizeChanged(object sender, EventArgs e)
        {
            //landscape
            if (Width > Height)
            {
                Grid.SetRowSpan(LogoImage, 3);
                Grid.SetColumnSpan(LogoImage, 1);
                Grid.SetRow(LoginStack,0);
                Grid.SetRowSpan(LoginStack, 3);
                LoginStack.Margin = new Thickness(20, 0);
                LoginStack.VerticalOptions = LayoutOptions.Center;
                LoginStack.HorizontalOptions = LayoutOptions.Center;
                if (MainGrid.ColumnDefinitions.Count > 2)
                {
                    MainGrid.ColumnDefinitions.RemoveAt(0);
                    MainGrid.ColumnDefinitions[0].Width = new GridLength(1.25, GridUnitType.Star);
                    Grid.SetColumnSpan(WallpaperImage, 2);
                }
                LoginStack = PageData.PManager.Responsive.LandscapeStack(LoginStack);
            }
            //portrait
            else
            {
                Grid.SetRowSpan(LogoImage, 1);
                Grid.SetColumnSpan(LogoImage, 3);
                Grid.SetRow(LoginStack, 1);
                Grid.SetRowSpan(LoginStack, 1);
                LoginStack.Margin = new Thickness(0, 0);
                LoginStack.HorizontalOptions = LayoutOptions.Fill;
                if (MainGrid.ColumnDefinitions.Count < 3)
                {
                    MainGrid.ColumnDefinitions.Insert(0, new ColumnDefinition());
                    MainGrid.ColumnDefinitions[1].Width = new GridLength(2.5, GridUnitType.Star);
                    Grid.SetColumnSpan(WallpaperImage, 3);
                    Grid.SetColumn(LoginStack, 1);
                }
                LoginStack = PageData.PManager.Responsive.PortraitStack(LoginStack);
            }
        }

        private async void ForgotClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword());
        }
        private async void CreateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstLoginPage());
        }
        private async void RetrieveDataClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataRetriveController());
        }

        private async void SignInClicked(object sender, EventArgs e)
        {

            Validator.ValidateID(StudentIDEntry.Text);
            Validator.ValidatePassword(PasswordEntry.Text);
           // Validator.ValidatePasswordStatus("");          //not working

            //if (Validator.PasswordIsSet)          //not working
            //{
                if (Validator.passwordMatches || Validator.idMatches || vd.ValidateLogin(StudentIDEntry.Text, PasswordEntry.Text))
                {
                    await DisplayAlert("Success", "You are Logged In", "OK");
                    await Navigation.PushAsync(new CoursesViewPage());
                    StudentIDEntry.Text = null;
                    PasswordEntry.Text = null;
                }
                else
                {
                    await DisplayAlert("Invalid", vd.errorMsg, "OK");
                }

            //}
            //else
            //{
            //    await DisplayAlert("Warning", "You have not set up your account, please set up your password to continue: ", "OK");
            //}

            //min's older validator
            //if (vd.ValidateLogin(StudentIDEntry.Text, PasswordEntry.Text) == true)
            //{
            //    StudentIDEntry.Text = null;
            //    PasswordEntry.Text = null;
            //    await Navigation.PushAsync(new CoursesViewPage());
            //}
            //else
            //{
            //    await DisplayAlert("Invalid", vd.errorMsg, "OK");
            //}

        }




            
        
    }
}
