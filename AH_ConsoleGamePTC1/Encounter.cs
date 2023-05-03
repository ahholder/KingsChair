using System;
using System.Drawing;
using System.Numerics;
using System.Threading;

namespace ConsoleAdventure
{
    class Encounter
    {
        //Clears the screen from prior encounter info
        public static void Reset()
        {
            Console.Clear();
            Console.CursorVisible = false;
        }

        //Creates a line of text that includes appropriate icon info & display info
        public static void MakeLine(int icon, int row, string line, Player player)
        {
            var written = Icon.DrawIcon(icon, row, player);
            written += line;
            written = "| " + written;
            written += Guidelines.LineCloser(written);
            Console.WriteLine(written);
        }

        //Generates multiple lines based on string input
        public static void MakeLineBatch(string[] lines, int icon, int row, int line, Player player)
        {
            var written = "";
            for (var i = 0; i < line; i++)
            {
                written = lines[i];
                if (written.ToLower() != "spacer")
                {
                    if (i <= 6)
                    {
                        MakeLine(icon, row, written, player);
                    }
                    else if (i > 6 && icon == 8 && i < 10)
                    {
                        MakeLine(icon, row, written, player);
                    }
                    else
                    {
                        MakeLine(-1, row, written, player);
                    }
                    row += 1;
                } else
                {
                    Guidelines.Spacer();
                }
            }
        }

        //Introduces the premise and mechanics
        public static void Intro(Player player)
        {
            Reset();
            string written = "";
            int icon = 0;
            int row = 0;
            var line = 0;
            string[] lines = new string[20];

            //Provide Readouts
            lines[line] = "The death of a distant relative has left you the successor to the kingdom's throne!";
            line += 1;
            lines[line] = $"You will need to grow your kingdom to a population of {Guidelines.Goal()}k by year's end.";
            line += 1;
            lines[line] = "Each day, you will have an audience with 5 citizens making requests.";
            line += 1;
            lines[line] = "Use your kingdom's resources to further your goals and grow your population.";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "Make your choices using Q & W";
            line += 1;
            lines[line] = "Press any key to continue!";
            line += 1;
            lines[line] = "";
            line += 1;

            //Create Title
            Guidelines.Title("Introduction to King's Chair:");

            //Create Lines
            MakeLineBatch(lines, icon, row, line, player);

            //Final
            Guidelines.Spacer();
            Choice.Continuer();
        }

        //Allows the player to name themselves and learn what type of ruler they are
        public static Player Identify(Player player)
        {
            Reset();
            string written = "";
            int icon = 0;
            int row = 0;
            var line = 0;
            string[] lines = new string[20];

            //Provide Readouts
            lines[line] = "You are " + Terms.RTypes(player.Role) + "!";
            line += 1;
            lines[line] = player.DescribeRole(0);
            line += 1;
            lines[line] = player.DescribeRole(1);
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "When you are ready, enter your name and begin your rule!";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;

            //Create Title
            Guidelines.Title("Your Role as Ruler:");

            //Create Lines
            MakeLineBatch(lines, icon, row, line, player);

            //Assign Name
            Guidelines.Spacer();
            Console.CursorVisible = true;
            player.Name = Console.ReadLine();

            //Successful Readout Begins

            Reset();
            icon = 0;
            row = 0;
            line = 0;

            //Provide Readouts
            lines[line] = "You are now Lord " + player.Name + ", leader of the " + Terms.RTypes(player.Role) + " kingdom!";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "Press any key to continue!";
            line += 1;
            lines[line] = "";
            line += 1;

            //Create Title
            Guidelines.Title("Your Role as Ruler:");

            //Create Lines
            MakeLineBatch(lines, icon, row, line, player);

            //Absolute Final
            Guidelines.Spacer();
            Choice.Continuer();
            return player;
        }

        //Provides information for the start of a new cycle (month)
        public static Player DisplayCycle(Player player)
        {
            Reset();
            string written = "";
            int icon = 8;
            int row = 0;
            var line = 0;
            string[] lines = new string[20];

            //Provide Readouts
            lines[line] = "Another month has passed under your rule of the kingdom!";
            line += 1;
            lines[line] = player.Upkeep();
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = $"You have received reports of {Terms.Event(0, player.Event)}.";
            line += 1;
            lines[line] = $"This month, {Terms.Event(1, player.Event)}.";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = $"You will have {Guidelines.MaxEncounters()} audiences this month.";
            line += 1;
            lines[line] = $"It will cost you {player.Cost} gold to approve a request.";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "Press any key to continue!";
            line += 1;
            lines[line] = "";
            line += 1;

            //Create Title
            written = player.Name + "'s " + " Kingdom - Month #" + player.Cycle + " - " + Guidelines.Goal() + "k Population Goal:";
            Guidelines.Title(written);

            //Create Lines
            MakeLineBatch(lines, icon, row, line, player);

            //Final
            Guidelines.Spacer();
            Choice.Continuer();
            return player;
        }

