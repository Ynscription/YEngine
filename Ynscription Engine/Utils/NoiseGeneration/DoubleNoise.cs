using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YnscriptionEngine.Utils.NoiseGeneration {
	public class DoubleNoise {
		private int seed;

		public DoubleNoise (int s) {
			seed = s;
		}

		public int getValue (int x, int y) {
			int n = (int)x*331 + (int)y*337 + seed;
			n = (n<<17)^n;
			return (n * (n * n * 41333 + 53307781) + 1376312589) & 0x7fffffff;
		}
	}
}
