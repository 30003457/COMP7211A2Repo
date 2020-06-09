using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace COMP7211Assignment2.Controller_Folder
{
    class ResponsiveController
    {
        public StackLayout LandscapeStack(StackLayout stack)
        {
            stack.Orientation = StackOrientation.Horizontal;
            return stack;
        }
        public StackLayout PortraitStack(StackLayout stack)
        {
            stack.Orientation = StackOrientation.Vertical;
            return stack;
        }
    }
}
