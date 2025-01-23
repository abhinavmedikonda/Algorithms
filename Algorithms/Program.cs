using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms;

// dotnet run --project ./algorithms

class cTree{
    public char value;
    public List<cTree> children = new();
}

class Result
{
	public static void noPrefix(List<string> words)
    {
        cTree tree = new();
        addString(tree, words[0]);
        foreach(var item in words.Skip(1)){
            if(isPrefixString(tree, item)){
                Console.WriteLine("BAD SET");
                Console.WriteLine(item);
                return;
            }
        }

        Console.WriteLine("GOOD SET");
    }
    
    private static bool isPrefixString(cTree tree, string s){
        if(s.Length == 0 || tree.children.Count == 0){
            return true;
        }
        
        foreach(var item in tree.children){
            if(s[0] == item.value){
                return isPrefixString(item, s.Substring(1));
            }
        }
        
        addString(tree, s);
        return false;
    }
    
    private static void addString(cTree tree, string s){
        foreach(var item in s){
			cTree next = new(){value = item};
            tree.children.Add(next);
            tree = next;
        }
    }
}

class Solution
{

/*
7
aab
defgab
abcde
aabcde
cedaaa
bbbbbbbbbb
jabjjjad
*/
	// public static void Main(string[] args)
    // {
    //     int n = Convert.ToInt32(Console.ReadLine().Trim());

    //     List<string> words = new List<string>();

    //     for (int i = 0; i < n; i++)
    //     {
    //         string wordsItem = Console.ReadLine();
    //         words.Add(wordsItem);
    //     }

    //     Result.noPrefix(words);
    // }
}