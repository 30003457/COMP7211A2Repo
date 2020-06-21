using Xamarin.Forms;

namespace COMP7211Assignment2.Controller_Folder
{
    //Code by Min 30003457
    internal class ResponsiveController
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
