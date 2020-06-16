﻿using COMP7211Assignment2.Controller_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    //Code by Lewis Evans 27033957

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLoginPage : ContentPage
    {
        private ValidatorV3 vd;
        public FirstLoginPage()
        {
            InitializeComponent();
            vd = new ValidatorV3();
        }

        private async void CreatePasswordClicked(object sender, EventArgs e)
        {
            if (vd.ValidateNewPassword(Password1.Text, Password2.Text))
            {
                Password1.Text = null;
                Password2.Text = null;
                await DisplayAlert("Valid", "The password was created successfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Invalid", vd.errorMsg, "OK");
            }

            //if (Password1.Text == null)
            //{
            //    DisplayAlert("Error", "No Password Entered please try again", "OK");
            //}
            //else if (Password2.Text == null)
            //{
            //    DisplayAlert("Error", "No Password Entered please try again", "OK");
            //}
            //else
            //{
            //    DisplayAlert("Success", "Creating Login...", "ok");
            //}

        }
    }
}