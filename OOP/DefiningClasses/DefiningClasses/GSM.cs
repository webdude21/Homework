namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Gsm
    {
        private const string Validation = @"\A[\w]{3}[-\w]{0,17}";

        public static readonly Gsm iphone4S = new Gsm("IPhone-4S", "Apple", "Pesho", new Display(4.5, ColorDepth._32Bit),
            new Battery("sanyo-321r54D", 120, 14, BatteryType.LiPol), 900);

        private readonly List<Call> callHistory = new List<Call>();

        public Battery GsmBattery { get; private set; }

        public Display GsmDisplay { get; private set; }

        private string manufacturer;

        private string name;

        private string owner;

        private uint price;

        public Gsm(string name, string manufacturer) : this(name, manufacturer, 50, null)
        {
        }

        public Gsm(string name, string manufacturer, uint price, string owner) : this(name, manufacturer, owner, null, null, price)
        {
        }

        public Gsm(string name, string manufacturer, string owner, Display gsmDisplay, Battery gsmBattery, uint price = 100)
        {
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.GsmBattery = gsmBattery;
            this.GsmDisplay = gsmDisplay;
        }

        public List<Call> CallHistory
        {
            get
            {
                return new List<Call>(this.callHistory);
            }
        }

        public static Gsm Iphone4S
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
                    throw new ArgumentOutOfRangeException("The price of the" +
                        " phone should be between 10 and 10000");
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
            throw new ArgumentOutOfRangeException(string.Format("The entry \"{0}\" isn't valid. The {1} must consist of between 3 and 20 valid characters!", input, thrower));
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
            foreach (var call in this.callHistory.Where(call => call.Id == callId))
            {
                this.callHistory.Remove(call);
                return;
            }
        }

        internal void RemoveLongestCall()
        {
            this.callHistory.Remove(this.callHistory.OrderByDescending(call => call.Duration.Ticks).First());
        }

        internal decimal CalculatePriceOfCalls(decimal pricePerMinute)
        {
            return this.callHistory.Sum(x => x.Duration.Minutes * pricePerMinute);
        }

        public override string ToString()
        {
            return string.Format("GsmBattery: {0}, GsmDisplay: {1}, Manufacturer: {2}, Name: {3}, Price: {4}, Owner: {5}", this.GsmBattery, this.GsmDisplay, this.Manufacturer, this.Name, this.Price, this.Owner);
        }
    }
}