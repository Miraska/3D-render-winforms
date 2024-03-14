using System;

namespace _3D_render._3d_engine
{
	internal class Matrix
	{
		public static int[,] Multiply(int[,] a, int[,] b)
		{
			int[,] m = new int[4, 4];

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					m[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j] + a[i, 3] * b[3, j];
				}
			}

			return m;
		}

		public static float[,] Multiply(float[,] a, float[,] b)
		{
			float[,] m = new float[4, 4];

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					m[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j] + a[i, 3] * b[3, j];
				}
			}

			return m;
		}

		public static double[,] Multiply(double[,] a, double[,] b)
		{
			double[,] m = new double[4, 4];

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					m[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j] + a[i, 3] * b[3, j];
				}
			}

			return m;
		}

		public static double[,] Multiply(int[,] a, double[,] b)
		{
			double[,] m = new double[4, 4];

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					m[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j] + a[i, 3] * b[3, j];
				}
			}

			return m;
		}

		public static Vector3 MultiplyVector(int[,] m, Vector3 v)
		{
			return new Vector3
				(
					m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
					m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
					m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
					m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w
				);
		}

		public static Vector3 MultiplyVector(float[,] m, Vector3 v)
		{
			return new Vector3
				(
					m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
					m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
					m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
					m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w
				);
		}

		public static Vector3 MultiplyVector(double[,] m, Vector3 v)
		{
			return new Vector3
				(
					m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
					m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
					m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
					m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w
				);
		}

		public static int[,] GetTranslationMatrix(int dx, int dy, int dz)
		{
			int[,] matrix = { { 1, 0, 0, dx }, { 0, 1, 0, dy }, { 0, 0, 1, dz }, { 0, 0, 0, 1 } };
			return matrix;
		}

		public static int[,] GetScale(int sx, int sy, int sz)
		{
			int[,] matrix = { { sx, 0, 0, 0 }, { 0, sy, 0, 0 }, { 0, 0, sz, 0 }, { 0, 0, 0, 1 } };
			return matrix;
		}

		public static double[,] GetRotationX(int angle)
		{
			double rad = Math.PI / 180 * angle;

			double[,] matrix = { { 1, 0, 0, 0 }, { 0, Math.Cos(rad), -Math.Sin(rad), 0 }, { 0, Math.Sin(rad), Math.Cos(rad), 0 }, { 0, 0, 0, 1 } };

			return matrix;
		}

		public static double[,] GetRotationY(int angle)
		{
			double rad = Math.PI / 180 * angle;

			double[,] matrix = { { Math.Cos(rad), 0, Math.Sin(rad), 0 }, { 0, 1, 0, 0 }, { -Math.Sin(rad), 0, Math.Cos(rad), 0 }, { 0, 0, 0, 1 } };
			return matrix;
		}

		public static double[,] GetRotationZ(int angle)
		{
			double rad = Math.PI / 180 * angle;

			double[,] matrix = { {Math.Cos(rad), -Math.Sin(rad), 0, 0 }, { Math.Sin(rad), Math.Cos(rad), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

			return matrix;
		}
	}
}