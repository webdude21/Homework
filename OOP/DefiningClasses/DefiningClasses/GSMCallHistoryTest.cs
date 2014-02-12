using System;

static class GSMCallHistoryTest
{
    public static void Test()
    {
        // create new GSM instance
        GSM Huawei = new GSM("Ascend G600", "Huawei", 600, "Mtel", new Display(4.5, Display.ColorDepth._32Bit), new Battery("Toshiba-tbsae", 380, 6, Battery.Type.LiPol));
        
        // add some calls to list of calls
        Huawei.AddCall("0888124122", 210);
        Huawei.AddCall("0888124122", 40);
        Huawei.AddCall("0888124122", 80);
        Huawei.AddCall("0919125121", 600);
        Huawei.AddCall("0919125121", 10);

        Huawei.ShowCalls(); // Print the call list
        // Calculate the price of the each call
        Console.WriteLine("The price of all calls is {0} ", Huawei.CalculatePriceOfCalls(0.32m));
        Huawei.RemoveLongestCall();
        Huawei.ClearCallHistory();
        Huawei.ShowCalls();
    }
}
