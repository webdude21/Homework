// Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters.
// The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key,
// the second – with the second, etc. When the last key character is reached, the next is the first.
namespace EncryptDecrypt
{
    using System;
    using System.Text;

    internal class EncryptDecryptString
    {
        private static void Main()
        {
            var cipher = "@*4Ff(#";
            var input = "This is supposed to be a very secret message";
            try
            {
                var output = EncryptDecrypt(cipher, input);
                Console.WriteLine("This is the encrypted text: \r\n\'{0}'", output);

                // When printing the encrypted message it sometimes happens to generate new line symbols or 
                // carriage return which the printing more difficult
                Console.WriteLine("This is the text decrypted: '{0}'", EncryptDecrypt(cipher, output));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Either the cypher or the input string was null.");
            }
        }

        private static string EncryptDecrypt(string cipher, string input)
        {
            var currentCipherchr = 0;
            var output = new StringBuilder();

            if (cipher == null || input == null)
            {
                throw new ArgumentNullException();
            }

            for (var i = 0; i < input.Length; i++)
            {
                if (currentCipherchr > (cipher.Length - 1))
                {
                    // if we reach the end of the cipher key then we start from the begining again
                    currentCipherchr = 0;
                }

                output.Append((char)(cipher[currentCipherchr] ^ input[i]));
                currentCipherchr++;
            }

            return output.ToString();
        }
    }
}