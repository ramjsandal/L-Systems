using Raylib_cs;
using raylib_proj;
using System.Collections.Specialized;
using System.Formats.Asn1;
using System.Numerics;

namespace game;

class Program
{

    public static void Main()
    {
        LSystem plant = new DragonCurve();
        Raylib.InitWindow(1600, 900, "L-System");

        while (!Raylib.WindowShouldClose())
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                plant.Generate();
            }
            plant.DrawLSystem();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}