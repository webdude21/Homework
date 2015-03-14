using System;

namespace DefiningClasses
{
    internal static class GsmCallHistoryTest
    {
        public static void Test()
        {
            var huawei = new Gsm("Ascend G600", "Huawei", "Mtel",  new Display(4.5, ColorDepth._32Bit), 
                new Battery("Toshiba-tbsae", 380, 6, BatteryType.LiPol), 600);

            huawei.AddCall("0888124122", 210);
            huawei.AddCall("0888124122", 40);
            huawei.AddCall("0888124122", 80);
            huawei.AddCall("0919125121", 600);
            huawei.AddCall("0919125121", 10);

            huawei.ShowCalls();

            Console.WriteLine("The price of all calls is {0} ", huawei.CalculatePriceOfCalls(0.32m));
            huawei.RemoveLongestCall();
            huawei.ClearCallHistory();
            huawei.ShowCalls();
        }
    }
}