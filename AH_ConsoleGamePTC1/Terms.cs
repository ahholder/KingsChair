using System;
using System.Drawing;
using System.Threading;

namespace ConsoleAdventure
{
    class Terms
    {
        //Returns a valid key from the input list
        public static string Valid(int key)
        {
            if (key == 0) return "Q - ";
            if (key == 1) return "W - ";
            if (key == 2) return "E - ";
            if (key == 3) return "R - ";
            //Unrecognized key number
            return "X - ";
        }

        //Returns the attribute names for rulership progress
        public static string Favors(int num)
        {
            if (num == 1) return "Violence";
            if (num == 2) return "Order";
            if (num == 3) return "Learning";
            if (num == 4) return "Plague";
            if (num == 5) return "Suffering";
            if (num == 6) return "Industry";
            //Population increases @ val 7
            //Gold increases @ val 8

            //Unrecognized attribute
            return "Other";
        }

        //Returns the names for the different types of rulers
        public static string RTypes(int num)
        {
            if (num == 0) return "Undead"; //Likes Plague, Likes Suffering
            if (num == 1) return "Orcish"; //Likes Violence, Dislikes Learning
            if (num == 2) return "Gnomish"; //Likes Learning, Likes Industry
            if (num == 3) return "Elven"; //Dislikes Suffering, Dislikes Industry
            if (num == 4) return "Celstial"; //Likes Order, Dislikes Plague
            if (num == 5) return "Fey"; //Dislikes Violence, Dislikes Order
            /*if (num == 6) return ""; //
            if (num == 7) return ""; //
            if (num == 8) return ""; //
            if (num == 9) return ""; //
            if (num == 10) return ""; //
            if (num == 11) return ""; //*/

            //Unrecognized Ruler Type
            return "Noble";
        }

        //Returns a name/description for a special event
        public static string Event(int style, int num)
        {
            var i = 0;
            string final = "";
            string[] name = new string[Guidelines.MaxEvents() + 1];
            string[] info = new string[Guidelines.MaxEvents() + 1];
            //Catalogue of events
            name[i] = "RIOTS";
            info[i] = "increasing Suffering decreases Order";
            i += 1;
            name[i] = "WARMONGERING";
            info[i] = "increasing Industry increases Violence";
            i += 1;
            name[i] = "IMMUNIZATION";
            info[i] = "increasing Learning decreases Plague";
            i += 1;
            name[i] = "POLLUTION";
            info[i] = "increasing Industry increases Plague";
            i += 1;
            name[i] = "QUARANTINES";
            info[i] = "increasing Plague increases Order";
            i += 1;
            name[i] = "BOOK BURNING";
            info[i] = "decreasing Order decreases Learning";
            i += 1;
            name[i] = "DEMILITARISATION";
            info[i] = "decreasing Violence decreases Industry";
            i += 1;
            name[i] = "PANIC";
            info[i] = "increasing Violence decreases Order";
            i += 1;
            name[i] = "CELEBRATION";
            info[i] = "decreasing Order decreases Suffering";
            i += 1;
            name[i] = "VIGILANCE";
            info[i] = "increasing Order decreases Suffering";
            i += 1;
            name[i] = "PARANOIA";
            info[i] = "increasing Suffering decreases Learning";
            i += 1;
            name[i] = "BREAKTHROUGHS";
            info[i] = "increasing Learning increases Industry";
            i += 1;
            name[i] = "Placeholder";
            info[i] = "";
            i += 1;

            //Determine Final Output
            final = name[num];
            if (style == 1) final = info[num];
            if (style == 2) final = name[num] + " - " + info[num];
            return final;
        }

