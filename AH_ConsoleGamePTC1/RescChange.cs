using System;
using System.Drawing;
using System.Threading;

namespace ConsoleAdventure
{
    class RescChange
    {
        public int Type { get; set; } = 0;
        public int Value { get; set; } = 0;

        //Establishes type and value based on parameters
        public void Make(int type, int value)
        {
            Type = type;
            Value = value;
        }

        //Gathers and applies the type and amount needed
        public void Assess(int req, bool approved, int stat)
        {
            int[] changes = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //Request #0
            if (req == 0)
            {
                if (approved)
                {
                    changes[2] = 1;
                    changes[3] = -2;
                } else
                {
                    changes[3] = 1;
                }
            }
            //Request #1
            if (req == 1)
            {
                if (approved)
                {
                    changes[0] = 1;
                    changes[1] = 1;
                    changes[2] = 1;
                }
                else
                {
                    changes[0] = -1;
                }
            }
            //Request #2
            if (req == 2)
            {
                if (approved)
                {
                    changes[0] = 2;
                    changes[1] = 1;
                }
                else
                {
                    changes[4] = -1;
                }
            }
            //Request #3
            if (req == 3)
            {
                if (approved)
                {
                    changes[3] = -1;
                    changes[4] = 2;
                }
                else
                {
                    changes[3] = 1;
                }
            }
            //Request #4
            if (req == 4)
            {
                if (approved)
                {
                    changes[2] = -1;
                    changes[5] = 2;
                }
                else
                {
                    changes[2] = 1;
                }
            }
            //Request #5
            if (req == 5)
            {
                if (approved)
                {
                    changes[1] = -1;
                    changes[3] = 2;
                    changes[6] = 1;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #6
            if (req == 6)
            {
                if (approved)
                {
                    changes[0] = 2;
                    changes[2] = 1;
                }
                else
                {
                    changes[2] = -1;
                }
            }
            //Request #7
            if (req == 7)
            {
                if (approved)
                {
                    changes[0] = -1;
                    changes[2] = 2;
                }
                else
                {
                    changes[0] = 1;
                }
            }
            //Request #8
            if (req == 8)
            {
                if (approved)
                {
                    changes[4] = 1;
                    changes[5] = 2;
                }
                else
                {
                    changes[5] = -1;
                }
            }
            //Request #9
            if (req == 9)
            {
                if (approved)
                {
                    changes[4] = -2;
                    changes[5] = -1;
                }
                else
                {
                    changes[3] = 1;
                }
            }
            //Request #10
            if (req == 10)
            {
                if (approved)
                {
                    changes[5] = 2;
                    changes[7] = 1;
                }
                else
                {
                    changes[5] = -1;
                }
            }
            //Request #11
            if (req == 11)
            {
                if (approved)
                {
                    changes[3] = -2;
                    changes[5] = -1;
                }
                else
                {
                    changes[5] = 1;
                }
            }
            //Request #12
            if (req == 12)
            {
                if (approved)
                {
                    changes[0] = -1;
                    changes[1] = 1;
                    changes[5] = -1;
                }
                else
                {
                    changes[0] = 1;
                }
            }
            //Request #13
            if (req == 13)
            {
                if (approved)
                {
                    changes[2] = 1;
                    changes[3] = -1;
                    changes[4] = 1;
                }
                else
                {
                    changes[2] = -1;
                }
            }
            //Request #14
            if (req == 14)
            {
                if (approved)
                {
                    changes[2] = -2;
                    changes[3] = -1;
                }
                else
                {
                    changes[2] = 1;
                }
            }
            //Request #15
            if (req == 15)
            {
                if (approved)
                {
                    changes[4] = 1;
                    changes[5] = 2;
                }
                else
                {
                    changes[4] = -1;
                }
            }
            //Request #16
            if (req == 16)
            {
                if (approved)
                {
                    changes[2] = 2;
                    changes[5] = 1;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #17
            if (req == 17)
            {
                if (approved)
                {
                    changes[4] = -2;
                    changes[5] = -1;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #18
            if (req == 18)
            {
                if (approved)
                {
                    changes[1] = 1;
                    changes[5] = -2;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #19
            if (req == 19)
            {
                if (approved)
                {
                    changes[0] = -2;
                    changes[2] = -1;
                }
                else
                {
                    changes[2] = 1;
                }
            }
            //Request #20
            if (req == 20)
            {
                if (approved)
                {
                    changes[4] = -2;
                    changes[5] = -1;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #21
            if (req == 21)
            {
                if (approved)
                {
                    changes[2] = 2;
                    changes[3] = -1;
                }
                else
                {
                    changes[5] = 1;
                }
            }
            //Request #22
            if (req == 22)
            {
                if (approved)
                {
                    changes[0] = 2;
                    changes[4] = 1;
                }
                else
                {
                    changes[0] = -1;
                }
            }
            //Request #23
            if (req == 23)
            {
                if (approved)
                {
                    changes[0] = 2;
                    changes[3] = 1;
                }
                else
                {
                    changes[3] = -1;
                }
            }
            //Request #24
            if (req == 24)
            {
                if (approved)
                {
                    changes[0] = -1;
                    changes[1] = 1;
                    changes[5] = -1;
                }
                else
                {
                    changes[0] = 1;
                }
            }
            //Request #25
            if (req == 25)
            {
                if (approved)
                {
                    changes[2] = 2;
                    changes[4] = -1;
                }
                else
                {
                    changes[2] = -1;
                }
            }
            //Request #26
            if (req == 26)
            {
                if (approved)
                {
                    changes[0] = 2;
                    changes[2] = 1;
                }
                else
                {
                    changes[0] = -1;
                }
            }
            //Request #27
            if (req == 27)
            {
                if (approved)
                {
                    changes[0] = 1;
                    changes[1] = 2;
                }
                else
                {
                    changes[5] = -1;
                }
            }
            //Request #28
            if (req == 28)
            {
                if (approved)
                {
                    changes[2] = 2;
                    changes[5] = 1;
                }
                else
                {
                    changes[5] = -1;
                }
            }
            //Request #29
            if (req == 29)
            {
                if (approved)
                {
                    changes[4] = -2;
                    changes[5] = -1;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #30
            if (req == 30)
            {
                if (approved)
                {
                    changes[0] = -1;
                    changes[1] = 2;
                }
                else
                {
                    changes[0] = 1;
                }
            }
            //Request #31
            if (req == 31)
            {
                if (approved)
                {
                    changes[0] = 2;
                    changes[3] = 1;
                }
                else
                {
                    changes[3] = -1;
                }
            }
            //Request #32
            if (req == 32)
            {
                if (approved)
                {
                    changes[0] = -2;
                    changes[3] = 1;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #33
            if (req == 33)
            {
                if (approved)
                {
                    changes[4] = 2;
                    changes[5] = 1;
                }
                else
                {
                    changes[4] = -1;
                }
            }
            //Request #34
            if (req == 34)
            {
                if (approved)
                {
                    changes[0] = -1;
                    changes[2] = 2;
                }
                else
                {
                    changes[2] = -1;
                }
            }
            //Request #35
            if (req == 35)
            {
                if (approved)
                {
                    changes[3] = 1;
                    changes[4] = 2;
                }
                else
                {
                    changes[5] = 1;
                }
            }
            //Request #36
            if (req == 36)
            {
                if (approved)
                {
                    changes[4] = 2;
                    changes[7] = 1;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #37
            if (req == 37)
            {
                if (approved)
                {
                    changes[1] = -2;
                    changes[7] = 1;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #38
            if (req == 38)
            {
                if (approved)
                {
                    changes[2] = -2;
                    changes[7] = 1;
                }
                else
                {
                    changes[2] = 1;
                }
            }
            //Request #39
            if (req == 39)
            {
                if (approved)
                {
                    changes[1] = -2;
                    changes[6] = 1;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #40
            if (req == 40)
            {
                if (approved)
                {
                    changes[0] = 1;
                    changes[1] = -1;
                    changes[6] = 1;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #41
            if (req == 41)
            {
                if (approved)
                {
                    changes[1] = 1;
                    changes[3] = -2;
                }
                else
                {
                    changes[0] = 1;
                }
            }
            //Request #42
            if (req == 42)
            {
                if (approved)
                {
                    changes[2] = -1;
                    changes[4] = -2;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #43
            if (req == 43)
            {
                if (approved)
                {
                    changes[1] = 1;
                    changes[5] = 2;
                }
                else
                {
                    changes[5] = -1;
                }
            }
            //Request #44
            if (req == 44)
            {
                if (approved)
                {
                    changes[0] = 1;
                    changes[3] = 1;
                    changes[4] = 1;
                }
                else
                {
                    changes[4] = -1;
                }
            }
            //Request #45
            if (req == 45)
            {
                if (approved)
                {
                    changes[0] = -1;
                    changes[5] = 2;
                }
                else
                {
                    changes[0] = 1;
                }
            }
            //Request #46
            if (req == 46)
            {
                if (approved)
                {
                    changes[2] = 2;
                    changes[3] = -1;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #47
            if (req == 47)
            {
                if (approved)
                {
                    changes[5] = -3;
                }
                else
                {
                    changes[3] = 1;
                }
            }
            //Request #48
            if (req == 48)
            {
                if (approved)
                {
                    changes[3] = -1;
                    changes[4] = -2;
                }
                else
                {
                    changes[4] = 1;
                }
            }
            //Request #49
            if (req == 49)
            {
                if (approved)
                {
                    changes[0] = 1;
                    changes[1] = 2;
                }
                else
                {
                    changes[1] = -1;
                }
            }
            //Request #50
            if (req == 50)
            {
                if (approved)
                {
                    changes[0] = 2;
                    changes[2] = 1;
                }
                else
                {
                    changes[0] = -1;
                }
            }
            //Request #51
            if (req == 51)
            {
                if (approved)
                {
                    changes[1] = -2;
                    changes[4] = -1;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #52
            if (req == 52)
            {
                if (approved)
                {
                    changes[1] = -2;
                    changes[4] = 1;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #53
            if (req == 53)
            {
                if (approved)
                {
                    changes[0] = -3;
                }
                else
                {
                    changes[1] = -1;
                }
            }
            //Request #54
            if (req == 54)
            {
                if (approved)
                {
                    changes[2] = -3;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #55
            if (req == 55)
            {
                if (approved)
                {
                    changes[1] = -2;
                    changes[2] = 1;
                }
                else
                {
                    changes[1] = 1;
                }
            }
            //Request #56
            if (req == 56)
            {
                if (approved)
                {
                    changes[0] = 1;
                    changes[4] = -2;
                }
                else
                {
                    changes[0] = -1;
                }
            }
            //Request #57
            if (req == 57)
            {
                if (approved)
                {
                    changes[1] = 1;
                    changes[4] = 2;
                }
                else
                {
                    changes[1] = -1;
                }
            }
            //Request #58
            if (req == 58)
            {
                if (approved)
                {
                    changes[1] = -1;
                    changes[2] = -2;
                }
                else
                {
                    changes[2] = 1;
                }
            }
            //Request #59
            if (req == 59)
            {
                if (approved)
                {
                    changes[1] = 1;
                    changes[6] = 1;
                    changes[7] = 1;
                }
                else
                {
                    changes[1] = -1;
                }
            }
            //Request #60
            if (req == 60)
            {
                if (approved)
                {
                    changes[0] = 0;
                    changes[0] = 0;
                }
                else
                {
                    changes[0] = 0;
                }
            }

            //Final
            Make(stat, changes[stat]);
        }

        //Provides a readout of the changes
        public string Read()
        {
            string written = "";
            if (Value > 0) written = "+";
            written = written + Value + " ";
            if (Type < Guidelines.MaxStats() - 1) written += Terms.Favors(Type + 1);
            if (Type == Guidelines.MaxStats() - 1) written += "Population";
            if (Type > Guidelines.MaxStats() - 1) written += "Gold";
            return written;
        }

    }
}