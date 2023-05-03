using System;
using System.Drawing;
using System.Threading;

namespace ConsoleAdventure
{
    class Guidelines
    {

        //Draw a standardized heading
        public static void Title(string title)
        {
            Spacer();
            var display = title;
            if (title == null || title == "")
            {
                display = "King's Chair v1.0";
            }
            display = "| " + display;
            display += LineCloser(display);
            Console.WriteLine(display);

            Spacer();
            var buffer = "|";
            buffer += LineCloser(buffer);
            Console.WriteLine(buffer);
        }

        //Draw a standardized separation (110 characters)
        public static void Spacer()
        {
            //Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            string spacer = "";
            for (var i = 0; i < LineLength(); i++) spacer += "-";
            Console.WriteLine(spacer);
        }

        //Return the max length for a line in the console
        public static int LineLength()
        {
            return 110;
        }

        //Setup a line's formatting so it is consistent
        public static string LineCloser(string line)
        {
            var length = 0;
            var remainder = LineLength();
            string close = "";
            foreach (var c in line) length += 1;
            remainder -= length;
            if (remainder <= 0) return "";
            for (var i = 0; i < remainder - 1; i++) close += " ";
            close += "|";
            return close;
        }

        //Return the Pop. needed at year's end to win the game

        public static int Goal()
        {
            return 200;
        }

        //Return the maximum number of ruler types ("roles") available
        public static int MaxRTypes()
        {
            return 6;
        }

        //Return the maximum number of stats tracked by decisions
        public static int MaxStats()
        {
            return 7;
        }

        //Return the maximum number of (monthly) events that can appear
        public static int MaxEvents()
        {
            return 12;
        }

        //Return the maximum number types of audiences that can appear
        public static int MaxAudiences()
        {
            return 26;
        }

        //Return the number of audiences held each month
        public static int MaxRequests()
        {
            return 60;
        }

        //Return the max number of random names for audience attendees
        public static int MaxAnames()
        {
            return 30;
        }

        //Return the number of audiences held each month
        public static int MaxEncounters()
        {
            return 5;
        }

        //Return the number of months before the game ends
        public static int MaxCycles()
        {
            return 12;
        }

        //Returns the number of gold generated each cycle (month)
        public static int GoldGain()
        {
            return 2;
        }

        //Sets a unique int for a random seed based on the current time
        public static int RNG()
        {
            var rng = DateTime.Now.Second * DateTime.Now.Minute;
            rng += DateTime.Now.Hour * DateTime.Now.Minute;
            rng += DateTime.Now.Second * DateTime.Now.Hour;
            rng += DateTime.Now.Year * DateTime.Now.Day;
            return rng;
        }

        //Determines if 'a' or 'an' is appropriate
        public static string ArticleMaker(string word)
        {
            if (word.ToLower()[0] == 'a' || word.ToLower()[0] == 'e' || word.ToLower()[0] == 'i' || word.ToLower()[0] == 'o' || word.ToLower()[0] == 'u') return "an ";
            return "a ";
        }




    }
}