using Raylib_cs;
using System.Formats.Asn1;

namespace game;

class Program
{
    public static Dictionary<char, string> rules = new Dictionary<char, string>()
    {
        { 'X', "F+[[X]-X]-F[-FX]+X" },
        { 'F', "FF" }
    };

    string word;
    string generate()
    {
        string nextWord = "";

        for (int i = 0; i < word.Length; i++)
        {
            var c = word[i];
            if (rules.ContainsKey(c))
            {
                nextWord += rules[c]; 
            } else
            {
                nextWord += c;
            }
        }

        return nextWord;

    }

    public static void Main()
    {
        Program program = new Program();
        program.word = "X";
        Raylib.InitWindow(800, 480, "Hello World");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText(program.word, 12, 12, 20, Color.Black);
            Raylib.EndDrawing();
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
              program.word = program.generate();
            }
        }

        Raylib.CloseWindow();
    }
}