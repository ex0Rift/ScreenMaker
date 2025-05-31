using System;
using System.Threading;

namespace Console_screen
{
    class Program
    {
        static ScreenMaker screenMaker = new ScreenMaker(10, 21); // small screen
        static int[] BallCoords = { 5, 10 }; // somewhere in the middle

        static void Maain(string[] args)
        {
            screenMaker.FormScreen();

            Thread ballthread = new Thread(new ThreadStart(BallLogic));
            ballthread.Start();

            Thread UpdateThread = new Thread(new ThreadStart(Update));
            UpdateThread.Start();

            Console.ReadLine(); // Keep main thread alive
        }

        static void BallLogic()
        {
            while (true)
            {
                screenMaker.EditScreenObj(BallCoords[0], BallCoords[1], "x");
                Thread.Sleep(1000);
                screenMaker.EditScreenObj(BallCoords[0], BallCoords[1], "o");
                Thread.Sleep(1000);
            }
        }

        static void Update()
        {
            while (true)
            {
                screenMaker.ShowScreen();
                Thread.Sleep(50);
            }
        }
    }
}