using System;

namespace BattleShips
{
    public class Player : Board
    {
        private Board board;

        public Player(Board board)
        {
        this.board = board;
        }

        public void PlaceShips()
        {
            for (int i = 1; i < 4; i++)
            {
                bool placed = false;
                while(!placed)
                {
                    Console.WriteLine($"Umieść statek o długości {i}:");
                    Console.WriteLine("Podaj współrzędną X: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj współrzędną Y: ");
                    int y = int.Parse(Console.ReadLine());
                    Console.WriteLine("Czy statek ma być ustawiony poziomo (t/n) ");
                    bool horizontal = Console.ReadLine().ToLower() == "t";

                    placed = board.PlaceShip(x, y, i, horizontal);
                    if(!placed)
                    Console.WriteLine("Nie można umieścić tutaj statku");
                }
            }
        }

        public void TakeTurn(Board enemyBoard)
        {
            bool validShot = false;
            while (!validShot)
            {
                Console.WriteLine("Podaj współrzędną X do strzału: ");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj współrzędną Y do strzału: ");
                int y = int.Parse(Console.ReadLine());

                validShot = enemyBoard.FireAt(x, y);
                if (!validShot)
                    Console.WriteLine("Pudło");
                else
                    Console.WriteLine("Trafiony");
            }
        }
    }
}
