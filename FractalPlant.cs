using Raylib_cs;
using System.Numerics;

namespace raylib_proj
{
    internal class FractalPlant : ALSystem
    {

        Stack<(Vector2, double)> values = new Stack<(Vector2, double)>();

        public FractalPlant()
        {
            word = "X";
            angleIncrement = -25;
            baseAngle = -25;
            basePosition = new Vector2(0, 900);
            length = 2;
            rules = new Dictionary<char, string>()
            {
                { 'X', "F+[[X]-X]-F[-FX]+X" },
                { 'F', "FF" }
            };
        }
        public override void DrawRules(char c)
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
                    currentAngle -= angleIncrement;
                    break;
                case '+':
                    currentAngle += angleIncrement;
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
    }
}
