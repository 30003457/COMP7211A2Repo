using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }
        void SignInClicked(object sender, EventArgs e)
        {


            if (StudentIDEntry.Text == null)
            {
                DisplayAlert("Error", "No Student ID Entered please try again", "OK");
            }
            else if (PasswordEntry.Text == null)
            {
                DisplayAlert("Error", "No Password Entered please try again", "OK");
            }
            else
            {
                DisplayAlert("Success", "You have successfully logged in", "OK");
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
