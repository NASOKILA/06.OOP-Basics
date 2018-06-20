namespace Forum.App.UserInterface.ViewModels
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using Forum.App.Services;
    using System.Linq;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel()
        {
            Content = new List<string>();
        }

        public ReplyViewModel(Reply reply)
        {
            Author = UserService.GetUser(reply.AuthorId).Username;
            Content = GetLines(reply.Content);
        }



        public string Author { get; set; }

        public IList<string> Content { get; set; }

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
    }
}