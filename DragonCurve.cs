using Raylib_cs;
using System.Numerics;

namespace raylib_proj
{
    internal class DragonCurve : ALSystem
    {
        public DragonCurve()
        {
            word = "F";
            baseAngle = 90;
            basePosition = new Vector2(800, 400);
            length = 10;
            rules = new Dictionary<char, string>()
            {
                { 'F', "F+G" },
                { 'G', "F-G" }
            };
        }
        public override void DrawRules(char c)
        {
            switch (c)
            {
                case 'F':
                case 'G':
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
                default:
                    Console.WriteLine($"Invalid Argument: {c}");
                    break;
            }
        }
    }
}
