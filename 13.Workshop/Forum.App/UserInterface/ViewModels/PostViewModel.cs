namespace Forum.App.UserInterface.ViewModels
{
    using Forum.App.Services;
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        //vzimame si vsichko keto ni e nujno v konstruktura
        public PostViewModel(Post post)
        {
            Author = UserService.GetUser(post.AuthorId).Username;
            Category = PostService.GetCategory(post.CategoryId).Name;
            Title = post.Title;
            PostId = post.Id;
            Content = GetLines(post.Content);
            Replies = PostService.GetPostReplies(post.Id);
        }

        public PostViewModel()
        {
            Content = new List<string>();
        }

        private IList<string> GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            IList<string> lines = new List<string>();

            //vzimame vseki 37mi sinvol
            for (int i = 0; i < content.Length; i += LINE_LENGHT)
            {
                char[] row = contentChars.Skip(i).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }

    }
}







