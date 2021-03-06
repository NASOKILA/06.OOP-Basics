﻿using Forum.App.UserInterface.ViewModels;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    internal class PostService
    {
        public static Category GetCategory(int id)
        {
            var forumData = new ForumData();
            Category category = forumData.Categories.SingleOrDefault(c => c.Id == id);
            return category;
        }

        public static IList<ReplyViewModel> GetPostReplies(int postId) {

            var forumdata = new ForumData();

            Post post = forumdata.Posts.Single(p => p.Id == postId);

            List<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (int replyId in post.ReplyIds)
            {
                Reply currentReply = forumdata.Replies.Single(r => r.Id == replyId);

                replies.Add(new ReplyViewModel(currentReply));
            }

            return replies;
        }

        public static string[] GetAllCategoryNames()
        {
            var forumData = new ForumData();
            return forumData.Categories.Select(c => c.Name).ToArray();
        }
		
        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            var forumData = new ForumData();

            var postIds = forumData.Categories.FirstOrDefault(c => c.Id == categoryId).PostIds;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;   
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            var forumdata = new ForumData();

            Post post = forumdata.Posts.SingleOrDefault(p => p.Id == postId);

            return new PostViewModel(post);
        }
		
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

        public static bool TrySavePost(PostViewModel postViewModel) {

            var isTitleValid = !string.IsNullOrWhiteSpace(postViewModel.Title);
            var isContentValid = postViewModel.Content.Any();
            var isCategoryValid = !string.IsNullOrWhiteSpace(postViewModel.Category);

            if (!isTitleValid || !isContentValid || !isCategoryValid)
                return false;
			
            var forumData = new ForumData();
            var category = EnsureCategory(postViewModel, forumData);
            var postId = forumData.Posts.LastOrDefault()?.Id + 1 ?? 1;
            var author = UserService.GetUser(postViewModel.Author, forumData);
            var content = string.Join("", postViewModel.Content);
            var post = new Post(postId, postViewModel.Title, content, category.Id, author.Id, new List<int>());

            forumData.Posts.Add(post);

            category.PostIds.Add(postId);

            author.PostIds.Add(postId);

            forumData.SaveChanges();

            postViewModel.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel replyViewModel, int postId) {

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