        //Returns a name/description for an audience attendee
        public static string Audience(int style, int num)
        {
            var i = 0;
            string final = "";
            string[] name = new string[Guidelines.MaxAudiences() + 1];
            string[] info = new string[Guidelines.MaxAudiences() + 1];
            //Catalogue of events
            name[i] = "NOBLE";
            info[i] = "Approval grants you +2 Gold";
            i += 1;
            name[i] = "NOMAD";
            info[i] = "Rejection causes -1k Population";
            i += 1;
            name[i] = "COMMANDER";
            info[i] = "Violence gain doubles";
            i += 1;
            name[i] = "GUARD CAPTAIN";
            info[i] = "Order gain doubles";
            i += 1;
            name[i] = "SCHOLAR";
            info[i] = "Learning gain doubles";
            i += 1;
            name[i] = "WITCH DOCTOR";
            info[i] = "Plague gain doubles";
            i += 1;
            name[i] = "TORTURER";
            info[i] = "Suffering gain doubles";
            i += 1;
            name[i] = "BARON";
            info[i] = "Industry gain doubles";
            i += 1;
            name[i] = "PACIFIST";
            info[i] = "Violence can't increase";
            i += 1;
            name[i] = "CRIMINAL";
            info[i] = "Order can't increase";
            i += 1;
            name[i] = "SKEPTIC";
            info[i] = "Learning can't increase";
            i += 1;
            name[i] = "PHYSICIAN";
            info[i] = "Plague can't increase";
            i += 1;
            name[i] = "ALTRUIST";
            info[i] = "Suffering can't increase";
            i += 1;
            name[i] = "LAZY";
            info[i] = "Industry can't increase";
            i += 1;
            name[i] = "VETERAN";
            info[i] = "Approval grants +1 Violence";
            i += 1;
            name[i] = "MISSIONARY";
            info[i] = "Approval grants -1 Violence";
            i += 1;
            name[i] = "JUDGE";
            info[i] = "Approval grants +1 Order";
            i += 1;
            name[i] = "DEFIANT";
            info[i] = "Approval grants -1 Order";
            i += 1;
            name[i] = "SAGE";
            info[i] = "Approval grants +1 Learning";
            i += 1;
            name[i] = "HERETIC";
            info[i] = "Approval grants -1 Learning";
            i += 1;
            name[i] = "URCHIN";
            info[i] = "Approval grants +1 Plague";
            i += 1;
            name[i] = "APOTHECARY";
            info[i] = "Approval grants -1 Plague";
            i += 1;
            name[i] = "MENACE";
            info[i] = "Approval grants +1 Suffering";
            i += 1;
            name[i] = "CIVIL SERVANT";
            info[i] = "Approval grants -1 Suffering";
            i += 1;
            name[i] = "INVENTOR";
            info[i] = "Approval grants +1 Industry";
            i += 1;
            name[i] = "SLOB";
            info[i] = "Approval grants -1 Industry";
            i += 1;
            name[i] = "Placeholder";
            info[i] = "";
            i += 1;

            //Determine Final Output
            final = name[num];
            if (style == 1) final = info[num];
            if (style == 2) final = name[num] + " - " + info[num];
            return final;
        }

