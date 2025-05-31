
using System.Linq.Expressions;

class Program
{
    static string 
        TLCorner = "\u2554",
        TRCorner = "\u2557",
        BLCorner = "\u255a",
        BRCorner = "\u255d",
        Line = "\u2550",
        VLine = "\u2551";

    static int width = 61, height = 10;//width must be an odd number
    
    static string[,] ScreenSpace = new string[height, width];
    
    static void xzMain()
    {
        if (width % 2 == 0)//checks if width is even and exits if true
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Width MUST be odd.");
            Environment.Exit(1);
        }
        
        FormScreen();
        Console.CursorVisible=false;
        int locx = 5, locy = 5;
        ScreenSpace[locy, locx] = "o";
        //Task exitcheck = Task.Run(() => CheckForExit()); ===BREAKS MOVMENT===
        ShowScreen();
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            ScreenSpace[locy, locx] = " ";
            //ScreenSpace[5, 4] = ScreenSpace[5, 4] == "o" ? " " : "o";
            //ScreenSpace[4, 4] = ScreenSpace[4, 4] == "o" ? " " : "o";
            if (key.Key == ConsoleKey.UpArrow) if(locy>1) locy -= 1;
            if (key.Key == ConsoleKey.DownArrow) if(locy<height-2) locy += 1;
            if (key.Key == ConsoleKey.LeftArrow) if(locx>1) locx -= 2;
            if (key.Key == ConsoleKey.RightArrow) if(locx<width-2)locx += 2;
            if (key.Key == ConsoleKey.E) Environment.Exit(0);
            
            ScreenSpace[locy, locx] = "o";
            
            ShowScreen();
        }
    }

    static void FormScreen()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++) ScreenSpace[y, x] = " ";
        }
        for (int i = 0; i < width; i++)ScreenSpace[0, i] = Line;//Form top border
        for (int i = 0; i < height; i++) ScreenSpace[i, 0] = VLine;//form left border
        for (int i = 0; i < width; i++) ScreenSpace[height-1,i]=Line;//form bottem border
        for (int i = 0; i < height; i++) ScreenSpace[i, width-1] = VLine; //form right border
        ScreenSpace[0, 0] = TLCorner;
        ScreenSpace[0, width - 1] = TRCorner;
        ScreenSpace[height - 1, 0] = BLCorner;
        ScreenSpace[height - 1, width - 1] = BRCorner;
    }
    
    static void ShowScreen()
    {
        Console.SetCursorPosition(0,0);
        for (int i = 0; i < ScreenSpace.GetLength(0); i++ )
        {
            for (int j = 0; j < ScreenSpace.GetLength(1); j++)
            {
                Console.Write(ScreenSpace[i,j]+"");
            }
            Console.WriteLine();
        }  
    }
}
