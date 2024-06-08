using Raylib_cs;
using System.Numerics;

namespace raylib_proj
{
    internal class SierpinskiTriangle : ALSystem
    {

        public SierpinskiTriangle()
        {
            word = "F-G-G";
            angleIncrement = 120;
            baseAngle = 120;
            basePosition = new Vector2(800, 0);
            length = 2;
            rules = new Dictionary<char, string>()
            {
                { 'F', "F-G+F+G-F" },
                { 'G', "GG" }
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
