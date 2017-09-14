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
using YnscriptionEngine.GameStates;

namespace YnscriptionEngine {
	public abstract class YGame : Game{
		public SpriteBatch spriteBatch;

		public int screenWidth = 1024;
		public int screenHeight = 768;

		public Dictionary<string, BaseGameState> gameScreens; 

		public Rectangle ScreenRectangle;

		public YGame () :base(){
			gameScreens = new Dictionary<string,BaseGameState> ();
		}

		protected override void Initialize () {
			base.Initialize ();
		}

		protected override void LoadContent () {
			base.LoadContent ();
		}

		protected override void Update (GameTime gameTime) {
			base.Update (gameTime);
		}


		protected override void Draw (GameTime gameTime) {
			base.Draw (gameTime);
		}

	}
}
