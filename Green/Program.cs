using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Green
{
    class Program
    {
        static void Main(string[] args)
        {
            // Player creations
            
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

            var currentLevel = 1;

            //Map reaveal
            Console.Clear();
            Console.WriteLine($"Wanna see the map {name}? Press any key untill it is revealed...");

            
            
            for (int index = 0; index < scrollStart.Length / 2 + 1; index++)
            {
                Console.WriteLine(scrollStart[index]+ Level.DrawScrollBody(Level.DrawLevel(currentLevel))[index] + scrollEnd[index]);
            }
          
            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in Level.DrawLevel(currentLevel))
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"    |    {row}    |");
                for (int index = scrollStart.Length / 2 + 1; index < scrollStart.Length; index++)
                {
                    Console.WriteLine(scrollStart[index] + Level.DrawScrollBody(Level.DrawLevel(currentLevel))[index] + scrollEnd[index]);
                }
                nextMapRowPosition++;
                Console.ReadKey(true);
            }
            Console.Clear();

            foreach (string row in Level.DrawLevel(currentLevel))
            {
                Console.WriteLine(row);
            }

            int playerColumn = 2;
            int playerRow = Level.DrawLevel(currentLevel).Length-2;
            Console.WriteLine();
            Console.WriteLine($"If struggling, press Enter to reset Avatar to starting position, or press \"g\" to give up, {name}.");
            while (true)
            {
                if (currentLevel > 3)
                {
                    break;
                }

                WriteAt(playerColumn, playerRow, "@");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                string currentRow = Level.DrawLevel(currentLevel)[playerRow];
                //string currentRowUp = DrawLevel(currentLevel)[playerRow-1];
                //string currentRowDown = DrawLevel(currentLevel)[playerRow + 1];
                char currentCell = currentRow[playerColumn];

                WriteAt(playerColumn, playerRow, currentCell);

                int targetColumn = playerColumn;
                int targetRow = playerRow;

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    targetColumn = playerColumn-1;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    targetColumn = playerColumn+1;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    targetRow = playerRow-1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    targetRow = playerRow+1;
                }
                // Resetting position
                else if (keyInfo.Key == ConsoleKey.G)
                {

                    targetColumn = Level.DrawLevel(currentLevel)[playerRow].Length - 3;
                    targetRow = 2;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    targetColumn = 2;
                    targetRow = Level.DrawLevel(currentLevel).Length - 2;
                }

                if (targetColumn >= 0 && targetColumn < Level.DrawLevel(currentLevel)[playerRow].Length && Level.DrawLevel(currentLevel)[playerRow][targetColumn] != '8')
                {
                    playerColumn = targetColumn;
                }
                if (targetRow >= 0 && targetRow < Level.DrawLevel(currentLevel).Length-1 && Level.DrawLevel(currentLevel)[targetRow][playerColumn] != '8')
                {
                    playerRow = targetRow;
                }

                if (Level.Completed(playerRow,playerColumn, Level.DrawLevel(currentLevel)))
                {
                    Console.Clear();
                    Console.WriteLine();

                    foreach (string row in Congratulations.Draw(1))
                    {
                        Console.WriteLine(row);
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Congratulations {name}, You finished this level!");
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Press Enter to advance to another level");
                    Console.ReadLine();
                    Console.Clear();
                    currentLevel++;
                    if (currentLevel > 3)
                    {
                        break;

                    }
                    Console.WriteLine($"Wanna see the map {name}? Press any key untill it is revealed...");
                    for (int index = 0; index < scrollStart.Length / 2 + 1; index++)
                    {
                        Console.WriteLine(scrollStart[index] + Level.DrawScrollBody(Level.DrawLevel(currentLevel))[index] + scrollEnd[index]);
                    }

                    int nextMapRowPosition2 = Console.CursorTop;
                    foreach (string row in Level.DrawLevel(currentLevel))
                    {
                        Console.SetCursorPosition(0, nextMapRowPosition2);
                        Console.WriteLine($"    |    {row}    |");
                        for (int index = scrollStart.Length / 2 + 1; index < scrollStart.Length; index++)
                        {
                            Console.WriteLine(scrollStart[index] + Level.DrawScrollBody(Level.DrawLevel(currentLevel))[index] + scrollEnd[index]);
                        }
                        nextMapRowPosition2++;
                        Console.ReadKey(true);
                    }
                    Console.Clear();

                    
                    foreach (string row in Level.DrawLevel(currentLevel))
                    {
                        Console.WriteLine(row);
                    }
                    playerColumn = 2;
                    playerRow = Level.DrawLevel(currentLevel).Length - 2;
                    Console.WriteLine();
                    Console.WriteLine($"If struggling, press Enter to reset Avatar to starting position, or press \"g\" to give up, {name}.");
                    continue;

                }


            }
            Console.Clear();
            Console.WriteLine();

            foreach (string row in Congratulations.Draw(2))
            {
                Console.WriteLine(row);
            }
            Console.WriteLine();
                Console.WriteLine($"               Congratulations {name}, You won!");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Press Enter, to close the program");
            Console.ReadLine();
        }



        static void WriteAt(int columnNumber, int columnRow, string text)
        {
            Console.SetCursorPosition(columnNumber, columnRow);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void WriteAt(int columnNumber, int columnRow, char sign)
        {
            Console.SetCursorPosition(columnNumber, columnRow);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(sign);
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
   
}
