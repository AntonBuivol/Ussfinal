using DocumentFormat.OpenXml.Office.CustomXsn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Uss
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(95, 25);
            
            Store store = new Store();

            Console.WriteLine("Kõik mängijad ja nende viimane punktisumma: ");

            store.read();

            Console.WriteLine("Kirjuta oma nimi: ");

            User users = new User(Console.ReadLine());

            Console.Clear();



            Console.ForegroundColor = ConsoleColor.Red;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек			
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            
            Sound play = new Sound();
            _ = play.Tagaplaanis_Mangida("../../../music.wav");

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();



            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(Console.WindowWidth - 15, 1);
                Console.Write("Mängija: " + users.username);
                Console.SetCursorPosition(Console.WindowWidth - 15, 5);
                Console.Write("Skoor: " + users.score);

                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    users.plusScore();
                    _ = play.Natuke_Mangida("../../../eat.wav");
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            store.AddUser(users);
            WriteGameOver(users);
            store.save();
            Console.ReadLine();
        }



        static void WriteGameOver(User users)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("GAME   OVER", xOffset + 1, yOffset++);
            WriteText("MÄNGIJA: " + users.username+ " SKOOR: " + users.score.ToString(), xOffset + 1, yOffset++);
            yOffset++;
            WriteText("CREATOR: ANTON BUIVOL", xOffset + 2, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            Sound over = new Sound();
            _ = over.Natuke_Mangida("../../../game_over.wav");
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

    }
}
