using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ExampleApp
{
	class Primes : List<long> {
		public Primes() : base() {
			this.Add (2); // start off with a base case of the first prime.
		}

		private void ExtendTo(long upperBound)  {
			// Sieve the numbers between our last item and the bound, adding all the primes found.
			for (long candidate = this.Last() + 1; candidate <= upperBound; candidate++) {
				if (this.Any ((prime) => candidate % prime == 0)) {
					// If any prime divides this candidate, it's composite. Try the next one.
					continue;
				} else {
					// It's prime. Keep it.
					this.Add(candidate);
				}
			}
		}

		public IEnumerable<long> FactorsOf(long number) {
			ExtendTo(number); // Make sure all possible divisors are present.
			foreach (var p in this) {
				if (number % p == 0) {
					yield return p;
					foreach (var more in FactorsOf(number/p)) {
						yield return more;
					}
					break;
				}
			}
		}
	}


	class PrimesTests {

		private long MultiplyAll(IEnumerable<long> factors) {
			return factors.Aggregate ((long)1, (runningProduct, nextFactor) => runningProduct * nextFactor);
		}

		[Test]
		public void FactorizationTest() {

			var p = new Primes();

			var factors = new List<long>{ 2, 2, 5, 11, 53 };
			long candidate = MultiplyAll(factors);

			var computedFactors = p.FactorsOf(candidate).ToList();
			var pairs = computedFactors.Zip(factors, (a,b) => new Tuple<long,long>(a,b));
			Assert.That (pairs.All ((pair) => pair.Item1 == pair.Item2));

		}
	}
}



