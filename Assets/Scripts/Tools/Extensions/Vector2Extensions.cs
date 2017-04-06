using System;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// A static class which contains extension methods for the Vector2 class.
    /// </summary>
    public static class Vector2Extensions
    {

        public static Vector2 Multiply(this Vector2 v1, Vector2 v2){
            return new Vector2(v1.x*v2.x,v1.y*v2.y);
        }

        public static Vector2 Divide(this Vector2 v1, Vector2 v2){
            return new Vector2(v1.x/v2.x,v1.y/v2.y);
        }

        public static Vector2 Rotate(this Vector2 v, float degrees) {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
             
            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
         }

         public static Vector3 RotateXYPlane(this Vector3 v, float degrees){
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
             
            float tx = v.x;
            float ty = v.z;
            v.x = (cos * tx) - (sin * ty);
            v.z = (sin * tx) + (cos * ty);
            return v;
         }

        public static Vector2 Round(this Vector2 v) {
            return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
        }

        public static Vector2 Floor(this Vector2 v){
            return new Vector2(Mathf.Floor(v.x), Mathf.Floor(v.y));
        }

        public static Vector2 Ceil(this Vector2 v){
            return new Vector2(Mathf.Ceil(v.x), Mathf.Ceil(v.y));
        }
        
        /// <summary>
        /// Determines whether this Vector2 contains any components which are not a number.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>
        /// 	<c>true</c> if either x or y are NaN; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNaN(this Vector2 v)
        {
            return float.IsNaN(v.x) || float.IsNaN(v.y);
        }

        /// <summary>
        /// Creates a vector perpendicular to this vector.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 Perpendicular(this Vector2 v)
        {
            return new Vector2(v.y, -v.x);
        }

        /// <summary>
        /// Calculates the perpendicular dot product of this vector and another.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Cross(this Vector2 a, Vector2 b)
        {
            return a.x * b.y - a.y * b.x;
        }

        /// <summary>
        /// Determines the length of a vector using the manhattan length function
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float ManhattanLength(this Vector2 v)
        {
            return Math.Abs(v.x) + Math.Abs(v.y);
        }

        /// <summary>
        /// Returns the largest element in the vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float LargestElement(this Vector2 v)
        {
            return Math.Max(v.x, v.y);
        }

        /// <summary>
        /// Calculates the area of an irregular polygon. If the polygon is anticlockwise wound the area will be negative
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Area(this List<Vector2> v)
        {
            var area = 0f;

            int previous = v.Count - 1;
            for (int i = 0; i < v.Count; i++)
            {
                area += (v[i].x + v[previous].x) * (v[i].y - v[previous].y);
                previous = i;
            }

            return -area / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool IsConvex(this List<Vector2> v, float epsilon = float.Epsilon)
        {
            int sign = 0;
            bool first = true;
            for (int i = 0; i < v.Count; i++)
            {
                var p = v[i];
                var p1 = v[(i + 1) % v.Count];
                var p2 = v[(i + 2) % v.Count];

                var d1 = p1 - p;
                var d2 = p2 - p1;

                var crossProduct = d1.x * d2.y - d1.y * d2.x;
                int crossProductSign = crossProduct > epsilon ? 1 : crossProduct < -epsilon ? -1 : 0;

                if (crossProductSign == 0)
                    continue;

                if (first)
                {
                    sign = crossProductSign;
                    first = false;
                }
                else if (crossProductSign != sign)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Rearrange elements in a vector2
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 xx(this Vector2 v)
        {
            return new Vector2(v.x, v.x);
        }

        /// <summary>
        /// Rearrange elements in a vector2
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 xy(this Vector2 v)
        {
            return new Vector2(v.x, v.y);
        }

        /// <summary>
        /// Rearrange elements in a vector2
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 yx(this Vector2 v)
        {
            return new Vector2(v.y, v.x);
        }

        /// <summary>
        /// Rearrange elements in a vector2
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 yy(this Vector2 v)
        {
            return new Vector2(v.y, v.y);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _xy(this Vector2 v, float x)
        {
            return new Vector3(x, v.x, v.y);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 x_y(this Vector2 v, float y)
        {
            return new Vector3(v.x, y, v.y);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 xy_(this Vector2 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _xx(this Vector2 v, float x)
        {
            return new Vector3(x, v.x, v.x);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 x_x(this Vector2 v, float y)
        {
            return new Vector3(v.x, y, v.x);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 xx_(this Vector2 v, float z)
        {
            return new Vector3(v.x, v.x, z);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _yy(this Vector2 v, float x)
        {
            return new Vector3(x, v.y, v.y);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 y_y(this Vector2 v, float y)
        {
            return new Vector3(v.y, y, v.y);
        }

        /// <summary>
        /// Create a new vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 yy_(this Vector2 v, float z)
        {
            return new Vector3(v.y, v.y, z);
        }
    }

