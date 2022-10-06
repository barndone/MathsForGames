﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector3
    {
        public float x, y, z;

        //3 parameter constructor
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float Magnitude
        {
            get
            {
                return MathF.Sqrt((x * x) + (y * y) + (z * z));
            }
        }

        public void Normalize()
        {
            this /= Magnitude;
        }

        public Vector3 Normalized
        {
            get
            {   
                return this / Magnitude;
            }
        }

        public void Scale(Vector3 rhs)
        {
            this.x *= rhs.x;
            this.y *= rhs.y;
            this.z *= rhs.z;
        }

        public Vector3 Scaled(Vector3 rhs)
        {
            return new Vector3(rhs.x * x, rhs.y * y, rhs.z * z);
        }

        //returns the dot product of 2 Vector3s
        public float Dot(Vector3 rhs)
        {
            return (this.x * rhs.x) + (this.y * rhs.y) + (this.z * rhs.z);
        }

        //returns the cross product of two Vector3s
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3( (this.y * rhs.z) - (this.z * rhs.y), 
                                (this.z * rhs.x) - (this.x * rhs.z), 
                                (this.x * rhs.y) - (this.y * rhs.x));
        }

        #region Operators
        //  addition
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;
            result.z = lhs.z + rhs.z;
            return result;
        }

        //  subtraction
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;
            result.z = lhs.z - rhs.z;
            return result;
        }

        //  negation
        public static Vector3 operator -(Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = rhs.x * -1.0f;
            result.y = rhs.y * -1.0f;
            result.z = rhs.z * -1.0f;
            return result;
        }

        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        // Equals(Vector3)
        // Equals(object) - override!
        // == operator
        // != operator
        // GetHashCode()
        // ToString()

        public bool Equals(Vector3 other)
        {
            if (MathF.Abs(x - other.x) < 0.0001 &&
                MathF.Abs(y - other.y) < 0.0001 &&
                MathF.Abs(z - other.z) < 0.0001)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && Equals((Vector3)obj);
        }

        /// <summary>
        /// Determines if two vectors are approximately equal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>True if approximately equal, false if not</returns>
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Determines if two vectors are approximately inequal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>True if approximately inequal, false if not</returns>
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(x);
            hash.Add(y);
            hash.Add(z);

            return hash.ToHashCode();
        }

        #endregion

        //override the default ToString implementation
        public override string ToString()
        {
            return "{ " + x + "(x) " + y + "(y) " + z + "(z) }";
        }
    }
}
