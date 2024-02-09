using System;

namespace Vector_Calculator
{
    public class Vector
    {
        //haha
        public static float GetMagnitude(float[] v)
        {
            float output = 0;
            for (int d = 0; d < v.Length; d++)
            {
                output += MathF.Pow(v[d], 2);
            }
            return MathF.Sqrt(output);
        }

        public static float GetDirection(float[] v)
        {
            return MathF.Atan(v[1] / v[0]) * 180 / MathF.PI;
        }

        public static string Add(float[] v1, float[] v2)
        {
            string output = "<" + (v1[0] + v2[0]);
            for (int d = 1; d < v1.Length; d++)
            {
                output += ", " + (v1[d] + v2[d]);
            }
            return output + ">";
        }

        public static string Negate(float[] v)
        {
            string output = "<" + -v[0];
            for (int d = 1; d < v.Length; d++)
            {
                output += ", " + -v[d];
            }
            return output + ">";
        }

        public static string Subtract(float[] v1, float[] v2)
        {
            string output = "<" + (v1[0] - v2[0]);
            for (int d = 1; d < v1.Length; d++)
            {
                output += ", " + (v1[d] - v2[d]);
            }
            return output + ">";
        }

        public static string Scale(float[] v1, float m)
        {
            string output = "<" + (v1[0] * m);
            for (int d = 1; d < v1.Length; d++)
            {
                output += ", " + (v1[d] * m);
            }
            return output + ">";
        }

        public static string Normalize(float[] v)
        {
            float mag = GetMagnitude(v);
            string output = "<" + (v[0] / mag);
            for (int d = 1; d < v.Length; d++)
            {
                output += ", " + (v[d] / mag);
            }
            return output + ">";
        }

        public static float DotProduct(float[] v1, float[] v2)
        {
            float output = 0;
            for (int d = 0; d < v1.Length; d++)
            {
                output += v1[d] * v2[d];
            }
            return output;
        }

        public static string CrossProduct(float[] v1, float[] v2)
        {
            return "<" + (v1[1] * v2[2] - v1[2] * v2[1]) + ", " + (v1[2] * v2[0] - v1[0] * v2[2]) + ", " + (v1[0] * v2[1] - v1[1] * v2[0]) + ">";
        }

        public static float AngleBetween(float[] v1, float[] v2)
        {
            return MathF.Acos(DotProduct(v1, v2) / (GetMagnitude(v1) * GetMagnitude(v2))) * 180 / MathF.PI;
        }

        public static string ProjectOnto(float[] v1, float[] v2)
        {
            return Scale(v2, DotProduct(v1, v2) / MathF.Pow(GetMagnitude(v2), 2));
        }
    }
}
