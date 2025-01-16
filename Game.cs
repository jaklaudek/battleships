using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Game
    {
        private Board playerBoard;
        private Board enemyBoard;
        private Player player;
        private AIEnemy aienemy;
        
        public Game() 
        {
            playerBoard = new Board();
            enemyBoard = new Board();
            player = new Player(playerBoard);
            aienemy = new AIEnemy(enemyBoard);
        }

        public void Start()
        {
            Console.WriteLine("- - S T A T K I - -");
            Console.WriteLine();

            player.PlaceShips();
            aienemy.PlaceShips();

            PlayGame();
        }
        public void PlayGame()
        {
            Console.Clear();
            Console.WriteLine("- - P L A Y E R - -");
            playerBoard.Display(false);
            Console.WriteLine();
            Console.WriteLine("- - E N E M Y S - -");
            enemyBoard.Display(true);
            bool GameOver = false;
            while (GameOver == false)
            {
                player.TakeTurn(enemyBoard);

                if(enemyBoard.NoMoreShips() == true)
                {
                    Console.WriteLine("Z W Y C I E S T W O");
                    GameOver = true;
                    continue;
                }

                aienemy.TakeTurn(playerBoard);

                if (playerBoard.NoMoreShips() == true)
                {
                    Console.WriteLine("P R Z E G R A L E S");
                    GameOver = true;
                }
                Console.Clear();
                Console.WriteLine("- - P L A Y E R - -");
                playerBoard.Display(false);
                Console.WriteLine();
                Console.WriteLine("- - E N E M Y S - -");
                enemyBoard.Display(true);

            }
        }
    }
}
