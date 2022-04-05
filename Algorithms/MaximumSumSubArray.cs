using System;
namespace Algorithms
{
    //positive numbers maximum sum
    public class MaximumSumSubArray
    {
        //static void Main(string[] args)
        //{
        //    MaximumSumSubArray mssa = new MaximumSumSubArray();
        //    var result = mssa.GetMaximumSumSubArray(new int[] { 1, 2, 3, -2, 3, 4, 0, 5 });
        //}

        private MaximumSumSubArrayResult GetMaximumSumSubArray(int[] numbers)
        {
            int index = 0, mssaIndex = 0, mssaLength = 0, length = 0, sum = 0, maxSum = 0;

            if (numbers == null || numbers.Length == 0)
            {
                return null;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    sum += numbers[i];
                    length++;
                    if (length == 1)
                    {
                        index = i;
                    }
                    if (sum > maxSum)
                    {
                        mssaIndex = index;
                        maxSum = sum;
                        mssaLength = length;
                    }
                }
                else
                {
                    sum = 0;
                    length = 0;
                }
            }

            return new MaximumSumSubArrayResult { Index = mssaIndex, Length = mssaLength };
        }
    }

    public class MaximumSumSubArrayResult
    {
        public int Index { get; set; }
        public int Length { get; set; }
    }
}
