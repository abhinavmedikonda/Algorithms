using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Concurrency;

public class Parallels
{

	private static void Start(){
		var s = "hello, world";

		foreach (var c in s)
		{
			if(c == ','){
				break;
			}

			Console.Write(c);
		}

		Console.WriteLine();
		Parallel.For(0, s.Length, (i, loopState) => {
			if(s[i] == ','){
				loopState.Break();
			}

			Console.Write(s[i]);
		});

		Console.WriteLine();
		Parallel.ForEach(s, (c, loopState) => {
			if(c == ','){
				loopState.Stop();
			}

			Console.Write(c);
		});
	}

	public static void Main(string[] args){
        Start();
	}

}
