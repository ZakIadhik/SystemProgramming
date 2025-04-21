using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingApp
{
    public class CasinoGame
    {
        private const int MaxPlayers = 5; 
        private const int MinPlayers = 20; 
        private const int MaxPlayersCount = 100; 
        private SemaphoreSlim _tableSemaphore = new SemaphoreSlim(MaxPlayers, MaxPlayers); 
        private List<Player> _players = new List<Player>();
        private Random _random = new Random();

        public async Task StartGame()
        {
            int totalPlayers = _random.Next(MinPlayers, MaxPlayersCount); 
            List<Task> playerTasks = new List<Task>();

           
            for (int i = 0; i < totalPlayers; i++)
            {
                Player player = new Player(i + 1, _random.Next(100, 500)); 
                _players.Add(player);

              
                playerTasks.Add(Task.Run(() => PlayGame(player)));
            }

         
            await Task.WhenAll(playerTasks);

          
            await WriteReportAsync();
        }

        private async Task PlayGame(Player player)
        {
            await _tableSemaphore.WaitAsync(); 

            try
            {
                int initialMoney = player.Money;
                Console.WriteLine($"Player {player.Id} started the game with {player.Money}.");

              
                while (player.Money > 0)
                {
                    int bet = _random.Next(10, player.Money + 1);
                    int betNumber = _random.Next(1, 37); 
                    int winNumber = _random.Next(1, 37); 

                    if (betNumber == winNumber)
                    {
                   
                        player.Money += bet;
                        Console.WriteLine($"Player {player.Id} won {bet}. Balance: {player.Money}.");
                    }
                    else
                    {
                      
                        player.Money -= bet;
                        Console.WriteLine($"Player {player.Id} lost {bet}. Balance: {player.Money}.");
                    }

                 
                    await Task.Delay(500);
                }

                Console.WriteLine($"Player {player.Id} finished the game with {player.Money}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in game for player {player.Id}: {ex.Message}");
            }
            finally
            {
                _tableSemaphore.Release(); 
            }
        }

        private async Task WriteReportAsync()
        {
            try
            {
                Console.WriteLine("Writing report...");
                using (StreamWriter writer = new StreamWriter("casinoReport.txt"))
                {
                    await writer.WriteLineAsync("Player ID\tInitial Amount\tFinal Amount");
                    foreach (var player in _players)
                    {
                        await writer.WriteLineAsync($"Player {player.Id}\t{player.InitialMoney,5}\t{player.Money,5}");
                    }
                }
                Console.WriteLine("Report written.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing report: {ex.Message}");
            }
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public int Money { get; set; }
        public int InitialMoney { get; set; }

        public Player(int id, int initialMoney)
        {
            Id = id;
            Money = initialMoney;
            InitialMoney = initialMoney;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("The game has started. Please wait for it to finish...\n");

            CasinoGame casinoGame = new CasinoGame();
            await casinoGame.StartGame();

            Console.WriteLine("The game is over. The report has been written to the file.");
        }
    }
}