        //Goes through an audience
        public static Player Audience(Player player, int round)
        {
            Reset();
            string written = "";
            int icon = 8;
            int row = 0;
            var line = 0;
            string[] lines = new string[20];
            var r = new Random(Guidelines.RNG());
            var decision = 0;
            bool approved = false;
            player.AssignAudience();
            player.AssignRequest();

            //Provide Readouts
            lines[line] = Terms.RTypes(player.Role) + ":";
            line += 1;
            lines[line] = player.DescribeRole(0);
            line += 1;
            lines[line] = player.DescribeRole(1);
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = Terms.Event(0, player.Event) + ":";
            line += 1;
            lines[line] = Terms.Event(1, player.Event);
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = $"{player.Attendee} the {Terms.Audience(0, player.Audience)}:";
            line += 1;
            lines[line] = Terms.Audience(1, player.Audience);
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;

            //Create Title
            written = player.Name + "'s " + " Kingdom - Month #" + player.Cycle + " - " + Guidelines.Goal() + "k Population Goal - Audience " + (round + 1) + " / " + Guidelines.MaxEncounters() + ":";
            Guidelines.Title(written);

            //Create Lines
            MakeLineBatch(lines, icon, row, line, player);
            Guidelines.Spacer();

            //Create Selection Details
            written = "";
            icon = r.Next(0, 8);
            row = 0;
            line = 0;

            //Provide Readouts II
            lines[line] = Terms.Requests(player.Request, 0);
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = Terms.Requests(player.Request, 1);
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = Terms.Requests(player.Request, 2);
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "<Make your choices using [Q / W]>";
            line += 1;
            lines[line] = "";
            line += 1;

            //Create Lines II
            MakeLineBatch(lines, icon, row, line, player);

            //Selection Detail Closer
            Guidelines.Spacer();
            decision = Choice.Option(2);

            //Execute Decision
            if (decision == 0 && player.GP >= player.Cost) approved = true;
            player.LastApproved = approved;
            if (approved == true) player.GP -= player.Cost;
            player = AudienceDecision(player, decision, approved);

            //Final
            return player;
        }

        //Introduces the premise and mechanics
        public static Player AudienceDecision(Player player, int decision, bool approved)
        {
            Reset();
            string written = "";
            var r = new Random(Guidelines.RNG());
            int icon = 8;
            int row = 0;
            var line = 1;
            string[] lines = new string[20];
            var num = player.Request;

            //Apply Results
            for (var i2 = 1; i2 < Guidelines.MaxStats() + 2; i2++)
            {
                RescChange proxy = new RescChange();
                proxy.Assess(num, approved, i2 - 1);
                if (proxy.Read().Contains("0") != true)
                    {
                    if (written != "") written += ", ";
                    //written += proxy.Read();
                    player.RescQueue.Add(proxy);
                }
            }
            player.Harvest(0, false, true);
            for (var i = 0; i < Guidelines.MaxStats() + 1; i++)
            {
                lines[line] = player.Harvest(i, true, false);
                if (player.Harvest(i, true, false) != "") line += 1;
            }
            if (line < 15)
            {
                for (var i2 = line; i2 < 8; i2++)
                {
                    lines[line] = $" ";
                    line += 1;
                }
            }

            //Provide Readouts
            if (approved == false && decision == 0)
            {
                lines[0] = "You lack funding and must REJECT the request!";
            } else if (approved == false)
            {
                lines[0] = "You decide to REJECT the request!";
            } else
            {
                lines[0] = "You decide to APPROVE the request!";
            }

            lines[line] = "Press any key to continue!";
            line += 1;
            lines[line] = "";
            line += 1;
            lines[line] = "";
            line += 1;

            //Create Title
            written = player.Name + "'s " + Terms.RTypes(player.Role) + " Kingdom - Month #" + player.Cycle + ":";
            Guidelines.Title(written);

            //Create Lines
            MakeLineBatch(lines, icon, row, line, player);

            //Final
            Guidelines.Spacer();
            Choice.Continuer();
            return player;
        }

        //Game Over - Victory or Defeat
        public static void GameOver(Player player)
        {
            Reset();
            string written = "";
            int icon = 5;
            int row = 0;
            var line = 0;
            string[] lines = new string[20];
            bool win = false;

            //Determine Victory
            if (player.Pop >= Guidelines.Goal()) win = true;
            if (win == true) icon = 0;

            //Fashion Display

            //Provide Readouts
            if (win == false)
            {
                lines[line] = $"You have ended the year with only {player.Pop}k citizens!";
                line += 1;
                lines[line] = "Without a large enough population, your kingdom loses its identity.";
                line += 1;
                lines[line] = "Neighboring kingdoms lay uncontested claim to your lands.";
                line += 1;
                lines[line] = "Your people are scattered across borders. Your advisors abandon you.";
                line += 1;
                lines[line] = "Your reign on the king's chair ends in failure...";
                line += 1;
                lines[line] = "";
                line += 1;
                lines[line] = "Press any key to end the game";
                line += 1;
                lines[line] = "";
                line += 1;
            } else
            {
                lines[line] = $"You have ended the year with {player.Pop}k citizens!";
                line += 1;
                lines[line] = "Your culture and way of life have been thoroughly secured.";
                line += 1;
                lines[line] = "Every citizen in the kingdom has you to thank for that.";
                line += 1;
                lines[line] = "As one, the people wholly accept you as their new ruler.";
                line += 1;
                lines[line] = "Your legend will only grow as your reign continues on the king's chair...";
                line += 1;
                lines[line] = "";
                line += 1;
                lines[line] = "Press any key to end the game";
                line += 1;
                lines[line] = "";
                line += 1;
            }

            //Create Title
            if (win == false) Guidelines.Title("DEFEAT:");
            if (win == true) Guidelines.Title("VICTORY:");

            //Create Lines
            MakeLineBatch(lines, icon, row, line, player);

            //Final
            Guidelines.Spacer();
            Choice.Continuer();
        }

    }
}