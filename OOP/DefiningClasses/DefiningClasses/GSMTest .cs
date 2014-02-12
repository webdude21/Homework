using System;
using System.Text;
class GSMTest
{
    static void Main()
    {        
        // Generate some test batteries and displays
        Display premiumDisplay = new Display(4.5, Display.ColorDepth._32Bit);
        Display mediocreDisplay = new Display(3.5, Display.ColorDepth._16Bit);
        Display poorDisplay = new Display(2.5, Display.ColorDepth._8bit);
        Battery premiumBattery = new Battery("Sanyo-SN532e", 120, 20, Battery.Type.LiPol);
        Battery mediocreBattery = new Battery("Shanzungmang-2341", 80, 15, Battery.Type.LiIon);
        Battery poorBattery = new Battery("Mistucura-1224fe", 40, 5, Battery.Type.NiMH);

        // initilize gsms in the array
        GSM[] gsmArray = new GSM[4];
        gsmArray[0] = new GSM("One", "HTC", 200, "Kiro", premiumDisplay, premiumBattery);
        gsmArray[1] = new GSM("Blade", "Zte");
        gsmArray[2] = new GSM("Galaxy S4", "Samsung", 1000, "Misho", premiumDisplay, mediocreBattery);
        gsmArray[3] = new GSM("Ascend G600", "Huawei", 600, "Mtel", premiumDisplay, new Battery("Toshiba-tbsae", 380, 6, Battery.Type.LiPol));

        // print the gsms
        foreach (GSM phone in gsmArray)
        {
            Console.WriteLine(phone);
        }

        // print the static property Iphone4S
        Console.WriteLine(GSM.Iphone4S);
        // test GsmCallHistory
        GSMCallHistoryTest.Test();
    }
}
