namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;
    using System;

    public class LogInController : IController, IReadUserInfoController
    {
        public string Username { get; private set; }
        
        //Not part of the interface, needed only for inner usage
        private string Password { get; set; }

        //Not part of the interface, needed only for inner usage
        private bool Error { get; set; }

        //all commands for the login controller
        private enum Command {
            ReadUsername,
            ReadPassword,
            LogIn,
            Back
        }

        //its clear what it does it resets the username and pasword fields and sets error to false
        private void ResetLogin() {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }


        //konstruktura prosto resetva poletata kato izvikva ResetLogin
        public LogInController()
        {
            this.ResetLogin();
        }

        
        //Izpulnqva komandata v zavisimost kakva e tq
        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Login;
                case Command.LogIn:
                    //Log in user
                    //Opitvame da lognem usera, ako stane vrushtame success message ako ne Error:
                    var userLoggedIn = UserService.TryLoginUser(Username, Password);

                    if (userLoggedIn)
                        return MenuState.SuccessfulLogIn;

                    return MenuState.Error;
                case Command.Back:
                    ResetLogin();
                    return MenuState.Back;
                default:
                    throw new InvalidOperationException();
            }
        }

        //izvikva se ot RenderCurrentView() main controllera,
        //metoda vrushta view
        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }


    }
}
