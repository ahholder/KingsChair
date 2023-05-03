using System;
using System.Drawing;
using System.Numerics;
using System.Threading;

namespace ConsoleAdventure
{
    class Player
    {
        public string Name { get; set; }
        public int GP { get; set; } = 0;
        public int Pop { get; set; } = 10;
        public int Cycle { get; set; } = 0;
        public int Role { get; set; } = 0;
        public int[] Favor { get; set; } = { 0, 0, 0, 0, 0, 0 };
        public int[] Boost { get; set; } = { 0, 0 };
        public int Event { get; set; } = 0;
        public int Audience { get; set; } = 0;
        public int Request { get; set; } = 0;
        public int Cost { get; set; } = 1;
        public bool LastApproved { get; set; } = false;
        public string Attendee { get; set; }
        public List<int> EventPool { get; set; } = new List<int>();
        public List<int> AudiencePool { get; set; } = new List<int>();
        public List<int> RequestPool { get; set; } = new List<int>();
        public List<RescChange> RescQueue { get; set; } = new List<RescChange>();

        //Determines the amount of favor applicable to the ruler type
        public int MakeValue()
        {
            var value1 = Favor[Math.Abs(Boost[0]) - 1];
            var value2 = Favor[Math.Abs(Boost[1]) - 1];
            if (value1 != 0 && Boost[0] < 0) value1 *= -1;
            if (value2 != 0 && Boost[1] < 0) value2 *= -1;
            return value1 + value2;
        }

        //Determines the number of citizens gained/lost for a month
        public string Upkeep()
        {
            var upkeep = MakeValue();
            var gains = "";
            Populate(upkeep);
            GP += Guidelines.GoldGain();
            gains = $"You lost {upkeep}k citizens";
            if (upkeep > 0) gains = $"You gained {upkeep}k new citizens";
            gains += $" and earned {Guidelines.GoldGain()} gold!";
            return gains;
        }

        //Changes the number of citizens
        public void Populate(int num)
        {
            Pop += num;
            if (Pop < 1) Pop = 1;
        }

        //Establishes the type of ruler that a player becomes
        public void AssignRole()
        {
            var RNG = new Random(Guidelines.RNG());
            var result = RNG.Next(0, Guidelines.MaxRTypes());
            Role = result;
            if (Role == 0)
            {
                Boost[0] = 4;
                Boost[1] = 5;
            } else if (Role == 1)
            {
                Boost[0] = 1;
                Boost[1] = -3;
            }
            else if (Role == 2)
            {
                Boost[0] = 3;
                Boost[1] = 6;
            }
            else if (Role == 3)
            {
                Boost[0] = -5;
                Boost[1] = -6;
            }
            else if (Role == 4)
            {
                Boost[0] = 2;
                Boost[1] = -4;
            }
            else if (Role == 5)
            {
                Boost[0] = -1;
                Boost[1] = -2;
            }
        }

        //Provides info for what stats boost favor
        public string DescribeRole(int num)
        {
            var written = "";
            if (Boost[num] > 0)
            {
                written = "You value ";
            }
            else
            {
                written = "You hate ";
            }
            written += Terms.Favors(Math.Abs(Boost[num]));
            written += ".";
            return written;
        }

        //Assigns an Event to the player
        public void AssignEvent()
        {
            var r = new Random(Guidelines.RNG());
            var spcl = r.Next(0, EventPool.ToArray().Length);
            Event = EventPool.ToArray()[spcl];
            EventPool.Remove(Event);

            //Refresh Pool if Empty
            if (EventPool.ToArray().Length < 1) RefreshPool(0);

            //Testing
            /*string test = spcl + ": ";
            foreach (var thing in EventPool) test = test + thing + " ";
            Console.WriteLine(test);
            Console.ReadLine();*/
        }

        //Assigns an Audience to the player
        public void AssignAudience()
        {
            var r = new Random(Guidelines.RNG());
            var spcl = r.Next(0, AudiencePool.ToArray().Length);
            Audience = AudiencePool.ToArray()[spcl];
            AudiencePool.Remove(Audience);
            Attendee = Terms.Attendee();

            //Refresh Pool if Empty
            if (AudiencePool.ToArray().Length < 1) RefreshPool(1);

            //Testing
            /*string test = spcl + ": ";
            foreach (var thing in AudiencePool) test = test + thing + " ";
            Console.WriteLine(test);
            Console.ReadLine();*/
        }

