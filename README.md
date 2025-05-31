# ScreenMaker

example boilerpalte

```csharp
namespace Console_screen
{
    public class Game
    {
        // Initialise the ScreenMaker class
        static ScreenMaker screenMaker = new ScreenMaker(10, 21, ConsoleColor.Blue);
        
        static void Main()
        {
            screenMaker.FormScreen(); // Creates the screen

            while (true) // Logic loop keeps the program alive
            {
                screenMaker.ShowScreen(); // This must be called after updates for it to physically be displayed
            }
        }
    }
}
```


when creating the screen from the file ScreenMaker the attributes mean different things

>"10" is the amount of ROWS
>
>"21" is the amount of columns (THIS MUST BE AN ODD NUMBER)
>
>"ConsoleColor.Blue" this changes the screens color, by defalt it is darkGray if left empty

<br><br><br>

# Different functions to call
```csharp
screenMaker.CreatePlayer(5,6,"A");
```

This creates a movable characcter on your screen via the arrow keys, it cannot go out of the bounds of your screen.

>"5" is its row
>
>"6" is its column
>
>"A" is the symbol it uses to represent itself, it is not requred and if nothing is used the defalt is "P"

<br>

```csharp
screenMaker.EditScreenObj(1,2,"B");
```

This creates an object on the screen with no movent logic, it is just an item displayed on the screen, bare in mind if the player goes over this object it will be replaced with nothing
>"1" is its row
>
>"2" is its column
>
>"B" is its characcter displayed on the screen
>
><br>

```csharp
screenMaker.MoveScreenObj(ref VarRow,ref VarColumn,changeY,changeX);
```

This can move an obect on the screen by a chosen distance, if no character is in the coordinates provided then nothing willl happen. if a variable is provided it will be updated according to the new coordinates

>"ref VarRow" ref is required this alows the variable to be updated, this is the variable previously created by yourself for an object on the screen and is used to fetch the row atribute
>
>"ref VarColumn" like previous one but instead for the column
>
>"changeY" and "changeX" this is by how many places you want to change the position of the object X is columns and Y is rows
