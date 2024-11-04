using System;
using System.Linq;

namespace Algorithms.Tree;

public class BTree{
	public BTree left;
	public BTree right;
	public int value;

	public static void inOrder(BTree theBTree){
		if(theBTree == null){
			return;
		}

		inOrder(theBTree.left);
		Console.Write($"{theBTree.value} ");
		inOrder(theBTree.right);
	}

	public static void preOrder(BTree theBTree){
		if(theBTree == null){
			return;
		}

		Console.Write($"{theBTree.value} ");
		preOrder(theBTree.left);
		preOrder(theBTree.right);
	}

	public static void postOrder(BTree theBTree){
		if(theBTree == null){
			return;
		}

		postOrder(theBTree.left);
		postOrder(theBTree.right);
		Console.Write($"{theBTree.value} ");
	}
}