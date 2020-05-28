using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace COMP7211Assignment2
{
    //Patrick crampton
    //basic email program  to send an email  and attachment  for the rep report
    public partial class Email : ContentPage
    {
        public Email()
        {
            InitializeComponent();
        }




        private void Button_Clicked(object sender, EventArgs e)
        {
            EmailMessage message = new EmailMessage(EntrySubject.Text, EditorBody.Text, EntryEmailAddress.Text)
            {
                BodyFormat = EmailBodyFormat.PlainText

            };
            string fn = "Attachment.txt";
            string file = Path.Combine(FileSystem.CacheDirectory, fn);

            File.WriteAllText(file, "Student Repp APP report");

            message.Attachments.Add(new EmailAttachment(file));

        }




        private static Task ComposeAsync(EmailMessage message)
        {
            throw new NotImplementedException();
        }

    }
}
