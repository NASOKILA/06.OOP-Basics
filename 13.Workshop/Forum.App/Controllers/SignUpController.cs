namespace Forum.App.Controllers
{
	using Forum.App;
	using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using System;

    public class SignUpController : IController, IReadUserInfoController
	{
		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; set; }
        public string Password { get; set; }

        private string ErrorMessage { get; set; }

        private enum Command {
            ReadUsername,
            ReadPassword,
            SignUp,
            Back
        }

        public enum SignUpStatus
        {
            Success,
            DetailsError,
            UsernameTaken
        }

        private void ResetSignUp() {
            Username = string.Empty;
            Password = string.Empty;
            ErrorMessage = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:

                    var signedUpUser = UserService.TrySignUpUser(this.Username, this.Password);

                    switch (signedUpUser) {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:

                            ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;
                        case SignUpStatus.UsernameTaken:

                            ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                    }
                    
                    return MenuState.Error;
                case Command.Back:
                    ResetSignUp();
                    return MenuState.Back;
                default:
                    throw new NotSupportedException();
            }
        }

        public IView GetView(string userName)
        {
            return new SignUpView(ErrorMessage);
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