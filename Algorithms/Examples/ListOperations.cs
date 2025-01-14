using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Examples;

public class ListOperations
{

	private static void Start(){
		var list = new List<int>{8, 5, 9};
		list.AddRange(new List<int>{3, 7, 1}); //add list to existing list
		var newList = list.Concat(new List<int>{3, 7, 1}); //to return new list
		list.Remove(8); //remove element
		list.RemoveAll(x => x>10); //remove all matching
		var index = list.FindIndex(x => x == 8);
		if(index >= 0) list.RemoveAt(index); //remove element at index
		list.Clear(); //remove everything

		var elems1 = yield1();
		foreach(var elem in elems1)
		{
			Console.WriteLine( "Got " + elem );
		}

		var elems2 = yield2();
		foreach(var elem in elems2)
		{
			Console.WriteLine( "Got " + elem );
		}
	}

	private static IEnumerable<int> yield1()
	{
		Console.WriteLine("Returning 1");
		yield return 1;
		Console.WriteLine("Returning 2");
		yield return 2;
		Console.WriteLine("Returning 3");
		yield return 3;
	}

	private static IEnumerable<int> yield2()
	{
		for(int i=1; i<4; i++){
			Console.WriteLine($"Returning {i}");
			yield return i;
		}
	}

	// public static void Main(string[] args){
	// 	 Start();
	// }

}
