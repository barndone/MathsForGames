using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace Tanks
{
    public class TankBody : SpriteObject
    {

        protected override void OnUpdate(float deltaTime)
        {
            //
            //  Parameters
            //
            float moveX = 0.0f;
            float moveY = 0.0f;
            float rotationAngle = 0.0f;
            const float ROTATESPEED = 1f;
            const float MOVESPEED = 20.0f;

            //  Check for Input
            //  1. A / D rotate the TANK BODY
            //  ROTATION
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                rotationAngle += ROTATESPEED * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                rotationAngle -= ROTATESPEED * deltaTime;
            }
            //  2. W / S move the TANK BODY towards the FORWARD vector
            //  TRANSLATION
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                moveX += MathF.Cos(LocalRotation) * MOVESPEED * deltaTime;
                moveY += MathF.Sin(LocalRotation) * MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                moveX -= MathF.Cos(LocalRotation) * MOVESPEED * deltaTime;
                moveY -= MathF.Sin(LocalRotation) * MOVESPEED * deltaTime;
            }

            //Apply movements
            Rotate(rotationAngle);
            Translate(moveX, moveY);
        }
    }
}
