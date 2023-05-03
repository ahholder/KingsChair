using System;
using System.Drawing;
using System.Threading;

namespace ConsoleAdventure
{
    class Program
    {

        //Start the program's functions
        static void Main(string[] args)
        {
            //Create the player Object
            Player player = new Player();
            for (var i = 0; i < 3; i++) player.RefreshPool(i);

            //Give Introduction
            Encounter.Intro(player);
            player.AssignRole();
            player = Encounter.Identify(player);
            for (var i = 0; i < Guidelines.MaxCycles(); i++)
            {
                player.NewCycle();

                player = Encounter.DisplayCycle(player);
                for (var i2 = 0; i2 < Guidelines.MaxEncounters(); i2++)
                {
                    player.RescQueue.Clear();
                    player.RescQueue = new List<RescChange>();
                    player = Encounter.Audience(player, i2);
                }

            }

            player.Upkeep();
            Encounter.GameOver(player);
        }

    }
}