using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace YnscriptionEngine.Input {
	public class MouseHandler : Microsoft.Xna.Framework.GameComponent{

		static MouseState currentState;
		static MouseState lastState;
		static Rectangle screenRectangle;
		static bool fixedCursor;

		public MouseState CurrentState {
			get { return currentState; }
		}
		public MouseState LastState {
			get { return lastState; }

		}
		public static bool FixedCursor {
			get {return fixedCursor;}
			set {fixedCursor = value;}
		}

		public MouseHandler (Game game) : base (game){
			currentState = Mouse.GetState();
			screenRectangle = ((YGame)game).ScreenRectangle;
			fixedCursor = false;
		}



		public override void Update (GameTime gameTime) {
			lastState = currentState;
			currentState = Mouse.GetState();
			
			//This is for fps so the cursor stays in the middle
			if (fixedCursor) {
				Mouse.SetPosition (screenRectangle.Width / 2, screenRectangle.Height / 2);
			}
			base.Update (gameTime);
		}

		public void flush () {
			lastState = currentState;
		}

		private static ButtonState getButtonState (MouseButtons button, MouseState state) {
			ButtonState r = new ButtonState ();
			if (button == MouseButtons.LeftButton) {
				r = state.LeftButton;
			} else if (button == MouseButtons.MiddleButton) {
				r = state.MiddleButton;
			} else if (button == MouseButtons.RightButton) {
				r = state.RightButton;
			} else if (button == MouseButtons.Button1) {
				r = state.XButton1;
			} else if (button == MouseButtons.Button2) {
				r = state.XButton2;
			}


			return r;
		}

		public static bool ButtonReleased (MouseButtons button) {
			return (getButtonState (button,lastState) == ButtonState.Pressed) && (getButtonState(button,currentState) == ButtonState.Released);
		}
		public static bool ButtonPressed (MouseButtons button) {
			return (getButtonState (button, lastState) == ButtonState.Released) && (getButtonState (button, currentState) == ButtonState.Pressed);
		}
		public static bool ButtonDown (MouseButtons button) {
			return (getButtonState (button, currentState) == ButtonState.Pressed);
		}

		public static Vector2 Position () {
			return new Vector2(currentState.X, currentState.Y);
		}

		public static Vector2 Movement () {
			if (fixedCursor) {
				return new Vector2 (currentState.X - screenRectangle.Width/2, currentState.Y - screenRectangle.Height/2);
			}else {
				return new Vector2 (currentState.X - lastState.X, currentState.Y - lastState.Y);
			}
		}

		public static int Scroll () {
			return currentState.ScrollWheelValue - lastState.ScrollWheelValue;
		}

	}
	public enum MouseButtons {
		LeftButton, MiddleButton, RightButton, ScrollWheel, Button1, Button2

	}
}
