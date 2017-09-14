using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace YnscriptionEngine.ComponentData {
	public abstract class Entity {

		protected Vector3 position;
		protected Vector3 rotation;
		protected Vector3 beingColor;

		public Vector3 Position {
			get {return position;}
			set {position = value;}
		}

		public Vector3 Rotation {
			get { return rotation; }
			set { rotation = value; }
		}
		public Vector3 BeingColor {
			get { return beingColor; }
			set { beingColor = value; }
		}

		public abstract void update (GameTime gameTime);

	}
}
