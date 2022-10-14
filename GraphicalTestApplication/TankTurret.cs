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
            TankShell newShell = (TankShell)GameObjectFactory.FireShell("res/shell.png");
            // newShell.LocalPosition =    new Vector3(this.LocalPosition.x + ((this.sprite.width) * MathF.Acos(this.LocalRotation)),
            //                                       this.LocalPosition.y + ((this.sprite.width) * MathF.Asin(this.LocalRotation)), 
            //                                     this.LocalPosition.z);
            newShell.LocalPosition = LocalPosition;
            newShell.Translate( this.GlobalTransform.m7 + ((this.sprite.width) * MathF.Acos(this.LocalRotation)), 
                                this.GlobalTransform.m8 + ((this.sprite.width) * MathF.Asin(this.LocalRotation)));
            
            newShell.LocalRotation = MathUtils.AngleFrom2D(this.LocalTransform.m1, this.LocalTransform.m2);
            Program.AddRootGameObject(newShell);
        }
        protected override void OnUpdate(float deltaTime)
        {

            float rotationAngle = 0.0f;
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

            Rotate(rotationAngle);

            //logic for shooting shells:
            //fire from the origin in the direction vector of the turret
            //not a child of the tank
            //method to create a shell?

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                FireShell();
            }
        }
    }
}
