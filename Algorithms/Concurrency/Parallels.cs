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
		ParallelOptions parallelOptions = new();
		parallelOptions.MaxDegreeOfParallelism = 15;
		Console.WriteLine($"MaxDegreeOfParallelism: {parallelOptions.MaxDegreeOfParallelism}");

		var rnd = new Random();
        int breakIndex = rnd.Next(1, 11);

        Console.WriteLine($"Will call Break at iteration {breakIndex}\n");

        var result = Parallel.For(1, 101, parallelOptions, (i, state) => 
        {
            Console.WriteLine($"Beginning iteration {i}");
            int delay;
            lock (rnd)
                delay = rnd.Next(1, 1001);
            Thread.Sleep(delay);

            if (state.ShouldExitCurrentIteration)
            {
                if (state.LowestBreakIteration < i){
		            Console.WriteLine($"returns in iteration {i}, delay: {delay}");
                    return;
				}
            }

            if (i == breakIndex)
            {
                Console.WriteLine($"Break in iteration {i}");
                state.Break();
            }

            Console.WriteLine($"Completed iteration {i}, delay: {delay}");
        });

        if (result.LowestBreakIteration.HasValue)
            Console.WriteLine($"\nLowest Break Iteration: {result.LowestBreakIteration}");
        else
            Console.WriteLine($"\nNo lowest break iteration.");

		Console.WriteLine();
		Parallel.For(0, 15, parallelOptions, (i, loopState) => {
			if(i == 3){
				loopState.Break();
			}

			if(loopState.ShouldExitCurrentIteration){
				Console.WriteLine("true");
			}
			if(!loopState.ShouldExitCurrentIteration || loopState.LowestBreakIteration < i){
				SudokuSolver.printBoard(SudokuSolver.GetSolution(SudokuSolver.GetBoard()));
				Console.WriteLine(i);
			}
		});

		var s = "Executes a foreach (For Each in Visual Basic) operation in which iterations may run in parallel";
		Console.WriteLine();
		Parallel.ForEach(s, (c, loopState, l) => {
			if(l == breakIndex){
				loopState.Stop();
			}

			if(!loopState.IsStopped){
				Console.Write(c);
			}
		});
	}

	// public static void Main(string[] args){
    //     Start();
	// }

}
