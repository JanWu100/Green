namespace Green
{
    public class Level
    {
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
        public static bool Completed(int playerRow, int playerColumn, string[] level)
        {
            if (playerRow == 0 && playerColumn >= level[playerRow].Length - 4 &&
                playerColumn <= level[playerRow].Length - 1)
            {
                return true;
            }
            else return false;
        }
        private static bool DrawUnregularScrollRow(int i, int multiplier, string[] level)
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
                if (i >= 0 && i <= 4 || i >= (level[0].Length) + 5 && i <= (level[0].Length) + 8)
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
