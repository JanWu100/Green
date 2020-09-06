using System;
using System.Linq;

namespace Green
{
    class Program
    {
        static void Main(string[] args)
        {
            // Player creation
            Console.WriteLine("What is your name, Friend?");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("I will still call you Friend, then.");
                name = "Friend";
            }
            else if (name.ToLower() == "friend")
            {
                Console.WriteLine("Ha! I knew it.");
                name = "Friend";
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
            //string[] level = {
            //  "##########",
            //  "#     #  #",
            //  "#    ##  #",
            //  "#     #  #",
            //  "#        #",
            //  "#     #   ",
            //  "##########"

            //};
            string[] level = {
            "888888888888888888888888888888888888888888888888888888888888888888888   8",
            "8   8               8               8           8                   8   8",
            "8   8   888888888   8   88888   888888888   88888   88888   88888   8   8",
            "8               8       8   8           8           8   8   8       8   8",
            "888888888   8   888888888   888888888   88888   8   8   8   888888888   8",
            "8       8   8               8           8   8   8   8   8           8   8",
            "8   8   8888888888888   8   8   888888888   88888   8   888888888   8   8",
            "8   8               8   8   8       8           8           8       8   8",
            "8   8888888888888   88888   88888   8   88888   888888888   8   88888   8",
            "8           8       8   8       8   8       8           8   8           8",
            "8   88888   88888   8   88888   8   888888888   8   8   8   8888888888888",
            "8       8       8   8   8       8       8       8   8   8       8       8",
            "8888888888888   8   8   8   888888888   8   88888   8   88888   88888   8",
            "8           8   8           8       8   8       8   8       8           8",
            "8   88888   8   888888888   88888   8   88888   88888   8888888888888   8",
            "8   8       8           8           8       8   8   8               8   8",
            "8   8   888888888   8   88888   888888888   8   8   8888888888888   8   8",
            "8   8           8   8   8   8   8           8               8   8       8",
            "8   888888888   8   8   8   88888   888888888   888888888   8   888888888",
            "8   8       8   8   8           8           8   8       8               8",
            "8   8   88888   88888   88888   888888888   88888   a   888888888   8   8",
            "8   8                   8           8               8               8   8",
            "8   888888888888888888888888888888888888888888888888888888888888888888888"

            };
            string[] scrollStart = {
            "    _",
            "  =(_",
            "    |",
            "    |",
            "  =(_"
            };
            string[] scrollEnd = {
            "_",
            "_)=",
            "|    ",
            "|    ",
            "_)=  "
            };
            string[] congrats = { @"                                 _       
                                | |      
  ___ ___  _ __   __ _ _ __ __ _| |_ ___ 
 / __/ _ \| '_ \ / _` | '__/ _` | __/ __|
| (_| (_) | | | | (_| | | | (_| | |_\__ \
 \___\___/|_| |_|\__, |_|  \__,_|\__|___/
                  __/ |                  
                 |___/      " };

            string[] scrollMiddle = 
                {   "________________________________________________________________________________________________",
                    "____       _________       __________       _______       ___________       ______        ______",
                    "                                                                                                ",
                    "__________       _______        __________       _______       _________       ______      _____",
                    "________________________________________________________________________________________________"};

            //Map reaveal
            Console.Clear();
            Console.WriteLine($"Wanna see the map {name}? Press any key untill it is revealed...");

            int scrollLength = level[0].Length+8;
            

            for (int index = 0; index < scrollStart.Length / 2 + 1; index++)
            {
                Console.WriteLine(scrollStart[index]+ scrollMiddle[index].Substring(0, scrollLength) + scrollEnd[index]);
            }
          
            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in level)
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"    |    {row}    |");
                for (int index = scrollStart.Length / 2 + 1; index < scrollStart.Length; index++)
                {
                    Console.WriteLine(scrollStart[index] +scrollMiddle[index].Substring(0,scrollLength) + scrollEnd[index]);
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
            int playerRow = level.Length-2;
            Console.WriteLine();
            Console.WriteLine($"If struggling, press Enter to reset Avatar to starting position, or press \"g\" to give up, {name}.");
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

                if (keyInfo.Key == ConsoleKey.LeftArrow && currentRow[playerColumn-1] != '8')
                {
                    targetColumn = playerColumn-1;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && currentRow[playerColumn+1] != '8')
                {
                    targetColumn = playerColumn+1;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow && currentRowUp[playerColumn] != '8')
                {
                    targetRow = playerRow-1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && currentRowDown[playerColumn] != '8')
                {
                    targetRow = playerRow+1;
                }
                // Resetting position
                else if (keyInfo.Key == ConsoleKey.G)
                {
                    //targetColumn = 2;
                    //targetRow = level.Length - 2;
                    targetColumn = level[playerRow].Length - 3;
                    targetRow = 2;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    targetColumn = 2;
                    targetRow = level.Length - 2;
                }

                if (targetColumn >= 0 && targetColumn < level[playerRow].Length)
                {
                    playerColumn = targetColumn;
                }
                if (targetRow >= 0 && targetRow < level.Length-1)
                {
                    playerRow = targetRow;
                }

            //You Win
                //if (playerRow == level.Length-2 && playerColumn == level[playerRow].Length - 1)
                if (playerRow == 0 && playerColumn >= level[playerRow].Length - 4 && playerColumn <= level[playerRow].Length - 1)
                {
                    break;
                }
                

            }
            Console.Clear();
            Console.WriteLine();
            foreach (string row in congrats)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine();
                Console.WriteLine($"    Congratulations {name}, You won!");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Press Enter twice, to close the program");
            Console.ReadLine();
        }
    }
}
