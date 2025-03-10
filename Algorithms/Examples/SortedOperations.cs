﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Examples;

public class SortedOperations
{
	private static void Start(){
		var list = new List<int>{8, 5, 9};

		// customize sortedList sort logic
		var desc = Comparer<int>.Create((a, b) => a < b ? 1 : -1);
		var sList = new SortedList<int, int>(desc);
		foreach(var item in list){
			if(sList.ContainsKey(item)){
				sList[item]++;
			}
			else{
				sList.Add(item, 1);
			}
		}

		Console.WriteLine(sList.First().Value);
		sList.Remove(sList.First().Key);
		sList[sList.First().Key]--;

		var sSet = new SortedSet<int>(list);
		Console.WriteLine(sSet.First());
		sSet.Remove(sSet.First());

		// sort list by custom logic
		list.Sort((a, b) => a > b ? 1 : -1);

		Console.Read();
	}

	// public static void Main(string[] args){
	// 	 Start();
	// }
}
