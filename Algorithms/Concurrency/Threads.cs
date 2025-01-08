using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Algorithms.Concurrency;

public class Threads
{

	private static void RawApproach(object o){
        var n = o as int?;
        if(n == null){
            return;
        }

		for(int i=0; i<n; i++){
			Console.WriteLine($"raw child: {i}");
			Console.WriteLine($"raw child: {Thread.CurrentThread.ManagedThreadId}");
			SudokuSolver.printBoard(SudokuSolver.GetSolution(SudokuSolver.GetBoard()));
		}
	}

    private static void TypeSafeApproach(int n){
		for(int i=0; i<n; i++){
			Console.WriteLine($"typeSafe child: {i}");
			Console.WriteLine($"typeSafe child: {Thread.CurrentThread}");
			Thread.Sleep(1000);
		}
	}

	private static void Start(){
		var n = 3;
        for(int i=0; i<n; i++){
			Console.WriteLine($"main start: {i}");
			Thread.Sleep(1000);
		}

		var t1 = new Thread(RawApproach);
		t1.Start(n);
        // t1.Join();

        var t2 = new Thread(() => TypeSafeApproach(n));
        t2.Start();
        // t2.Join();

        while(true){
			ThreadPool.GetAvailableThreads(out int wts, out int cpts);
			Console.WriteLine($"     available threads: {wts}, {cpts}");
			Console.WriteLine($"         threads count: {Process.GetCurrentProcess().Threads.Count}");
			Console.WriteLine($"ThreadPool ThreadCount: {ThreadPool.ThreadCount}");
			Console.WriteLine($"       ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
			
			Thread.Sleep(1000);
		}
	}

	// public static void Main(string[] args){
    //     Start();
	// }

}
