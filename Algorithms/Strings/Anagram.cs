﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Strings;

public class Anagram
{

	/*
	* determine minimum no.of character changes required to make left half and right half of given string anagrams
	*/
	public static int anagram(string s)
	{
		if (s.Length % 2 == 1)
		{
			return -1;
		}

		string left = s.Substring(0, s.Length / 2), right = s.Substring(s.Length / 2);
		var leftHash = hashMap(left);
		var rightHash = hashMap(right);

		int result = 0;


		foreach (var item in leftHash)
		{
			if (rightHash.ContainsKey(item.Key) && leftHash[item.Key] > rightHash[item.Key])
			{
				result += leftHash[item.Key] - rightHash[item.Key];
			}
			else if(!rightHash.ContainsKey(item.Key))
			{
				result += leftHash[item.Key];
			}
		}

		return result;
	}

	private static Dictionary<char, int> hashMap(string theS)
	{
		var hash = new Dictionary<char, int>();

		foreach (var c in theS)
		{
			if (hash.ContainsKey(c))
			{
				hash[c]++;
			}
			else
			{
				hash.Add(c, 1);
			}
		}

		return hash;
	}

/*
6
aaabbb
ab
abc
mnop
xyyx
xaxbbbxx
*/

	//public static void Main(string[] args)
	//{
	//	int q = Convert.ToInt32(Console.ReadLine().Trim());

	//	for (int qItr = 0; qItr < q; qItr++)
	//	{
	//		string s = Console.ReadLine();

	//		int result = Anagram.anagram(s);

	//		Console.WriteLine(result);
	//	}

	//	Console.Read();
	//}

}
