using Forum.App.UserInterface.ViewModels;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    internal class PostService
    {

        //pravim si metod koito da ni vzima kategoriqta po id
        public static Category GetCategory(int id)
        {
            var forumData = new ForumData();
            Category category = forumData.Categories.SingleOrDefault(c => c.Id == id);
            return category;
        }

        //vzimame Replies na dadeniq Post i gi ravim na ReplyViewModel
        public static IList<ReplyViewModel> GetPostReplies(int postId) {

            var forumdata = new ForumData();

            Post post = forumdata.Posts.Single(p => p.Id == postId);

            List<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (int replyId in post.ReplyIds)
            {
                Reply currentReply = forumdata.Replies.Single(r => r.Id == replyId);

                //suzdavame replyViewModel kato mu podavame Reply i gi slagame vsichi v spisuka
                replies.Add(new ReplyViewModel(currentReply));
            }

            //vrushtame spisuka sus vsichi ReplyViewModel
            return replies;
        }

        //Metod za vzimane na vsichki imena na kategorii:
        public static string[] GetAllCategoryNames()
        {
            var forumData = new ForumData();
            return forumData.Categories.Select(c => c.Name).ToArray();
        }

        //Metod za namirane na post po kategoriq
        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            var forumData = new ForumData();

            var postIds = forumData.Categories.FirstOrDefault(c => c.Id == categoryId).PostIds;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;   
        }

        //trqbva ni metod koito da ni zarejda PostViewModel-a
        public static PostViewModel GetPostViewModel(int postId)
        {
            var forumdata = new ForumData();

            //namirame post i go vrushtame kato si pravim nov PostViewModel
            Post post = forumdata.Posts.SingleOrDefault(p => p.Id == postId);

            return new PostViewModel(post);
        }

        //metod koit oproverqva dali dadena katregoriq sushtestvuva
        public static Category EnsureCategory(PostViewModel postViewModel, ForumData forumData)
        {
            var category = forumData.Categories.SingleOrDefault(c => c.Name == postViewModel.Category);
            if (category == null)
            {
                var id = forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;

                category = new Category(id, postViewModel.Category, new List<int>());
                forumData.Categories.Add(category);
                forumData.SaveChanges();
            }

            return category;
        }

        //metod koito se opiva da zapzi daden post
        public static bool TrySavePost(PostViewModel postViewModel) {

           
            //proverqvame dali posta, kategoriite i kontenta sa validni 
            var isTitleValid = !string.IsNullOrWhiteSpace(postViewModel.Title);
            var isContentValid = postViewModel.Content.Any();
            var isCategoryValid = !string.IsNullOrWhiteSpace(postViewModel.Category);

            //proverqvame dali sa validni i trite
            if (!isTitleValid || !isContentValid || !isCategoryValid)
                return false;

            //proverqvame dali kategoriqta sushtestvuva
            var forumData = new ForumData();
            var category = EnsureCategory(postViewModel, forumData);

            //smqtame si idto na posta
            var postId = forumData.Posts.LastOrDefault()?.Id + 1 ?? 1;

            //posle vzimame avtora na tozi post go zapisvame v bazta (.csv faila) 
            var author = UserService.GetUser(postViewModel.Author, forumData);
            var content = string.Join("", postViewModel.Content);
            var post = new Post(postId, postViewModel.Title, content, category.Id, author.Id, new List<int>());

            //dobavqme posta v postovete 
            forumData.Posts.Add(post);

            //dobavqme id-to na posta v PistId-tata na tazi kategoriq
            category.PostIds.Add(postId);

            //dobavqme idto na posta i kum tezi na avtora
            author.PostIds.Add(postId);

            //zapazvame promenite
            forumData.SaveChanges();

            //setvame post id-to
            postViewModel.PostId = postId;

            return true;
        }

        //metod koito da ni zapzva reply za vseki post
        public static bool TrySaveReply(ReplyViewModel replyViewModel, int postId) {

            //ako nqma kontent vrushtame false
            if (!replyViewModel.Content.Any())
                return false;

            var forumData = new ForumData();
            var author = UserService.GetUser(replyViewModel.Author, forumData);
            var post = forumData.Posts.Single(p => p.Id == postId);
            var replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            var content = string.Join("", replyViewModel.Content);
            var reply = new Reply(replyId, content, author.Id, postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);

            forumData.SaveChanges();
            return true;
        }


    }
}



