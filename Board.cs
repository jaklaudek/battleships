using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Board
    {
        private char[,] grid;
        private const int size = 10;
        public Board() 
        {
            grid = new char[size,size];
            InitializeGrid();
        }
        public void InitializeGrid()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = '~';
                }
            }
        }
        public bool PlaceShip(int x, int y, int length, bool horizontal)
        {
            if (IsPlacementRight(x, y, length) != true)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (horizontal == true)
                    {
                        grid[x, y + i] = '+';
                    }
                    else
                    {
                        grid[x + i, y] = '+';
                    }
                }
                return true;
            }
        }
        private bool IsPlacementRight(int x, int y, int length)
        {
            if (x+length > size)
            {
                return false;
            }
            if (y + length > size)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                int cx = x + 1;
                int cy = y + 1;
                if(grid[cx, cy] != '~')
                {
                    return false;
                }
            }
            return true;
        }
        public bool FireAt(int x, int y)
        {
            if (grid[x,y] == '+')
            {
                grid[x, y] = 'X';
                return true;
            }
            else if (grid[x,y] == 'X')
            {
                grid[x, y] = 'X';
                return true;
            }
            else
            {
                grid[x, y] = 'O';
                return false;
            }
        }

        public bool NoMoreShips()
        {
            foreach(char c in grid)
            {
                if (c == '+')
                {
                    return false;
                }
            }
            return true;
        }

        public void Display(bool hideShips)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (hideShips == true)
                    {
                        if (grid[i, j] == '+')
                        {
                            Console.Write('~' + " ");
                        }
                        else
                        {
                            Console.Write(grid[i, j] + " ");
                        }
                    }
                    else
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
