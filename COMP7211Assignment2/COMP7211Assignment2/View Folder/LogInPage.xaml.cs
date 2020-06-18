using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;
using System.Security.Cryptography.X509Certificates;
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
        ValidatorV3 vd;
        ValidateLoginData Validator;
        public int StudentID;
        public LogInPage()
        {
            InitializeComponent();
            vd = new ValidatorV3();
            Validator = new ValidateLoginData();
            StudentID = Convert.ToInt32(StudentIDEntry.Text);

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

        private async void SignInClicked(object sender, EventArgs e)
        {
            try
            {
                if (await vd.ValidateUser(StudentIDEntry.Text) == true)
                {
                    if (vd.CheckFirstLogin() == true)
                    {
                        await Navigation.PushAsync(new FirstLoginPage(Convert.ToInt32(StudentIDEntry.Text)));
                    }
                    else
                    {
                        if (vd.ValidatePassword(PasswordEntry.Text) == true)
                        {
                            StudentIDEntry.Text = null;
                            PasswordEntry.Text = null;
                            await Navigation.PushAsync(new CoursesViewPage());
                        }
                        else
                        {
                            await DisplayAlert("Invalid", vd.errorMsg, "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Invalid", vd.errorMsg, "OK");
                }
            }
            catch (Exception _e)
            {
                await DisplayAlert("Invalid", _e.Message, "OK");
                throw;
            }
            
        }
    }
}
