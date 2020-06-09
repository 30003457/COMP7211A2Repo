using COMP7211Assignment2.Model_Folder;
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
    public partial class ReplyPostPage : ContentPage
    {
        public ReplyPostPage()
        {
            InitializeComponent();
            lblStatus.Text = PageData.PManager.UpdateStatusText();
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostViewPageTama());
        }
    }
}