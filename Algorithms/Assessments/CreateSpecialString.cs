using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Assessments;

public class CreateSpecialString
{

	/// <summary>
	/// amazon Code Question 2
	/// Developers at Amazon are working on a text generation utility for one of their new products.
	/// Currently, the utility generates only special strings. A string is special if there are no
	/// matching adjacent characters. Given a string s of length n, generate a special string of length n
	/// that is lexicographically greater than s. If multiple such special strings are possible,
	/// then return the lexicographically smallest string among them.
	/// Notes:
	/// •⁠  ⁠Special String: A string is special if there are no two adjacent characters that are the same.
	/// •⁠  ⁠Lexicographical Order: This is a generalization of the way words are alphabetically ordered in dictionaries. For example, "abc" is lexicographically smaller than "abd" because 'c' comes before 'd' in the alphabet.
	/// A string a is lexicographically smaller than a string b if and only if one of the following holds:
	/// •⁠  ⁠a is a prefix of b, but a is not equal to b. For example, "abc" is smaller than "abed",
	/// •⁠  ⁠In the first position where a and b differ, the character in a comes before the character in b in the alphabet. For example, "abe" is smaller than
	/// "abd" because 'c' comes before 'd'.
	/// </summary>
	private static string NextString(string str)
	{
		// Non-repeating case
		bool hasRepeatingChar = false;
		int repeatingIdx = -1;
		for (int i = 1; i < str.Length; i++)
		{
			if (str[i] == str[i - 1])
			{
				hasRepeatingChar = true;
				repeatingIdx = i;
				break;
			}
		}

		int idx = hasRepeatingChar ? repeatingIdx : str.Length - 1;

		// Traverse until non-first 'z' character
		while (idx >= 0 && str[idx] == 'z') idx--;
		if (idx < 0) return "a" + str;
		else
		{
			// Increment the non-'z' character
			string output = (idx - 1 >= 0) ? str.Substring(0, idx) : "";
			char c = (char)(str[idx] + 1);
			output += c;

			// Append AB pattern until the end
			output += GenerateABStr(str.Length - idx - 1);
			return output;
		}
	}

	private static string GenerateABStr(int len)
	{
		bool isB = false;
		string outStr = "";
		int curr = 0;
		while (curr < len)
		{
			outStr += isB ? 'b' : 'a';
			isB = !isB;
			curr++;
		}
		return outStr;
	}

	// public static void Main(string[] args){
	//	 NextString(""abbd);
	// }

}
