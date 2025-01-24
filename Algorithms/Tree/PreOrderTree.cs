using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace Algorithms.Trees;

public class PreOrderTree {
	// public static BTree fromArray(List<int> pre, List<char> isLeaf){
	// 	var node = new BTree{value = pre[0]};
	// 	var stack = new Stack<BTree>();

	// 	for(int i=1; i<pre.Count; i++){
	// 		if(node.left == null){
	// 			node.left = new BTree{value = pre[i]};
	// 			if(isLeaf[i] == 'n'){
	// 				stack.Push(node);
	// 				node = node.left;
	// 			}
	// 		}
	// 		else if(node.right == null){
	// 			node.right = new BTree{value = pre[i]};
	// 			if(isLeaf[i] == 'n'){
	// 				stack.Push(node);
	// 				node = node.right;
	// 			}
	// 		}
	// 		else{
	// 			while(node.right != null){
	// 				node = stack.Pop();
	// 			}
	// 		}
	// 	}

	// 	return stack.First();
	// }

	public static BTree fromArray(List<int> pre, List<char> isLeaf){
		var index = -1;
		return fromArrayRecur(pre, isLeaf, ref index);
	}

	private static BTree fromArrayRecur(List<int> pre, List<char> isLeaf, ref int index){
		index++;
		if(index >= pre.Count){
			return null;
		}

		var returns = new BTree{value=pre[index]};
		if(isLeaf[index] == 'n'){
			returns.left = fromArrayRecur(pre, isLeaf, ref index);
			returns.right = fromArrayRecur(pre, isLeaf, ref index);
		}

		return returns;
	}

/*
5
3 5 2 7 4
n y n y y
*/

	// public static void Main(string[] args){
	// 	var n = int.Parse(Console.ReadLine());
	// 	var pre = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
	// 	var isLeaf = Console.ReadLine().Split(' ').ToList().Select(x => char.Parse(x)).ToList();
		
	// 	BTree.preOrder(fromArray(pre, isLeaf));
	// }
}