        //Assigns a Request to the player
        public void AssignRequest()
        {
            var r = new Random(Guidelines.RNG());
            var spcl = r.Next(0, RequestPool.ToArray().Length);
            Request = RequestPool.ToArray()[spcl];
            RequestPool.Remove(Request);

            //Refresh Pool if Empty
            if (RequestPool.ToArray().Length < 1) RefreshPool(2);

            //Testing
            /*string test = spcl + ": ";
            foreach (var thing in RequestPool) test = test + thing + " ";
            Console.WriteLine(test);
            Console.ReadLine();*/
        }

        //Refreshes the chosen random pool
        public void RefreshPool(int num)
        {
            if (num == 0)
            {
                EventPool.Clear();
                for (var i = 0; i < Guidelines.MaxEvents(); i++) EventPool.Add(i);
            }
            if (num == 1)
            {
                AudiencePool.Clear();
                for (var i = 0; i < Guidelines.MaxAudiences(); i++) AudiencePool.Add(i);
            }
            if (num == 2)
            {
                RequestPool.Clear();
                for (var i = 0; i < Guidelines.MaxRequests(); i++) RequestPool.Add(i);
            }
        }

        //Starts a new cycle (month)
        public void NewCycle()
        {
            Cycle += 1;
            RescQueue.Clear();
            RescQueue = new List<RescChange>();
            AssignEvent();
            Cost = 1;
        }

