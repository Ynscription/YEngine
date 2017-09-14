using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YnscriptionEngine.Utils.DataStructures;

namespace YnscriptionEngine.Render {
	public class Scene  : DrawableGameComponent{

		private Camera camera; 
		private Tree <Actor> actors;
		private List<Actor> Lights;

		public Scene (Game game, Camera cam) : base (game){
			actors = new Tree<Actor> ();
			Lights = new List<Actor> ();
			camera = cam;
		}

		public void addActor (Actor actor) {
			actors.Value = actor;
		}

		public void addActor (Actor parent, Actor actor) {
			if (parent == null) {
				actors.Value = actor;
			}else {
				Tree<Actor> tree = actors.findValue(parent);
				tree.addChild (new Tree<Actor> (actor));
			}
		}

		public void addLight (Actor parent, Actor light) {
			Tree<Actor> tree = actors.findValue (parent);
			tree.addChild (new Tree<Actor> (light));
			Lights.Add (light);
		}

		protected override void LoadContent () {
			base.LoadContent ();
		}


		public override void Update (GameTime gameTime) {
			base.Update (gameTime);
			camera.update();
			updateChildren (actors, gameTime);

		}

		
		private void updateChildren (Tree<Actor> tree, GameTime gameTime) {
			tree.Value.update (gameTime);
			foreach (Tree<Actor> t in tree.Children) {
				updateChildren (t, gameTime);
			}
		}


		public override void Draw (GameTime gameTime) {
			base.Draw (gameTime);
			GraphicsDevice.DepthStencilState = new DepthStencilState () { DepthBufferEnable = true };
			drawTree (actors,Matrix.CreateTranslation (0,0,0), Lights);
		}

		private void drawTree (Tree<Actor> tree, Matrix world, List<Actor> lights) {
			world = world * Matrix.CreateTranslation (tree.Value.Position);
			tree.Value.draw (world, camera);
			foreach (Tree<Actor> t in tree.Children) {
				drawTree (t,world,lights);
			}
		}




	}
}
