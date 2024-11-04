using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.StringBuilders;

class HighestValuePalindrome
{

	/// <summary>
	/// given a string representation of a number(s) and a maximum number of changes you can make(k).
	/// Alter the string, one digit at a time, to create the string representation of the largest number possible
	/// </summary>

	public static string highestValuePalindrome(string s, int n, int k)
	{
		var difference = 0;
		
		for (int i=0; i<s.Length/2; i++){
			if(s[i] != s[s.Length-i-1]){
				difference++;
			}
		}
		
		var extra = k-difference;
		if(extra < 0){
			return "-1";
		}
		
		var sb = new StringBuilder(s);
		var oddFlag = sb.Length%2 == 1 && sb[sb.Length/2] != 9;
		for(int i=0; i<sb.Length/2; i++){
			if(sb[i] == sb[sb.Length-i-1]){
				if(sb[i] == '9' || extra < 2){
					continue;
				}

				extra -= 2;
				sb[i] = '9';
				sb[sb.Length-i-1] = '9';
			}
			if(sb[i] != sb[sb.Length-i-1]){
				if(sb[sb.Length-i-1] == '9'){
					sb[i] = '9';
				}
				else if(sb[i] == '9'){
					sb[sb.Length-i-1] = '9';
				}
				else if(extra > 0){
					extra -= 1;
					sb[i] = '9';
					sb[sb.Length-i-1] = '9';
				}
				else if(extra == 0){
					sb[i] = sb[i] > sb[sb.Length-i-1] ? sb[i] : sb[sb.Length-i-1];
					sb[sb.Length-i-1] = sb[i] > sb[sb.Length-i-1] ? sb[i] : sb[sb.Length-i-1];
				}
			}
		}
		
		if(sb.Length%2 == 1 && sb[sb.Length/2] != 9 && extra > 0){
			sb[sb.Length/2] = '9';
		}
		
		return sb.ToString();
	}

/*
6 3
092282
*/

	// public static void Main(string[] args)
	// {
	//	 string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

	//	 int n = Convert.ToInt32(firstMultipleInput[0]);

	//	 int k = Convert.ToInt32(firstMultipleInput[1]);

	//	 string s = Console.ReadLine();

	//	 string result = HighestValuePalindrome.highestValuePalindrome(s, n, k);

	//	 Console.WriteLine(result);

	//	 Console.Read();
	// }
}
