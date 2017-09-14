using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace YnscriptionEngine.Utils.DataStructures {
	public class Tree <T> {

		private T value;

		public T Value {
			get {return value;}
			set {this.value = value;}
		}

		private LinkedList<Tree<T>> children;


		public LinkedList<Tree<T>> Children {
			get {return children;}
		}

		public Tree () {
			children = new LinkedList<Tree<T>> ();
		}

		public Tree (T v) {
			value = v;
			children = new LinkedList<Tree<T>> ();
		}
		
		public void addChild (Tree<T> child) {
			children.AddLast (child);
		}

		public void removeChild (Tree<T> child) {
			children.Remove (child);
		}

		public Tree <T> findValue (T vtofind) {
			if (value.Equals (vtofind)) {
				return this;
			}else {
				if (children.Count == 0) {
					return null;
				}else {
					Tree<T> r = null;
					foreach (Tree<T> tree in children) {
						r = tree.findValue (vtofind);
						if (r != null) {
							return r;
						}
					}
					return r;
				}
			}
		}


	}
}
