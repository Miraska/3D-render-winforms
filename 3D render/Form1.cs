using _3D_render._3d_engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_render
{
	public partial class Form1 : Form
	{
		Graphics surface;

		public Form1()
		{
			InitializeComponent();
			surface = pictureBox1.CreateGraphics();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			Vector3 vector3 = new Vector3(10, 10, 10);

			Vector3[] vertices = {
				new Vector3(-1, 1, 1), // 0 вершина
			    new Vector3(-1, 1, -1), // 1 вершина
			    new Vector3(1, 1, -1), // 2 вершина
			    new Vector3(1, 1, 1), // 3 вершина
			    new Vector3(-1, -1, 1), // 4 вершина
			    new Vector3(-1, -1, -1), // 5 вершина
			    new Vector3(1, -1, -1), // 6 вершина
			    new Vector3(1, -1, 1) // 7 вершина
			};

			int[][] edges =
			{
				new int[2] { 0, 1 },
				new int[2] {1, 2 },
				new int[2] {2, 3 },
				new int[2] {3, 0 },

				new int[2] {0, 4 },
				new int[2] {1, 5 },
				new int[2] {2, 6 },
				new int[2] {3, 7 },

				new int[2] {4, 5 },
				new int[2] {5, 6 },
				new int[2] {6, 7 },
				new int[2] {7, 4 }
			};


			double[,] matrix;
			int angle = 0;

			//Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.White, Color.Orange };

			Task.Run(() =>
			{
				while (true)
				{
					Thread.Sleep(10);
					label2.Text = (1000 / 10).ToString();
					List<Vector3> sceneVertices = new List<Vector3>();

					angle++;

					matrix = Matrix.GetRotationX(20 + angle);
					matrix = Matrix.Multiply(Matrix.GetRotationY(angle), matrix);
					matrix = Matrix.Multiply(Matrix.GetScale(100, 100, 100), matrix);
					matrix = Matrix.Multiply(Matrix.GetTranslationMatrix(400, 200, 0), matrix);


					for (int i = 0; i < vertices.Length; i++)
					{
						var vertex = Matrix.MultiplyVector(matrix, vertices[i]);
						sceneVertices.Add(vertex);
					}
										
					surface.Clear(Color.Black);

					Draw(edges, sceneVertices);
				}
			});
		}

		private void Draw(int[][] edges, List<Vector3> sceneVertices)
		{
			for (int i = 0; i < edges.Length; i++)
			{
				int[] a = edges[i];

				surface.DrawLine
				(
					new Pen(Color.White, 1f),
					(float)sceneVertices[a[0]].x,
					(float)sceneVertices[a[0]].y,
					(float)sceneVertices[a[1]].x,
					(float)sceneVertices[a[1]].y
				);
			}
		}
	}
}
