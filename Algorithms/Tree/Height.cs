using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Tree
{
	public class Height {
		public static int getHeight(BTree root){
			if(root == null){
				return 0;
			}
			
			var q = new Queue<BTree>();
			q.Enqueue(root);
			q.Enqueue(null);
			var result = 0;

			while(q.Count > 1){
				var node = q.Dequeue();
				if(node == null){
					if(q.Peek() == null){
						break;
					}

					result++;
					q.Enqueue(null);
					continue;
				}
				
				if(node.left != null){
					q.Enqueue(node.left);
				}
				if(node.right != null){
					q.Enqueue(node.right);
				}
			}

			return result;
		}

		// public static int getHeight(BTree root){
		//	 if(root == null){
		//		 return 0;
		//	 }
			
		//	 return getHeight(root, 0);
		// }

		// private static int getHeight(BTree root, int height){
		//	 if(root.left == null && root.right == null){
		//		 return height;
		//	 }
		//	 if(root.left == null){
		//		 return getHeight(root.right, height+1);
		//	 }
		//	 if(root.right == null){
		//		 return getHeight(root.left, height+1);
		//	 }

		//	 var lHeight = getHeight(root.left, height+1);
		//	 var rHeight = getHeight(root.right, height+1);

		//	 return lHeight > rHeight ? lHeight : rHeight;
		// }

/*
6
3 5 2 7 4 6

  3
2   5
   4   7
	  6
*/

		// public static void Main(string[] args){
		//	 var n = int.Parse(Console.ReadLine());
		//	 var input = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
			
		//	 Console.WriteLine(getHeight(BST.getBST(input)));

		//	 Console.Read();
		// }
	}
}
