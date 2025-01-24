using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Trees;

public class BST {
	public static BTree getBST(List<int> theList){
		if(theList?.Count == 0){
			return null;
		}
		
		var result = new BTree{value = theList[0]};

		for(int i=1; i<theList.Count; i++){
			addNode(result, theList[i]);
		}

		return result;
	}

	private static void addNode(BTree theBTree, int theData){
		while(theBTree != null){
			if(theData == theBTree.value){
				return;
			}
			if(theData > theBTree.value){
				if(theBTree.right == null){
					theBTree.right = new BTree{value = theData};
					return;
				}

				theBTree = theBTree.right;
			}
			else{
				if(theBTree.left == null){
					theBTree.left = new BTree{value = theData};
					return;
				}

				theBTree = theBTree.left;
			}
		}
	}

/*
6
3 5 2 7 4 6
*/

	// public static void Main(string[] args){
	//	 var n = int.Parse(Console.ReadLine());
	//	 var input = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
		
	//	 BTree.inOrder(getBST(input)); // inOrder for a BST will be sorted just like the name
	//	 Console.WriteLine();
	//	 BTree.preOrder(getBST(input));
	//	 Console.WriteLine();
	//	 BTree.postOrder(getBST(input));

	//	 Console.Read();
	// }

}
