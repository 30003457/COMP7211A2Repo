using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;
using COMP7211Assignment2.View_Folder;
using COMP7211Assignment2.Controller_Folder;

//********************
//Code by Min 30003457
//********************
namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        Validator vd;
        public LogInPage()
        {
            InitializeComponent();           
        }
        private async void ForgotClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword());
        }
        private async void CreateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstLoginPage());
        }
       
        void SignInClicked(object sender, EventArgs e)
        {

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

            PlaceholderUserDatabase users = new PlaceholderUserDatabase();
            LoginSystem.LoggedInUser = users.records.Where(i => i.IsRep = true).First();
            if (LoginSystem.LoggedInUser.IsRep == true)
            {
                Navigation.PushAsync(new CoursesViewRepPage());
            }
            else if (LoginSystem.LoggedInUser.IsRep == false)
            {
                Navigation.PushAsync(new CoursesViewPage());
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
