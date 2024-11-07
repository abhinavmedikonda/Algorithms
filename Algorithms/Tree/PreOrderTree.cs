using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace Algorithms.Tree;

public class PreOrderTree {
	public static BTree fromArray(List<int> pre, List<char> isLeaf){
		var returns = new BTree{value = pre[0]};
		var node = returns;
		var stack = new Stack<BTree>();

		for(int i=1; i<pre.Count; i++){
			if(node.left == null){
				node.left = new BTree{value = pre[i]};
				if(isLeaf[i] == 'n'){
					stack.Push(node);
					node = node.left;
				}
			}
			else if(node.right == null){
				node.right = new BTree{value = pre[i]};
				if(isLeaf[i] == 'n'){
					stack.Push(node);
					node = node.right;
				}
			}
			else{
				while(node.right != null){
					node = stack.Pop();
				}
			}
		}

		return returns;
	}

/*
5
3 5 2 7 4
n y n y y
*/

	public static void Main(string[] args){
		var n = int.Parse(Console.ReadLine());
		var pre = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
		var isLeaf = Console.ReadLine().Split(' ').ToList().Select(x => char.Parse(x)).ToList();
		
		BTree.preOrder(fromArray(pre, isLeaf));
	}
}
