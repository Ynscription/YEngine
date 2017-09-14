using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YnscriptionEngine.Input;

namespace YnscriptionEngine.GUI.Controls {
	public class ControlManager : List<Control>{

		int selectedControl = 0;
		static SpriteFont spriteFont;

		public event EventHandler FocusChanged;

		public static SpriteFont SpriteFont {
			get {return spriteFont;}
		}




		public ControlManager (SpriteFont spriteFont) :base(){
			ControlManager.spriteFont = spriteFont;
		}

		public ControlManager (SpriteFont spriteFont, int capacity) :base (capacity){
			ControlManager.spriteFont = spriteFont;
		}

		public ControlManager (SpriteFont spriteFont, IEnumerable<Control> collection) : base (collection) {
			ControlManager.spriteFont = spriteFont;
		}



		public void Update (GameTime gameTime) {
			if (Count == 0) {
				return;
			}
			foreach (Control c in this) {
				if (c.Enabled) {
					c.Update(gameTime);
				}
				if (c.HasFocus) {
					c.HandleInput ();
				}
			}
			if (KeyBoardHandler.KeyPressed (Keys.Up) || KeyBoardHandler.KeyPressed (Keys.W)) {
				PreviousControl ();
			}if (KeyBoardHandler.KeyPressed (Keys.Down) ||KeyBoardHandler.KeyPressed (Keys.S)) {
				NextControl();
			}

		}

		public void Draw (SpriteBatch spriteBatch) {
			foreach (Control c in this) {
				if (c.Visible) {
					c.Draw(spriteBatch);
				}
			}
		}

		public void NextControl () {
			if (Count == 0) {
				return;
			}

			int currentControl = selectedControl;
			this [selectedControl].HasFocus = false;
			bool flag = true;
			
			do {
				selectedControl++;
				if (selectedControl == Count) {
					selectedControl = 0;
				}
				if (this[selectedControl].TabStop && this [selectedControl].Enabled) {
					if (FocusChanged != null) {
						FocusChanged(this[selectedControl], null);
					}
					flag = false;
				}
				
			}while (flag && (currentControl != selectedControl));
			this [selectedControl].HasFocus = true;
			
		}

		public void PreviousControl () {
			if (Count == 0) {
				return;
			}

			int currentControl = selectedControl;
			this [selectedControl].HasFocus = false;
			bool flag = true;

			do {
				selectedControl--;
				if (selectedControl < 0) {
					selectedControl = Count -1;
				}
				if (this [selectedControl].TabStop && this [selectedControl].Enabled) {
					if (FocusChanged != null) {
						FocusChanged (this[selectedControl],null);
					}
					flag = false;
				}

			} while (flag && (currentControl != selectedControl));
			this [selectedControl].HasFocus = true;

		}


	}
}
