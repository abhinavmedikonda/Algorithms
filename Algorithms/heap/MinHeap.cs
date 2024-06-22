using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Heap
{
    public class MinHeap
    {
        static void MinHeapifyUp(List<int> theHeap, int index){
            if(index == 0){
                return;
            }

            var parentIndex = (index-1)/2;
            
            if(theHeap[index] < theHeap[parentIndex]){
                SwapItemsWithIndex(theHeap, index, parentIndex);
                MinHeapifyUp(theHeap, parentIndex);
            }
        }
        
        static void MinHeapifyDown(List<int> theHeap, int index){
            if((index*2)+1 > theHeap.Count-1){
                return;
            }

            int childIndex = default;
            if(theHeap.Count-1 > (index*2)+1 && theHeap[(index*2)+2] < theHeap[(index*2)+1]){
                childIndex = (index*2)+2;
            }
            else{
                childIndex = (index*2)+1;
            }
            
            if(theHeap[childIndex] < theHeap[index]){
                SwapItemsWithIndex(theHeap, index, childIndex);
                MinHeapifyDown(theHeap, childIndex);
            }
        }
        
        static void SwapItemsWithIndex(List<int> theHeap, int a, int b){
            var temp = theHeap[a];
            theHeap[a] = theHeap[b];
            theHeap[b] = temp;
        }

/*
12
1 3
1 65
1 10
1 4
1 44
1 67
1 99
1 24
1 9
2 65
3
2 3
1 7
3
1 -1
3
2 -1
3
2 7
*/

        /// <summary>
        /// menu:
        /// 1. add new number to heap
        /// 2. delete number from heap
        /// 3. print the minimum number in the heap
        /// </summary>
        static void Main(String[] args)
        {
            var heap = new List<int>();
        
            var operations = Convert.ToInt32(Console.ReadLine());
            
            for(int i=0; i<operations; i++){
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                switch(input[0]){
                    case 1:
                        heap.Add(input[1]);
                        MinHeapifyUp(heap, heap.Count-1);
                        break;
                    case 2:
                        var index = heap.FindIndex(x => x == input[1]);
                        SwapItemsWithIndex(heap, index, heap.Count-1);
                        heap.RemoveAt(heap.Count-1);
                        if(index == heap.Count) continue;
                        if(heap[index] < input[1]){
                            MinHeapifyUp(heap, index);
                        }
                        else{
                            MinHeapifyDown(heap, index);
                        }
            
                        break;
                    case 3:
                        Console.WriteLine(heap[0]);
                        break;
                }
            }
        }
    }
}