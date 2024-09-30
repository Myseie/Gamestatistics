using Simple_Gamestatistics;

class Program
{
    static void Main()
    {
        Gamemanager manager = new Gamemanager();
        string filePath = "games.txt";
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nVälj ett alternativ");
            Console.WriteLine("1. Lägg till ett spel");
            Console.WriteLine("2. Uppdatera spelstatistik");
            Console.WriteLine("3. Visa all spelstatistik");
            Console.WriteLine("4. Sök efter ett spel");
            Console.WriteLine("5. Spara spel till fil");
            Console.WriteLine("6. Avsluta ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ange spelnamn: ");
                    string gameName = Console.ReadLine();

                    Console.Write("Ange speltyp (t.ex. fotboll, schack): ");
                    string gameType = Console.ReadLine();

                    Console.Write("Ange antal omgångar: ");
                    int rounds = int.Parse(Console.ReadLine());

                    Console.Write("Ange antal vinster: ");
                    int wins = int.Parse(Console.ReadLine());

                    Console.Write("Ange antal förluster: ");
                    int losses = int.Parse(Console.ReadLine());

                    Game newGame = new Game(gameName, gameType, rounds, wins, losses);
                    manager.AddGame(newGame);


                    break;

                case "2":
                    Console.Write("Ange spelnamn : ");
                    string gameToUpdate = Console.ReadLine();

                    Console.Write("Ange antal nya omgångar :");
                    int newRounds = int.Parse(Console.ReadLine());

                    Console.Write("Ange antal nya vinster : ");
                    int newWins = int.Parse(Console.ReadLine());

                    Console.Write("Ange antal nya förluster : ");
                    int newLosses = int.Parse(Console.ReadLine());

                    manager.UpdateGameStats(gameToUpdate, newRounds, newWins, newLosses);
                    
                    break;

                case "3":
                    manager.ShowAllGames();
                    break;

                case "4":
                    Console.Write("Ange spelnamn eller typ att söka efter : ");
                    string searchTerm = Console.ReadLine();
                    manager.SearchGame(searchTerm);

                    break;

                case "5":
                    manager.SaveToFile(filePath);
                    break;

                case "6":
                    manager.SaveToFile(filePath);
                    exit = true;
                    break;



                default:

                    Console.WriteLine("Ogiltligt val, försök igen.");
                    break;
            }
        }
    }
}
