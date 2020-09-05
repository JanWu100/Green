using System;

namespace Green
{
    class Program
    {
        static void Main(string[] args)
        {
            // Player creation
            Console.WriteLine("What is your name, Cupcake?");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("I will still call you Cupcake, then.");
                name = "Cupcake";
            }
            else if (name.ToLower() == "cupcake")
            {
                Console.WriteLine("Ha! I knew it.");
                name = "Cupcake";
            }
            Console.WriteLine("Where are you from, " + name + "?");
            string place = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(place))
            {
                Console.WriteLine("Fine, dont tell me.");
                place = ("Nowhere");
            }
            Console.WriteLine($"Welcome to Green, {name} from {place}!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            string[] level = {
              "##########",
              "#     #  #",
              "#    ##  #",
              "#     #  #",
              "#        #",
              "#     #  #",
              "##########"

            };
                    string[] scroll = {
            "    ____________________",
            "  =(__   ___     __    _)=",
            "    |                  |",
            "    |__   ___  __   ___|   ",
            "   =(____________________)="
            };
            Console.Clear();
            Console.WriteLine($"Wanna see the map {name}? Press any key untill it is revealed...");

            for (int index = 0; index < scroll.Length / 2 + 1; index++)
            {
                Console.WriteLine(scroll[index]);
            }
          
            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in level)
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"    |    {row}    |");
                for (int index = scroll.Length / 2 + 1; index < scroll.Length; index++)
                {
                    Console.WriteLine(scroll[index]);
                }
                nextMapRowPosition++;
                Console.ReadKey(true);
            }

            Console.Clear();


            foreach (string row in level)
            {
                Console.WriteLine(row);
            }

            int playerColumn = 2;
            int playerRow = 3;

            while (true)
            {
                Console.SetCursorPosition(playerColumn, playerRow);
                Console.Write("@");
              
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(playerColumn, playerRow);
                string currentRow = level[playerRow];
                string currentRowUp = level[playerRow-1];
                string currentRowDown = level[playerRow + 1];


                char currentCell = currentRow[playerColumn];
                

                Console.Write(currentCell);
                int targetColumn = playerColumn;
                int targetRow = playerRow;

                if (keyInfo.Key == ConsoleKey.LeftArrow && currentRow[playerColumn-1] != '#')
                {
                    targetColumn = playerColumn-1;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && currentRow[playerColumn+1] != '#')
                {
                    targetColumn = playerColumn+1;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow && currentRowUp[playerColumn] != '#')
                {
                    targetRow = playerRow-1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && currentRowDown[playerColumn] != '#')
                {
                    targetRow = playerRow+1;
                }
                // Resetting position
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    targetColumn = 2;
                    targetRow = 3;
                }

                if (targetColumn >= 0 && targetColumn < level[playerRow].Length)
                {
                    playerColumn = targetColumn;
                }
                if (targetRow >= 0 && targetRow < level.Length)
                {
                    playerRow = targetRow;
                }
            }
            Console.SetCursorPosition(0, level.Length);
        }
    }
}
