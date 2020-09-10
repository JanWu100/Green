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
                Console.WriteLine(scrollStart[index]+ DrawScrollBody(DrawLevel(currentLevel))[index] + scrollEnd[index]);
            }
          
            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in DrawLevel(currentLevel))
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"    |    {row}    |");
                for (int index = scrollStart.Length / 2 + 1; index < scrollStart.Length; index++)
                {
                    Console.WriteLine(scrollStart[index] + DrawScrollBody(DrawLevel(currentLevel))[index] + scrollEnd[index]);
                }
                nextMapRowPosition++;
                Console.ReadKey(true);
            }
            Console.Clear();

            foreach (string row in DrawLevel(currentLevel))
            {
                Console.WriteLine(row);
            }

            int playerColumn = 2;
            int playerRow = DrawLevel(currentLevel).Length-2;
            Console.WriteLine();
            Console.WriteLine($"If struggling, press Enter to reset Avatar to starting position, or press \"g\" to give up, {name}.");
            while (true)
            {
                if (currentLevel > 3)
                {
                    break;
                }
                Console.SetCursorPosition(playerColumn, playerRow);
                Console.Write("@");
              
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(playerColumn, playerRow);
                string currentRow = DrawLevel(currentLevel)[playerRow];
                string currentRowUp = DrawLevel(currentLevel)[playerRow-1];
                string currentRowDown = DrawLevel(currentLevel)[playerRow + 1];


                char currentCell = currentRow[playerColumn];
                

                Console.Write(currentCell);
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

                    targetColumn = DrawLevel(currentLevel)[playerRow].Length - 3;
                    targetRow = 2;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    targetColumn = 2;
                    targetRow = DrawLevel(currentLevel).Length - 2;
                }

                if (targetColumn >= 0 && targetColumn < DrawLevel(currentLevel)[playerRow].Length && DrawLevel(currentLevel)[playerRow][targetColumn] != '8')
                {
                    playerColumn = targetColumn;
                }
                if (targetRow >= 0 && targetRow < DrawLevel(currentLevel).Length-1 && DrawLevel(currentLevel)[targetRow][playerColumn] != '8')
                {
                    playerRow = targetRow;
                }

                if (LevelCompleted(playerRow,playerColumn, DrawLevel(currentLevel)))
                {
                    Console.Clear();
                    Console.WriteLine();

                    foreach (string row in DrawCongratulations(1))
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
                        Console.WriteLine(scrollStart[index] + DrawScrollBody(DrawLevel(currentLevel))[index] + scrollEnd[index]);
                    }

                    int nextMapRowPosition2 = Console.CursorTop;
                    foreach (string row in DrawLevel(currentLevel))
                    {
                        Console.SetCursorPosition(0, nextMapRowPosition2);
                        Console.WriteLine($"    |    {row}    |");
                        for (int index = scrollStart.Length / 2 + 1; index < scrollStart.Length; index++)
                        {
                            Console.WriteLine(scrollStart[index] + DrawScrollBody(DrawLevel(currentLevel))[index] + scrollEnd[index]);
                        }
                        nextMapRowPosition2++;
                        Console.ReadKey(true);
                    }
                    Console.Clear();

                    
                    foreach (string row in DrawLevel(currentLevel))
                    {
                        Console.WriteLine(row);
                    }
                    playerColumn = 2;
                    playerRow = DrawLevel(currentLevel).Length - 2;
                    Console.WriteLine();
                    Console.WriteLine($"If struggling, press Enter to reset Avatar to starting position, or press \"g\" to give up, {name}.");
                    continue;

                }


            }
            Console.Clear();
            Console.WriteLine();

            foreach (string row in DrawCongratulations(2))
            {
                Console.WriteLine(row);
            }
            Console.WriteLine();
                Console.WriteLine($"               Congratulations {name}, You won!");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Press Enter, to close the program");
            Console.ReadLine();
        }

        public static string[] DrawLevel(int levelNumber)
        {
            
            if (levelNumber == 1)
            {
                string[] level =
                {
                    "8888888888   8",
                    "8        8   8",
                    "8   888      8",
                    "8   8     8888",
                    "8   8888888  8",
                    "8            8",
                    "8   8888888888"
                };
                return level;
            }
            else if (levelNumber == 2)
            {
                string[] level =
                {
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
                return level;


            }
            else if (levelNumber == 3)
            {
                string[] level =
                {
                    "888888888888888888888888888888888888888888888888888888888888888888888   8",
                    "8   8               8                    8                   8      8   8",
                    "8   8   888888888   8   88888   88 88888   88888   88888   8        8   8",
                    "8               8       8   8           8    88888   88888   8 888888   8",
                    "8       8   8               8           8   8   8   8   8           8   8",
                    "8   8   8888888888888   8   8   88   8   888888888   888888888          8",
                    "8   8               8   8   8       8           8           8       8   8",
                    "8   8888888888888   88888   88888   8   88888   888888888   8   88888   8",
                    "8           8       8   8       8          8   8                        8",
                    "8   88888   88888   8   88888   8   888888888   8   8   8   8888888888888",
                    "8       8       8   8   8       8       8       8   8   8       8       8",
                    "8888888888888   8   8   8   888888888   8       8   8       8           8",
                    "8   88888   8   888888888   88888   8   88888   88888   8888888888888   8",
                    "8   8       8           8   888888888   8888888888888   8           88888",
                    "8   8           8   8   8   88               8   8       88888888       8",
                    "8   888888888   8   8   8   88888   888888888   888888888   8   888888888",
                    "8   888888888888888888888888888888888888888888888888888888888888888888888"

                };
                return level;

            }
            else
            {
                string[] congrats =
                {
                    @"YOU WON THE GAME"
                };
                return congrats;
            }
        }

        public static string[] DrawCongratulations(int version)
        {
            if (version == 1)
            {
                string[] congrats =
                {
                    @"                                 _       
                                | |      
  ___ ___  _ __   __ _ _ __ __ _| |_ ___ 
 / __/ _ \| '_ \ / _` | '__/ _` | __/ __|
| (_| (_) | | | | (_| | | | (_| | |_\__ \
 \___\___/|_| |_|\__, |_|  \__,_|\__|___/
                  __/ |                  
                 |___/      "
                };
                return congrats;
            }
            else
            {
                string[] congrats =
                {
                    @"                                                888            
                                               888            
                                               888            
 .d8888b .d88b. 88888b.  .d88b. 888d888 8888b. 888888.d8888b  
d88P""   d88""""88b888 ""88bd88P""88b888P""      ""88b888   88K      
888     888  888888  888888  888888    .d888888888   ""Y8888b. 
Y88b.   Y88..88P888  888Y88b 888888    888  888Y88b.      X88 
 ""Y8888P ""Y88P"" 888  888 ""Y88888888    ""Y888888 ""Y888 88888P' 
                             888                              
                        Y8b d88P                              
                         ""Y88P""                               "
                };
                return congrats;
            }
            


            
        }
        public static bool LevelCompleted(int playerRow, int playerColumn , string[]level)
        {
            if (playerRow == 0 && playerColumn >= level[playerRow].Length - 4 &&
                playerColumn <= level[playerRow].Length - 1)
            {
                return true;
            }
            else return false;
        }
        private static bool DrawUnregularScrollRow(int i,int multiplier,string[] level)
        {
            
            if (i >= 0 && i <= multiplier
                || i >= 2 * multiplier && i <= 3 * multiplier
                || i >= 4 * multiplier && i <= 5 * multiplier
                || i >= 6 * multiplier && i <= 7 * multiplier
                || i >= 8 * multiplier && i <= 9 * multiplier
                || i >= 10 * multiplier && i <= 11 * multiplier
                || i >= (level[0].Length) + 5 && i <= (level[0].Length + 8))
            {
                return true;
            }
            else return false;

        }

        public static string[] DrawScrollBody(string[] level)
        {
            var unregularLineMultiplier = 0;
            if (level[0].Length < 30)
            {
                unregularLineMultiplier += 3;
            }
            else unregularLineMultiplier += 9;

            var scroll1 = "";
            for (int i = 0; i < level[0].Length + 8; i++)
            {
                scroll1 += "_";
            }

            var scroll2 = "";
            for (int i = 0; i < level[0].Length + 8; i++)
            {
                if (DrawUnregularScrollRow(i, unregularLineMultiplier, level))
                {
                    scroll2 += "_";
                }
                else
                {
                    scroll2 += " ";
                }
            }

            var scroll3 = "";
            for (int i = 0; i < level[0].Length + 8; i++)
            {
                scroll3 += " ";
            }

            var scroll4 = "";
            for (int i = 0; i < level[0].Length + 8; i++)
            {
                if (i >= 0 && i <= 4 || i >= (level[0].Length) + 5 && i <= (level[0].Length)+8)
                {
                    scroll4 += "_";
                }
                else if (DrawUnregularScrollRow(i, unregularLineMultiplier, level))
                {
                    scroll4 += " ";
                }
                else
                {
                    scroll4 += "_";
                }
            }

            var scroll5 = "";
            for (int i = 0; i < level[0].Length + 8; i++)
            {
                scroll5 += "_";
            }
            var scrollMiddle = new string[] { scroll1, scroll2, scroll3, scroll4, scroll5 };
            return scrollMiddle;
        }
    }
}
