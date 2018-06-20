namespace Forum.App.Controllers
{
    using System;

    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;
    using System.Linq;
    using Forum.App.Services;

    public class CategoriesController : IController, IPaginationController
    {
        
        public const int PAGE_OFFSET = 10;

        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public CategoriesController()
        {
            CurrentPage = 0;
            LoadCategories();
        }

        //opisvame si vuzmojnite komandi !!!
        private enum Command { Back = 0, ViewCategory = 1, PreviousPage = 11, NextPage = 12 };

        public int CurrentPage { get; set; }

        //pravim si i nqkolko novi propertita:
        public string[] AllCategoriesName { get; set; }

        public string[] CurrentPageCategories { get; set; }

        private int LastPage => AllCategoriesName.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => CurrentPage == 0;

        private bool IsLastPage => CurrentPage == LastPage;

        //change page uvelichavame i namalqvame s 1kogato otidem i se vurnem ot dadena stranica.
        private void ChangePage(bool forward = true)
        {
            //ili uvelichavame s 1 ili s -1 t.e. namalqvame 
            CurrentPage += forward ? 1 : -1;
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
                index = 1;

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewCategory:
                    return MenuState.OpenCategory;
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
            //zarejdame gi vsichki kategorii
            LoadCategories();

            //podavame kum viewto samo tezi koito sa za tazi stranica    
            //IsFirstPage, IsLastPage sa za da reshi kude da sloji butonite napred i nazad 
            return new CategoriesView(CurrentPageCategories, IsFirstPage, IsLastPage);
        }

        //Trqbva da zaredim kategoriite za tekushtata stranica
        private void LoadCategories()
        {
            //ako sme na purva stranica skipvame 0 i vzimame 10
            //ako sme na vtorata skipvame 10 i vzimame 10 i t.n. ...
            AllCategoriesName = PostService.GetAllCategoryNames();

            CurrentPageCategories = AllCategoriesName
                .Skip(CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .ToArray();
        }
    }
}
