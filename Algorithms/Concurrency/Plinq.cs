using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Concurrency;

public class Plinq
{

	private static void Start(){
		Stopwatch sw = new();
		sw.Start();
		var result = Enumerable.Range(0, 1000)
			.Select(x => {Utils.Compute(5); return x;})
			.Sum();
		sw.Stop();
		Console.WriteLine($"  no parallel: {result}: {sw.Elapsed.Milliseconds}ms");
		sw.Reset();
		sw.Start();
		result = Enumerable.Range(0, 1000)
			.AsParallel()
			.Select(x => {Utils.Compute(5); return x;})
			.Sum();
		sw.Stop();
		Console.WriteLine($"with parallel: {result}: {sw.Elapsed.Milliseconds}ms");
	}

	// public static void Main(string[] args){
    //     Start();
	// }

}
