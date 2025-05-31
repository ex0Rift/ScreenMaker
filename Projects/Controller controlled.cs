namespace Console_screen;

public class Controller_controlled
{
    static int height = 10, width = 15;
    
    static ScreenMaker screenMaker = new ScreenMaker(height,width,ConsoleColor.DarkBlue);//add Console screen handler
    static Controller controller = new Controller();
    
    
    static void aMain()
    {
        screenMaker.FormScreen();

        int pR = 1, pC = 1;
        screenMaker.EditScreenObj(pR,pC,"N");
        
        while (true)
        {
            int[] points = controller.Getdata();
            
            if (points[0]>100)
                screenMaker.MoveScreenObj(ref pR,ref pC,1,0);
                
            
            screenMaker.ShowScreen();
            Thread.Sleep(500);
        }
    }
    
}