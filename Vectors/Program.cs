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
        Player player = new Player();

        Raylib.InitWindow(screenWidth, screenHeight,"My MathLibrary in Raylib");
        Raylib.SetTargetFPS(60);


        //game loop
        while (!Raylib.WindowShouldClose())
        {
            //update
            player.Update();

            //draw
            //drawing objects to the screen
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.EndDrawing();
            player.Draw();
        }

        //deinitialize
        //aka cleanup
        Raylib.CloseWindow();

        return 0;
    }
}
}