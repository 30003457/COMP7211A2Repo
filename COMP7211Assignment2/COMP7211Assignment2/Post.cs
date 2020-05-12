using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{
 public class Post
{
        public string Subject { get; set; }
        public string Userpost { get; set; }
  
        public DateTime Date { get; set; }
        
        public int Upvote { get; set;}
        public int Dwnvote { get; set; }

        public string PostSummary
        {
            get
            {
                return $"Subject : {this.Subject}\n\n Post: {this.Userpost}\n\n" +
                    $" Date: {this.Date.ToString("d")} \n\n " +
                    $"Total DownVotes: {this.Dwnvote} \t Total UpVotes{this.Upvote}|\n\n\n";
            }
        }

}
}
