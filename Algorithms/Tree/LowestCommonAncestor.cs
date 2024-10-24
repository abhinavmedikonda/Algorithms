using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Tree
{
    public class LowestCommonAncestor {
        public static int lowestCommonAncestor(BTree root, int value1, int value2){
            var result = lowestCommonAncestorRecur(root, value1, value2);

            return result == null ? -1 : result.data;
        }

        private static BTree lowestCommonAncestorRecur(BTree node, int value1, int value2){
            if(node == null){
                return null;
            }

            var left = node.left == null ? null : lowestCommonAncestorRecur(node.left, value1, value2);
            var right = node.right == null ? null : lowestCommonAncestorRecur(node.right, value1, value2);

            if(left != null && right != null || node.data == value1 || node.data == value2){
                return node;
            }

            return left != null ? left : right;
        }

/*
6
3 5 2 7 4 6
4 7

  3
2   5
   4   7
      6
*/

        // public static void Main(string[] args){
        //     var n = int.Parse(Console.ReadLine());
        //     var numbers = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
        //     var values = Console.ReadLine().Split(' ');
            
        //     Console.WriteLine(lowestCommonAncestor(BST.getBST(numbers), int.Parse(values[0]), int.Parse(values[1])));

        //     Console.Read();
        // }
    }
}
