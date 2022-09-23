﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal struct Vector4
    {
        public float x, y, z, w;

        //4 param constructor
        public Vector4 (float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        //operations:
        //  addition
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;
            result.z = lhs.z + rhs.z;
            result.w = lhs.w + rhs.w;

            return result;
        }
        //  subtraction
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;
            result.z = lhs.z - rhs.z;
            result.w = lhs.w - rhs.w;

            return result;
        }
        //  negation
        public static Vector4 operator -(Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = -1 * rhs.x;
            result.y = -1 * rhs.y;
            result.z = -1 * rhs.z;
            result.w = -1 * rhs.w;

            return result;
        }
        //equality comparisons
        //  ==
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            //if the difference of each component is less than twice the float.Epsilon, consider them equal
            if (MathF.Abs(lhs.x - rhs.x) < (float.Epsilon)
                && MathF.Abs(lhs.y - rhs.y) < (float.Epsilon)
                && MathF.Abs(lhs.z - rhs.z) < (float.Epsilon)
                && MathF.Abs(lhs.w - rhs.w) < (float.Epsilon))
            {
                return true;
            }
            //otherwise, they are not equal
            else
            {
                return false;
            }
        }

        //  !=
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            return !(lhs == rhs);
        }

        //ToString() override
        public override string ToString()
        {
            return "{ " + x + "(x)\n{ " + y + "(y)\n " + z + "(z)\n" + w + " }";
        }
    }
}