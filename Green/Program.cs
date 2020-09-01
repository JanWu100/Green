using System;

namespace Green
{
    class Program
    {
        static void Main(string[] args)
        {
            // Przywitanie info ze pobieramy imie
            Console.WriteLine("What is your name, Cupcake?");
            // Pobranie informacji o graczu
            string name = Console.ReadLine();

            //Sprawdz czy podal imie
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

            // Wyswietl wiadomosc z imienienm
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

            //int lineIndex = 0;
            //while (lineIndex < scroll.Length / 2+1){
            //  Console.WriteLine(scroll[lineIndex++]);
            //}
            for (int index = 0; index < scroll.Length / 2 + 1; index++)
            {
                Console.WriteLine(scroll[index]);
            }
            /*
            if (lineIndex < scroll.Length) {
              Console.WriteLine(scroll[lineIndex++]);
            }
            if (lineIndex < scroll.Length){
              Console.WriteLine(scroll[lineIndex++]);
            }
            if (lineIndex < scroll.Length) {
              Console.WriteLine(scroll[lineIndex++]);
            }
            */
            /*  Console.WriteLine(scroll[lineIndex]);
              lineIndex = lineIndex + 1;
              Console.WriteLine(scroll[lineIndex]);
              lineIndex++;
              Console.WriteLine(scroll[lineIndex]);
              Console.WriteLine(scroll[lineIndex++]);
              */


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
            //for (int index = scroll.Length /2+1; index < scroll.Length; index++){
            //  Console.WriteLine(scroll[index]);
            // Console.ReadKey(true); 
            //}

            //lineIndex = scroll.Length /2+1;
            // while (lineIndex < scroll.Length) {
            //   Console.WriteLine(scroll[lineIndex++]);
            // }
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
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    playerColumn--;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    playerColumn++;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    playerRow--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    playerRow++;
                }
            }
            Console.SetCursorPosition(0, level.Length);
        }
    }
}
