using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Gamestatistics
{
    class Game
    {
        public string GameName { get; }

        public string GameType { get; }

        public int TotalRounds { get; private set;  }

        public int Wins { get; private set; }

        public int Losses { get; private set; }

        public Game(string gameName, string gameType, int totalRounds, int wins, int losses)
        {
            GameName = gameName;

            GameType = gameType;

            TotalRounds = totalRounds;

            Wins = wins;

            Losses = losses;

        }

        public void UpdateStats(int roundsPlayed, int wins, int losses)
        {
            TotalRounds += roundsPlayed;

            Wins += wins;

            Losses += losses;
        }

        public override string ToString()
        {
            return $"Spel: {GameName}, Typ: {GameType}, Omgångar: {TotalRounds}, Vinster: {Wins}, Förluster: {Losses}";
        }
    }
}