        //Returns an audience's request and possible responses
        public static string Requests(int num, int part)
        {
            string request = "";
            string resp1 = "";
            string resp2 = "";
            RescChange proxy = new RescChange();

            for (var i2 = 1; i2 < Guidelines.MaxStats() + 2; i2++)
            {
                proxy.Assess(num, true, i2 - 1);
                if (proxy.Read().Contains("0") != true)
                {
                    if (resp1 != "") resp1 += ", ";
                    resp1 += proxy.Read();
                }
                proxy.Assess(num, false, i2 - 1);
                if (proxy.Read().Contains("0") != true)
                {
                    if (resp2 != "") resp2 += ", ";
                    resp2 += proxy.Read();
                }
            }

            //Potential Requests
            if (num == 0) request = "We need the state alchemists to cure a blight ravaging our crops!";
            if (num == 1) request = "Military service should be mandatory for all citizens.";
            if (num == 2) request = "We need more public executions.";
            if (num == 3) request = "We should burn smaller villages afflicted with the plague.";
            if (num == 4) request = "The minimum working age should be lowered.";
            if (num == 5) request = "Groups of refugees are asking you for asylum.";
            if (num == 6) request = "Military research needs more funding.";
            if (num == 7) request = "Old military outposts should be converted into schools.";
            if (num == 8) request = "Workers' hours should be increased.";
            if (num == 9) request = "Welfare programs should be expanded.";
            if (num == 10) request = "I would like to oversee the opening of a new gold mine.";
            if (num == 11) request = "We should sanction farms in plague-infested regions.";
            if (num == 12) request = "Shutdown the warehouses being used as drug dens!";
            if (num == 13) request = "We need fewer ethical restrictions on alchemical research.";
            if (num == 14) request = "We should bar sick children from our institutions.";
            if (num == 15) request = "Prisoners should be utilized as a source of labor.";
            if (num == 16) request = "Prisons should be more focused on reforms, not punishment.";
            if (num == 17) request = "We should cap the number of hours in a citizen's workweek.";
            if (num == 18) request = "Our sacred forests should no longer be harvested for timber.";
            if (num == 19) request = "We should divert funds from military research.";
            if (num == 20) request = "We should host a festival this week!";
            if (num == 21) request = "Academies should encourage alchemical studies over manual labor.";
            if (num == 22) request = "We should invade the neighboring kingdom while they are vulnerable!";
            if (num == 23) request = "Your alchemists want to weaponize an existing plague.";
            if (num == 24) request = "Negotiate an end to this violent workers' uprising!";
            if (num == 25) request = "We need more funding for your academies.";
            if (num == 26) request = "Study of military tactics should be offered to our academy students.";
            if (num == 27) request = "Declare martial law on your rebellious provinces!";
            if (num == 28) request = "We need blueprints for bridges to better connect our provinces.";
            if (num == 29) request = "We should limit city growth to curb the spread of disease.";
            if (num == 30) request = "Violent crime should be punishable by death.";
            if (num == 31) request = "Battlefield medics should switch to more offensive roles.";
            if (num == 32) request = "We need to protect our leper colonies from abuse.";
            if (num == 33) request = "We should reduce the amount of leisure time for our workforce.";
            if (num == 34) request = "Academics should be spared from military drafts.";
            if (num == 35) request = "We should divert funds going to improved working conditions.";
            if (num == 36) request = "We should increase taxes for this month.";
            if (num == 37) request = "We should nationally monetize gambling rings.";
            if (num == 38) request = "Entry fees for our academies should be increased.";
            if (num == 39) request = "We should begin integrating our war prisoners into society.";
            if (num == 40) request = "Parole should be offered to several lifelong prisoners.";
            if (num == 41) request = "Armed forces should quell wandering groups of the infected.";
            if (num == 42) request = "We should not resort to torturing information from our prisoners.";
            if (num == 43) request = "New roads should be built to connect our kingdom.";
            if (num == 44) request = "Sick and wounded soldiers should remain on the front lines.";
            if (num == 45) request = "We should convert certain military installations to textiles.";
            if (num == 46) request = "Funding should go to alchemical cures for common ailments.";
            if (num == 47) request = "We should limit overfishing before a famine is inevitable.";
            if (num == 48) request = "Extra treasury funds should go to feeding the impoverished.";
            if (num == 49) request = "Military deserters should be executed.";
            if (num == 50) request = "Career soldiers should be trained for your army.";
            if (num == 51) request = "Outdated, ceremonial laws should be stricken from records.";
            if (num == 52) request = "Guards should be forgiven for turning a blind eye to petty crime.";
            if (num == 53) request = "New sanctions should be placed on civilian weapon ownership.";
            if (num == 54) request = "Book censorship should be increased.";
            if (num == 55) request = "Military chain of command should be less rigidly enforced.";
            if (num == 56) request = "We should hold a yearly festival featuring arena combat.";
            if (num == 57) request = "Arriving refugees should be scattered and integrated into our culture.";
            if (num == 58) request = "Academy attendance should not be mandatory.";
            if (num == 59) request = "We should conduct a population census to streamline tax collection.";
            if (num == 60) request = "";

            //Final
            if (resp1 == "") resp1 = "Nothing Happens";
            if (resp2 == "") resp2 = "Nothing Happens";
            resp1 = "Accept (Q): " + resp1;
            resp2 = "Reject (W): " + resp2;
            request = "\"" + request + "\"";
            if (part == 0) return request;
            if (part == 1) return resp1;
            if (part == 2) return resp2;
            return "";
        }



        //Returns a random name for an attendee
        public static string Attendee()
        {
            var i = 0;
            var r = new Random(Guidelines.RNG());
            var num = r.Next(0, Guidelines.MaxAnames());
            string final = "";
            string[] name = new string[Guidelines.MaxAnames() + 1];
            //Catalogue of events
            name[i] = "Alexander";
            i += 1;
            name[i] = "Danielle";
            i += 1;
            name[i] = "David";
            i += 1;
            name[i] = "Ella";
            i += 1;
            name[i] = "Domenick";
            i += 1;
            name[i] = "Ilja";
            i += 1;
            name[i] = "Peter";
            i += 1;
            name[i] = "Jas";
            i += 1;
            name[i] = "Hunter";
            i += 1;
            name[i] = "Preston";
            i += 1;
            name[i] = "Julie";
            i += 1;
            name[i] = "Daniel";
            i += 1;
            name[i] = "Alaina";
            i += 1;
            name[i] = "Kelly";
            i += 1;
            name[i] = "Haley";
            i += 1;
            name[i] = "Dustin";
            i += 1;
            name[i] = "Liliana";
            i += 1;
            name[i] = "Tim";
            i += 1;
            name[i] = "Ashlyn";
            i += 1;
            name[i] = "Stuart";
            i += 1;
            name[i] = "Roxanne";
            i += 1;
            name[i] = "Eugene";
            i += 1;
            name[i] = "Nancy";
            i += 1;
            name[i] = "Richard";
            i += 1;
            name[i] = "Kathy";
            i += 1;
            name[i] = "Chuck";
            i += 1;
            name[i] = "Francie";
            i += 1;
            name[i] = "Andy";
            i += 1;
            name[i] = "Dianna";
            i += 1;
            name[i] = "Alec";
            i += 1;
            name[i] = "PLACEHOLDER";
            i += 1;

            //Determine Final Output
            final = name[num];
            return final;
        }

    }
}