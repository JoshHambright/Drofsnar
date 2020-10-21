using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Drofsnar
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> newDict = new Dictionary<string, string>()
            //{
            //    {"Alex", "Blastoise" },
            //    {"Khaled", "Pikachu" },
            //    {"Nathan", "Charizard" },
            //    {"Stasi", "charizard" }
            //};
            //newDict.Add("Josh", "Pigeon");

            //string joshPokemon = newDict["Josh"];
            //Console.WriteLine(joshPokemon);
            //Console.ReadKey();

            string gameSequence = System.IO.File.ReadAllText(@"D:\ElevenFiftyProjects\DotNetProjects\Drofsnar\game-sequence.txt");
            //Console.WriteLine(gameSequence);
            //Console.ReadKey();
            string[] steps = gameSequence.Split(',');
            //foreach (string step in steps)
            //{
            //    Console.WriteLine(step);
            //}
            //Console.ReadKey();
            Dictionary<string, int> points = new Dictionary<string, int>()
            {
                {"Bird", 10 },
                {"CrestedIbis", 100 },
                {"GreatKiskudee", 300 },
                {"RedCrossbill", 500 },
                {"Red-neckedPhalarope", 700 },
                {"EveningGrosbeak", 1000 },
                {"GreaterPrairieChicken", 2000 },
                {"IcelandGull", 3000 },
                {"Orange-belliedParrot", 5000 },
                {"InvincibleBirdHunter", 0 },
                {"VulnerableBirdHunter", 0 }
            };
            int scoreKeeper = 5000;
            int currentLives = 3;
            int vulnerableBirdHunterPoints = 200;
            bool bonusLife = false;
            Console.WriteLine(scoreKeeper);
            foreach (string step in steps)
            {
                if (currentLives > 0)
                {
                    if (step == "InvincibleBirdHunter")
                    {
                        //Invincible Bird Hunter Encountered: Lose a life, no points Assigned
                        currentLives--;
                        vulnerableBirdHunterPoints = 200;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Encounter: " + step + " ------- Current score " + scoreKeeper + "---------- Curent Lives " + currentLives);
                        Console.ResetColor();

                    }
                    else if (step == "VulnerableBirdHunter")
                    {
                        //Vulnerable Bird Hunter Encountered: Check how many bird hunters eaten, points double each time.
                        scoreKeeper = scoreKeeper + vulnerableBirdHunterPoints;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine("Encounter: " + step + "--" + vulnerableBirdHunterPoints + " pts ------- Current score " + scoreKeeper + "---------- Curent Lives " + currentLives);
                        Console.ResetColor();
                        vulnerableBirdHunterPoints = vulnerableBirdHunterPoints * 2;

                    }
                    else
                    {

                        // Basic Scoring based on points and birds
                        scoreKeeper = scoreKeeper + points[step];
                        Console.WriteLine("Encounter: " + step + "--" + points[step] + " pts  ------------ Current score " + scoreKeeper + "---------- Curent Lives " + currentLives);
                    }

                    if (bonusLife == false && scoreKeeper >= 10000)
                    {
                        bonusLife = true;
                        currentLives++;
                        Console.WriteLine("BONUS LIFE!");
                    }

                }
                else { Console.WriteLine("You Ded"); break; }


            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Final Score: " + scoreKeeper);
            Console.ReadKey();


        }
    }
}
