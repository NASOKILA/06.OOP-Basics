namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using Forum.Models;
    using System.Linq;

    public class AddReplyController : IController
    {

        //opisvame si komandite v kontrollera
        private enum Command { Write, Post };
        
        private static int centerTop = Position.ConsoleCenter().Top;

        private static int centerLeft = Position.ConsoleCenter().Left;

        public ReplyViewModel Reply { get; private set; }

        public TextArea TextArea { get; set; }

        public bool Error { get; private set; }

        public void ResetReply()
        {
            this.Error = false;

            this.Reply = new ReplyViewModel();

            int contentLength = postViewModel?.Content.Count ?? 0;

            this.TextArea = new TextArea(centerLeft - 18, centerTop + contentLength - 7,
                TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);

        }
        
        private PostViewModel postViewModel;
        
        public AddReplyController()
        {

        }

        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {

                case Command.Write:
                    TextArea.Write();
                    Reply.Content = TextArea.Lines.ToArray();
                    return MenuState.AddPost;
                case Command.Post:

                    //Opitvame se da adnem posta i ako ne uspeem setvame Error na true i Rirendvame
                    var replyAdded = PostService.TrySaveReply(Reply, postViewModel.PostId);
                    if (!replyAdded)
                    {
                        Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            return new AddReplyView(this.postViewModel, this.Reply, this.TextArea, this.Error);

        }


        //metod za setvame na post id
        public void SetPostId(int postId)
        {
            postViewModel = PostService.GetPostViewModel(postId);   
        }

    }
}
