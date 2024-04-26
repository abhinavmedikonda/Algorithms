using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Tree
{
    public class MinHeightTrees {
        /// <summary>
        /// Given a tree of n nodes labelled from 0 to n - 1, and an array of n - 1 edges
        /// where edges[i] = [ai, bi] indicates that there is an undirected edge between the two nodes ai and bi in the tree,
        /// you can choose any node of the tree as the root. When you select a node x as the root,
        /// the result tree has height h. Among all possible rooted trees, find those with minimum height
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static IList<int> FindMinHeightTrees(int n, int[][] edges) {
            if(n == 1) return new List<int>{0};
            Dictionary<int, HashSet<int>> tree = new Dictionary<int, HashSet<int>>();
            for(int i=0; i<edges.Length; i++){
                if(!tree.ContainsKey(edges[i][0])){
                    tree[edges[i][0]] = new HashSet<int>();
                }

                tree[edges[i][0]].Add(edges[i][1]);

                if(!tree.ContainsKey(edges[i][1])){
                    tree[edges[i][1]] = new HashSet<int>();
                }

                tree[edges[i][1]].Add(edges[i][0]);
            }

            var queue = new Queue<int>();

            foreach(var item in tree){
                if(item.Value.Count == 1){
                    queue.Enqueue(item.Key);
                }
            }

            while(n > 2){
                var count = queue.Count;
                n -= queue.Count;
                for(int i=0; i<count; i++){
                    var item = queue.Dequeue();
                    var parent = tree[item].First();
                    tree[parent].Remove(item);
                    if(tree[parent].Count == 1){
                        queue.Enqueue(parent);
                    }
                }
            }

            return queue.ToList();
        }

        // public static void Main(string[] args){
        //     var response = MinHeightTrees.FindMinHeightTrees(4, new int[][]{new int[]{3,0},
        //                                                                     new int[]{3,1},
        //                                                                     new int[]{3,2},
        //                                                                     new int[]{3,4},
        //                                                                     new int[]{5,4}});
        //     Console.WriteLine(string.Join(", ", response));
        //     Console.Read();
        // }
    }
}
