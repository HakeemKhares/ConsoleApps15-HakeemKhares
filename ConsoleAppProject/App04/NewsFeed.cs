using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {

        public List<Post> posts { get; }
        public int itemNumber;
        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();
            
            MessagePost post = new MessagePost("Ye", "I love Kanye");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost("Elon Musk", "Stonks.jpg", "Digest Bitcoin");
            AddPhotoPost(photoPost);
        }


        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public void Display()
        {
            // display all text posts
            foreach (var (item, index) in posts.Select((value, x) => (value, x)))
            {
                itemNumber = index + 1;
                Console.WriteLine("-------------------------");
                Console.WriteLine($"{itemNumber}");
                item.Display();
                Console.WriteLine();
            }
        }
    }

}
