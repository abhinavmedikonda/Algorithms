using System;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Concurrency;

public class Parallels
{

	private static async Task Start(){
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
		Console.WriteLine($"T: {Thread.CurrentThread.ManagedThreadId}");
		Parallel.Invoke([
			() => {
				Console.WriteLine($"T1: {Thread.CurrentThread.ManagedThreadId}");
				Utils.Compute(100);
			},
			() => {
				Console.WriteLine($"T2: {Thread.CurrentThread.ManagedThreadId}");
				Utils.RandomCompute();
			}
		]);

		Console.WriteLine();
		await Task.Run(() => { // Task.Run starts new thread
			Parallel.For(0, 15, parallelOptions, (i, loopState) => {
				if(i == breakIndex){
					loopState.Break();
					Console.WriteLine($"break iteration: {i}");
				}

				if(loopState.ShouldExitCurrentIteration && loopState.LowestBreakIteration < i){
					Console.WriteLine($"exit iteration: {i}");
					return;
				}

				SudokuSolver.printBoard(SudokuSolver.GetSolution(SudokuSolver.GetBoard()));
				Console.WriteLine(i);
			});
		});

		var s = "Parallel.ForEach executes a foreach operation in which iterations may run in parallel";
		Console.WriteLine();
		await Task.Run(() => {
			Parallel.ForEach(s, (c, loopState, l) => {
				if(l == breakIndex){
					loopState.Stop();
				}

				if(!loopState.IsStopped){
					Console.Write(c);
				}
			});
		});
	}

	// public static async Task Main(string[] args){
	// 	await Start();
	// }

}
