using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Tree;

public class BST {
    public static BTree getBST(List<int> theList){
        if(theList?.Count == 0){
            return null;
        }
        
        var result = new BTree{data = theList[0]};

        for(int i=1; i<theList.Count; i++){
            addBTree(result, theList[i]);
        }

        return result;
    }

    public static void addBTree(BTree theBTree, int theData){
        while(theBTree != null){
            if(theData == theBTree.data){
                return;
            }
            if(theData > theBTree.data){
                if(theBTree.right == null){
                    theBTree.right = new BTree{data = theData};
                    return;
                }

                theBTree = theBTree.right;
            }
            else{
                if(theBTree.left == null){
                    theBTree.left = new BTree{data = theData};
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
    //     var n = int.Parse(Console.ReadLine());
    //     var input = Console.ReadLine().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
        
    //     inOrder(getBST(input)); // inOrder for a BST will be sorted just like the name
    //     Console.WriteLine();
    //     preOrder(getBST(input));
    //     Console.WriteLine();
    //     postOrder(getBST(input));

    //     Console.Read();
    // }

    public static void inOrder(BTree theBTree){
        if(theBTree == null){
            return;
        }

        inOrder(theBTree.left);
        Console.Write($"{theBTree.data} ");
        inOrder(theBTree.right);
    }

    public static void preOrder(BTree theBTree){
        if(theBTree == null){
            return;
        }

        Console.Write($"{theBTree.data} ");
        preOrder(theBTree.left);
        preOrder(theBTree.right);
    }

    public static void postOrder(BTree theBTree){
        if(theBTree == null){
            return;
        }

        postOrder(theBTree.left);
        postOrder(theBTree.right);
        Console.Write($"{theBTree.data} ");
    }
}
