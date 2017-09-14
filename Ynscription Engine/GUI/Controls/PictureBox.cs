using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YnscriptionEngine.GUI.Controls {
	public class PictureBox :Control{
		Texture2D image;
		Rectangle sourceRect;
		Rectangle destRect;

		public Texture2D Image {
			get {return image;}
			set {image = value;}
		}

		public Rectangle SourceRect {
			get {return sourceRect;}
			set {sourceRect = value; }
		}

		public Rectangle DestRect {
			get { return destRect; }
			set { destRect = value; }
		}

		public PictureBox (Texture2D image, Rectangle destination)
			: base () {
			Image = image;
			DestRect = destination;
			SourceRect = new Rectangle (0,0,image.Width,image.Height);
			Color = Color.White;
		}

		public PictureBox (Texture2D image, Rectangle destination, Rectangle source) :base (){
			Image = image;
			DestRect = destination;
			SourceRect = source;
			Color = Color.White;
		}
		public override void Update (GameTime gameTime) {
			
		}
		public override void Draw (SpriteBatch spriteBatch) {
			spriteBatch.Draw (Image, DestRect, Color);
		}

		public override void HandleInput () {
			
		}

		public void SetPosition (Vector2 newPosition) {
			destRect = new Rectangle ((int)newPosition.X, (int)newPosition.Y, sourceRect.Width, sourceRect.Height);
		}


	}
}
