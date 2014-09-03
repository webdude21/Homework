namespace BuddyChat.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using BuddyChat.Data;
    using BuddyChat.Model;

    public static class ChatController
    {
        static ChatController()
        {
            MongoDatabase = new MongoDbContext();
        }

        public static User User { get; set; }

        public static MongoDbContext MongoDatabase { get; set; }

        public static ObservableCollection<Post> GetPostCollection()
        {
            var collection = new ObservableCollection<Post>(MongoDatabase.GetList<Post>());
            ConvertToCurrentDateTimeNow(collection);
            return collection;
        }

        public static void SendPost(string post)
        {
            MongoDatabase.Insert(new Post { Content = post, PostedOn = DateTime.UtcNow, PostedBy = User.Name });
        }

        public static void ConvertToCurrentDateTimeNow(IEnumerable<Post> posts)
        {
            foreach (var post in posts)
            {
                post.PostedOn = post.PostedOn.ToLocalTime();
            }
        }

        public static Task<IList<Post>> GetPostsSince(DateTime time)
        {
            return Task.Run(
                () =>
                    {
                        var result = MongoDatabase.GetPostsSince(time);
                        ConvertToCurrentDateTimeNow(result);
                        return result;
                    });
        }
    }
}