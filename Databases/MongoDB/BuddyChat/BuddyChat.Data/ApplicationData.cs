namespace BuddyChat.Data
{
    using System.Collections.ObjectModel;

    using BuddyChat.Model;

    public class ApplicationData
    {
        public ApplicationData(ObservableCollection<Post> posts)
        {
            this.Posts = posts;
        }

        public ApplicationData()
            : this(new ObservableCollection<Post>())
        {
        }

        public ObservableCollection<Post> Posts { get; set; }
    }
}