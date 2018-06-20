namespace Forum.App.Controllers
{
    using System;

    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Services;
    using System.Linq;
    using Forum.App.Views;

    public class CategoryController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        //opisvame si vuzmojnite komandi !!!
        private enum Command { Back = 0, ViewPost = 1, PreviousPage = 11, NextPage = 12 };
        
        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategory(0);
        }

        public int CurrentPage { get; set; }

        public string[] PostTitles { get; set; }
        
        private int LastPage => PostTitles.Length / (PAGE_OFFSET + 1);

        public int CategoryId { get; private set; }
        
        private bool IsFirstPage => CurrentPage == 0;

        private bool IsLastPage => CurrentPage == LastPage;


        public void SetCategory(int categoryId)
        {
            this.CategoryId = categoryId;
        }


        private void ChangePage(bool forward = true) {
            this.CurrentPage += forward ? 1 : -1;
            GetPosts();
        }


        private void GetPosts()
        {
            var allCategoryPosts = PostService.GetPostsByCategory(CategoryId);

            PostTitles = allCategoryPosts
                .Skip(CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .Select(p => p.Title)
                .ToArray();
        }


        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
                index = 1;

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewPost:
                    return MenuState.ViewPost;
                case Command.PreviousPage:
                    ChangePage(false);
                    return MenuState.Rerender;
                case Command.NextPage:
                    ChangePage();
                    return MenuState.Rerender;
            }

            throw new InvalidOperationException();
        }


        public IView GetView(string userName)
        {
            GetPosts();
            var categoryName = PostService.GetCategory(CategoryId).Name;

            return new CategoryView(categoryName, PostTitles, IsFirstPage, IsLastPage);
        }

       



    }
}
