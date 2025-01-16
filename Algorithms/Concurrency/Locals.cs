using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Concurrency;

public class Locals
{

	[ThreadStatic]
	static int threadStatic = 5;
	static int variable;
	static AsyncLocal<int> asyncLocal = new AsyncLocal<int>();
	static ThreadLocal<int> threadLocal = new ThreadLocal<int>(() => 5);

	private static async Task Start(){
		variable = 1;
		asyncLocal.Value = 1;
		threadLocal.Value = 1;
		threadStatic = 1;
		var t1 = Output("t1");

		variable = 2;
		asyncLocal.Value = 2;
		threadLocal.Value = 2;
		threadStatic = 2;
		var t2 = Output("t2");
		await Task.WhenAll(t1, t2);
	}

	static async Task Output(string name)
	{
		await Task.Delay(1000);
		Console.WriteLine($"{name} T={Thread.CurrentThread.ManagedThreadId}: V={variable}, AL={asyncLocal.Value}, TL={threadLocal.Value}, TS={threadStatic}");
		variable = 3;
		asyncLocal.Value = 3;
		threadLocal.Value = 3;
		threadStatic = 3;
		Console.WriteLine($"{name} T={Thread.CurrentThread.ManagedThreadId}: V={variable}, AL={asyncLocal.Value}, TL={threadLocal.Value}, TS={threadStatic}");
	}

	// public static async Task Main(string[] args){
    //     await Start();
	// }

}
