using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


struct gameObject
{
    public int x;
    public int y;
    public ConsoleColor color;
    public int width;
    public string shape;
    // I've called this structure gameObject. I'll be using it for both the falling rocks and
    // the Dwarf itself. It has x and y as coordinates. It has color, shape and width.
}

class FallingRocks

{

    static void PrintOnPosition(int x, int y, string s, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(s);   

    // This is a method that's called every time something needs to be printed on the console.
    // Its arguments are the coordinates X and Y, the string ("s") to be printed and 
    // the color that's going to be used.
    }

    static System.String GetRandomString(System.Int32 length)
    {
        System.Byte[] seedBuffer = new System.Byte[4];
        using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rngCryptoServiceProvider.GetBytes(seedBuffer);
            System.String chars = "^@*&+%$#!.;-"; // Characters allowed to be rocks.
            System.Random random = new System.Random(System.BitConverter.ToInt32(seedBuffer, 0));
            return new System.String(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    // I cannot really explain how this works. I got it from the Internet and it gets the job done.
    // It generates a random string from a character set.
    }

    static void Main(string[] args)
    {
        byte gameFieldWidth = 30; 
        uint livesCount = 10; // This is the lives we have in the game.
        uint liveScore = 0; // This keeps the score.
        string[] randomColor = { "Gray", "Blue", "Green", "Cyan", "Red", "Magenta", "Yellow", "White",
        "DarkBlue","DarkGreen","DarkMagenta","DarkCyan","DarkRed","DarkYellow"};
        // An array of strings used to select a Random color further in the program.

        Console.BufferHeight = Console.WindowHeight = 20; 
        Console.BufferWidth = Console.WindowWidth = gameFieldWidth;
        // This sets the game area. Height and Width.

        // Initialize and define the Dwarf
        gameObject playerDwarf = new gameObject();
        playerDwarf.x = 14; // This is the starting position of the Dwarf
        playerDwarf.y = Console.WindowHeight - 1;
        playerDwarf.shape = "<O>"; // Get the shape of the Dwarf
        playerDwarf.width = playerDwarf.shape.Length; // Get the width of the Dwarf

        Random randomRockGen = new Random(); // Initialize a random generator
        List<gameObject> rocks = new List<gameObject>(); 
        // Initialize a list to hold the information about all of the falling rocks.

        while(true)
        // To ensure that the game never ends as long as the player plays without loosing all
        // of his lives, a while cycle is implemented.
        {
            {
                // Create a rock, set it's properties and add it to the List of falling rocks.
                gameObject newRock = new gameObject();
                liveScore++;
                newRock.color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), randomColor[randomRockGen.Next(0, 13)]);
                // Randomly pick a color for the new rock!
                newRock.x = randomRockGen.Next(1, gameFieldWidth);
                // It generates the rock a random position depending within the game field.
                newRock.y = 1; // It's starts falling from the top, as it should.
                newRock.shape = GetRandomString(randomRockGen.Next(1, 4)) ; // This is what it looks like.
                newRock.width = newRock.shape.Length; // The width of the rock.
                rocks.Add(newRock); // It adds the newly created rock to the list "rocks".
            }

            Console.Clear(); // Clear the console, so it can be filled again.

            PrintOnPosition(0, 0, "Lives: " + livesCount, ConsoleColor.Cyan);
            PrintOnPosition(15, 0, "Score: " + liveScore, ConsoleColor.Cyan);
            // Display how many lives we have.

            foreach (gameObject rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.shape, rock.color);
                // The cycle foreach draws every rock in the list of rocks.
            }


            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true); // Gets which key is pressed, if any.
                while (Console.KeyAvailable) Console.ReadKey(true); // Ensures the smoothens of the game.
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (playerDwarf.x - 1 >= 0)
                    {
                        playerDwarf.x = playerDwarf.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (playerDwarf.x + 1 < gameFieldWidth - (playerDwarf.width))
                    {
                        playerDwarf.x = playerDwarf.x + 1;
                    }
                // This ensures the player stays within the confines of the playing field.
                }
            }

            PrintOnPosition(playerDwarf.x, playerDwarf.y, playerDwarf.shape); 
            // This draws the Dwarf.

            List<gameObject> newList = new List<gameObject>();
            for (int i = 0; i < rocks.Count; i++)
            {
                gameObject oldRock = rocks[i]; // It gets the "i" rock from the list of rocks.
                // Then assigns it to the oldRock object (structure). 
                gameObject newRock = new gameObject(); 
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1; // The rock has moved down.
                newRock.shape = oldRock.shape;
                newRock.color = oldRock.color;
                newRock.width = oldRock.width;
                // After all of the rocks are moved down and saved in the "NewList"
                // the new list becomes the old list and it's ready for the next cycle.


                if (((oldRock.y == playerDwarf.y) &&
                        !((playerDwarf.x + (playerDwarf.width - 1)) < (newRock.x)) ^
                        ((playerDwarf.x) > (newRock.x + (newRock.width - 1)))) && (oldRock.shape == "+"))    
                // This checks if the Dwarf and the Rock crash
                { 
                     livesCount++;
                    // If the crash is with a "+" rock then it gives you an additional life.
                }
                else if (((oldRock.y == playerDwarf.y) &&
                       !((playerDwarf.x + (playerDwarf.width - 1)) < (newRock.x)) ^
                       ((playerDwarf.x) > (newRock.x + (newRock.width - 1)))) && (oldRock.shape == "$"))   
                {
                    // If you catch a dollar sign you'll get 100 points.
                    liveScore = liveScore + 100;

                }
                else if ((oldRock.y == playerDwarf.y) &&
                        !((playerDwarf.x + (playerDwarf.width - 1)) < (newRock.x)) ^
                        ((playerDwarf.x) > (newRock.x + (newRock.width - 1))))
                {
                    // If you crash with anything other then a "+" or "$" rock it takes one life.
                    livesCount--;
                    if (livesCount == 0)
                    {
                        // If your lives run out,the program stops it's execution.
                        PrintOnPosition(10, 15, "GAME OVER!", ConsoleColor.Red);
                        Console.ReadLine();
                        return;
                    }
                }

                if (newRock.y < Console.WindowHeight) // Check if the new rock is within the game field.
                {
                    newList.Add(newRock); // add the new rock to the new list
                }
                
            }
            rocks = newList; // It gets the data from the new list of rocks after they've been moved.
            // Draw score
            Thread.Sleep(200); // Sets the game speed
        }
    }
}


// The game has a few bonuses. If you catch a "+" sign you'll get an extra life. If you catch a "$" you get
// + 100 to your score. Everything else gets you killed.