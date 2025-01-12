using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Concurrency;

public class Tasks
{

	private static async Task t123456789(Stopwatch st){
		var start = st.Elapsed.Seconds;
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t123456789)} start");
        var v12345 = t12345(st);
		var v6789 = t6789(st);
		await Task.WhenAll(v12345, v6789);
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t123456789)}: {st.Elapsed.Seconds-start}seconds");
	}

	private static async Task t12345(Stopwatch st){
		Stopwatch stopwatch = new();
		stopwatch.Start();
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t12345)} start");
		await t1(st);
		var v234 = t234(st);
		var v5 = t5(st);
		await Task.WhenAll(v234, v5);
        await Task.Delay(5000);
		stopwatch.Stop();
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t12345)}: {stopwatch.Elapsed.Seconds}seconds");
	}

	private static async Task t1(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t1)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t1)} done");
	}

	private static async Task t234(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t234)} start");
		await Task.WhenAll(t2(st), t3(st), t4(st));
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t234)} done");
	}

	private static async Task t2(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t2)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t2)} done");
	}

	private static async Task t3(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t3)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t3)} done");
	}

	private static async Task t4(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t4)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t4)} done");
	}

	private static async Task t5(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t5)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t5)} done");
	}

	private static async Task t6789(Stopwatch st){
		Stopwatch stopwatch = new();
		stopwatch.Start();
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t6789)} start");
		await Task.WhenAll(t6(st), t7(st), t8(st), t9(st));
        await Task.Delay(5000);
		stopwatch.Stop();
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t6789)}: {stopwatch.Elapsed.Seconds}seconds");
	}

	private static async Task t6(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t6)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t6)} done");
	}

	private static async Task t7(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t7)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t7)} done");
	}

	private static async Task t8(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t8)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t8)} done");
	}

	private static async Task t9(Stopwatch st){
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t9)} start");
        await Task.Delay(5000);
		Console.WriteLine($"{st.Elapsed.Seconds}: {nameof(t9)} done");
	}

	private static async Task Start(){
		try
		{
			Stopwatch st = new();
			st.Start();
			await t123456789(st);
		}
		catch (System.Exception e)
		{
			Console.WriteLine($"{e.Message}");
			throw;
		}
	}

	// public static async Task Main(string[] args){
    //     await Start();
	// }

}
