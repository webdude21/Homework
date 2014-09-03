namespace BuddyChat.Controller
{
    using System;

    using BuddyChat.Model;

    public static class LoginController
    {
        private const int MaxUsernameLength = 20;

        private const int MinUserNameLenght = 2;

        private const string InvalidUserMessage =
            "You must type a valid username with with between {0} and {1} characters";

        public static void Login(string username)
        {
            if (!IsValidUsername(username))
            {
                throw new ArgumentException(string.Format(InvalidUserMessage, MinUserNameLenght, MaxUsernameLength));
            }

            ChatController.User = new User(username);
        }

        private static bool IsValidUsername(string username)
        {
            var isUsernameValid = !string.IsNullOrWhiteSpace(username) && username.Length <= MaxUsernameLength
                                  && username.Length >= MinUserNameLenght;
            return isUsernameValid;
        }
    }
}