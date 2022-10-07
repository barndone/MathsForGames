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
        public Vector3 origin = new Vector3(0.5f, 0.5f, 0.5f);

        protected override void OnUpdate(float deltaTime)
        {
            //  TODO: Implement me!
            float xMove = 0.0f;
            float yMove = 0.0f;

            float spriteScalar = 0.0f;

            float rotationAngle = 0.0f;

            const float ROTATESPEED = 30.0f;

            const float MOVESPEED = 20.0f;

            //  check for input

            //
            //  Translation
            //

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

            //
            //  Rotation
            //

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

            //
            //  Scaling
            //

            //  Scale up:
            if (Raylib.IsKeyDown(KeyboardKey.KEY_FOUR))
            {
                spriteScalar += 1 * deltaTime;
            }

            //  Scale down:
            if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE))
            {
                spriteScalar -= 1 * deltaTime;
            }


            //  apply the movement / rotation / scaling
            Translate(xMove, yMove);
            Rotate(rotationAngle);
            Scale(spriteScalar, spriteScalar);


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
            //extracts the x axis vector and y axis vector, then stores the magnitude of each as the x and y component
            //of a scale vector2
            Vector2 scale = new Vector2(new Vector2(GlobalTransform.m1, GlobalTransform.m2).Magnitude,
                new Vector2(GlobalTransform.m4, GlobalTransform.m5).Magnitude);

            // extract the position
            Vector3 pos = myTransform.GetTranslation();

            // draw the sprite
            Raylib.DrawTexturePro(
                //  texture to draw 
                monsterSprite,
                //  source rect: 0,0, width, height of portion you want drawn
                new Rectangle(0, 0, (float)monsterSprite.width, (float)monsterSprite.height),
                //destination: portion of the screen: start point x, y, width, height (SCALING * width/height)
                new Rectangle(pos.x, pos.y, monsterSprite.width * scale.x, monsterSprite.height * scale.y),
                //origin: pivot point: default top left corner, for middle origin: half of destination width/height
                new System.Numerics.Vector2(origin.x, origin.y),
                //rotation              `
                MathUtils.AngleFrom2D(GlobalTransform.m1, GlobalTransform.m2),
                //tint                  `
                Color.WHITE
                );
        }
    }
}
