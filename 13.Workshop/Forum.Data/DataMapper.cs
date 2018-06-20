using Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Forum.Data
{
    class DataMapper
    {
        

        //Store our data file (.csv files)
        private const string DATA_PATH = "../data/";

        //Is stores the configuration file name
        private const string CONFIG_PATH = "config.ini";

        //Stores the 'content' of our configuration file
        private const string DEFAULT_CONFIG =
            "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        //Is the object representation of the configuration file in our class
        private static readonly Dictionary<string, string> config;


        //Helper methods:


        private static void EnsureConfigFile(string configPath) {

            //Checks if the given file exists, if not create a new one by using DEFAULT_CONFIG
            if(!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }

        }

        private static void EnsureFile(string path)
        {
            //if the given file does not exist it creates a new empty one.
            if (!File.Exists(path))
            {
                File.Create(path).Close(); //.Close() closes the file
            }
        }

        //Read lines of files and return them
        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }


        private static Dictionary<string, string> LoadConfig(string configPath) {

            //Proverqvame dali sushtestvuva
            EnsureConfigFile(configPath);

            //chetem vsichko ot nego
            var contents = ReadLines(configPath);

            //vzimme spisuk ot masiv ot stringove i go pravim na rechnik
            var config = contents
                .Select(l => l.Split('='))
                .ToDictionary(l => l[0], l => DATA_PATH + l[1]);

            //vruhtame rechnika s key string imeto na klasa i velue string neshtata v nego.         
            return config;
        }

       
        //Write lines into files
        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        //imame private statichen konstruktor koito zarejda konfiguraciqta.  
        //initialize directory for configuration file and an object config
         static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }



        //Load Categories prochitame gi sus ReadAllLines() metoda i gi pravim na 
        //Category obekti
        public static List<Category> LoadCategories()
        {
            //Vzimame vsichki kategorii kato gi prochitame kato redove i gi parsvame 
            //kum obekti 

            List<Category> categories = new List<Category>();

            var dataLines = ReadLines(config["categories"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                var id = int.Parse(args[0]);

                var name = args[1];
                var postIds = new List<int>();
                if (args.Length >= 3)
                {
                    postIds = args[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                }
                //suzdavame si vsqka kategoriq
                Category category = new Category(id, name, postIds);

                //pulnim categories obekta i nakraq go vrushtame
                categories.Add(category);
            }

            return categories;
        }


        //Save Categories tuk pravim obratnono na gornata funkciq, vzimame obektite 
        //i gi zapisvame sus metoda WriteLines()
        public static void SaveCategories(List<Category> categories)
        {
            //priemame spisuk ot kategorii

            //pravim si spisuk koito da ni durji vsqka kategoriq obache izpisana kato string s daden format
            List<string> lines = new List<string>();

            //pravim si format za vsqka kategoriq s koito da zapulvame tozi spisuk
            const string categoryFormat = "{0};{1};{2}";

            //pulnim toq spisuk sus stringove
            foreach (var category in categories)
            {
                //tuk suzdavame string i polzvame formata.
                string line = string.Format(categoryFormat,
                    category.Id,
                    category.Name,
                    string.Join(",", category.PostIds));

                //vseki string go zapisvame v lines spisuka
                lines.Add(line);
            }

            //i nakraq go izpisvame vuv faila 
            //config["categories"] e putq
            WriteLines(config["categories"], lines.ToArray());
        }

        
        //Load Users
        public static List<User> LoadUsers()
        {

            List<User> users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var userName = args[1];
                var password = args[2];

                var postIds = new List<int>(); 
                if (args.Length >= 4)
                {
                     postIds = args[3]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                }
                User user = new User(id, userName, password, postIds);
                users.Add(user);
            }

            return users;
        }


        //Save Users
        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();
            const string userFormat = "{0};{1};{2};{3}";

            foreach (var user in users)
            {
                string line = string.Format(userFormat,
                    user.Id,
                    user.Username,
                    user.Password,
                    string.Join(",", user.PostIds));

                lines.Add(line);

            }

            WriteLines(config["users"], lines.ToArray());
        }


        //Load Posts
        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();

            var dataLines = ReadLines(config["posts"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                var id = int.Parse(args[0]);

                var title = args[1];

                var content = args[2];

                var categoryId = int.Parse(args[3]);

                var authorId = int.Parse(args[4]);

                var replyIds = new List<int>();
                if (args.Length >= 6)
                {
                    replyIds = args[5]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                }

                Post post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }


        //Save Posts
        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();
            const string postFormat = "{0};{1};{2};{3};{4};{5}";

            foreach (var post in posts)
            {
                string line = string.Format(postFormat,
                    post.Id,
                    post.Title,
                    post.Content,
                    post.CategoryId,
                    post.AuthorId,
                    string.Join(",", post.ReplyIds)
                    );

                lines.Add(line);

            }

            WriteLines(config["posts"], lines.ToArray());
        }


        //Load Replyes
        public static List<Reply> LoadReplies()
        {

            List<Reply> replies = new List<Reply>();

            var dataLines = ReadLines(config["replies"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                var id = int.Parse(args[0]);
                
                var content = args[1];

                var authorId = int.Parse(args[2]);

                var postId = int.Parse(args[3]);

                Reply reply = new Reply(id, content, authorId, postId);

                replies.Add(reply);
            }

            return replies;
        }


        //Save Replyes
        public static void SaveReplies (List<Reply> replies)
        {
            List<string> lines = new List<string>();
            const string postFormat = "{0};{1};{2};{3}";

            foreach (var reply in replies)
            {
                string line = string.Format(postFormat,
                    reply.Id,
                    reply.Content,
                    reply.AuthorId,
                    reply.PostId);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
        
    }
}
