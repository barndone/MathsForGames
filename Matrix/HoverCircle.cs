using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameFramework;
using MathLibrary;

using Raylib_cs;

namespace Matrix
{
    class HoverCircle : GameObject
    {

        public float radius = 25.0f;
        private bool isHovering;

        public Color normalColor = Color.GRAY;
        public Color hoverColor = Color.RED;
        protected override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);

            Matrix3 global = GlobalTransform;
            Vector3 worldPosition = global.GetTranslation();

            isHovering = CollisionTests.CirclePointTest(worldPosition, radius, new Vector3 (Raylib.GetMouseX(), Raylib.GetMouseY(), worldPosition.z));
        }

        protected override void OnDraw()
        {
            base.OnDraw();

            Matrix3 global = GlobalTransform;
            Vector3 worldPosition = global.GetTranslation();

            //TODO: RADIUS IS CURRENTLY NOT CONSIDERING SCALE
            Raylib.DrawCircle((int)worldPosition.x, (int)worldPosition.y, radius, isHovering ? hoverColor : normalColor);
        }
    }
}
