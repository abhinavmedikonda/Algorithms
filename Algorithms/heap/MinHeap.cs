using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Heap
{
    public class MinHeap
    {
        /// <summary>
        /// menu:
        /// 1. add new number to heap
        /// 2. delete number from heap
        /// 3. print the minimum number in the heap
        /// </summary>
        public static int? minHeap(List<int> heap, List<int> arr)
        {
            if (arr[0] == 1) add(heap, arr[1]);
            else if (arr[0] == 2) delete(heap, arr[1]);
            else if (arr.Count > 0) return heap[0];

            return null;
        }

        public static void add(List<int> heap, int num)
        {
            heap.Add(num);

            heapify(heap, heap.Count - 1);
        }

        public static void heapify(List<int> heap, int ind)
        {
            while (ind > 0)
            {
                if (heap[ind] < heap[(ind - 1) / 2]) swap(heap, ind, (ind - 1) / 2);

                ind = (ind - 1) / 2;
            }
        }

        public static void delete(List<int> heap, int num)
        {
            var nullableInd = find(heap, num, 0);

            if (nullableInd == null) return;

            var ind = nullableInd ?? 0;

            swap(heap, ind, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);

            if (ind == heap.Count) return;

            if (heap[(ind - 1) / 2] > heap[ind])
            {
                heapify(heap, ind);
            }
            else
            {
                while (true)
                {
                    if (2 * ind + 2 < heap.Count && heap[2 * ind + 2] < heap[2 * ind + 1])
                    {
                        swap(heap, ind, 2 * ind + 2);
                        ind = 2 * ind + 2;
                    }
                    else if (2 * ind + 1 < heap.Count)
                    {
                        swap(heap, ind, 2 * ind + 1);
                        ind = 2 * ind + 1;
                    }

                    break;
                }
            }
        }

        public static int? find(List<int> heap, int num, int ind)
        {
            if (ind >= heap.Count || num < heap[ind]) return null;

            if (heap[ind] == num) return ind;

            var res = find(heap, num, 2 * ind + 1);
            if (res != null) return res;

            return find(heap, num, 2 * ind + 2);
        }

        public static void swap(List<int> heap, int ind1, int ind2)
        {
            var temp = heap[ind2];
            heap[ind2] = heap[ind1];
            heap[ind1] = temp;
        }

/*
12
1 3
1 65
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

        // static void Main(String[] args)
        // {
        //    var heap = new List<int>();
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(heapTemp => Convert.ToInt32(heapTemp)).ToList();

        //        var result = MinHeap.minHeap(heap, arr);

        //        if (result != null) Console.WriteLine(result);
        //    }

        //    Console.Read();
        // }
    }
}