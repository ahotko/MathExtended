using System;

namespace MathExtended.Matrices
{
    public partial class Matrix
    {

        public static class Transformations
        {
            public static class Space2D
            {
                /// <summary>
                /// Creates rotation matrix for 2D rotation
                /// </summary>
                /// <param name="angle">Rotation Angle in Degrees</param>
                /// <returns>Rotation Matrix</returns>
                public static Matrix Rotation(double angle)
                {
                    double _rad = Math.PI * angle / 180.0;
                    var _result = new Matrix(2);
                    _result[1, 1] = Math.Cos(_rad);
                    _result[1, 2] = -Math.Sin(_rad);
                    _result[2, 1] = Math.Sin(_rad);
                    _result[2, 2] = Math.Cos(_rad);
                    return _result;
                }

                /// <summary>
                /// Creates Scaling matrix for 2D
                /// </summary>
                /// <param name="scaleX">Factor to scale in X direction</param>
                /// <param name="scaleY">Factor to scale in Y direction</param>
                /// <returns>Rotation Matrix</returns>
                public static Matrix Scale(double scaleX, double scaleY)
                {
                    var _result = new Matrix(2);
                    _result[1, 1] = scaleX;
                    _result[1, 2] = 0;
                    _result[2, 1] = 0;
                    _result[2, 2] = scaleY;
                    return _result;
                }

                /// <summary>
                /// Creates Shearing matrix for 2D in X direction
                /// </summary>
                /// <param name="angle">Shear angle in X direction</param>
                /// <returns>Rotation Matrix</returns>
                public static Matrix ShearX(double angle)
                {
                    var _result = new Matrix(2);
                    _result[1, 1] = 1;
                    _result[1, 2] = Math.Tan(angle);
                    _result[2, 1] = 0;
                    _result[2, 2] = 1;
                    return _result;
                }

                /// <summary>
                /// Creates Shearing matrix for 2D in Y direction
                /// </summary>
                /// <param name="angle">Shear angle in Y direction</param>
                /// <returns>Rotation Matrix</returns>
                public static Matrix ShearY(double angle)
                {
                    var _result = new Matrix(2);
                    _result[1, 1] = 1;
                    _result[1, 2] = 0;
                    _result[2, 1] = Math.Tan(angle);
                    _result[2, 2] = 1;
                    return _result;
                }

                /// <summary>
                /// Creates Reflection matrix for 2D
                /// </summary>
                /// <returns>Reflection Matrix</returns>
                public static Matrix Reflect()
                {
                    var _result = new Matrix(2);
                    _result[1, 1] = -1;
                    _result[1, 2] = 0;
                    _result[2, 1] = 0;
                    _result[2, 2] = -1;
                    return _result;
                }

                /// <summary>
                /// Creates Reflection matrix for 2D about X axis
                /// </summary>
                /// <returns>Reflection Matrix</returns>
                public static Matrix ReflectAboutX()
                {
                    var _result = new Matrix(2);
                    _result[1, 1] = 1;
                    _result[1, 2] = 0;
                    _result[2, 1] = 0;
                    _result[2, 2] = -1;
                    return _result;
                }

                /// <summary>
                /// Creates Reflection matrix for 2D about Y axis
                /// </summary>
                /// <returns>Reflection Matrix</returns>
                public static Matrix ReflectAboutY()
                {
                    var _result = new Matrix(2);
                    _result[1, 1] = -1;
                    _result[1, 2] = 0;
                    _result[2, 1] = 0;
                    _result[2, 2] = 1;
                    return _result;
                }
            }

            public static class Space3D
            {
                /// <summary>
                /// Creates roration matrix for 3D rotation around X axis
                /// </summary>
                /// <param name="angle">Rotation Angle in Degrees</param>
                /// <returns>Rotation Matrix</returns>
                public static Matrix RotationX(double angle)
                {
                    double _rad = Math.PI * angle / 180.0;
                    var _result = new Matrix(3);
                    _result[1, 1] = 1.0;
                    _result[1, 2] = 0.0;
                    _result[1, 3] = 0.0;
                    //
                    _result[2, 1] = 0.0;
                    _result[2, 2] = Math.Cos(_rad);
                    _result[2, 3] = -Math.Sin(_rad);
                    //
                    _result[3, 1] = 0.0;
                    _result[3, 2] = Math.Sin(_rad);
                    _result[3, 3] = Math.Cos(_rad);
                    return _result;
                }

                /// <summary>
                /// Creates roration matrix for 3D rotation around Y axis
                /// </summary>
                /// <param name="angle">Rotation Angle in Degrees</param>
                /// <returns>Rotation Matrix</returns>
                public static Matrix RotationY(double angle)
                {
                    double _rad = Math.PI * angle / 180.0;
                    var _result = new Matrix(3);
                    _result[1, 1] = Math.Cos(_rad);
                    _result[1, 2] = 0.0;
                    _result[1, 3] = Math.Sin(_rad);
                    //
                    _result[2, 1] = 0.0;
                    _result[2, 2] = 1.0;
                    _result[2, 3] = 0.0;
                    //
                    _result[3, 1] = -Math.Sin(_rad);
                    _result[3, 2] = 0.0;
                    _result[3, 3] = Math.Cos(_rad);
                    return _result;
                }

                /// <summary>
                /// Creates roration matrix for 3D rotation around Z axis
                /// </summary>
                /// <param name="angle">Rotation Angle in Degrees</param>
                /// <returns>Rotation Matrix</returns>
                public static Matrix RotationZ(double angle)
                {
                    double _rad = Math.PI * angle / 180.0;
                    var _result = new Matrix(3);
                    _result[1, 1] = Math.Cos(_rad);
                    _result[1, 2] = -Math.Sin(_rad);
                    _result[1, 3] = 0.0;
                    //
                    _result[2, 1] = Math.Sin(_rad);
                    _result[2, 2] = Math.Cos(_rad);
                    _result[2, 3] = 0.0;
                    //
                    _result[3, 1] = 0.0;
                    _result[3, 2] = 0.0;
                    _result[3, 3] = 1.0;
                    return _result;
                }

                public static Matrix Scaling(double factor)
                {
                    return Scaling(factor, factor, factor);
                }

                public static Matrix Scaling(double factorX, double factorY, double factorZ)
                {
                    var _result = new Matrix(3);
                    _result[1, 1] = factorX;
                    _result[1, 2] = 0.0;
                    _result[1, 3] = 0.0;
                    //
                    _result[2, 1] = 0.0;
                    _result[2, 2] = factorY;
                    _result[2, 3] = 0.0;
                    //
                    _result[3, 1] = 0.0;
                    _result[3, 2] = 0.0;
                    _result[3, 3] = factorZ;
                    return _result;
                }

                public static Matrix Translation(double moveX, double moveY, double moveZ)
                {
                    var _result = new Matrix(4);
                    _result[1, 1] = 1.0;
                    _result[1, 2] = 0.0;
                    _result[1, 3] = 0.0;
                    _result[1, 3] = moveX;
                    //
                    _result[2, 1] = 0.0;
                    _result[2, 2] = 1.0;
                    _result[2, 3] = 0.0;
                    _result[2, 4] = moveY;
                    //
                    _result[3, 1] = 0.0;
                    _result[3, 2] = 0.0;
                    _result[3, 3] = 1.0;
                    _result[3, 4] = moveZ;
                    //
                    _result[4, 1] = 0.0;
                    _result[4, 2] = 0.0;
                    _result[4, 3] = 0.0;
                    _result[4, 4] = 1.0;
                    return _result;
                }
            }
        }
    }
}

