using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathLibrary;
using Raylib_cs;

namespace Vectors
{
    public  class Player : GameObject
    {
        private float radius;                                               //for storing the radius of the player
                                                                            //used for checking when to wrap the player to the other side of the screen

        private bool leftClicked = false;
        private bool rightClicked = false;
        private Vector3 target = new Vector3();

        public Player(float radius, int screenWidth, int screenHeight) 
        {
            this.radius = radius;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public override void Update()
        {

            //keyboard input for WASD
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && !leftClicked && !rightClicked)
            {
                position.x -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && !leftClicked && !rightClicked)
            {
                position.x += 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && !leftClicked && !rightClicked)
            {
                position.y -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && !leftClicked && !rightClicked)
            {
                position.y += 1;
            }

            //mouse input
            //set bool, if bool is true, do the thing otherwise do nothing?
            //left click
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                target.x = Raylib.GetMouseX();
                target.y = Raylib.GetMouseY();
                leftClicked = true;
            }
            //right click
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                target.x = Raylib.GetMouseX();
                target.y = Raylib.GetMouseY();
                rightClicked = true;
            }
            //check position +/-r
            //if position +/- r exceeds the boundaries of the window
            //update position component with corresponding boundary
            //if collide with top/bottom, y value to the opposite boundary +/- r
            //if collide with left/right, x value to the opposite boundary +/- r
            //check upper bounds
            if (position.y < 0 - radius)
            {
                position.y = screenHeight + radius;
            }
            //check lower bounds
            if (position.y > screenHeight + radius)
            {
                position.y = 0 - radius;
            }
            //check left bounds
            if(position.x < 0 - radius)
            {
                position.x = screenWidth + radius;
            }
            //check right bounds
            if (position.x > screenWidth + radius)
            {
                position.x = 0 - radius;                
            }
        }

        public override void Draw()
        {
            Raylib.DrawCircle((int)position.x, (int)position.y, radius, Color.BLUE);
        }
    }
}
