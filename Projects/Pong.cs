
namespace Console_screen;

public class Pong
{
    private static int width = 71, height = 11;
    private static int[] PlayerOneCoords = {3,2};
    private static int[] BallCoords = { 5, 30 };
    private static int updr = 0, updc = 0;
    
    static ScreenMaker screenMaker = new ScreenMaker(height,width,ConsoleColor.Green);//add Console screen handler
    //static Controller controller = new Controller();
    
    static void GMain()//not running program because of GMain
    {
        //initialising
        screenMaker.FormScreen();
        
        //start ball
        Thread ballthread = new Thread(new ThreadStart(BallLogic));
        //ballthread.Start();
        
        //start update loop
        Thread UpdateThread = new Thread(new ThreadStart(ScreenUpdate));
        UpdateThread.Start();
        
        //create player padle
        screenMaker.EditScreenObj(PlayerOneCoords[0],PlayerOneCoords[1],"B");
        
        while (true)
        {
            if (Console.KeyAvailable) //key inputing LOGIC
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow) updr = -1;
                else if (key.Key == ConsoleKey.DownArrow) updr = 1;
                else updr = 0;

                if (PlayerOneCoords[0] == 1 && updr == -1) updr = 0;
                if (PlayerOneCoords[0] == height - 2 && updr == 1) updr = 0;
                
                
                //move screen items per frame
                screenMaker.MoveScreenObj( ref PlayerOneCoords[0],  ref PlayerOneCoords[1], updr, 0);
            }
        }
    }   
    
    static void BallLogic()
    {
        //create ball
        screenMaker.EditScreenObj(BallCoords[0],BallCoords[1],"o");
        
        int changeX = 1, changeY = 1;
        
        while (true)
        {
            if (BallCoords[0] == height - 2) changeY = changeY * -1;
            if (BallCoords[0] == 1) changeY = changeY * -1;
            if (BallCoords[1] == width - 2) changeX = changeX * -1;
            if (BallCoords[1] == 1) changeX = changeX * -1;
            
            screenMaker.MoveScreenObj(ref BallCoords[0],ref BallCoords[1],changeY,changeX);
            Thread.Sleep(200);
        }
    }

    static void ScreenUpdate()
    {
        while (true)
        {
            screenMaker.ShowScreen();
            Thread.Sleep(10);
        }
    }
}   