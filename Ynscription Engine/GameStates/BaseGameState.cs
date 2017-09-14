using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using YnscriptionEngine;
using YnscriptionEngine.GUI.Controls;


namespace YnscriptionEngine.GameStates {
	public abstract partial class BaseGameState :GameState {

		protected YGame GameRef;

		protected ControlManager ControlManager;

		public BaseGameState (Game game, GameStateManager manager) :base (game, manager) {
			GameRef = (YGame)game;
		}

		protected override void LoadContent () {
			ContentManager content = Game.Content;
			SpriteFont menuFont = content.Load<SpriteFont> (@"Fonts\ControlFont");
			ControlManager = new ControlManager (menuFont);
			base.LoadContent ();
		}

		public override void Update (GameTime gameTime) {
			base.Update (gameTime);
		}

		public override void Draw (GameTime gameTime) {
			base.Draw (gameTime);
		}


	}
}
