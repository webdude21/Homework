using System.Text.RegularExpressions;
using System;

public class Battery
{
    public enum Type
    {
        LiIon, NiMH, NiCd, LiPol
    }

    private const uint maxHoursIdle = 500;
    private const uint maxHoursTalk = 30;
    private string model;
    private double hoursIdle;
    private double hoursTalk;
    private const string validation = @"[\w]{3}[-\w]{0,17}";
    private Type battery;

    public Battery(string model) : this(model , 0, 0, 0)
    {
        // Constructor that allows init of battery with only it's name
    }

    public Battery(string model, uint hoursIdle, uint hoursTalk): this(model, hoursIdle, hoursTalk, 0)
    {
        // Constructor that allows init of battery with only it's name, hoursIdle, hoursTalk
    }

    public Battery(string model, uint hoursIdle, uint hoursTalk, Type battery)
    {
        this.model = model;
        this.hoursIdle = hoursIdle;
        this.hoursTalk = hoursTalk;
        this.battery = battery;
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            if (Regex.IsMatch(value, validation))
            {
                this.model = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("The entry \"{0}\" isn't valid. The battery name must consist of between 3 and 20 valid charachters!",
            value));
            }
        }
    }
    public double HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (this.hoursIdle > maxHoursIdle)
            {
                throw new ArgumentOutOfRangeException(string.Format("The value you've entered \"{0}\" isn't valid. The maximum value is \"{1}\"",
                     value, maxHoursIdle));
            }
            else
            {
                this.hoursIdle = value;
            }
        }
    }
    public double HoursTalk
    {
        get { return this.hoursTalk; }
        set
        {
            if (this.hoursTalk > maxHoursTalk)
            {
                throw new ArgumentOutOfRangeException(string.Format("The value you've entered \"{0}\" isn't valid. The maximum value is \"{1}\"",
                     value, maxHoursTalk));
            }
            else
            {
                this.HoursTalk = value;
            }
        }
    }
}