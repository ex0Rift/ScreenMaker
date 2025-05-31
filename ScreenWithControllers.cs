namespace Console_screen;

public class ScreenWithControllers
{
    //initialise the screenMaker class
    static ScreenMaker screenMaker = new ScreenMaker(10, 21,ConsoleColor.Blue);

    static void Main()
    {
        screenMaker.FormScreen();//Creates the screen

        screenMaker.CreatePlayer(5,5,"A",ConsoleColor.DarkGreen);
        
        while (true)//logic loop keeps the program alive
        {
            screenMaker.ShowScreen();//This must be called after updates for it to physically be displayed
        }
    }
}