using System;
using System.Text;
using System.Text.RegularExpressions;

class EncodeAndEncrypt
{
    static void Main()
    {
        string message = Console.ReadLine();
        string cipher = Console.ReadLine();
        Console.WriteLine(Encode((Encrypt(message, cipher) + cipher) + cipher.Length));
    }

    static string Encode(string message)
    {
        while (Regex.IsMatch(message, @"([\D])\1{2,}"))
        {
            message = Regex.Replace(message, @"([\D])\1{2,}", x => x.Value.Length.ToString() + x.Value[0]);
        }
        return message;
    }

    static string Encrypt(string message, string cipher)
    {
        int cipherIndex = 0;
        int messageIndex = 0;
        char baseChar = 'A';
        StringBuilder output = new StringBuilder();
        int longer = Math.Max(message.Length, cipher.Length);
        bool overWrite = false;

        for (int i = 0; i < longer; i++)
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
                output[messageIndex] = (char)(((cipher[cipherIndex] - baseChar) ^ (output[messageIndex] - baseChar)) + baseChar);
            }
            else
            {
                output.Append((char)(((cipher[cipherIndex] - baseChar) ^ (message[messageIndex] - baseChar)) + baseChar));
            }
            cipherIndex++;
            messageIndex++;
        }
        return output.ToString();
    }
}