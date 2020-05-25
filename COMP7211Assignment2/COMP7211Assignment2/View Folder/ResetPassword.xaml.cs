using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword 
    {
        public ResetPassword()
        {
            InitializeComponent();
        }
        
       
        private void Button1(object sender, EventArgs e)
        {
            if (resetlink.Text==null)
            {
                var message = "Please enter a Email ID";
                DependencyService.Get<IMessage>().Longtime(message);
            }
            else 
            { 
            var message = "Link has been send!";
            DependencyService.Get<IMessage>().Longtime(message);
            }
        }
    }
}
