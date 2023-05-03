using System;
using System.Drawing;
using System.Threading;

namespace ConsoleAdventure
{
    class Icon
    {
        //Draws an icon for the game
        public static string DrawIcon(int type, int line, Player player)
        {
            //string[] resc = new string[10];
            var resc = "";
            //No Icon
            if (type == -1 || (line > 6 && type != 8) || (type == 8 && line > 9)) return "";
            //Crown Icon
            if (type == 0)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|                  |   ";
                if (line == 2) return "|    \\ \\ | / /     |   ";
                if (line == 3) return "|    =o==O==o=     |   ";
                if (line == 4) return "|                  |   ";
                if (line == 5) return "|                  |   ";
                if (line == 6) return "\\------------------/   ";
            }
            //Person Icon
            if (type == 1)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|                  |   ";
                if (line == 2) return "|         O/       |   ";
                if (line == 3) return "|        /|        |   ";
                if (line == 4) return "|        / \\       |   ";
                if (line == 5) return "|                  |   ";
                if (line == 6) return "\\------------------/   ";
            }
            //Chest Icon
            if (type == 2)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|                  |   ";
                if (line == 2) return "|    /========\\    |   ";
                if (line == 3) return "|    |---[]---|    |   ";
                if (line == 4) return "|    \\________/    |   ";
                if (line == 5) return "|                  |   ";
                if (line == 6) return "\\------------------/   ";
            }
            //Sword Icon
            if (type == 3)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|                  |   ";
                if (line == 2) return "|        |         |   ";
                if (line == 3) return "|       -o-        |   ";
                if (line == 4) return "|        l         |   ";
                if (line == 5) return "|                  |   ";
                if (line == 6) return "\\------------------/   ";
            }
            //House Icon
            if (type == 4)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|           ~~     |   ";
                if (line == 2) return "|    _____/\\___    |   ";
                if (line == 3) return "|   //////\\\\\\\\\\\\   |   ";
                if (line == 4) return "|    |  _   O |    |   ";
                if (line == 5) return "|    |_| |____|    |   ";
                if (line == 6) return "\\------------------/   ";
            }
            //Skull Icon
            if (type == 5)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|     ________     |   ";
                if (line == 2) return "|    / X    X \\    |   ";
                if (line == 3) return "|    |   /\\   |    |   ";
                if (line == 4) return "|     \\      /     |   ";
                if (line == 5) return "|      ||||||      |   ";
                if (line == 6) return "\\------------------/   ";
            }
            //Sun Icon
            if (type == 6)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|                  |   ";
                if (line == 2) return "|      \\ | /       |   ";
                if (line == 3) return "|     -- O --      |   ";
                if (line == 4) return "|      / | \\       |   ";
                if (line == 5) return "|                  |    ";
                if (line == 6) return "\\------------------/   ";
            }
            //Wall Icon
            if (type == 7)
            {
                if (line == 0) return "/------------------\\   ";
                if (line == 1) return "|_   _   _   _   _ |   ";
                if (line == 2) return "| |_| |_| |_| |_| ||   ";
                if (line == 3) return "|                  |   ";
                if (line == 4) return "|__________________|   ";
                if (line == 5) return "|                  |    ";
                if (line == 6) return "\\------------------/   ";
            }
            //Resource Icon
            if (type == 8)
            {
                if (line == 0) return "/------------------\\   ";
                if (line > 0 && line < 7)
                {
                    resc = "| " + Terms.Favors(line) + ": " + player.Favor[line - 1];
                    resc = resc + IconCloser(resc);
                    return resc;
                }
                if (line == 7)
                {
                    resc = "| Population" + ": " + player.Pop + "k";
                    resc = resc + IconCloser(resc);
                    return resc;
                }
                if (line == 8)
                {
                    resc = "| Gold" + ": " + player.GP;
                    resc = resc + IconCloser(resc);
                    return resc;
                }
                if (line == 9) return "\\------------------/   ";
            }
            //Empty or Invalid Icon
            return "|                  |";
        }

        //Fills remaining space in icon box
        static string IconCloser(string line)
        {
            var length = 0;
            var remainder = 20;
            string close = "";
            foreach (var c in line) length += 1;
            remainder -= length;
            if (remainder <= 0) return "";
            for (var i = 0; i < remainder - 1; i++) close += " ";
            close += "|   ";
            return close;
        }



    }
}