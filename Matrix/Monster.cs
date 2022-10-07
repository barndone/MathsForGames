using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace Matrix
{
    public class Monster : GameObject
    {
        public Texture2D monsterSprite;

        protected override void OnUpdate(float deltaTime)
        {
            //  TODO: Implement me!
            float xMove = 0.0f;
            float yMove = 0.0f;

            float rotationAngle = 0.0f;

            const float ROTATESPEED = 30.0f;

            const float MOVESPEED = 20.0f;

            //  check for input
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                xMove -= MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                xMove += MOVESPEED * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                yMove -= MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                yMove += MOVESPEED * deltaTime;
            }

            //  Rotate counter-clockwise
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                rotationAngle += ROTATESPEED * deltaTime;
            }

            //  Rotate clockwise
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                rotationAngle -= ROTATESPEED * deltaTime;

            }

            //  apply the movement / rotation
            Translate(xMove, yMove);
            Rotate(rotationAngle);


            //  F to make your minion pay respect
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                GameObject minion = GameObjectFactory.MakeSprite("res/chort.png");
                minion.LocalPosition = LocalPosition;
                Program.AddRootGameObject(minion);
                minion.Parent = this;
                children.Add(minion);
            }
        }
        protected override void OnDraw()
        {
            // calculate the local transform matrix
            Matrix3 myTransform = GlobalTransform;

            // extract the position
            Vector3 pos = myTransform.GetTranslation();

            // draw the monster sprite
            Raylib.DrawTexture(monsterSprite, (int)pos.x, (int)pos.y, Color.WHITE);
        }
    }
}
