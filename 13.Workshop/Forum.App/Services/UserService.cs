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


        //Ima dva metoda TrySignUp() i TryLogin()

        //TrySignUp - priema username i parola proverqva dali sa valiedni i ne sa kratki
        //Ako vsichko e ok suzdava nov user i go zapisva 
        public static SignUpStatus TrySignUpUser(string username, string password)
        {

            //proverqvame dali poletata sa validni i da sa s duljina poveche ot 3 sinvola
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                //details error shte ni izpishe che trqbva parolata da e > 3 sinvola i usera da ne e prazen
                return SignUpStatus.DetailsError;
            }


            //tova nie e vruzkata s bazata
            ForumData forumData = new ForumData();

            //proverqvame dali usera veche sushtestvuva
            bool userAlreadyExits = forumData.Users.Any(u => u.Username == username);

            //ako ne sushtestvuva go suzdavame i zapazvame 
            if (!userAlreadyExits)
            {
                //vzimame id-to na posledniq user i go uvelichavame s 1, ako nqma nikakvi useri Id-to e = na 1 !!!
                //LastOrDefault() vrushta posledniq, ako go nqma vrushta null
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

                //suzdavame user, dobavqme go i go zapazvame
                User user = new User(userId, username, password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();
                return SignUpStatus.Success;
            }

            //ako sushtestvuva vrushtame error
            return SignUpStatus.UsernameTaken;
        }

        public static bool TryLoginUser(string username, string password) {

            //i tuk validirame inputite
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                //ako ima greshka v nputite vrushta me false
                return false;
            }


            ForumData forumData = new ForumData();

            //ako inputite sa vlidni proverqvame v bazata dali imat takuv user s takuv username i takava parola.
            bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);
            
            //ako sushtestvuva vrushtame true ako ne false 
            return userExists;
        }
        
        //metod kioto da vzima usera po Id
        public static User GetUser(int id) {

            var forumData = new ForumData();
            User user = forumData.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }

        //metod koito vzima user po username
        public static User GetUser(string username, ForumData forumData) {

            User user = forumData.Users.SingleOrDefault(u => u.Username == username);
            return user;
            
        }

    }
}
