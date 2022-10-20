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
    public class TankShell : SpriteObject
    {
        public const float SHELLVELOCITY = 2f;
        protected override void OnUpdate(float deltaTime)
        {
            //apply constant translation of the shell in the direction it is facing
            //Translate by the constant shell velocity MULTIPLIED by the LOCAL rotation of the shell (ensures rotation is accurate)
            Translate(SHELLVELOCITY * LocalTransform.m1, SHELLVELOCITY * LocalTransform.m2);
        }


    }
}
