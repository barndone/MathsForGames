﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

using MathLibrary;
using GameFramework;

namespace Matrix
{
    public static class GameObjectFactory
    {
        public static GameObject MakeMonster()
        {
            Monster newMonster = new Monster();
            newMonster.sprite = Raylib.LoadTexture("res/monster.png");

            return newMonster;
        }

        public static GameObject MakeSprite(string pathToSprite)
        {
            SpriteObject newSprite = new SpriteObject();
            if (!File.Exists(pathToSprite))
            {
                throw new FileNotFoundException("File not found at path: " + pathToSprite);
            }

            newSprite.sprite = Raylib.LoadTexture(pathToSprite);

            return newSprite;
        }

        public static GameObject MakeHoverCircle(Vector3 pos, float radius)
        {
            HoverCircle newHoverCircle = new HoverCircle();
            newHoverCircle.LocalPosition = pos;
            newHoverCircle.radius = radius;

            return newHoverCircle;
        }
    }
}
