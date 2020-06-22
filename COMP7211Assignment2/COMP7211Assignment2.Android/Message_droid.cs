using Android.Widget;
using COMP7211Assignment2.Droid;
using Xamarin.Forms;
[assembly: Dependency(typeof(Message_droid))]
namespace COMP7211Assignment2.Droid
{
    public class Message_droid : IMessage
    {
        public void Longtime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void Shorttime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}