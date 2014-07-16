using System;

using DefiningClasses;

internal class GSMTest
{
    private static void Main()
    {
        // Generate some test batteries and displays
        var premiumDisplay = new Display(4.5, Display.ColorDepth._32Bit);
        var mediocreDisplay = new Display(3.5, Display.ColorDepth._16Bit);
        var poorDisplay = new Display(2.5, Display.ColorDepth._8bit);
        var premiumBattery = new Battery("Sanyo-SN532e", 120, 20, Battery.Type.LiPol);
        var mediocreBattery = new Battery("Shanzungmang-2341", 80, 15, Battery.Type.LiIon);
        var poorBattery = new Battery("Mistucura-1224fe", 40, 5, Battery.Type.NiMH);

        // initilize gsms in the array
        var gsmArray = new GSM[4];
        gsmArray[0] = new GSM("One", "HTC", "Kiro", premiumDisplay, premiumBattery, 200);
        gsmArray[1] = new GSM("Blade", "Zte");
        gsmArray[2] = new GSM("Galaxy S4", "Samsung", "Misho", premiumDisplay, mediocreBattery, 1000);
        gsmArray[3] = new GSM("Ascend G600", "Huawei",  "Mtel", premiumDisplay, 
            new Battery("Toshiba-tbsae", 380, 6, Battery.Type.LiPol), 600);

        // print the gsms
        foreach (var phone in gsmArray)
        {
            Console.WriteLine(phone);
        }

        // print the static property Iphone4S
        Console.WriteLine(GSM.Iphone4S);

        // test GsmCallHistory
        GSMCallHistoryTest.Test();
    }
}