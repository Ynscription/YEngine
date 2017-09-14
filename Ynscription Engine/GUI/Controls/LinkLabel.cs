using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YnscriptionEngine.Input;


namespace YnscriptionEngine.GUI.Controls {
	public class LinkLabel : Label{
		Color selecetedColor = Color.Red;

		public Color SelectedColor {
			get {return selecetedColor;}
			set {selecetedColor = value;}
		}

		public LinkLabel () :base (){
			TabStop = true;
			HasFocus = false;
			Position = Vector2.Zero;
		}


		public override void Update (GameTime gameTime) {
			
		}

		public override void HandleInput () {
			if (!hasFocus) {
				return;
			}
			if (KeyBoardHandler.KeyReleased (Keys.Enter)) {
				base.OnSelected (null);
			}
		}
		public override void Draw (SpriteBatch spriteBatch) {
			base.Draw(spriteBatch);
		}

	}
}
