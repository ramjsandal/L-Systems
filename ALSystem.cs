using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raylib_proj
{
    internal abstract class ALSystem : LSystem
    {
        protected string word;
        protected int baseAngle;
        protected int currentAngle;
        protected Vector2 basePosition;
        protected Vector2 currentPosition;
        protected int length;
        protected Dictionary<char, string> rules;

        public void DrawLSystem()
        {
            currentAngle = baseAngle;
            currentPosition = basePosition;
            for (int i = 0; i < word.Length; i++)
            {
                DrawRules(word[i]);
            }
        }

        public abstract void DrawRules(char c);

        public void Generate()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (rules.ContainsKey(c))
                {
                    stringBuilder.Append(rules[c]);
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            word = stringBuilder.ToString();
        }
    }
}
