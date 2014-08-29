namespace DecodeAndDecrypt
{
    using System;
    using System.Text;

    internal class DecodeANDDecrypt
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var cypherLenght = GetCipherLenght(input);
            input = Decode(input, cypherLenght);
            var cipher = GetCypher(input, cypherLenght);
            input = StripCipher(input, cypherLenght);
            Console.WriteLine(EncryptDecrypt(input, cipher));
        }

        private static int GetCipherLenght(string input)
        {
            var number = 0;
            var digitPosition = 0;
            for (var ch = input.Length - 1; ch >= 0; ch--)
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

        private static string StripCipher(string input, int cypherLenght)
        {
            input = input.Substring(0, input.Length - cypherLenght.ToString().Length - cypherLenght);
            return input;
        }

        private static string EncryptDecrypt(string message, string cipher)
        {
            var currentCipherchr = 0;
            var output = new StringBuilder();

            if (cipher == null || message == null)
            {
                throw new ArgumentNullException();
            }

            var currentMessage = 0;
            var longer = Math.Max(message.Length, cipher.Length);
            var overRide = false;
            for (var i = 0; i < longer; i++)
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
                    output[currentMessage] =
                        (char)(((cipher[currentCipherchr] - 65) ^ (output[currentMessage] - 65)) + 65);
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

        private static string GetCypher(string input, int cypherLenght)
        {
            string result = null;
            result = input.Substring(input.Length - (cypherLenght + cypherLenght.ToString().Length), cypherLenght);
            return result;
        }

        private static string Decode(string input, int cypherLenght)
        {
            var chrArr = input.ToCharArray(0, input.Length - cypherLenght.ToString().Length);
            var result = new StringBuilder();
            var currNum = 0;

            for (var ch = 0; ch < chrArr.Length; ch++)
            {
                if (char.IsDigit(chrArr[ch]))
                {
                    currNum = (chrArr[ch] - '0') + (currNum * 10);
                }
                else
                {
                    var currChar = input[ch];
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
}