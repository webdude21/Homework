using System;

class IntegerValueExchange
{
    static void Main(string[] args)
    {
        int five = 5;
        int ten = 10;
        int tempInt;

        tempInt = ten;
        ten = five;
        five = tempInt;

        // another way is 
        //ten = ten / 2;
        //five = five * 2;

        // another way is 
        //ten = ten - five;
        //five = five + five;


    }
}
