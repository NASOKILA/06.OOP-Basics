using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Post
    {
        //Polzvame kombinaciq ot ICollection<> IEnumerable<> i List<> za da mojem da vzemem samo tova koeto ni e nujno
        public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replies)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.ReplyIds = new List<int>(replies);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public ICollection<int> ReplyIds { get; set; }
    }
}
