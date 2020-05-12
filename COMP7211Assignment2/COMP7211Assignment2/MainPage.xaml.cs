using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace COMP7211Assignment2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public PostArchive posts = new PostArchive();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = posts;
        }



        private void BtnDwnVote_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnUpVote_Clicked(object sender, EventArgs e)
        {

        }
    }
}

