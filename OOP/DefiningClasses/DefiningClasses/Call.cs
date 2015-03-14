namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Call
    {
        private const string NumberValidation = @"\A\+{0,2}[\d]{6,30}";

        private static uint idCount = 1;

        private string dialedNumber;

        public Call(string dialedNumber, int durationInSeconds)
        {
            this.DialedNumber = dialedNumber;
            this.Duration = new TimeSpan(0, 0, durationInSeconds);
            this.DateAndTime = DateTime.Now;
            this.Id = idCount++;
        }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
            private set
            {
                if (Regex.IsMatch(value, NumberValidation))
                {
                    this.dialedNumber = value;
                }
                else
                {
                    throw new ArgumentException("The phone number isn't valid, It should be between 6 and 30 digits");
                }
            }
        }

        public TimeSpan Duration { get; private set; }

        public uint Id { get; private set; }

        public DateTime DateAndTime { get; private set; }

        public override string ToString()
        {
            var callInfo = new List<string>
                               {
                                   "Call ID: " + this.Id,
                                   "Time: " + this.DateAndTime.ToShortTimeString(),
                                   "Date: " + this.DateAndTime.ToShortDateString(),
                                   "Dialed Number: " + this.dialedNumber,
                                   "Duration: " + this.Duration
                               };

            return String.Join(", ", callInfo);
        }
    }
}