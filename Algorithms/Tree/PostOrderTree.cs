using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace Algorithms.Trees;

public class PostOrderTree {
	// public static BTree fromArray(List<int> post, List<char> isLeaf){
	// 	var node = new BTree{value = post[post.Count-1]};
	// 	var stack = new Stack<BTree>();

	// 	for(int i=post.Count-2; i>=0; i--){
	// 		if(node.right == null){
	// 			node.right = new BTree{ value = post[i] };
	// 			if(isLeaf[i] == 'n'){
	// 				stack.Push(node);
	// 				node = node.right;
	// 			}
	// 		}
	// 		else if(node.left == null){
	// 			node.left = new BTree{ value = post[i] };
	// 			if(isLeaf[i] == 'n'){
	// 				stack.Push(node);
	// 				node = node.left;
	// 			}
	// 		}
	// 		else{
	// 			while(node.left != null){
	// 				node = stack.Pop();
	// 			}
	// 		}
	// 	}

	// 	return stack.First();
	// }

	public static BTree fromArray(List<int> post, List<char> isLeaf){
		var index = post.Count;
		return fromArrayRecur(post, isLeaf, ref index);
	}

	private static BTree fromArrayRecur(List<int> post, List<char> isLeaf, ref int index){
		index--;
		if(index < 0){
			return null;
		}

		var returns = new BTree{value = post[index]};
		if(isLeaf[index] == 'n'){
			returns.right = fromArrayRecur(post, isLeaf, ref index);
			returns.left = fromArrayRecur(post, isLeaf, ref index);
		}

		return returns;
	}

/*
5
3 5 2 7 4
y y n n n
*/

	// public static void Main(string[] args){
	// 	var n = int.Parse(Console.ReadLine());
	// 	var post = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
	// 	var isLeaf = Console.ReadLine().Split(' ').ToList().Select(x => char.Parse(x)).ToList();
		
	// 	BTree.postOrder(fromArray(post, isLeaf));
	// }
}
