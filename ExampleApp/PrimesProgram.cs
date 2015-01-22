using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using System.IO;

namespace ExampleApp
{

	class MainClass
	{
		public static void Main (string[] args) {
			string currentLine;
			long currentNumber;
			if (args.Length < 1) {
				Console.Error.WriteLine ("Please provide the input file name.");
				return;
			}
			var primes = new Primes();
			using (var fstream = new FileInfo(args[0]).OpenText()) {
				while(!fstream.EndOfStream) {
					currentLine = fstream.ReadLine();
					if (long.TryParse(currentLine, out currentNumber)) {
						Console.WriteLine(String.Join (",", primes.FactorsOf(currentNumber)));
					}
				}
			}
		}
	}



}
