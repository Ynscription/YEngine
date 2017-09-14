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

namespace YnscriptionEngine.GameStates {
	public abstract partial class GameState : DrawableGameComponent{
		List <GameComponent> childComponents;

		public List<GameComponent> Components {
			get {return childComponents;}
		}

		GameState tag;

		public GameState Tag {
			get {return tag;}
		}

		protected GameStateManager StateManager;


		public GameState (Game game, GameStateManager manager) : base (game){
			StateManager = manager;
			childComponents = new List<GameComponent> ();
			tag = this;
		}


		public override void Initialize () {
			base.Initialize ();
		}

		public override void Update (GameTime gameTime) {
			foreach (GameComponent c in childComponents) {
				if (c.Enabled) {
					c.Update(gameTime);
				}
			}
			base.Update (gameTime);
		}


		public override void Draw (GameTime gameTime) {
			foreach (GameComponent c in childComponents) {
				if (c is DrawableGameComponent) {
					if (((DrawableGameComponent)c).Visible) {
						((DrawableGameComponent)c).Draw (gameTime);
					}
				}

			}

			base.Draw (gameTime);
		}


		internal protected virtual void StateChange (object sender, EventArgs e) {
			if (StateManager.CurrentState == Tag) {
				Show ();
			}else {
				Hide ();
			}
		}

		protected virtual void Show () {
			Visible = true;
			Enabled = true;
			foreach (GameComponent c in childComponents) {
				c.Enabled = true;
				if (c is DrawableGameComponent) {
					((DrawableGameComponent)c).Visible = true;
				}
			}
		}

		protected virtual void Hide () {
			Visible = false;
			Enabled = false;
			foreach (GameComponent c in childComponents) {
				c.Enabled = false;
				if (c is DrawableGameComponent) {
					((DrawableGameComponent) c).Visible = false;
				}
			}
		}




	}
}
