using System;

using DefiningClasses;

internal static class GSMCallHistoryTest
{
    public static void Test()
    {
        // create new GSM instance
        var huawei = new GSM(
            "Ascend G600", 
            "Huawei", 
            "Mtel", 
            new Display(4.5, Display.ColorDepth._32Bit), 
            new Battery("Toshiba-tbsae", 380, 6, Battery.Type.LiPol), 600);

        // add some calls to list of calls
        huawei.AddCall("0888124122", 210);
        huawei.AddCall("0888124122", 40);
        huawei.AddCall("0888124122", 80);
        huawei.AddCall("0919125121", 600);
        huawei.AddCall("0919125121", 10);

        huawei.ShowCalls(); // Print the call list

        // Calculate the price of the each call
        Console.WriteLine("The price of all calls is {0} ", huawei.CalculatePriceOfCalls(0.32m));
        huawei.RemoveLongestCall();
        huawei.ClearCallHistory();
        huawei.ShowCalls();
    }
}