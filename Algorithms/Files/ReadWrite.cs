using System;
using System.IO;
using System.Linq;

namespace Algorithms.Files
{
	public class ReadWrite
	{
		private static void ReadWriteFile(){
			Console.WriteLine(Environment.CurrentDirectory);
			string[] lines = File.ReadAllLines("abc.txt");//reads from current directory if path is not given
			foreach (var item in lines)
			{
				var words = item.Trim().Split(' ');
				Console.WriteLine(words[words.Length-1]);
			}
			File.WriteAllLines("xyz.txt", lines);
			string text = File.ReadAllText("/Users/abhi/Projects/Algorithms/Algorithms/bin/Debug/netcoreapp3.1/abc.txt");
			File.WriteAllText("xyz.txt", text);

			Console.WriteLine($"test{Environment.NewLine}it");

			Console.Read();
		}

		// public static void Main(string[] args)
		// {
		//	 ReadWriteFile();
		// }
	}
}
