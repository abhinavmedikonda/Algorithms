using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
	public class SudokuSolve
	{
		//static void Main(string[] args)
		//{
		//	SudokuSolve sudokuSolve = new SudokuSolve();

		//	char[,] board = sudokuSolve.GetBoard();

		//	sudokuSolve.IsSudokuSolvable(board);

		//	for (int i = 0; i < 9; i++)
		//	{
		//		for (int j = 0; j < 9; j++)
		//		{
		//			Console.Write(board[i, j]+" ");
		//		}

		//		Console.WriteLine();
		//	}

		//	Console.ReadLine();
		//}

		List<HashSet<int>> rowSet = new List<HashSet<int>>();
		List<HashSet<int>> columnSet = new List<HashSet<int>>();
		List<HashSet<int>> boxSet = new List<HashSet<int>>();
		bool isSolvable = true;

		//sudo xcode-select --install
		private bool IsSudokuSolvable(char[,] board)
		{
			int count = 0;
			
			for (int i = 0; i < 9; i++)
			{
				rowSet.Add(new HashSet<int>());
				columnSet.Add(new HashSet<int>());
				boxSet.Add(new HashSet<int>());
			}

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					int row = ((i / 3) * 3) + j;
					for (int k = 0; k < 3; k++)
					{
						int column = ((i % 3) * 3) + k;
						if(board[row,column] != '.')
						{
							count++;
							int num = (int)char.GetNumericValue(board[row, column]);
							if (rowSet[row].Contains(num) || columnSet[column].Contains(num) || boxSet[i].Contains(num))
							{
								isSolvable = false;
								break;
							}
							rowSet[row].Add(num);
							columnSet[column].Add(num);
							boxSet[i].Add(num);
						}
					}
				}
			}

			while (isSolvable)
			{
				isSolvable = false;
				IsSudokuSolvableRecur(board, ref count);
			}

			if (count == 81) return true;
			else return false;
		}

		private void IsSudokuSolvableRecur(char[,] board, ref int count)
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (board[i, j] == '.')
					{
						int box = ((i / 3) * 3) + (j / 3);
						foreach (var item in PossibleNumbers(i, j, box))
						{
							if (!CanRowContain(board, item, i, j, box) ||
								!CanColumnContain(board, item, i, j, box) ||
								!CanBoxContain(board, item, i, j, box))
							{
								board[i, j] = item.ToString()[0];
								rowSet[i].Add(item);
								columnSet[j].Add(item);
								boxSet[box].Add(item);
								count++;
								isSolvable = true;
								break;
							}
						}
					}
				}
			}
		}
		private List<int> PossibleNumbers(int row, int column, int box)
		{
			IEnumerable<int> union = rowSet[row].Union(columnSet[column].Union(boxSet[box]));
			IEnumerable<int> possibleNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			return possibleNumbers.Where(x => !union.Contains(x)).ToList();
		}
		private bool CanRowContain(char[,] board, int num, int row, int column, int box)
		{
			int boxIndex = box - (box % 3);
			int boxIndexEnd = boxIndex + 3;
			for (; boxIndex < boxIndexEnd; boxIndex++)
			{
				if (CanBoxRowContain(board, num, row, column, boxIndex)) return true;
			}

			return false;
		}
		private bool CanBoxRowContain(char[,] board, int num, int row, int column, int box)
		{
			if (boxSet[box].Contains(num)) return false;
			for (int i = 0; i < 3; i++)
			{
				int columnIndex = ((box % 3) * 3) + i;
				if (column != columnIndex && board[row, columnIndex] == '.' && !columnSet[columnIndex].Contains(num)) return true;
			}

			return false;
		}
		private bool CanColumnContain(char[,] board, int num, int row, int column, int box)
		{
			int boxIndex = box % 3;
			int boxIndexEnd = boxIndex + 6;

			for (; boxIndex <= boxIndexEnd; boxIndex += 3)
			{
				if (CanBoxColumnContain(board, num, row, column, boxIndex)) return true;
			}

			return false;
		}
		private bool CanBoxColumnContain(char[,] board, int num, int row, int column, int box)
		{
			if (boxSet[box].Contains(num)) return false;
			for (int i = 0; i < 3; i++)
			{
				int rowIndex = ((box / 3) * 3) + i;
				if (row != rowIndex && board[rowIndex, column] == '.' && !rowSet[rowIndex].Contains(num)) return true;
			}

			return false;
		}
		private bool CanBoxContain(char[,] board, int num, int row, int column, int box)
		{
			for (int i = 0; i < 3; i++)
			{
				int rowIndex = ((box / 3) * 3) + i;
				for (int j = 0; j < 3; j++)
				{
					int columnIndex = ((box % 3) * 3) + i;
					if (row != rowIndex )
					{

					}
				}
			}

			return false;
		}

		private char[,] GetBoard()
		{
			//return new char[,] {
			//	{ '5', '3', '.', '.', '7', '.', '.', '.', '.'},
			//	{ '6', '.', '.', '1', '9', '5', '.', '.', '.'},
			//	{ '.', '9', '8', '.', '.', '.', '.', '6', '.'},
			//	{ '8', '.', '.', '.', '6', '.', '.', '.', '3'},
			//	{ '4', '.', '.', '8', '.', '3', '.', '.', '1'},
			//	{ '7', '.', '.', '.', '2', '.', '.', '.', '6'},
			//	{ '.', '6', '.', '.', '.', '.', '2', '8', '.'},
			//	{ '.', '.', '.', '4', '1', '9', '.', '.', '5'},
			//	{ '.', '.', '.', '.', '8', '.', '.', '7', '9'}
			//};

			return new char[,] {
				{ '.', '5', '.', '.', '7', '.', '.', '8', '3'},
				{ '.', '.', '4', '.', '.', '.', '.', '6', '.'},
				{ '.', '.', '.', '.', '5', '.', '.', '.', '.'},
				{ '8', '3', '.', '6', '.', '.', '.', '.', '.'},
				{ '.', '.', '.', '9', '.', '.', '1', '.', '.'},
				{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
				{ '5', '.', '7', '.', '.', '.', '4', '.', '.'},
				{ '.', '.', '.', '3', '.', '2', '.', '.', '.'},
				{ '1', '.', '.', '.', '.', '.', '.', '.', '.'}
			};
		}
	}
}
