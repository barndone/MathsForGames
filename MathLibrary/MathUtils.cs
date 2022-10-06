using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class MathUtils
    {
        public static float DegreeToRadians(float degrees)
        {
            return (MathF.PI / 180.0f) * degrees;
        }
    }
}
