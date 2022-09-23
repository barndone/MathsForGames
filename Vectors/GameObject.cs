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
        public Vector3 position;

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
