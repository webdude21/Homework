namespace BuddyChat
{
    using System;
    using System.Windows;

    using BuddyChat.Controller;

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        public Login()
        {
            this.InitializeComponent();
            this.InitialLogic();
        }

        private void InitialLogic()
        {
            this.UserNameTextBox.Focus();
        }

        private void SuccesfullLogin()
        {
            var mainWindow = new Chat();
            this.Close();
            mainWindow.Show();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginController.Login(this.UserNameTextBox.Text);
                this.SuccesfullLogin();
            }
            catch (ArgumentException errorMessage)
            {
                MessageBox.Show(errorMessage.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}