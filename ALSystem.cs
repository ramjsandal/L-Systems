using System.Numerics;
using System.Text;

namespace raylib_proj
{
    internal abstract class ALSystem : LSystem
    {
        protected string word;
        protected double baseAngle;
        protected double angleIncrement;
        protected double currentAngle;
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

        public Vector2 GetPosition()
        {
            return basePosition;
        }
    }
}
