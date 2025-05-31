namespace Console_screen;

public class ScreenMaker
{
    static string 
        TLCorner = "\u2554",
        TRCorner = "\u2557",
        BLCorner = "\u255a",
        BRCorner = "\u255d",
        Line = "\u2550",
        VLine = "\u2551";

    public int[] PlayerCoords = {0,0};
    public string[,] ScreenSpace;
    private int height;
    private int width;

    private readonly object screenLock = new object();
    
    public ScreenMaker(int height, int width , System.ConsoleColor Colour = ConsoleColor.DarkGray)
    {
        Console.ForegroundColor = Colour;
        ScreenSpace = new string[height, width];
        //Console.WriteLine($"{width} {height}");
        this.height = height;
        this.width = width;
    }
    
    public void EditScreenObj( int Row , int Column , string Character)
    {
        lock (screenLock)ScreenSpace[Row, Column] = $"{Character}";
    }

    public void MoveScreenObj(ref int Row,ref int Column, int y, int x)
    {
        lock (screenLock)
        {
            string Character = ScreenSpace[Row, Column];
            if (Character != " ")
            {
                ScreenSpace[Row, Column] = " ";
                ScreenSpace[Row + y, Column + x] = $"{Character}";
                Row += y;
                Column += x;
            }
        }    
    }
    
    public void CreatePlayer(int row, int column, string Character = "P", System.ConsoleColor Color = ConsoleColor.Blue)
    {
        EditScreenObj(row,column,Character);
        PlayerCoords[0] = row;
        PlayerCoords[1] = column;
        Task.Run(async () => await MovmentControl());
    }

    private async Task MovmentControl()
    {
        while (true)
        {
            if (Console.KeyAvailable)
            {
                int RChange = 0, CChange = 0;
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow) RChange = -1;
                else if (key.Key == ConsoleKey.DownArrow) RChange = 1;
                else if (key.Key == ConsoleKey.LeftArrow) CChange = -1;
                else if (key.Key == ConsoleKey.RightArrow) CChange = 1;
                
                MoveScreenObj(ref PlayerCoords[0],ref PlayerCoords[1],RChange,CChange);
            }
        }
    }

    public void FormScreen()
    {
        Console.CursorVisible = false;
        if (width % 2 == 0)//checks if width is even and exits if true
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Width MUST be odd.");
            Environment.Exit(1);
        }
        
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
    
    public void ShowScreen()
    {
        lock (screenLock)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < ScreenSpace.GetLength(0); i++)
            {
                for (int j = 0; j < ScreenSpace.GetLength(1); j++)
                {
                    Console.Write(ScreenSpace[i, j] + "");
                }

                Console.WriteLine();
            }
        }
    }

    
}