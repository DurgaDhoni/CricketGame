using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketUpdatedGame
{
    class Team
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int BallsFaced { get; set; }
    }

    class CricketApp
    {
        private List<Team> _teams;
        public CricketApp()
        {
            _teams = new List<Team>();
        }
        public void GetPlayers()
        {
            Console.Write("Enter Total Number of Players in You Team : ");
            int playerCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < playerCount; i++)
            {
                Console.Write($"Enter the Player {i + 1} Name : ");
                string name = Console.ReadLine();
                _teams.Add(new Team()
                {
                    Name = name,
                });
            }
        }
        public void StartGame()
        {
            var random = new Random();
            foreach(var player in _teams)
            {
                Console.WriteLine($"{player.Name} is Know entered the crease");
                int balls = 0;
                while (true)
                {
                    Console.Write($"{player.Name} enter you score");
                    int score = Convert.ToInt32(Console.ReadLine());
                    int bowler = random.Next(0, 7);
                    Console.WriteLine($"{player.Name} hits a = {score}");
                    Console.WriteLine($"Bowler bouls a {bowler}");
                    if (score<0 && score > 6)
                    {
                        continue;
                    }
                    if (score == bowler)
                    {
                        break;
                    }
                    balls++;
                    player.Score += score;
                    player.BallsFaced = balls;
                }
            }
        }
        public void ScoreCard()
        {
            int totalScore = 0;
            foreach(var p in _teams)
            {
                totalScore += p.Score;
                Console.WriteLine($"{p.Name}---------{p.Score}({p.BallsFaced})");
            }
            Console.WriteLine($"Total Score is {totalScore}");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var startgame = new CricketApp();
            startgame.GetPlayers();
            startgame.StartGame();
            startgame.ScoreCard();
        }
    }
}