        //Modifies the player's favor stats (resources) based on the queue
        public string Harvest(int stat, bool read, bool provide)
        {
            //int[] tally = new int[Guidelines.MaxStats() + 2];
            int[] tally = new int[9];
            var written = "";
            foreach (var i in tally) tally[i] = 0;

            //Establish basic quotas
            foreach (var resc in RescQueue)
            {
                //Fundamentals
                tally[resc.Type] += resc.Value;

                //Special operations based on events & audiences
            }

            //Special Operations based on events & audiences
            if (Audience == 0 && LastApproved == true) tally[7] += 2; //Noble approval is +2 GP
            if (Audience == 1 && LastApproved == false) tally[6] -= 1; //Nomad rejection is -1k pop.
            if (Audience == 14 && LastApproved == true) tally[0] += 1; //Veteran approval gives +1 violence
            if (Audience == 15 && LastApproved == true) tally[0] -= 1; //Missionary approval gives -1 violence
            if (Audience == 16 && LastApproved == true) tally[1] += 1; //Judge approval gives +1 order
            if (Audience == 17 && LastApproved == true) tally[1] -= 1; //Defiant approval gives -1 order
            if (Audience == 18 && LastApproved == true) tally[2] += 1; //Sage approval gives +1 learning
            if (Audience == 19 && LastApproved == true) tally[2] -= 1; //Heretic approval gives -1 learning
            if (Audience == 20 && LastApproved == true) tally[3] += 1; //Urchin approval gives +1 plague
            if (Audience == 21 && LastApproved == true) tally[3] -= 1; //Apothecary approval gives -1 plague
            if (Audience == 22 && LastApproved == true) tally[4] += 1; //Menace approval gives +1 suffering
            if (Audience == 23 && LastApproved == true) tally[4] -= 1; //Civil Servant approval gives -1 suffering
            if (Audience == 24 && LastApproved == true) tally[5] += 1; //Inventor approval gives +1 industry
            if (Audience == 25 && LastApproved == true) tally[5] -= 1; //Slob approval gives -1 industry
            if (Audience == 2 && tally[0] > 0) tally[0] *= 2; //Commander doubles violence
            if (Audience == 3 && tally[1] > 0) tally[1] *= 2; //Guard Captain doubles order
            if (Audience == 4 && tally[2] > 0) tally[2] *= 2; //Scholar doubles learning
            if (Audience == 5 && tally[3] > 0) tally[3] *= 2; //Witch Doctor doubles plague
            if (Audience == 6 && tally[4] > 0) tally[4] *= 2; //Torturer doubles suffering
            if (Audience == 7 && tally[5] > 0) tally[5] *= 2; //Baron doubles industry
            if (Audience == 8 && tally[0] > 0) tally[0] = 0; //Pacifist can't increase violence
            if (Audience == 9 && tally[1] > 0) tally[1] = 0; //Criminal can't increase order
            if (Audience == 10 && tally[2] > 0) tally[2] = 0; //Skeptic can't increase learning
            if (Audience == 11 && tally[3] > 0) tally[3] = 0; //Physician can't increase plague
            if (Audience == 12 && tally[4] > 0) tally[4] = 0; //Altruist can't increase suffering
            if (Audience == 13 && tally[5] > 0) tally[5] = 0; //Lazy can't increase industry
            if (Event == 0 && tally[4] > 0) tally[1] -= tally[4]; //Event, Riots - increasing suffering decreases order
            if (Event == 1 && tally[5] > 0 && Audience != 8) tally[0] += tally[5]; //Event, Warmongering - increasing industry increases violence
            if (Event == 1 && tally[5] > 0 && Audience == 2) tally[0] += tally[5]; //Event, Warmongering - increasing industry increases violence -- doubled
            if (Event == 2 && tally[2] > 0) tally[3] -= tally[2]; //Event, Immunization - increasing learning decreases plague
            if (Event == 3 && tally[5] > 0 && Audience != 11) tally[3] += tally[5]; //Event, Pollution - increasing industry increases plague
            if (Event == 3 && tally[5] > 0 && Audience == 5) tally[3] += tally[5]; //Event, Pollution - increasing industry increases plague -- doubled
            if (Event == 4 && tally[3] > 0 && Audience != 9) tally[1] += tally[3]; //Event, Quarantine - increasing plague increases order
            if (Event == 4 && tally[3] > 0 && Audience == 3) tally[1] += tally[3]; //Event, Quarantine - increasing plague increases order -- doubled
            if (Event == 5 && tally[1] < 0) tally[2] += tally[1]; //Event, Book Burning - decreasing order decreases learning
            if (Event == 6 && tally[0] < 0) tally[5] += tally[0]; //Event, Demilitarisation - decreasing violence decreases industry
            if (Event == 7 && tally[0] > 0) tally[1] -= tally[0]; //Event, Panic - increasing violence decreases order
            if (Event == 8 && tally[1] < 0) tally[4] += tally[1]; //Event, Celebration - decreasing order decreases suffering
            if (Event == 9 && tally[1] > 0) tally[4] -= tally[1]; //Event, Vigilance - increasing order decreases suffering
            if (Event == 10 && tally[4] > 0) tally[2] -= tally[4]; //Event, Paranoia - increasing suffering decreases learning
            if (Event == 11 && tally[2] > 0 && Audience != 13) tally[5] += tally[2]; //Event, Breakthroughs - increasing learning increases industry
            if (Event == 11 && tally[2] > 0 && Audience == 7) tally[5] += tally[2]; //Event, Breakthroughs - increasing learning increases industry -- doubled

            //Provide Favor stat changes for ALL resources
            if (provide == true) {
                for (var i = 0; i < Guidelines.MaxStats() + 2; i++)
                {
                    //Fundamentals
                    if (i < Guidelines.MaxStats() - 1) Favor[i] += tally[i];
                    if (i == Guidelines.MaxStats() - 1) Populate(tally[i]);
                    if (i == Guidelines.MaxStats()) GP += tally[i];

                    //Special Operations based on events & audiences
                }
            }

            //Optional Readout
            if (read)
            {
                if (stat < Guidelines.MaxStats() - 1) written = $"{Terms.Favors(stat + 1)} ";
                if (stat == Guidelines.MaxStats() - 1) written = $"Population ";
                if (stat == Guidelines.MaxStats()) written = $"Gold ";
                if (tally[stat] > 0)
                {
                    written += $"increases by +{Math.Abs(tally[stat])}";
                }
                else if (tally[stat] < 0)
                {
                    written += $"decreased by {Math.Abs(tally[stat])}";
                }
                else
                {
                    written += "remains unchanged";
                }
                if (stat == Guidelines.MaxStats() - 1) written += "k";
                written += "!";
                if (written.Contains("remains unchanged") == true) written = "";
            }
            return written;
        }

    }
}