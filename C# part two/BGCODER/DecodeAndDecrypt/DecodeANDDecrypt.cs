using System;
using System.Text;

class DecodeANDDecrypt
{
    static void Main()
    {
        string input = Console.ReadLine();
        int cypherLenght = GetCipherLenght(input);
        input = Decode(input, cypherLenght);
        string cipher = GetCypher(input, cypherLenght);
        input = StripCipher(input, cypherLenght);
        Console.WriteLine(EncryptDecrypt(input, cipher));
    }

    static int GetCipherLenght(string input)
    {
        int number = 0;
        int digitPosition = 0;
        for (int ch = input.Length - 1; ch >= 0; ch--)
        {
            if (char.IsDigit(input[ch]))
            {
                number = number + ((input[ch] - '0') * (int)Math.Pow(10, digitPosition));
                digitPosition++;
            }
            else
            {
                return number;
            }
        }

        return number;
    }

    static string StripCipher(string input, int cypherLenght)
    {
        input = input.Substring(0, input.Length - cypherLenght.ToString().Length - (cypherLenght));
        return input;
    }

    static string EncryptDecrypt(string message, string cipher)
    {
        int currentCipherchr = 0;
        StringBuilder output = new StringBuilder();

        if (cipher == null || message == null)
        {
            throw (new ArgumentNullException());
        }

        int currentMessage = 0;
        int longer = Math.Max(message.Length, cipher.Length);
        bool overRide = false;
        for (int i = 0; i < longer; i++)
        {
            if (currentCipherchr > (cipher.Length - 1))
            {
                // if we reach the end of the cipher key then we start from the beginning again
                currentCipherchr = 0;
            }

            if (currentMessage > (message.Length - 1))
            {
                currentMessage = 0;
                overRide = !overRide;
            }

            if (overRide)
            {
                output[currentMessage] = (char)(((cipher[currentCipherchr] - 65) ^ (output[currentMessage] - 65)) + 65);
                currentCipherchr++;
                currentMessage++;
            }
            else
            {
                output.Append((char)(((cipher[currentCipherchr] - 65) ^ (message[currentMessage] - 65)) + 65));
                currentCipherchr++;
                currentMessage++;
            }
        }

        return output.ToString();
    }

    static string GetCypher(string input, int cypherLenght)
    {
        string result = null;
        result = input.Substring(input.Length - (cypherLenght + cypherLenght.ToString().Length), cypherLenght);
        return result;
    }

    static string Decode(string input, int cypherLenght)
    {
        char[] chrArr = input.ToCharArray(0, input.Length - cypherLenght.ToString().Length);
        StringBuilder result = new StringBuilder();
        int currNum = 0;

        for (int ch = 0; ch < chrArr.Length; ch++)
        {
            if (Char.IsDigit(chrArr[ch]))
            {
                currNum = (chrArr[ch] - '0') + (currNum * 10);
            }
            else
            {
                char currChar = input[ch];
                if (currNum > 0)
                {
                    result.Append(new string(currChar, currNum));
                    currNum = 0;
                }
                else
                {
                    result.Append(currChar);
                }
            }
        }
        result.Append(cypherLenght.ToString());
        return result.ToString();
    }
}