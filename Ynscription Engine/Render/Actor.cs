using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using YnscriptionEngine.Render;
using YnscriptionEngine.ComponentData;


namespace YnscriptionEngine.Render {
	public class Actor {

		private Model model;
		private Entity entity;

		public Model Model {
			get {return model;}
			set {model = value;}
		}
		public Vector3 Position {
			get {return entity.Position;}
			set {entity.Position = value;}
		}
		public Vector3 Rotation {
			get {return entity.Rotation;}
			set {entity.Rotation = value;}
		}

		public Vector3 ActorColor {
			get {return entity.BeingColor;}
			set { entity.BeingColor = value; }
		}

		public Entity Being {
			get {return entity;}
			set {entity = value;}
		}

		public Actor (Vector3 p, Vector3 r) {
			Model = null;
			Being = new Dummy ();
			Position = p;
			Rotation = r;			
		}

		public Actor (Vector3 p, Vector3 r, Vector3 c) {
			Model = null;
			Being = new Dummy (); //TODO maybe this could be a light class instead of a dummy
			Position = p;
			Rotation = r;
			ActorColor = c;
		}

		public Actor (Model m, Entity b, Vector3 c, Vector3 p, Vector3 r) {
			Model = m;
			Being = b;
			ActorColor = c;
			Position = p;
			Rotation = r;
			foreach (ModelMesh mesh in model.Meshes) {
				foreach (BasicEffect effect in mesh.Effects) {
					effect.DiffuseColor = ActorColor;
					effect.EnableDefaultLighting();
					effect.LightingEnabled = true;
					effect.AmbientLightColor = new Vector3 (0.3f, 0.3f, 0.3f);
					
				}
			}
		}

		public virtual void LoadContent (ContentManager Content) {

		}
		
		public void update (GameTime gameTime) {
			if (Being != null) {
				Being.update(gameTime);
			}
		}

		public virtual void draw (Matrix world, Camera camera) {
			if (model != null) {
				
				Matrix projection = camera.Projection;
				Matrix view = camera.View;

				foreach (ModelMesh mesh in model.Meshes) {
					foreach (BasicEffect effect in mesh.Effects) {
						//TODO see how we can do stuff with the lights
						effect.World = world * Matrix.CreateTranslation (Position) * Matrix.CreateRotationX (Rotation.X) * Matrix.CreateRotationY (Rotation.Y) * Matrix.CreateRotationZ (Rotation.Z);
						effect.Projection = projection;
						effect.View = view;
					}

					mesh.Draw ();
				}
			}
		}


	}
}
