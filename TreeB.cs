using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raylib_proj
{
    internal class TreeB : ALSystem
    {
        Stack<(Vector2, double)> values = new Stack<(Vector2, double)>();

        public TreeB()
        {
            word = "F";
            angleIncrement = 20;
            baseAngle = -90;
            basePosition = new Vector2(400, 900);
            length = 5;
            rules = new Dictionary<char, string>()
            {
                { 'F', "F[+F]F[-F][F]" },
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
