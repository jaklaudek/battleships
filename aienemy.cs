using System;

namespace BattleShips
{
    public class AIEnemy
    {
        private Board board;
        private Random random;

        public AIEnemy(Board board)
        {
            this.board = board;
            random = new Random();
        }

        public void PlaceShips()
        {
            for(int i = 1 ; i <= 4; i++)
            {
                bool placed = false;
                while(!placed)
                {
                    int x = random.Next(0, 10);
                    int y = random.Next(0, 10);
                    bool horizontal = random.Next(0, 2) == 0;
                    placed = board.PlaceShip(x, y, i, horizontal);
                }
            }
        }

        public void TakeTurn(Board playerBoard)
        {
            bool validShot = false;
            while(!validShot)
            {
                int x = random.Next(0, 10);
                int y = random.Next(0, 10);
                validShot = playerBoard.TakeTurn(x, y);
            }
        }
    }
}
