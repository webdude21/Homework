using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Call
{
    private string dialedNumber;
    private const string numberValidation = @"\A\+{0,2}[\d]{6,30}";
    private static uint IdCount = 1;

    public Call(string DialedNumber, int DurationInSeconds)
    {
        this.DialedNumber = DialedNumber;
        this.Duration = new TimeSpan(0,0,DurationInSeconds);
        this.DateAndTime = DateTime.Now;
        this.Id = Call.IdCount++;
    }
    public string DialedNumber
    {
        get {return this.dialedNumber; }
        private set
        {
            if (Regex.IsMatch(value, numberValidation))
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
        List<string> callInfo = new List<string>();

        callInfo.Add("Call ID: " + this.Id);
        callInfo.Add("Time: " + this.DateAndTime.ToShortTimeString());
        callInfo.Add("Date: " + this.DateAndTime.ToShortDateString());
        callInfo.Add("Dialed Number: " + this.dialedNumber);
        callInfo.Add("Duration: " + this.Duration);

        return String.Join(", ", callInfo);
    }
}