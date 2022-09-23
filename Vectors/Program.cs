using Raylib_cs;
using MathLibrary;

namespace Vectors
{ 
public class Program
{
    public static int Main()
    {
        //initialize
        const int screenWidth = 800;
        const int screenHeight = 450;
        Player player = new Player(10f,screenWidth, screenHeight);
        Ball ball = new Ball(new Vector3(1,1,0), 10f, 100f, screenWidth, screenHeight);

        Raylib.InitWindow(screenWidth, screenHeight,"My MathLibrary in Raylib");
        Raylib.SetTargetFPS(60);


        //game loop
        while (!Raylib.WindowShouldClose())
        {
            //update
            player.Update();
            ball.Update();

            //draw
            //drawing objects to the screen
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            player.Draw();
            ball.Draw();
            Raylib.EndDrawing();

        }

        //deinitialize
        //aka cleanup
        Raylib.CloseWindow();

        return 0;
    }
}
}