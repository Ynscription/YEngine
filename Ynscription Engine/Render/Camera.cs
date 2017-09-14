using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using YnscriptionEngine.Input;

namespace YnscriptionEngine.Render {
	public class Camera {
		private Matrix view;

		private Vector3 position;
		private Vector3 target;
		private Vector3 cameraUp;

		private double vertRot;
		private double horRot;

		private Matrix projection;

		private static float speed = 0.5f;
		private static float rotSpeed = 0.0025f;

		public Matrix View {
			get { return view;}
			set {view = value;}
		}
		public Matrix Projection {
			get {return projection;}
			set {projection = value;}
		}




		public Camera (Vector3 pos, Vector3 tar, Vector3 up, Matrix p) {
			View = Matrix.CreateLookAt (pos, pos + tar,up);
			position = pos;
			target = tar;
			cameraUp = up;
			Projection = p;
			vertRot = 0;
			horRot = 0;
		}





		public void update () {
			HandleKeyInput ();
			HandleMouseInput ();
			Console.Clear ();
			Console.WriteLine ("horRot = " + horRot);
			Console.WriteLine ("vertRot = " + vertRot);
			view = Matrix.CreateLookAt (position, position + target, Vector3.UnitZ);
		}


		private void HandleMouseInput () {
			Vector2 mouseMov = MouseHandler.Movement ();

			horRot += (-mouseMov.X * rotSpeed);
 			vertRot += (mouseMov.Y * rotSpeed);

			if (horRot > 2*Math.PI -0.001f) {
				horRot -=  2 * Math.PI;
			} else if (horRot < 0) {
				horRot += 2 * Math.PI;
			}

			if (vertRot < 0.001f) {
				vertRot = 0.001f;
			}else if (vertRot > (Math.PI - 0.001f)) {
				vertRot = Math.PI - 0.001f;
			}

			target.X = (float)(Math.Sin (vertRot) * Math.Cos (horRot));
			target.Y = (float) (Math.Sin (vertRot) * Math.Sin (horRot));
			target.Z = (float) (Math.Cos (vertRot));

		}
		


		#region KeyBoardInput
		private void HandleKeyInput () {
			Keys key = simplifyInputX();
			Vector3 move = Vector3.Zero;
			if (key == Keys.W) {
				move.X = (float)Math.Cos(horRot);
				move.Y = (float)Math.Sin(horRot);
				position = position + (Vector3.Multiply (move, speed));
			} else if (key == Keys.S) {
				move.X = (float) -Math.Cos (horRot);
				move.Y = (float) -Math.Sin (horRot);
				position = position + (Vector3.Multiply (move, speed));
			}

			key = simplifyInputY();
			if (key == Keys.A) {
				move.X = (float) Math.Cos (horRot + (Math.PI/2));
				move.Y = (float) Math.Sin (horRot + (Math.PI / 2));
				position = position + (Vector3.Multiply (move, speed));				
			}else if (key == Keys.D) {
				move.X = (float) Math.Cos (horRot - (Math.PI / 2));
				move.Y = (float) Math.Sin (horRot - (Math.PI / 2));
				position = position + (Vector3.Multiply (move, speed));			
			}

			key = simplifyInputZ ();
			if (key == Keys.Space) {
				position = position + Vector3.Multiply (Vector3.UnitZ,speed);
			} else if (key == Keys.LeftControl) {
				position = position - Vector3.Multiply (Vector3.UnitZ, speed);
			}
			




		}


		private Keys simplifyInputX () {
			int nx = 0;
			
			if (KeyBoardHandler.KeyDown (Keys.W)) {
				nx += 1;
			}
			if (KeyBoardHandler.KeyDown (Keys.S)) {
				nx -= 1;
			}
		
			Keys x = Keys.None;
			if (nx == 1) {
				x = Keys.W;
			}
			else if (nx == -1) {
				x = Keys.S;
			}
			return x;
		}
		
		private Keys simplifyInputY () {
			int ny = 0;

			if (KeyBoardHandler.KeyDown (Keys.D)) {
				ny += 1;
			}
			if (KeyBoardHandler.KeyDown (Keys.A)) {
				ny -= 1;
			}

			Keys y = Keys.None;
			if (ny == 1) {
				y = Keys.D;
			} else if (ny == -1) {
				y = Keys.A;
			}
			return y;
		}

		private Keys simplifyInputZ () {
			int nz = 0;

			if (KeyBoardHandler.KeyDown (Keys.Space)) {
				nz += 1;
			}
			if (KeyBoardHandler.KeyDown (Keys.LeftControl)) {
				nz -= 1;
			}

			Keys z = Keys.None;
			if (nz == 1) {
				z = Keys.Space;
			} else if (nz == -1) {
				z = Keys.LeftControl;
			}
			return z;
		}

		#endregion


	}
}
