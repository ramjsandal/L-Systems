using Raylib_cs;
using raylib_proj;
using System.Numerics;

namespace game;

class Program
{

    void moveCamera(ref Camera2D camera, int increment)
    {
        if (Raylib.IsKeyDown(KeyboardKey.LeftShift))
        {
            increment *= 5;
        }

        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            camera.Target.Y -= increment;
        }

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            camera.Target.X -= increment;
        }

        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            camera.Target.Y += increment;
        }

        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            camera.Target.X += increment;
        }
    }

    public static void Main()
    {
        int screenWidth = 1600;
        int screenHeight = 900;
        Program program = new Program();
        LSystem lsystem = new TreeC();
        Raylib.InitWindow(screenWidth, screenHeight, "L-System");

        Camera2D camera2D = new Camera2D();
        camera2D.Target = lsystem.GetPosition();
        camera2D.Offset = new Vector2(screenWidth / 2, screenHeight);
        camera2D.Zoom = 1.0f;

        while (!Raylib.WindowShouldClose())
        {

            camera2D.Zoom += (float)Raylib.GetMouseWheelMove() * 0.05f;
            program.moveCamera(ref camera2D, 1);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.BeginMode2D(camera2D);
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                lsystem.Generate();
            }
            lsystem.DrawLSystem();
            Raylib.EndMode2D();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}