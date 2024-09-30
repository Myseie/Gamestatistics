using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Gamestatistics
{
    class Gamemanager
    {
        private List<Game> games = new List<Game>();


        public void AddGame(Game game)
        {
            games.Add(game);

            Console.WriteLine($"Spelet : '{game.GameName}' har lagts till ");


        }

        public void UpdateGameStats(string gameName, int roundsPlayed, int wins, int losses)
        {
            Game gameToUpdate = games.Find(g => g.GameName.ToLower() == gameName.ToLower());

            if (gameToUpdate != null )
            {
                gameToUpdate.UpdateStats(roundsPlayed, wins, losses);
                Console.WriteLine($"Statistiken för spelet '{gameToUpdate.GameName}' har uppdaterats.");
            }
            else
            {
                Console.WriteLine($"Inget spel med namnet '{gameName}' hittades");
            }
        }

        public void ShowAllGames()
        {
            if ( games.Count == 0 )
            {
                Console.WriteLine("Inga spel har lagts till ännu");
            }
            else
            {
                Console.WriteLine("Spelstatistik:");
                foreach ( var game in games )
                {
                    Console.WriteLine(game);
                }
            }
        }

        public void SearchGame(string searchTerm)
        {
            List<Game> foundGames = games.FindAll(g => g.GameName.ToLower().Contains(searchTerm.ToLower()) || g.GameType.ToLower().Contains(searchTerm.ToLower()));
            if (foundGames.Count > 0) 
            {
                Console.WriteLine("Spel hittade:");
                foreach( var game in foundGames )
                {
                    Console.WriteLine(game);
                }
            }
            else
            {
                Console.WriteLine($"Inga spel hittades med sökordet : {searchTerm}");

            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var game in games)
                {
                    writer.WriteLine($"{game.GameName}, {game.GameType}, {game.TotalRounds}, {game.Wins}, {game.Losses}");
                }
            }
            Console.WriteLine("Spelstatistik har sparats till fil");
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        string gameName = parts[0];
                        string gameType = parts[1];
                        int totalRounds = int.Parse(parts[2]);
                        int wins = int.Parse(parts[3]);
                        int losses = int.Parse(parts[4]);

                        Game loadedGame = new Game(gameName, gameType, totalRounds, wins, losses);
                        games.Add(loadedGame);  
                    }
                }
            }
        }
    }
}
