using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raylib_proj
{
    internal class SierpinskiTriangle : LSystem
    {

        string word;

        int baseAngle;

        Vector2 basePosition;

        int length;

        int currentAngle;

        Vector2 currentPosition;

        public static Dictionary<char, string> rules = new Dictionary<char, string>()
    {
        { 'F', "F-G+F+G-F" },
        { 'G', "GG" }
    };

        public SierpinskiTriangle()
        {
            word = "F-G-G";
            baseAngle = 120;
            basePosition = new Vector2(0, 900);
            length = 2;
        }


        public void DrawLSystem()
        {
            currentAngle = baseAngle;
            currentPosition = basePosition;
            for (int i = 0; i < word.Length; i++)
            {
                DrawRules(word[i]);
            }
        }

        public void DrawRules(char c)
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

        public void Generate()
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

            word = nextWord;
        }
    }
}
