using System;
using NUnit.Framework;

namespace ExampleApp
{
	enum TriangleCategory {Isosocles, Eqilateral, Scalene};

	class Triangle {

		public readonly int a, b, c;

		public Triangle(int a, int b, int c) {
			this.a = a;
			this.b = b;
			this.c = c;
		}

		public TriangleCategory Category {
			get {
				if (a == b && b == c) {
					// then all sides are equal
					return TriangleCategory.Eqilateral;
				}
				if (a == b || b == c || c == a) {
					// Then two sides are equal
					return TriangleCategory.Isosocles;
				}
				// No equal sides
				return TriangleCategory.Scalene;
			}
		}
	}


	class TriangleTests {

		[Test] 
		public void CategorizesEquilateral() {
			var t = new Triangle (10, 10, 10);
			Assert.AreEqual(TriangleCategory.Eqilateral, t.Category);
		}

		[Test] 
		public void CategorizesIsosocles() {
			var t = new Triangle (20, 20, 10);
			Assert.AreEqual(TriangleCategory.Isosocles, t.Category);
		}

		[Test] 
		public void CategorizesScalene() {
			var t = new Triangle (10, 20, 30);
			Assert.AreEqual(TriangleCategory.Scalene, t.Category);
		}
	}

}

