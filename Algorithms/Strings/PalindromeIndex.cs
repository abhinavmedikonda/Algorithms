using System;


namespace Algorithms.Strings;

public class PalindromeIndex
{

	/*
	* find the index removing which string will be a palindrome.
	*/

	public static int palindromeIndex(string s)
	{
		for (int i = 0, j = s.Length - 1; i < j; i++, j--)
		{
			if (s[i] != s[j])
			{
				if (isPalindrome(s.Remove(i, 1)))
				{
					return i;
				}
				if (isPalindrome(s.Remove(j, 1)))
				{
					return j;
				}

				return -1;
			}
		}

		return -1;
	}

	private static bool isPalindrome(string s)
	{
		for (int i = 0, j = s.Length - 1; i < j; i++, j--)
		{
			if (s[i] != s[j])
			{
				return false;
			}
		}

		return true;
	}

/*
3
aaab
baa
aaa
*/

	//public static void Main(string[] args)
	//{
	//	int q = Convert.ToInt32(Console.ReadLine().Trim());

	//	for (int qItr = 0; qItr < q; qItr++)
	//	{
	//		string s = Console.ReadLine();

	//		int result = PalindromeIndex.palindromeIndex(s);

	//		Console.WriteLine(result);
	//	}

	//	Console.Read();
	//}

}
