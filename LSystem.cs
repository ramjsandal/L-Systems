using System.Numerics;

namespace raylib_proj
{
    internal interface LSystem
    {
        public void DrawRules(char c);

        public void DrawLSystem();

        public void Generate();

        public Vector2 GetPosition();

        public void SetPosition(Vector2 position);

    }
}
