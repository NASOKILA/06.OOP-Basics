﻿namespace Forum.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Controllers;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Services;

    internal class MenuController
    {
        private const int DEFAULT_INDEX = 0;
        private IController[] controllers;
        private Stack<int> controllerHistory;
        private int currentOptionIndex;
        private ForumViewEngine forumViewer;

        public MenuController(IEnumerable<IController> controllers, ForumViewEngine forumViewer)
        {
            this.controllers = controllers.ToArray();
            this.forumViewer = forumViewer;

            InitializeControllerHistory();

            this.currentOptionIndex = DEFAULT_INDEX;
        }

        private string Username { get; set; }
        private IView CurrentView { get; set; }

        private MenuState State => (MenuState)controllerHistory.Peek();

        private int CurrentControllerIndex => this.controllerHistory.Peek();

        private IController CurrentController => this.controllers[this.controllerHistory.Peek()];

        internal ILabel CurrentLabel => this.CurrentView.Buttons[currentOptionIndex];

        private void InitializeControllerHistory()
        {
            if (controllerHistory != null)
            {
                throw new InvalidOperationException($"{nameof(controllerHistory)} already initialized!");
            }
            int mainControllerIndex = 0;
            this.controllerHistory = new Stack<int>();
            this.controllerHistory.Push(mainControllerIndex);
            this.RenderCurrentView();
        }

        internal void PreviousOption()
        {
            this.currentOptionIndex--;

            if (this.currentOptionIndex < 0)
            {
                this.currentOptionIndex += this.CurrentView.Buttons.Length;
            }

            if (this.CurrentLabel.IsHidden)
            {
                this.PreviousOption();
            }
        }

        internal void NextOption()
        {
            this.currentOptionIndex++;

            int totalOptions = this.CurrentView.Buttons.Length;

            if (this.currentOptionIndex >= totalOptions)
            {
                this.currentOptionIndex -= totalOptions;
            }

            if (this.CurrentLabel.IsHidden)
            {
                this.NextOption();
            }
        }

        internal void Back()
        {
            if (this.State == MenuState.Categories || this.State == MenuState.OpenCategory)
            {
                IPaginationController currentController = (IPaginationController)this.CurrentController;
                currentController.CurrentPage = 0;
            }

            if (controllerHistory.Count > 1)
            {
                controllerHistory.Pop();
                this.currentOptionIndex = DEFAULT_INDEX;
            }
            RenderCurrentView();
        }

        internal void ExecuteCommand()
        {
            MenuState newState = this.CurrentController.ExecuteCommand(currentOptionIndex);
            switch (newState)
            {
                case MenuState.PostAdded:
                    AddPost();
                    break;
                case MenuState.OpenCategory:
                    OpenCategory();
                    break;
                case MenuState.ViewPost:
                    ViewPost();
                    break;
                case MenuState.SuccessfulLogIn:
                    SuccessfulLogin();
                    break;
                case MenuState.LoggedOut:
                    LogOut();
                    break;
                case MenuState.Back:
                    this.Back();
                    break;
				case MenuState.Error:
                case MenuState.Rerender:
                    RenderCurrentView();
                    break;
                case MenuState.AddReplyToPost:
                    RedirectToAddReply();
                    break;
                case MenuState.ReplyAdded:
                    AddReply();
                    break;
                default:
                    this.RedirectToMenu(newState);
                    break;
            }
        }


        private bool RedirectToMenu(MenuState newState) {

            if (this.State != newState) {
                
                this.controllerHistory.Push((int)newState);

                this.RenderCurrentView();

                return true;
            }

            return false;
        }

        private void AddReply()
        {
            Back();
        }

        private void RedirectToAddReply()
        {
            var postDetaisController = (PostDetailsController)this.CurrentController;

            var addReplyController = (AddReplyController)this.controllers[(int)MenuState.AddReply];

            addReplyController.SetPostId(postDetaisController.PostId);

            RedirectToMenu(MenuState.AddReplyToPost);

        }

        private void LogOut()
        {
            this.Username = string.Empty; 
            this.LogOutUser(); 
            this.RenderCurrentView(); 
        }

        private void SuccessfulLogin()
        {
            this.Username = ((IReadUserInfoController)CurrentController).Username;
            LogInUser(); 
            RedirectToMenu(MenuState.Main); 
        }

        private void ViewPost()
        {
            var categoryController = (CategoryController)this.CurrentController;
            var categoryId = categoryController.CategoryId;

            var posts = PostService.GetPostsByCategory(categoryId).ToArray();

            var postIndex = categoryController.CurrentPage * CategoryController.PAGE_OFFSET + this.currentOptionIndex;

            var post = posts[postIndex - 1];

            var postDetailsController = (PostDetailsController)this.controllers[(int)MenuState.ViewPost];
            postDetailsController.SetPostId(post.Id);

            RedirectToMenu(MenuState.ViewPost);
        }

        private void OpenCategory()
        {
            var categoriesContoller = (CategoriesController)this.CurrentController;

            int categoryIndex = categoriesContoller.CurrentPage * CategoriesController.PAGE_OFFSET +
                this.currentOptionIndex;

            var categoryCtrlr = (CategoryController)this.controllers[(int)MenuState.OpenCategory];
            categoryCtrlr.SetCategory(categoryIndex);

            this.RedirectToMenu(MenuState.OpenCategory);
        }

        private void AddPost()
        {
            var addPostController = (AddPostController)this.CurrentController;

            var postId = addPostController.Post.PostId;

            var postViewer = (PostDetailsController)this.controllers[(int)MenuState.ViewPost];

            postViewer.SetPostId(postId);

            addPostController.ResetPost();

            this.controllerHistory.Pop();

            this.RedirectToMenu(MenuState.ViewPost);
        }

        private void RenderCurrentView()
        {
            this.CurrentView = this.CurrentController.GetView(this.Username);
            this.currentOptionIndex = DEFAULT_INDEX;
            this.forumViewer.RenderView(this.CurrentView);
        }        

        private void LogInUser()
        {
            foreach (var controller in controllers)
            {
                if (controller is IUserRestrictedController userRestrictedController)
                {
                    userRestrictedController.UserLogIn();
                }
            }
        }

        private void LogOutUser()
        {
            foreach (var controller in controllers)
            {
                if (controller is IUserRestrictedController userRestrictedController)
                {
                    userRestrictedController.UserLogOut();
                }
            }
        }
    }
}