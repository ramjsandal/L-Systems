using Raylib_cs;
using System.Collections.Specialized;
using System.Formats.Asn1;
using System.Numerics;

namespace game;

class Program
{
    string word;

    int baseAngle;

    Vector2 basePosition;

    int length;

    Stack<(Vector2, int)> values = new Stack<(Vector2, int)>();

    int currentAngle;

    Vector2 currentPosition;


    public Program()
    {
        word = "X";
        baseAngle = -25;
        basePosition = new Vector2(0, 900);
        length = 2;
        currentAngle = baseAngle;
        currentPosition = basePosition;
        values.Push((currentPosition, currentAngle));
    }

    public static Dictionary<char, string> rules = new Dictionary<char, string>()
    {
        { 'X', "F+[[X]-X]-F[-FX]+X" },
        { 'F', "FF" }
    };

    void drawSystem()
    {
        currentAngle = baseAngle;
        currentPosition = basePosition;
        values.Push((currentPosition, currentAngle));
        for (int i = 0; i < word.Length; i++)
        {
            applyRule(word[i]);
        }

    }

    void applyRule(char c)
    {
        switch (c)
        {
            case 'F':
                double angleInRadians = currentAngle * Math.PI / 180.0;
                Vector2 end = new Vector2((float)(currentPosition.X + (length * Math.Cos(angleInRadians))),
                    (float)(currentPosition.Y + (length * Math.Sin(angleInRadians))));
                Raylib.DrawLineV(currentPosition, end, Color.Black);
                currentPosition = end;
                break;
            case '-':
                currentAngle -= baseAngle;
                break;
            case '+':
                currentAngle += baseAngle;
                break;
            case '[':
                values.Push((currentPosition, currentAngle));
                break;
            case ']':
                var val = values.Pop();
                currentPosition = val.Item1;
                currentAngle = val.Item2;
                break;
            case 'X':
                break;
            default:
                Console.WriteLine($"Invalid Argument: {c}");
                break;
        }

    }

    string generate()
    {
        string nextWord = "";

        for (int i = 0; i < word.Length; i++)
        {
            var c = word[i];
            if (rules.ContainsKey(c))
            {
                nextWord += rules[c];
            }
            else
            {
                nextWord += c;
            }
        }

        return nextWord;

    }

    public static void Main()
    {
        Program program = new Program();
        Raylib.InitWindow(1600, 900, "L-System");

        while (!Raylib.WindowShouldClose())
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                program.word = program.generate();
            }
            program.drawSystem();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}