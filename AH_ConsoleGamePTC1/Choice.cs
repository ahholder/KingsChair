using System;
using System.Drawing;
using System.Threading;

namespace ConsoleAdventure
{
    class Choice
    {
        //Standard choice options - Determine valid input based on key press + available choices
        public static int Option(int maxChoices)
        {
            bool choosing = true;
            int chosen = -1;
            while (choosing)
            {
                //Receive key input
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        chosen = 0;
                        break;
                    case ConsoleKey.W:
                        chosen = 1;
                        break;
                    default:
                        Console.WriteLine("\b \b");
                        break;
                }
                //Determine if choice is valid or redirect to input request
                if (chosen != -1 && chosen < maxChoices)
                {
                    choosing = false;
                } else
                {
                    chosen = -1;
                }
            }
            Console.WriteLine("\b \b");
            return chosen;
        }

        //Generic "Press Any Key to Continue"
        public static void Continuer()
        {
            Console.ReadKey();
            Console.WriteLine("\b \b");
        }


    }
}