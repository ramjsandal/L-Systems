using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raylib_proj
{
    internal interface LSystem
    {
        public void DrawRules(char c);

        public void DrawLSystem();

        public void Generate();

    }
}
