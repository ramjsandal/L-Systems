using Raylib_cs;
using System.Numerics;

namespace raylib_proj
{
    internal class KochCurve : ALSystem
    {
        public KochCurve()
        {
            word = "F";
            angleIncrement = 90;
            baseAngle = 90;
            basePosition = new Vector2(800, 400);
            length = 5;
            rules = new Dictionary<char, string>()
            {
                { 'F', "F+F-F-F+F" },
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
                default:
                    Console.WriteLine($"Invalid Argument: {c}");
                    break;
            }
        }
    }
}
