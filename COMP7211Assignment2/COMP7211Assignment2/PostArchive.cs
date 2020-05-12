using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{ 
    public class PostArchive
{
    private List<Post> PostList = new List<Post>();

    public PostArchive()

    {
        PostList.Add(new Post()
        {
            Subject = "this is a blah...",
            Userpost = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
            " Nunc mollis metus quis nunc egestas dictum. Suspendisse potenti. " +
            "In sed auctor lacus. Nam aliquet metus nec ultrices tincidunt. " +
            "Nunc at molestie turpis. Cras ultrices quam eget dui porta, et" +
            " consectetur nibh pellentesque. Sed non eros viverra, accumsan dolor " +
            "sed, hendrerit ipsum. Vestibulum venenatis varius nisl, quis venenatis " +
            "dui facilisis ac. In mi ipsum, feugiat sed luctus sed, placerat ac quam.",
            Date = new DateTime(2020, 1, 10, 20, 53, 24),

            Upvote = 0,
            Dwnvote = 0,
        });
        PostList.Add(new Post()
        {
            Subject = "Awsome ... blah...",
            Userpost = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
" Nunc mollis metus quis nunc egestas dictum. Suspendisse potenti. " +
"In sed auctor lacus. Nam aliquet metus nec ultrices tincidunt. " +
"Nunc at molestie turpis. Cras ultrices quam eget dui porta, et" +
" consectetur nibh pellentesque. Sed non eros viverra, accumsan dolor " +
"sed, hendrerit ipsum. Vestibulum venenatis varius nisl, quis venenatis " +
"dui facilisis ac. In mi ipsum, feugiat sed luctus sed, placerat ac quam.",
            Date = new DateTime(2020, 07, 10, 20, 54, 3),

            Upvote = 10,
            Dwnvote = 0,
        });
        PostList.Add(new Post()
        {
            Subject = "Blah Blah blah...",
            Userpost = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
" Nunc mollis metus quis nunc egestas dictum. Suspendisse potenti. " +
"In sed auctor lacus. Nam aliquet metus nec ultrices tincidunt. " +
"Nunc at molestie turpis. Cras ultrices quam eget dui porta, et" +
" consectetur nibh pellentesque. Sed non eros viverra, accumsan dolor " +
"sed, hendrerit ipsum. Vestibulum venenatis varius nisl, quis venenatis " +
"dui facilisis ac. In mi ipsum, feugiat sed luctus sed, placerat ac quam.",
            Date = new DateTime(2020, 03, 24, 13, 20, 1),

            Upvote = 25,
            Dwnvote = 20,
        });
    }

    public List<Post> GetPostList
    {
        get
        {
            return PostList;
        }
    }
    public void AddPost(Post pst)
    {
        PostList.Add(pst);
    }

}
}
