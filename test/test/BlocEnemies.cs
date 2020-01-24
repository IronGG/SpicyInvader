using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class BlocEnemies
    {
        bool right;
        bool left;

        int posX;
        int posY;

        int[,] blocEnemy = new int[8,8];

        public BlocEnemies()
        {
            right = true;
            left = false;
            const int spawnX = 0;
            const int spawnY = 0;

            posX = 0;
            posY = 0;
        }

        public void CreateGrid()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    blocEnemy[x, y] = 0;
                }
            }
        }

        public void RespawnAllEnemies()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    blocEnemy[x, y] = 1;
                }
            }
        }

        public void DisplayEnemies()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Console.SetCursorPosition(posX + y, posY + x);
                    switch (blocEnemy[x, y])
                    {
                        case 0:
                            Console.Write(" ");
                            break;

                        case 1 :
                            Console.Write("☺");
                            break;
                    }
                }
            }
        }

        public void EnemiesMovement()
        {
            if (right)
            {
                right = true;
                posX++;

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (posX + 8 == Console.WindowWidth && right)
                        {
                            left = true;
                            right = false;
                            posX--;
                            Console.SetCursorPosition(posX + y, posY + x);
                            Console.Write(" ");

                            if (posY + x == 0)
                            {
                                Console.SetCursorPosition(posX + y, posY - 1);
                                Console.Write(" ");
                            }

                            posY++;
                        }

                        if (y == 0)
                        {
                            Console.SetCursorPosition(posX + y - 1, posY + x);
                            Console.Write(" ");
                        }



                        Console.SetCursorPosition(posX + y, posY + x);
                        switch (blocEnemy[x, y])
                        {
                            case 0:
                                Console.Write(" ");
                                break;

                            case 1:
                                Console.Write("☺");
                                break;
                        }
                    }
                }
            }

            else if (left)
            {
                posX--;

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (posX + y == 0)
                        {
                            left = false;
                            right = true;
                            posX++;
                            Console.SetCursorPosition(posX + y - 1, posY + x);
                            Console.Write(" ");
                            Console.SetCursorPosition(posX + y - 1, posY + x - 1);
                            Console.Write(" ");
                            posY++;
                        }

                        if (y == 7)
                        {
                            Console.SetCursorPosition(posX + y + 1, posY + x);
                            Console.Write(" ");
                        }



                        Console.SetCursorPosition(posX + y, posY + x);
                        switch (blocEnemy[x, y])
                        {
                            case 0:
                                Console.Write(" ");
                                break;

                            case 1:
                                Console.Write("☺");
                                break;
                        }
                    }
                }
            }
        }
    }
}
