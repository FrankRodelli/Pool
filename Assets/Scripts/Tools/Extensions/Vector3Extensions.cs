using System;
using UnityEngine;


    /// <summary>
    /// A static class which contains extension methods for the Vector2 class.
    /// </summary>
    public static class Vector3Extensions
    {

        public static Vector3 Multiply(this Vector3 v1, Vector3 v2){
            return new Vector3(v1.x*v2.x,v1.y*v2.y,v1.z*v2.z);
        }

        public static Vector3 Divide(this Vector3 v1, Vector3 v2){
            return new Vector3(v1.x/v2.x,v1.y/v2.y,v1.z/v2.z);
        }

         // axisDirection - unit vector in direction of an axis (eg, defines a line that passes through zero)
        // point - the point to find nearest on line for
        public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
        {
            if (!isNormalized) axisDirection.Normalize();
            var d = Vector3.Dot(point, axisDirection);
            return axisDirection * d;
        }

        // lineDirection - unit vector in direction of line
        // pointOnLine - a point on the line (allowing us to define an actual line in space)
        // point - the point to find nearest on line for
        public static Vector3 NearestPointOnLine(
            this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false)
        {
            if (!isNormalized) lineDirection.Normalize();
            var d = Vector3.Dot(point - pointOnLine, lineDirection);
            return pointOnLine + (lineDirection * d);
        }

        public static Vector3 Round(this Vector3 v) {
            return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
        }

        public static Vector3 Floor(this Vector3 v){
            return new Vector3(Mathf.Floor(v.x), Mathf.Floor(v.y), Mathf.Floor(v.z));
        }

        public static Vector3 Ceil(this Vector3 v){
            return new Vector3(Mathf.Ceil(v.x), Mathf.Ceil(v.y), Mathf.Ceil(v.z));
        }


        /// <summary>
        /// Determines whether this Vector3 contains any components which are not a number.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>
        /// 	<c>true</c> if either x or y or z are NaN; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNaN(this Vector3 v)
        {
            return float.IsNaN(v.x) || float.IsNaN(v.y) || float.IsNaN(v.z);
        }

        /// <summary>
        /// Determines the length of a vector using the manhattan length function
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float ManhattanLength(this Vector3 v)
        {
            return Mathf.Abs(v.x) + Mathf.Abs(v.y) + Mathf.Abs(v.z);
        }

        /// <summary>
        /// Returns the largest element in the vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float LargestElement(this Vector3 v)
        {
            return Mathf.Max(Mathf.Max(v.x, v.y), v.z);
        }

        #region convert to v2
        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 xx(this Vector3 point)
        {
            return new Vector2(point.x, point.x);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 xy(this Vector3 point)
        {
            return new Vector2(point.x, point.y);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 xz(this Vector3 point)
        {
            return new Vector2(point.x, point.z);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 yx(this Vector3 point)
        {
            return new Vector2(point.y, point.x);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 yy(this Vector3 point)
        {
            return new Vector2(point.y, point.y);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 yz(this Vector3 point)
        {
            return new Vector2(point.y, point.z);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 zx(this Vector3 point)
        {
            return new Vector2(point.z, point.x);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 zy(this Vector3 point)
        {
            return new Vector2(point.z, point.y);
        }

        /// <summary>
        /// Get a vector 2 with the specified elements
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 zz(this Vector3 point)
        {
            return new Vector2(point.z, point.z);
        }
        #endregion

        #region reorder v3
        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xxx(this Vector3 point)
        {
            return new Vector3(point.x, point.x, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xxy(this Vector3 point)
        {
            return new Vector3(point.x, point.x, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xxz(this Vector3 point)
        {
            return new Vector3(point.x, point.x, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xyx(this Vector3 point)
        {
            return new Vector3(point.x, point.y, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xyy(this Vector3 point)
        {
            return new Vector3(point.x, point.y, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xyz(this Vector3 point)
        {
            return new Vector3(point.x, point.y, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xzx(this Vector3 point)
        {
            return new Vector3(point.x, point.z, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xzy(this Vector3 point)
        {
            return new Vector3(point.x, point.z, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 xzz(this Vector3 point)
        {
            return new Vector3(point.x, point.z, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yxx(this Vector3 point)
        {
            return new Vector3(point.y, point.x, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yxy(this Vector3 point)
        {
            return new Vector3(point.y, point.x, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yxz(this Vector3 point)
        {
            return new Vector3(point.y, point.x, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yyx(this Vector3 point)
        {
            return new Vector3(point.y, point.y, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yyy(this Vector3 point)
        {
            return new Vector3(point.y, point.y, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yyz(this Vector3 point)
        {
            return new Vector3(point.y, point.y, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yzx(this Vector3 point)
        {
            return new Vector3(point.y, point.z, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yzy(this Vector3 point)
        {
            return new Vector3(point.y, point.z, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 yzz(this Vector3 point)
        {
            return new Vector3(point.y, point.z, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zxx(this Vector3 point)
        {
            return new Vector3(point.z, point.x, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zxy(this Vector3 point)
        {
            return new Vector3(point.z, point.x, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zxz(this Vector3 point)
        {
            return new Vector3(point.z, point.x, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zyx(this Vector3 point)
        {
            return new Vector3(point.z, point.y, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zyy(this Vector3 point)
        {
            return new Vector3(point.z, point.y, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zyz(this Vector3 point)
        {
            return new Vector3(point.z, point.y, point.z);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zzx(this Vector3 point)
        {
            return new Vector3(point.z, point.z, point.x);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zzy(this Vector3 point)
        {
            return new Vector3(point.z, point.z, point.y);
        }

        /// <summary>
        /// Create a new vector 3 with the same elements in a different order
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 zzz(this Vector3 point)
        {
            return new Vector3(point.z, point.z, point.z);
        }
        #endregion

        #region reorder v3 substitute z
        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 xx_(this Vector3 point, float z)
        {
            return new Vector3(point.x, point.x, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 xy_(this Vector3 point, float z)
        {
            return new Vector3(point.x, point.y, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 xz_(this Vector3 point, float z)
        {
            return new Vector3(point.x, point.z, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 yx_(this Vector3 point, float z)
        {
            return new Vector3(point.y, point.x, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 yy_(this Vector3 point, float z)
        {
            return new Vector3(point.y, point.y, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 yz_(this Vector3 point, float z)
        {
            return new Vector3(point.y, point.z, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 zx_(this Vector3 point, float z)
        {
            return new Vector3(point.z, point.x, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 zy_(this Vector3 point, float z)
        {
            return new Vector3(point.z, point.y, z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 zz_(this Vector3 point, float z)
        {
            return new Vector3(point.z, point.z, z);
        }
        #endregion

        #region reorder v3 substitute y
        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 x_x(this Vector3 point, float z)
        {
            return new Vector3(point.x, z, point.x);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 x_y(this Vector3 point, float y)
        {
            return new Vector3(point.x, y, point.y);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 x_z(this Vector3 point, float y)
        {
            return new Vector3(point.x, y, point.z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 y_x(this Vector3 point, float y)
        {
            return new Vector3(point.y, y, point.x);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 y_y(this Vector3 point, float y)
        {
            return new Vector3(point.y, y, point.y);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 y_z(this Vector3 point, float y)
        {
            return new Vector3(point.y, y, point.z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 z_x(this Vector3 point, float y)
        {
            return new Vector3(point.z, y, point.x);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 z_y(this Vector3 point, float y)
        {
            return new Vector3(point.z, y, point.y);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 z_z(this Vector3 point, float y)
        {
            return new Vector3(point.z, y, point.z);
        }
        #endregion

        #region reorder v3 substitute y
        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _xx(this Vector3 point, float x)
        {
            return new Vector3(x, point.x, point.x);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _xy(this Vector3 point, float x)
        {
            return new Vector3(x, point.x, point.y);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _xz(this Vector3 point, float x)
        {
            return new Vector3(x, point.x, point.z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _yx(this Vector3 point, float x)
        {
            return new Vector3(x, point.y, point.x);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _yy(this Vector3 point, float x)
        {
            return new Vector3(x, point.y, point.y);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _yz(this Vector3 point, float x)
        {
            return new Vector3(x, point.y, point.z);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _zx(this Vector3 point, float x)
        {
            return new Vector3(x, point.z, point.x);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _zy(this Vector3 point, float x)
        {
            return new Vector3(x, point.z, point.y);
        }

        /// <summary>
        /// Create a vector 3 with 2 elements from this vector, and a third floating point value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 _zz(this Vector3 point, float x)
        {
            return new Vector3(x, point.z, point.z);
        }
        #endregion
    }
