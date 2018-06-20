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

        //tuk error mesage ni e string vmesto bool
        private string ErrorMessage { get; set; }

        //pravim si enum za vsichki komandi koito se polzvat v toziz kontroller
        private enum Command {
            ReadUsername,
            ReadPassword,
            SignUp,
            Back
        }

        //Pravim si enum i za statusite
        public enum SignUpStatus
        {
            Success,
            DetailsError,
            UsernameTaken
        }

        //resetva vsichki poleta
        private void ResetSignUp() {
            Username = string.Empty;
            Password = string.Empty;
            ErrorMessage = string.Empty;
        }


        //Izpulnqva komandata v zavisimost kakva e tq
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

                    //opitvame da Registrirame noviq user i ako ne stane vrushtame greshka

                    var signedUpUser = UserService.TrySignUpUser(this.Username, this.Password);

                    switch (signedUpUser) {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:

                            //setvame si Error da e DETAILS_ERROR i go vrushtame
                            ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;
                        case SignUpStatus.UsernameTaken:

                            //setvame si Error da e USERNAME_TAKEN_ERROR i go vrushtame
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
