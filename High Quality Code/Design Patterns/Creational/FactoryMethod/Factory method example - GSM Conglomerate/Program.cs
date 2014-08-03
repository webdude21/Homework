namespace FactoryMethod.GsmConglomerate
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var pearComp = new PearComputers();
            var samunComp = new SamunComputers();

            var firstPhone = pearComp.ManufactureGsm();
            var secondPhone = samunComp.ManufactureGsm();

            PrintGsmInfo(firstPhone);
            firstPhone.Start();

            Console.WriteLine();

            PrintGsmInfo(secondPhone);
            secondPhone.Start();
        }

        public static void PrintGsmInfo(Gsm gsm)
        {
            Console.WriteLine("Phone name: {0}", gsm.Name);
            Console.WriteLine("Height: {0}", gsm.Height);
            Console.WriteLine("Width: {0}", gsm.Width);
            Console.WriteLine("Weight: {0}", gsm.Weight);
            Console.WriteLine("Battery life: {0}", gsm.BatteryLife);
        }
    }
}