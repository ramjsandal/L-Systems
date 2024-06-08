using Raylib_cs;
using raylib_proj;

namespace game;

class Program
{

    public static void Main()
    {
        LSystem lsystem = new Tree1();
        Raylib.InitWindow(1600, 900, "L-System");

        while (!Raylib.WindowShouldClose())
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                lsystem.Generate();
            }
            lsystem.DrawLSystem();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}