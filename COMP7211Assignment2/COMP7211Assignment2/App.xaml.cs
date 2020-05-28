using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace COMP7211Assignment2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FlowListView.Init();

            MainPage = new NavigationPage(new LogInPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
