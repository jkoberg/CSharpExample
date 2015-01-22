using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ExampleApp
{
	// Wer're going to assume that your single-linked list of integers implements IEnumerable,
	// Because IEnumerable means something that can be traversed once, and doesn't imply bounded size.

	static class EnumerableWindowingExtensions {
		public static T NthFromEnd<T>(this IEnumerable<T> items, int n) {
			T lastT;
			var queue = new Queue<T>(n);
			var enumerator = items.GetEnumerator();

			for(var i=0; i < n; i++) {
				if (enumerator.MoveNext()) {
					queue.Enqueue (enumerator.Current);
				} else {
					throw new ArgumentException ("Not enough items");
				}
			}

			lastT = queue.Dequeue ();

			while(enumerator.MoveNext()) {
				queue.Enqueue(enumerator.Current);
				lastT = queue.Dequeue ();
			}

			return lastT;
		}

	}


	// System.Collections.Generic.LinkedList is almost certainly not a singly-linked list,
	// as evidenced by having both AddBefore and AddAfter methods, but oh well. 
	class EnumerableWindowingTests {

		[Test]
		public void TestThrowsExceptionWhenListTooShort() {
			var list = new LinkedList<int>(); 
			list.AddLast (10);
			list.AddLast (20);
			list.AddLast (30);
			list.AddLast (40);
			Assert.Throws<ArgumentException> (() => {
				list.NthFromEnd (5);
			});
		}

		[Test]
		public void ReturnsNthItemBeforeEnd() {
			var list = new LinkedList<int>();
			list.AddLast (10);
			list.AddLast (20);
			list.AddLast (30);
			list.AddLast (40);
			list.AddLast (50);
			list.AddLast (60);
			var item = list.NthFromEnd(5);
			Assert.AreEqual(20, item);
		}
	}
}

