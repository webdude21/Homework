namespace DefiningClasses
{
    using System;
    using System.Text.RegularExpressions;

    public class Battery
    {
        private const uint MaxHoursIdle = 500;

        private const uint MaxHoursTalk = 30;

        private const string Validation = @"[\w]{3}[-\w]{0,17}";

        private double hoursIdle;

        private double hoursTalk;

        private string model;

        public Battery(string model)  : this(model, 0, 0, 0)
        {
        }

        public Battery(string model, uint hoursIdle, uint hoursTalk) : this(model, hoursIdle, hoursTalk, 0)
        {
        }

        public Battery(string model, uint hoursIdle, uint hoursTalk, BatteryType batteryType)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public BatteryType BatteryType { get; private set; }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (Regex.IsMatch(value, Validation))
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(
                            "The entry \"{0}\" isn't valid. The battery name must consist of between 3 and 20 valid characters!",
                            value));
                }
            }
        }

        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (this.hoursIdle > MaxHoursIdle)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(
                            "The value you've entered \"{0}\" isn't valid. The maximum value is \"{1}\"",
                            value,
                            MaxHoursIdle));
                }
                this.hoursIdle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (this.hoursTalk > MaxHoursTalk)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(
                            "The value you've entered \"{0}\" isn't valid. The maximum value is \"{1}\"",
                            value,
                            MaxHoursTalk));
                }
                this.hoursTalk = value;
            }
        }
    }
}