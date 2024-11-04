using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Tree
{
	public class PreOrderTree {
		public static BTree fromArray(List<int> pre, List<char> preLN){
			var returns = new BTree{value = pre[0]};
			var node = returns;
			var stack = new Stack<BTree>();
			stack.Push(node);

			for(int i=1; i<pre.Count; i++){
				if(preLN[i] == 'n'){
					if(node.left == null){
						node.left = new BTree{ value = pre[i]};
						node = node.left;
						stack.Push(node);
					}
					else{
						node.right = new BTree{ value = pre[i]};
						node = node.right;
						stack.Push(node);
					}
				}
				else if(node.left == null){
					node.left = new BTree{ value = pre[i]};
				}
				else if(node.right == null){
					node.right = new BTree{ value = pre[i]};
					stack.Pop();
					node = stack.Count>0 ? stack.Peek() : null;
				}
			}

			return returns;
		}

/*
5
3 5 2 7 4
n l n l l
*/

		// public static void Main(string[] args){
		// 	var n = int.Parse(Console.ReadLine());
		// 	var pre = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
		// 	var preLN = Console.ReadLine().Split(' ').ToList().Select(x => char.Parse(x)).ToList();
			
		// 	BTree.preOrder(fromArray(pre, preLN));

		// 	Console.Read();
		// }
	}
}
