namespace EncodeAndEncrypt
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class EncodeAndEncrypt
    {
        private static void Main()
        {
            var message = Console.ReadLine();
            var cipher = Console.ReadLine();
            Console.WriteLine(Encode((Encrypt(message, cipher) + cipher) + cipher.Length));
        }

        private static string Encode(string message)
        {
            while (Regex.IsMatch(message, @"([\D])\1{2,}"))
            {
                message = Regex.Replace(message, @"([\D])\1{2,}", x => x.Value.Length.ToString() + x.Value[0]);
            }

            return message;
        }

        private static string Encrypt(string message, string cipher)
        {
            var cipherIndex = 0;
            var messageIndex = 0;
            var baseChar = 'A';
            var output = new StringBuilder();
            var longer = Math.Max(message.Length, cipher.Length);
            var overWrite = false;

            for (var i = 0; i < longer; i++)
            {
                if (cipherIndex >= cipher.Length)
                {
                    cipherIndex = 0;
                }

                if (messageIndex >= message.Length)
                {
                    messageIndex = 0;
                    overWrite = !overWrite;
                }

                if (overWrite)
                {
                    output[messageIndex] =
                        (char)(((cipher[cipherIndex] - baseChar) ^ (output[messageIndex] - baseChar)) + baseChar);
                }
                else
                {
                    output.Append(
                        (char)(((cipher[cipherIndex] - baseChar) ^ (message[messageIndex] - baseChar)) + baseChar));
                }

                cipherIndex++;
                messageIndex++;
            }

            return output.ToString();
        }
    }
}