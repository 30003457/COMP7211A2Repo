﻿using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        Validator vd;
        private double width, height;
        public LogInPage()
        {
            InitializeComponent();
            vd = new Validator();
            PageData.PManager = new PageManager(); //initiate page manager
            
            //responsive ui
            //this.SizeChanged += LogInPage_SizeChanged;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    Grid.SetRowSpan(LogoImage, 3);
                    Grid.SetColumnSpan(LogoImage, 1);
                    MainGrid.ColumnDefinitions.RemoveAt(MainGrid.ColumnDefinitions.Count-1);
                    LoginStack = PageData.PManager.Responsive.LandscapeStack(LoginStack);
                }
                else
                {
                    Grid.SetRowSpan(LogoImage, 1);
                    Grid.SetColumnSpan(LogoImage, 3);
                    MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    LoginStack = PageData.PManager.Responsive.PortraitStack(LoginStack);
                }
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

        private async void SignInClicked(object sender, EventArgs e)
        {
            if (vd.ValidateLogin(StudentIDEntry.Text, PasswordEntry.Text) == true)
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
        //try
        //{
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //    builder.DataSource = "mysqlserver-toiohomai.database.windows.net";
        //    builder.UserID = "serveradmin";
        //    builder.Password = "AdminAdmin1";
        //    builder.InitialCatalog = "ToiohomaiStudentsDB";

        //    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        //    {

        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("SELECT * FROM [StudentLogin] ");
        //        sb.Append("FROM [SalesLT].[ProductCategory] pc ");
        //        sb.Append("JOIN [SalesLT].[Product] p ");
        //        sb.Append("ON pc.productcategoryid = p.productcategoryid;");
        //        String sql = sb.ToString();

        //        using (SqlCommand command = new SqlCommand(sql, connection))
        //        {
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
        //                }
        //            }
        //        }
        //    }
        //}
        //catch (SqlException e)
        //{
        //    Console.WriteLine(e.ToString());
        //}
        //Console.ReadLine();


    }
}
