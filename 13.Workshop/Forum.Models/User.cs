using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class User
    {
        //Polzvame kombinaciq ot ICollection<> IEnumerable<> i List<> za da mojem da vzemem samo tova koeto ni e nujno
        public User(int id, string username, string password, IEnumerable<int> posts)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PostIds = new List<int>(posts);
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<int> PostIds { get; set; }

    }
}
