using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App
{
    public class ForumData
    {
        //this class is a holder of all our data so far

        //Pri suzdavaneto na konstruktura nie izvikvame Load() metodite ot DataMappera.
        public ForumData()
        {
            this.Users = DataMapper.LoadUsers();
            this.Categories = DataMapper.LoadCategories();
            this.Posts = DataMapper.LoadPosts();
            this.Replies = DataMapper.LoadReplies();
        }

        public List<Category> Categories { get; set; }

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

        public List<Reply> Replies { get; set; }


        //method to save the changes made on our collections:
        public void SaveChanges()
        {
            DataMapper.SaveUsers(this.Users);
            DataMapper.SavePosts(this.Posts);
            DataMapper.SaveReplies(this.Replies);
            DataMapper.SaveCategories(this.Categories);

        }


    }
}
