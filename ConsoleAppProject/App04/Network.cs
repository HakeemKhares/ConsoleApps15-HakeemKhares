using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject.App04
{
    public class Network
    {
        private NewsFeed news = new NewsFeed(); 

        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("News Feed");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "News Feed", "Like Post", "Unlike Post","Remove Post","Comment", "Quit"
            };

            bool wantToQuit = false;
            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);

                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisplayAll(); break;
                    case 4: LikePost(); break;
                    case 5: UnlikePost(); break;
                    case 6: RemovePost(); break;
                    case 7: Comment(); break;
                    case 8: wantToQuit = true;   break;
                }
            } while (!wantToQuit);
        }

        private void Comment()
        {
            DisplayAll();
            int number = (int)ConsoleHelper.InputNumber("Enter the post number that you would like to add a commnent to : ", 1, news.posts.Count);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("You will comment on the below post");
            news.posts[number - 1].Display();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Enter the comment that you would like to add");
            string text = Console.ReadLine();
            Console.WriteLine($"You felt the need to tell OP:{text}");
        }

        private void RemovePost()
        {
            DisplayAll();
            int number = (int)ConsoleHelper.InputNumber("Which post do you want to delete : ", 1, news.posts.Count);

            Console.WriteLine("---------------------------------");
            Console.WriteLine("You will remove the below post");
            news.posts[number - 1].Display();
            news.posts.RemoveAt(number - 1);
        }

        private void UnlikePost()
        {
            DisplayAll();
            int number = (int)ConsoleHelper.InputNumber("Which post would you like to unlike : ", 1, news.posts.Count);

            news.posts[number - 1].Unlike();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("You revoked your positive attitude.");
            news.posts[number - 1].Display();
        }

        private void LikePost()
        {
            DisplayAll();
            int number = (int)ConsoleHelper.InputNumber("Which post would you like to like : ", 1, news.posts.Count);

            news.posts[number - 1].Like();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("You gave this person a sense of self worth.");
            // this displays the liked post w/ new additional like
            news.posts[number - 1].Display();
        }

        private void DisplayAll()
        {
            news.Display();
        }

        private void PostImage()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Username:");
            string author = Console.ReadLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Filename:");
            string filename = Console.ReadLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("What the hell is going on?");
            string caption = Console.ReadLine();

            PhotoPost photoPost = new PhotoPost(author, filename, caption);
            news.AddPhotoPost(photoPost);

            Console.WriteLine("---------------------------------");
            Console.WriteLine("The internet won't be forgetting that anytime soon.");

            photoPost.Display();
        }

        private void PostMessage()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Username:");
            string author = Console.ReadLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("What're you trying to say?:");
            string message = Console.ReadLine();

            MessagePost messagePost = new MessagePost(author, message);
            news.AddMessagePost(messagePost);
            Console.WriteLine();
            messagePost.Display();
        }
    }
}
