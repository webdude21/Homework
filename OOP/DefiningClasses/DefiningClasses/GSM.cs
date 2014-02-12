using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

public class GSM
{
    // Fields
    private static readonly GSM iphone4S = new GSM("IPhone-4S", "Apple", 900, "Pesho", new Display(4.5, Display.ColorDepth._32Bit),
        new Battery("sanyo-321r54D", 120, 14, Battery.Type.LiPol));
    private string name;
    private string manufacturer;
    private uint price;
    private string owner;
    private const string validation = @"\A[\w]{3}[-\w]{0,17}"; // This is the regex that's used for many of the validations in the properties
    private Battery gsmBattery = null;
    private Display gsmDisplay = null;
    private List<Call> callHistory = new List<Call>();

    // Constructors
    public GSM(string Name, string Manufacturer)
        : this(Name, Manufacturer, 0, null)
    {
        // This constructor accepts only name and manufacturer
    }

    public GSM(string Name, string Manufacturer, uint Price, string Owner)
        : this(Name, Manufacturer, Price, Owner, null, null)
    {
        // This everything except Battery and Display
    }

    public GSM(string Name, string Manufacturer, uint Price = 100, string Owner, Display gsmDisplay, Battery gsmBattery)
    {
        this.Name = Name;
        this.Manufacturer = Manufacturer;
        this.Price = Price;
        this.Owner = Owner;
        this.gsmBattery = gsmBattery;
        this.gsmDisplay = gsmDisplay;
    }

    // Methods
    internal void ThrowArgumentExepttionNames(string input, string thrower)
    {
        throw new ArgumentOutOfRangeException(string.Format("The entry \"{0}\" isn't valid. The {1} must consist of between 3 and 20 valid charachters!",
            input, thrower));
    }

    internal void AddCall(string PhoneNumber, int DurationInSeconds)
    {
        this.callHistory.Add(new Call(PhoneNumber, DurationInSeconds));
    }

    internal void ClearCallHistory()
    {
        this.callHistory.Clear();
    }

    internal void ShowCalls()
    {
        if (callHistory.Count > 0)
        {
            foreach (Call call in this.callHistory)
            {
                Console.WriteLine(call);
            }
        }
        else
        {
            Console.WriteLine("The call history is empty");
        }

    }

    internal void RemoveCall(int callId)
    {
        foreach (Call call in this.callHistory)
        {
            if (call.Id == callId)
            {
                this.callHistory.Remove(call);
                return;
            }
        }
    }

    internal void RemoveLongestCall()
    {
        this.callHistory.Remove(callHistory.OrderByDescending(call => call.Duration.Ticks).First());
    }

    internal decimal CalculatePriceOfCalls(decimal pricePerMinute)
    {
        decimal total = 0;
        foreach (Call call in this.callHistory)
        {
            total = total + ((decimal)(call.Duration.TotalMinutes) * pricePerMinute);
        }

        return total;
    }

    // Properties

    public List<Call> CallHistory { get { return callHistory; } }
    public static GSM Iphone4S
    {
        get { return iphone4S; }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (Regex.IsMatch(value, validation))
            {
                this.name = value;
            }
            else
            {
                ThrowArgumentExepttionNames(value, "name");
            }
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        private set
        {
            if (Regex.IsMatch(value, validation))
            {
                this.manufacturer = value;
            }
            else
            {
                ThrowArgumentExepttionNames(value, "manufacturer");
            }
        }
    }

    public uint Price
    {
        get { return this.price; }
        set
        {
            if (value < 10 || value > 10000)
            {
                throw new ArgumentOutOfRangeException("The price of the phone should be between 10 and 10000");
            }
            else
            {
                this.price = value;
            }
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (Regex.IsMatch(value, validation))
            {
                this.owner = value;
            }
            else
            {
                ThrowArgumentExepttionNames(value, "owner");
            }
        }
    }

    public override string ToString()
    {
        // To expand later on
        return string.Format("{0}, {1}, {2}, {3}", this.name, this.manufacturer, this.price, this.owner);
    }
}

