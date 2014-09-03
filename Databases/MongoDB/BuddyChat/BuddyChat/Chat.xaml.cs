namespace BuddyChat
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;

    using BuddyChat.Controller;
    using BuddyChat.Model;

    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat
    {
        private readonly ObservableCollection<Post> posts;

        private DateTime lastUpdatDateTime;

        private Thread updatePostAsync;

        public Chat()
        {
            this.posts = new ObservableCollection<Post>();
            this.lastUpdatDateTime = DateTime.UtcNow;
            this.InitializeComponent();
            this.PostListView.ItemsSource = this.posts;
            this.UpdatePostsEachMsAsync();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.updatePostAsync.Abort();
            Application.Current.Shutdown();
        }

        private void ScrollListViewToBottom()
        {
            this.PostListView.SelectedIndex = this.PostListView.Items.Count - 1;
            this.PostListView.ScrollIntoView(this.PostListView.SelectedItem);
        }

        private void OnSendPostButtonClick(object sender, RoutedEventArgs e)
        {
            this.SendPost();
        }

        private void UpdatePosts()
        {
            this.UpdatePosts(DateTime.UtcNow);
        }

        private async void UpdatePosts(DateTime time)
        {
            this.lastUpdatDateTime = time.AddMinutes(-30);
            var getPostsSince = await ChatController.GetPostsSince(this.lastUpdatDateTime);

            foreach (var post in getPostsSince.Where(post => !this.posts.Contains(post)))
            {
                this.posts.Add(post);
            }

            this.ScrollListViewToBottom();
        }

        private void UpdatePostsEachMsAsync(int timeout = 1000)
        {
            this.updatePostAsync = new Thread(
                () =>
                    {
                        while (true)
                        {
                            this.PostListView.Dispatcher.BeginInvoke((Action)this.UpdatePosts);
                            Thread.Sleep(timeout);
                        }
                    });

            this.updatePostAsync.Start();
        }

        private void SendPost()
        {
            var post = this.MessageTextBox.Text;
            if (string.IsNullOrWhiteSpace(post))
            {
                return;
            }

            try
            {
                ChatController.SendPost(post);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Title);
            }
            finally
            {
                this.MessageTextBox.Text = string.Empty;
            }
        }

        private void NewDataPicked(object sender, SelectionChangedEventArgs e)
        {
            var newDate = this.DatePicker.SelectedDate;

            if (newDate == null)
            {
                return;
            }

            this.posts.Clear();
            this.UpdatePosts((DateTime)newDate);
        }
    }
}