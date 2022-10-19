using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace Tanks
{
    public class Tank : SpriteObject
    {
        //initialize a turret for the tank
        private void AddTurret()
        {
            //create a turret object using the gameobjectfactory
            TankTurret turret = (TankTurret)GameObjectFactory.MakeTurret("res/barrelGreen.png");
            //re-assign the origin of the turret to the base of the turret (as it would in reality)
            turret.origin = new Vector3(0, 0.5f, 0.5f);
            //add the turret to the children of the tank

            //Do NOT need to add to root game objects, do NOT need to add to list of children (it does that in setting the parent)
            turret.Parent = this;
            turret.LocalPosition = LocalPosition;
        }
        protected override void OnUpdate(float deltaTime)
        {
            if (ChildCount == 0)
            {
                AddTurret();
            }

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
                moveY -= MathF.Sin(LocalRotation) * MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                moveX -= MathF.Cos(LocalRotation) * MOVESPEED * deltaTime;
                moveY += MathF.Sin(LocalRotation) * MOVESPEED * deltaTime;
            }

            //Apply movements

            Translate(moveX, moveY);
            Rotate(rotationAngle);
        }
    }
}
