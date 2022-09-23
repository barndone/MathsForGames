using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vectors
{
    public  class Player : GameObject
    {

        public Player() { }

        public override void Update()
        {
            if (Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_A))
            {
                position.x -= 1;
            }
            if (Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_D))
            {
                position.x += 1;
            }
            if (Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_W))
            {
                position.y -= 1;
            }
            if (Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_S))
            {
                position.y += 1;
            }
        }

        public override void Draw()
        {
            Raylib_cs.Raylib.DrawCircle((int)position.x, (int)position.y, 10f, Raylib_cs.Color.BLUE);
        }
    }
}
