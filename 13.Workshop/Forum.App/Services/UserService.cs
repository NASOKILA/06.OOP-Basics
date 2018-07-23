using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                return SignUpStatus.DetailsError;
            }
            
            ForumData forumData = new ForumData();

            bool userAlreadyExits = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExits)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

                User user = new User(userId, username, password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();
                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTaken;
        }

        public static bool TryLoginUser(string username, string password) {

            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);
            
            return userExists;
        }
        
        public static User GetUser(int id) {

            var forumData = new ForumData();
            User user = forumData.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }

        public static User GetUser(string username, ForumData forumData) {

            User user = forumData.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }
    }
}