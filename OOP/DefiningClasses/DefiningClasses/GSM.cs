namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GSM
    {
        // Fields
        private const string Validation = @"\A[\w]{3}[-\w]{0,17}";

        // This is the regex that's used for many of the validations in the properties
        private static readonly GSM iphone4S = new GSM(
            "IPhone-4S", 
            "Apple", 
            "Pesho", 
            new Display(4.5, Display.ColorDepth._32Bit), 
            new Battery("sanyo-321r54D", 120, 14, Battery.Type.LiPol), 
            900);

        private readonly List<Call> callHistory = new List<Call>();

        private Battery gsmBattery;

        private Display gsmDisplay;

        private string manufacturer;

        private string name;

        private string owner;

        private uint price;

        // Constructors
        public GSM(string Name, string Manufacturer)
            : this(Name, Manufacturer, 0, null)
        {
            // This constructor accepts only name and manufacturer
        }

        public GSM(string name, string manufacturer, uint price, string owner)
            : this(name, manufacturer, owner, null, null, price)
        {
            // This everything except Battery and Display
        }

        public GSM(
            string name, 
            string manufacturer, 
            string owner, 
            Display gsmDisplay, 
            Battery gsmBattery, 
            uint price = 100)
        {
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.gsmBattery = gsmBattery;
            this.gsmDisplay = gsmDisplay;
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public static GSM Iphone4S
        {
            get
            {
                return iphone4S;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (Regex.IsMatch(value, Validation))
                {
                    this.name = value;
                }
                else
                {
                    this.ThrowArgumentExepttionNames(value, "name");
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (Regex.IsMatch(value, Validation))
                {
                    this.manufacturer = value;
                }
                else
                {
                    this.ThrowArgumentExepttionNames(value, "manufacturer");
                }
            }
        }

        public uint Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 10 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException("The price of the phone should be between 10 and 10000");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (Regex.IsMatch(value, Validation))
                {
                    this.owner = value;
                }
                else
                {
                    this.ThrowArgumentExepttionNames(value, "owner");
                }
            }
        }

        // Methods
        internal void ThrowArgumentExepttionNames(string input, string thrower)
        {
            throw new ArgumentOutOfRangeException(
                string.Format(
                    "The entry \"{0}\" isn't valid. The {1} must consist of between 3 and 20 valid charachters!", 
                    input, 
                    thrower));
        }

        internal void AddCall(string phoneNumber, int durationInSeconds)
        {
            this.callHistory.Add(new Call(phoneNumber, durationInSeconds));
        }

        internal void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        internal void ShowCalls()
        {
            if (this.callHistory.Count > 0)
            {
                foreach (var call in this.callHistory)
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
            foreach (var call in this.callHistory)
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
            this.callHistory.Remove(this.callHistory.OrderByDescending(call => call.Duration.Ticks).First());
        }

        internal decimal CalculatePriceOfCalls(decimal pricePerMinute)
        {
            decimal total = 0;
            foreach (var call in this.callHistory)
            {
                total = total + ((decimal)call.Duration.TotalMinutes * pricePerMinute);
            }

            return total;
        }

        // Properties
        public override string ToString()
        {
            // To expand later on
            return string.Format("{0}, {1}, {2}, {3}", this.name, this.manufacturer, this.price, this.owner);
        }
    }
}