using System;
using System.Collections.Generic;

namespace SwimApp
{
    class Program
    {
        //global variables
        static List<string> teamA = new List<string>();
        static List<string> teamB = new List<string>();
        static List<string> teamReserves = new List<string>();

        static float fastestTime = 9999f;
        static string topSwimmer = "";

        static void OneSwimmer()
        {
            //Record swimmer details
            Console.WriteLine("Enter the swimmer's name:");

            string swimmerName = Console.ReadLine();

            Console.WriteLine($"Swimmer name:  {swimmerName}");

            int sumTotalTime = 0;
            
            //Loop four times
            for (int i = 0; i < 4; i++)
            {
                int minutes, seconds, totalTime = 0;

                //Generate a random number between 1 and 4 (incl)
                Random randomNumber = new Random();
                minutes = randomNumber.Next(1, 4);
                seconds = randomNumber.Next(0, 59);

                totalTime = (minutes * 60) + seconds;

                Console.WriteLine($"Swimmer Time {i+1}: {minutes} min\t {seconds} seconds\t\tTotal time in seconds\t: {totalTime}s\t");

                sumTotalTime += totalTime;
            }

            float avgTime = (float)sumTotalTime / 4;

            if (avgTime < fastestTime)
            {
                fastestTime = avgTime;
                topSwimmer = swimmerName;
            }

            string allocatedTeam = "Reserve";

            //assign the swimmer to a team
            if(avgTime <= 160)
            {
                teamA.Add(swimmerName);
                allocatedTeam = "A";
            }
            else if(avgTime <= 210)
            {
                teamB.Add(swimmerName);
                allocatedTeam = "B";
            }
            else
            {
                teamReserves.Add(swimmerName);
            }
            Console.WriteLine($"Avg time: {avgTime}");

            Console.WriteLine($"Team: {allocatedTeam}");

          
            


            
            
        }

        //returns a string containing the team lists
        static string CreateTeamLists()
        {
            string teamLists = "The teams are:\n\nTeam A\n";

            //add team A to team list
            foreach (string swimmer in teamA)
            {
                teamLists += swimmer + "\t";
          
            
            }
            teamLists += $"\nwith{teamA.Count} team member(s)\n\n";

            //add team B to team list
            foreach (string swimmer in teamB)
            {
                teamLists += swimmer + "\t";

            }
            teamLists += $"\nwith{teamB.Count} team member(s)\n\nTeam B\n";

            //add team Reserves to team list
            foreach (string swimmer in teamReserves)
            {
                teamLists += swimmer + "\t";

            }
            teamLists += $"\nwith{teamReserves.Count} team member(s)\n\nTeam Reserves\n\n";

            return teamLists;
        } 


        



            


        static void Main(string[] args)
        {
            string flag = "";
            while (!flag.Equals("Stop"))
            {
                OneSwimmer();

                Console.WriteLine("Press <Enter> to add another swimmer ot type 'Stop' to end");
                flag = Console.ReadLine();
            }

            Console.WriteLine($"The fastest swimmer was {topSwimmer} with an average time of {fastestTime} seconds");


            Console.WriteLine(CreateTeamLists());
        }
    }
}
