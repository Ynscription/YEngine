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
	public class KeyBoardHandler : Microsoft.Xna.Framework.GameComponent {
		static KeyboardState currentState;
		static KeyboardState lastState { get; set; }

		public KeyboardState CurrentState {
			get {return currentState;}
		}
		public KeyboardState LastState {
			get {return lastState;}

		}

		

		public KeyBoardHandler (Game game) : base (game) {
			currentState = Keyboard.GetState();
		}

		public override void Initialize () {
			base.Initialize ();
		}

		public override void Update (GameTime gameTime) {
			lastState = currentState;
			currentState = Keyboard.GetState();
			base.Update (gameTime);
		}


		public static void flush () {
			lastState = currentState;
		}

		public static bool KeyReleased(Keys key) {
			return lastState.IsKeyDown(key) && currentState.IsKeyUp(key);
		}
		public static bool KeyPressed (Keys key) {
			return lastState.IsKeyUp(key) && currentState.IsKeyDown(key);
		}
		public static bool KeyDown (Keys key) {
			return currentState.IsKeyDown (key);
		}







	}
}
