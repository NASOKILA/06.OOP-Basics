namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;

    public class PostDetailsController : IController, IUserRestrictedController
    {

        public bool LoggedInUser { get; set; }

        //opisvame si neshtata koito moje da pravi tozi kontroller
        private enum Command { Back, AddRepply};
        
        public int PostId { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
                index = 1;

            switch ((Command)index)
            {
                case Command.AddRepply:
                    return MenuState.AddReplyToPost;
                case Command.Back:
                    ForumViewEngine.ResetBuffer();  //resetvame bufera i se vrushtame obratno 
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            var postViewModel = PostService.GetPostViewModel(PostId);
            return new PostDetailsView(postViewModel);
        }


        //polzvame slednite dva metoda za da kajem da li usera e lognat ili ne kato setvame LoggedIn promenlivata
        //na true ili na false
        public void UserLogIn()
        {
            LoggedInUser = true;
        }

        public void UserLogOut()
        {
            LoggedInUser = false;
        }

        //setvame postId-to
        public void SetPostId(int postId) {
            PostId = postId;
        }


    }
}
