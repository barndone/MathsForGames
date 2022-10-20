using Raylib_cs;
using GameFramework;
using Tanks;

public class Program
{
    private static List<GameObject> gameObjects = new List<GameObject>();
    private static List<GameObject> targets = new List<GameObject>();
    private static List<GameObject> projectiles = new List<GameObject>();

    private static List<GameObject> pendingObjects = new List<GameObject>();
    private static List<GameObject> pendingProjectiles = new List<GameObject>();

    private static List<GameObject> killObjects = new List<GameObject>();


    //  used for adding game objects to the gameObjects list
    public static void AddRootGameObject(GameObject newGameObject)
    {
        pendingObjects.Add(newGameObject);
    }

    //  used for adding projectiles to the projectile list
    public static void AddProjectile(GameObject newProjectile)
    {
        pendingProjectiles.Add((TankShell)newProjectile);
    }

    public static void Destroy(GameObject toDestroy)
    {
        killObjects.Add(toDestroy);
    }

    public static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Tank Go Brr");
        Raylib.SetTargetFPS(60);

        // INITIALIZE GAMEPLAY

        bool isPaused = false;

        gameObjects.Add(GameObjectFactory.MakeTank("res/tankGreen.png"));


        targets.Add((Target)GameObjectFactory.MakeTarget("res/target.png"));

        targets[0].Translate(screenW / 2, screenH / 2);

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update GAMEPLAY
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
            {
                isPaused = !isPaused;
            }

            // Update all current objects
            if (!isPaused)
            {
                //update tanks
                foreach (var go in gameObjects)
                {
                    go.Update(Raylib.GetFrameTime());
                }

                //update projectiles
                foreach (var go in projectiles)
                {
                    go.Update(Raylib.GetFrameTime());
                }

                //check collision of targets 
                foreach (Target target in targets)
                {
                    foreach (TankShell shell in projectiles)
                    {
                        //  if collision -- do the thing
                        if (MathLibrary.CollisionTests.CircleCircleTest(
                                                       target.LocalPosition, target.sprite.width / 2,
                                                       shell.LocalPosition, shell.sprite.width / 2))
                        {
                            Destroy(shell);
                            Destroy(target);
                        }
                    }
                    //otherwise, do nothing
                }
            }

            // Draw GAMEPLAY
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            // Draw all current objects
            foreach (var go in gameObjects)
            {
                go.Draw();
            }

            //  Draw all current Targets
            foreach (var go in targets)
            {
                go.Draw();
            }

            //  draw all current projectiles
            foreach (var go in projectiles)
            {
                go.Draw();
            }

            Raylib.EndDrawing();

            // Process PENDING OBJECTS

            // Remove all objects that are marked for destroy
            foreach (var kill in killObjects)
            {
                gameObjects.Remove(kill);
                targets.Remove(kill);
                projectiles.Remove(kill);
            }
            killObjects.Clear();

            // Add all objects that are waiting to be alive
            foreach (var pending in pendingObjects)
            {
                gameObjects.Add(pending);
            }
            pendingObjects.Clear();

            //  Add all projectiles to the scene
            foreach (var pending in pendingProjectiles)
            {
                projectiles.Add((TankShell)pending);
            }
            pendingProjectiles.Clear();


            //  add all projectiles that are waiting
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }

}
