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

    public class TankTurret : SpriteObject
    {
        private void FireShell()
        {
            //Initialize the shell
            TankShell newShell = (TankShell)GameObjectFactory.FireShell("res/shell.png");
            
            //set the local position relative to the global transform of the Turret
            newShell.LocalPosition = GlobalTransform.GetTranslation();

            //translate the shell to the end of the barrel
            //  Isolate Global Rotation (m1, m2) - acts as a +/- sign and multiply by the sprite (barrel) width
            newShell.Translate(GlobalTransform.m1 * this.sprite.width, GlobalTransform.m2 * this.sprite.width);
            
            //rotate the shell by the NEGATIVE of the current global translation (since positive Y is downward)
            newShell.LocalRotation = -MathUtils.AngleFrom2D(GlobalTransform.m1, GlobalTransform.m2);
            Program.AddRootGameObject(newShell);
        }
        protected override void OnUpdate(float deltaTime)
        {

            //holds the input rotation angle
            float rotationAngle = 0.0f;
            //constant for rotation speed
            const float ROTATESPEED = 1f;

            //Rotate the turret!
            // Q rotate + E rotate -
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                rotationAngle += ROTATESPEED * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                rotationAngle -= ROTATESPEED * deltaTime;
            }


            //apply the rotation to the turret
            Rotate(rotationAngle);

            //initialize a projectile on specified key-press
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                FireShell();
            }
        }
    }
}
