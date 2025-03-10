﻿using System;
using System.Collections.Generic;

namespace Algorithms.Recursion;

public class TwoPowerGame
{

	/// <summary>
	/// check to see if it is a power of 2. If it is, they divide it by 2.
	///	If not, they reduce it by the next lower number which is a power of 2.
	///	Whoever reduces the number to 1 wins the game. Louise always starts
	/// </summary>
	public static string counterGame(long n)
	{
		var stack = new Stack<long>(new List<long>{2L});
		while(n >= stack.Peek()){
			Console.WriteLine(stack.Peek());
			stack.Push(stack.Peek()*2);
		}
		
		var counter = 0;
		
		while(n > 1){
			var item = stack.Pop();
			if(item > n){
				continue;
			}
			else if(item == n){
				n /= 2;
			}
			else{
				n -= item;
			}
			
			counter++;
		}
		
		return counter%2 == 0 ? "Richard" : "Louise";

		// int totalTurns = 0;
		// long twoSquares = 1;

		// while (twoSquares < n)
		// {
		//	 twoSquares *= 2;
		// }

		// while (n > 1)
		// {
		//	 totalTurns++;

		//	 if (n == twoSquares)
		//	 {
		//		 n /= 2;
		//		 twoSquares /= 2;
		//	 }
		//	 else
		//	 {
		//		 while (twoSquares >= n)
		//		 {
		//			 twoSquares /= 2;
		//		 }

		//		 n -= twoSquares;
		//	 }

		// }

		// return totalTurns % 2 == 0 ? "Richard" : "Louise";
	}

	//static Dictionary<int, long> hash = new Dictionary<int, long> { { 1, 2 } };

	//public static string twoPowerGame(long n)
	//{
	//	bool player1 = false;

	//	while (n != 1)
	//	{
	//		if (maxTwoPowerIn(n) == n)
	//		{
	//			n /= 2;
	//		}
	//		else
	//		{
	//			n -= maxTwoPowerIn(n);
	//		}

	//		player1 = !player1;
	//	}

	//	return player1 ? "Louise" : "Richard";
	//}

	//private static long maxTwoPowerIn(long n)
	//{
	//	int highPower = 2;

	//	while (twoPower(highPower) < n)
	//	{
	//		highPower *= 2;
	//	}

	//	int lowPower = highPower / 2, power = (lowPower + highPower) / 2;

	//	while (twoPower(power) != n)
	//	{
	//		if (highPower - lowPower == 1)
	//		{
	//			return twoPower(highPower) == n ? n : twoPower(lowPower);
	//		}

	//		if (twoPower(power) > n)
	//		{
	//			highPower = power;
	//		}
	//		else
	//		{
	//			lowPower = power;
	//		}

	//		power = (lowPower + highPower) / 2;
	//	}

	//	return n;
	//}

	//private static long twoPower(int power)
	//{
	//	if (hash.ContainsKey(power))
	//	{
	//		return hash[power];
	//	}
	//	else
	//	{
	//		hash.Add(power, twoPower(power / 2) * twoPower(power / 2) * (power % 2 == 0 ? 1 : 2));
	//		return twoPower(power);
	//	}
	//}

/*
2
6
132
*/

	//public static void Main(string[] args)
	//{
	//	int t = Convert.ToInt32(Console.ReadLine().Trim());

	//	for (int tItr = 0; tItr < t; tItr++)
	//	{
	//		long n = Convert.ToInt64(Console.ReadLine().Trim());

	//		string result = TwoPowerGame.counterGame(n);

	//		Console.WriteLine(result);
	//	}

	//	Console.Read();
	//}
}
