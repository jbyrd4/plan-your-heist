﻿using System;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Team squad = new Team();
            Console.WriteLine("Plan your heist!");
            Console.WriteLine("What is your name, Comrade Member?");
            string response = Console.ReadLine();
            while (!String.IsNullOrWhiteSpace(response))
            {
                TeamMember fool = new TeamMember(response);
                squad.AddTeamMember(fool);
                Console.WriteLine("What is your friend's name, Comrade member?");
                response = Console.ReadLine();
            }
            //make the bank here so they can choose the bank after making the team
            Bank bank = new Bank("Big Bank");
            // ask for how many trial runs
            Console.WriteLine("How many times should we hit this bank, COMRADE?");
            int trialRuns = int.Parse(Console.ReadLine());
            //loop to run trials
            for (int i = 0; i < trialRuns; i++)
            {
                bank.NewDifficulty();
                squad.addTeamSkillLevel();
                //display teams skill lvl and bank difficulty
                Console.WriteLine($"Bank: {bank.DifficultyLevel} || Squad: {squad.TeamSkillLevel}");


                if (squad.TeamSkillLevel > bank.DifficultyLevel)
                {
                    Console.WriteLine("Great Success!");
                    squad.Successes++;
                }
                else
                {
                    Console.WriteLine("Failure");
                    squad.Failures++;
                }
            }

            Console.WriteLine($"Comrade, we have been successful {squad.Successes} times, and failed {squad.Failures} times.");

            // Console.WriteLine($"You have a team of {squad.GetTeamSize()}.");
            // Console.WriteLine("The team is as follows: ");
            // squad.DisplayMembersInfo();
        }
    }
}
