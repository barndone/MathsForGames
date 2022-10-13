using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public static class CollisionTests
    {
        public static bool CirclePointTest(Vector3 circlePosition, float circleRadius, Vector3 pointPosition)
        {
            /* SLOW IMPLEMENTATION
            //get the distance
            float distance = (circlePosition - pointPosition).Magnitude;
            //compare to radius of circle, if less collision, if more no collision
            return distance <= circleRadius;
            */
            
            //FASTER IMPLEMENTATION
            
            Vector3 offset = circlePosition - pointPosition;
            float distanceSquared = offset.Dot(offset);
            
            return distanceSquared <= circleRadius * circleRadius;
        }
    }
}
