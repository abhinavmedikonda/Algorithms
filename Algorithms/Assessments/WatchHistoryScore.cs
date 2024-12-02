using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Assessments;

public class WatchHistoryScore
{

	/// <summary>
	/// amazon Code Question 1
	/// Data analysts at Amazon are studying the trends in movies and shows popular
	/// on Prime Video in order to enhance the user experience.
	/// 
	/// They have identified the best critic-rated and the best audience-rated web series,
	/// represented by integer IDs series1, and series2. They also define the watch score of a
	/// contiguous period of some days as the number of distinct series watched by a
	/// viewer during that period.
	/// 
	/// Given an array watch_history, of size n, that represents the web series watched by
	/// a viewer over a period of n days, and two integers, series and series2,
	/// report the minimum watch score of a contiguous period of days in which both series? and series2
	/// have been viewed at least once. If series1 and series2 are the same value,
	/// one occurrence during the period is sufficient.
	/// </summary>
	public static int getMinScore(List<int> watch_history, int series1, int series2)
	{
		if(series1 == series2){
			if(watch_history.Contains(series1)){
				return 1;
			}
			else{
				return 0;
			}
		}
		
		int result = 0;
		int s1Index = watch_history.FindIndex(0, x => x == series1);
		int s2Index = watch_history.FindIndex(0, x => x == series2);
		
		int min = s1Index < s2Index ? series1 : series2;
		int max = s1Index > s2Index ? series1 : series2;
		
		int minIndex=0, maxIndex=0;
		
		while(true){
			minIndex = watch_history.FindIndex(minIndex, x => x == min);
			maxIndex = watch_history.FindIndex(maxIndex, x => x == max);
			
			if(minIndex < 0 || maxIndex < 0){
				break;
			}
			
			var score = watch_history.Skip(minIndex).Take(maxIndex-minIndex+1).Distinct().Count();

			result = Math.Min(result, score);

			minIndex = maxIndex;
			var temp = min;
			min = max;
			max = temp;
		}
		
		return result;
	}

	// public static void Main(string[] args){
	//	 getMinScore(new List<int>{1, 2, 2, 2, 5, 2}, 1, 5);
	// }

}
