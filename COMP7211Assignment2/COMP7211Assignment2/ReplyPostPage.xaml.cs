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
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostPageTama());
        }
    }
}