//Auteur : JMY
//Date   : 03.09.2018
//Lieu   : ETML
//Description : Squelette pour SpaceInvaders en console

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace spaceInvadersSquelette
{
    class Program
    {
        //Graphisme avancé du vaisseau
        const string ship = "^";
        const int shipY = 21;//position verticale du vaisseau

        static void Main(string[] args)
        {
            BlocEnemies BlocEnemies = new BlocEnemies();
            Random rndPosEnemy = new Random();

            int shipX = 50;

            int score = 0;

            int missileX = -1;
            int missileY = -1;

            int enemyX = 5;
            int enemyY = 1;

            bool missileFired = false;

            int tics = 0;


            Console.SetCursorPosition(enemyX, enemyY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("☺");
            Console.ForegroundColor = ConsoleColor.Gray;

            BlocEnemies.RespawnAllEnemies();
            BlocEnemies.DisplayEnemies();

            while (true)
            {
                //Utilisateur a appuyé sur une touche ?
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        //Touche fléchée gauche
                        case ConsoleKey.LeftArrow:
                            //Décalage de la position de référence
                            Console.SetCursorPosition(shipX, shipY);
                            Console.Write(" ");//Effacer l'ancienne position
                            shipX--;

                            break;

                        case ConsoleKey.RightArrow:

                             //Décalage de la position de référence
                             Console.SetCursorPosition(shipX, shipY);
                             Console.Write(" ");//Effacer l'ancienne position
                             shipX++;
                            break;

                        //MISSILE
                        case ConsoleKey.Spacebar:

                            //Un seul missile à la fois
                            if (!missileFired)
                            {
                                missileFired = true;
                                missileY = shipY;
                                missileX = shipX;//Placement du missile initial
                            }
                            break;
                    }

                }

                //On affiche le vaisseau à la bonne positition
                Console.SetCursorPosition(shipX, shipY);
                Console.Write(ship);

                if (tics % 40 == 0)
                {
                    //Effacer l'ancien missile
                    /*Console.SetCursorPosition(enemyX, enemyY);
                    Console.Write(" ");
                    enemyY++;
                    //AFficher la nouvelle position
                    Console.SetCursorPosition(enemyX, enemyY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("☺");
                    Console.ForegroundColor = ConsoleColor.Gray;*/

                    BlocEnemies.EnemiesMovement(); //TEST ATTENTION !
                }

                //Gestion du missile
                if (missileFired)
                {

                    if(enemyX == missileX && enemyY == missileY)
                    {
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(" ");
                        score++;
                        Console.SetCursorPosition(0, 0);
                        Console.Write($"Le score est de {score}");

                        enemyX = rndPosEnemy.Next(Console.WindowWidth);
                        enemyY = 0;
                    }

                    if (missileY > 0)
                    {
                        //Réduire la vitesse du missile
                        if (tics % 5 == 0)
                        {
                            //Effacer l'ancien missile
                            Console.SetCursorPosition(missileX, missileY);
                            Console.Write(" ");

                            //AFficher la nouvelle position
                            Console.SetCursorPosition(missileX, --missileY);
                            Console.Write("*");
                        }
                    }
                    else
                    {
                        //Fin du missile
                        Console.SetCursorPosition(missileX, missileY);
                        Console.Write(" ");
                        missileFired = false;
                    }
                }

                //Temporisation FPS
                System.Threading.Thread.Sleep(2);

                tics++;
                if (tics == Int32.MaxValue)
                    tics = 0;

            }

        }
    }
}
