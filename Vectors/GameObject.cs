using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathLibrary;

namespace Vectors
{
    public class GameObject
    {
        protected Vector3 position;
        protected int screenWidth;
        protected int screenHeight;

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
