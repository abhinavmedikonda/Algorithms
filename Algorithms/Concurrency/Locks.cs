using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Concurrency;

public class Locks
{

	private static void Start(){
		var sum = 0;
		for(int i=0; i<1000; i++){
			sum += i;
		}

		Console.WriteLine($"      sum: {sum}");

		sum = 0;
		Parallel.For(1, 1000, (i) => {
			Utils.RandomCompute();
			sum += i;
		});

		Console.WriteLine($"  no lock: {sum}");

		var syncRoot = new object();
		sum = 0;
		Parallel.For(1, 1000, (i) => {
			Utils.RandomCompute();
			lock(syncRoot){
				sum += i;
			}
		});

		Console.WriteLine($"with lock: {sum}");
	}

	// public static void Main(string[] args){
    //     Start();
	// }

}
