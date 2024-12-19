using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms;

public class SudokuSolve
{

	static void Main(string[] args)
	{
		SudokuSolve sudokuSolve = new SudokuSolve();

		char[,] board = sudokuSolve.GetBoard();

		// sudokuSolve.IsSudokuSolvable(board);
		sudokuSolve.GetSolution(board);

		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				Console.Write(board[i, j] + (j%3==2 ? " " : ""));
			}

			Console.WriteLine();
			if(i%3 == 2){
				Console.WriteLine();
			}
		}
	}

	List<HashSet<int>> rowSets = new List<HashSet<int>>();
	List<HashSet<int>> columnSets = new List<HashSet<int>>();
	List<HashSet<int>> boxSets = new List<HashSet<int>>();
	bool isSolvable = true;

	//sudo xcode-select --install
	private bool IsSudokuSolvable(char[,] board)
	{
		int count = 0;
		
		for (int i = 0; i < 9; i++)
		{
			rowSets.Add(new HashSet<int>());
			columnSets.Add(new HashSet<int>());
			boxSets.Add(new HashSet<int>());
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
						if (rowSets[row].Contains(num) || columnSets[column].Contains(num) || boxSets[i].Contains(num))
						{
							isSolvable = false;
							break;
						}
						rowSets[row].Add(num);
						columnSets[column].Add(num);
						boxSets[i].Add(num);
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
							rowSets[i].Add(item);
							columnSets[j].Add(item);
							boxSets[box].Add(item);
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
		IEnumerable<int> union = rowSets[row].Union(columnSets[column].Union(boxSets[box]));
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
		if (boxSets[box].Contains(num)) return false;
		for (int i = 0; i < 3; i++)
		{
			int columnIndex = ((box % 3) * 3) + i;
			if (column != columnIndex && board[row, columnIndex] == '.' && !columnSets[columnIndex].Contains(num)) return true;
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
		if (boxSets[box].Contains(num)) return false;
		for (int i = 0; i < 3; i++)
		{
			int rowIndex = ((box / 3) * 3) + i;
			if (row != rowIndex && board[rowIndex, column] == '.' && !rowSets[rowIndex].Contains(num)) return true;
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
		// return new char[,] {
		// 	{ '5', '3', '4', '6', '7', '8', '9', '1', '2'},
		// 	{ '6', '7', '2', '1', '9', '5', '3', '4', '8'},
		// 	{ '1', '9', '8', '3', '4', '2', '5', '6', '7'},
		// 	{ '8', '5', '9', '7', '6', '1', '4', '2', '3'},
		// 	{ '4', '2', '6', '8', '5', '3', '7', '9', '1'},
		// 	{ '7', '1', '3', '9', '2', '4', '8', '5', '6'},
		// 	{ '9', '6', '1', '5', '3', '7', '2', '8', '4'},
		// 	{ '2', '8', '7', '4', '1', '9', '6', '3', '5'},
		// 	{ '3', '4', '5', '2', '8', '6', '1', '7', '9'}
		// };

		return new char[,] {
			{ '5', '3', '.', '.', '7', '.', '.', '.', '.'},
			{ '6', '.', '.', '1', '9', '5', '.', '.', '.'},
			{ '.', '9', '8', '.', '.', '.', '.', '6', '.'},
			{ '8', '.', '.', '.', '6', '.', '.', '.', '3'},
			{ '4', '.', '.', '8', '.', '3', '.', '.', '1'},
			{ '7', '.', '.', '.', '2', '.', '.', '.', '6'},
			{ '.', '6', '.', '.', '.', '.', '2', '8', '.'},
			{ '.', '.', '.', '4', '1', '9', '.', '.', '5'},
			{ '.', '.', '.', '.', '8', '.', '.', '7', '9'}
		};

		// return new char[,] {
		// 	{ '.', '5', '.', '.', '7', '.', '.', '8', '3'},
		// 	{ '.', '.', '4', '.', '.', '.', '.', '6', '.'},
		// 	{ '.', '.', '.', '.', '5', '.', '.', '.', '.'},
		// 	{ '8', '3', '.', '6', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '9', '.', '.', '1', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '5', '.', '7', '.', '.', '.', '4', '.', '.'},
		// 	{ '.', '.', '.', '3', '.', '2', '.', '.', '.'},
		// 	{ '1', '.', '.', '.', '.', '.', '.', '.', '.'}
		// };
	}

	private char[,] GetSolution(char[,] board){
		var possibilities = CreatePossibilitiesMap();
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				var c = board[i,j];
				if(c == '.'){
					continue;
				}

				possibilities[i,j].Clear();

				updatePossibilities(board, i, j, c, possibilities);
			}
		}

		bool change = true;
		while(change){
			change = checkPossibilities(board, possibilities);
		}

		GetSolutionRecur(board, 0, 0, possibilities, 0);

		return board;
	}

	private bool checkPossibilities(char[,] board, HashSet<char>[,] possibilities){
		bool updates = false;
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				if(board[i,j] == '.'){
					if(possibilities[i,j].Count == 1){
						updateCell(board, i, j, possibilities[i,j].First(), possibilities);
						updates = true;
						continue;
					}

					for(int n=0; n<possibilities[i,j].Count; n++){
						var c = possibilities[i,j].ToList()[n];
						var possible = false;
						for(int k=0; k<9; k++){
							if(k == j){
								continue;
							}
							if(possibilities[i, k].Contains(c)){
								possible = true;
								break;
							}
						}

						if(!possible){
							updateCell(board, i, j, c, possibilities);
							updates = true;
							break;
						}

						possible = false;
						for(int k=0; k<9; k++){
							if(k == i){
								continue;
							}
							if(possibilities[k, j].Contains(c)){
								possible = true;
								break;
							}
						}

						if(!possible){
							updateCell(board, i, j, c, possibilities);
							updates = true;
							break;
						}

						possible = false;
						var row = 3*(i/3);
						var column = 3*(j/3);
						for(int x=row; x<row+3; x++){
							for(int y=column; y<column+3; y++){
								if(x==i && y==j){
									continue;
								}
								if(possibilities[x, y].Contains(c)){
									possible = true;
								}
							}
						}

						if(!possible){
							updateCell(board, i, j, c, possibilities);
							updates = true;
						}
					}
				}
			}
		}

		var count = 0;
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				Console.Write(board[i,j]);
				if(board[i,j] == '.'){
					count++;
				}
			}

			Console.WriteLine();
		}

		Console.WriteLine(count);

		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				Console.Write(possibilities[i,j].Count);
			}

			Console.WriteLine();
		}

		return updates;
	}

	private void updateCell(char[,] board, int i, int j, char c, HashSet<char>[,] possibilities){
		board[i,j] = c;
		possibilities[i,j].Clear();
		updatePossibilities(board, i, j, c, possibilities);
	}

	private void updatePossibilities(char[,] board, int i, int j, char c, HashSet<char>[,] possibilities){
		for(int k=0; k<9; k++){
			if(possibilities[i, k].Contains(c)){
				possibilities[i, k].Remove(c);
			}
		}

		for(int k=0; k<9; k++){
			if(possibilities[k, j].Contains(c)){
				possibilities[k, j].Remove(c);
			}
		}

		var row = 3*(i/3);
		var column = 3*(j/3);
		for(int x=row; x<row+3; x++){
			for(int y=column; y<column+3; y++){
				if(possibilities[x, y].Contains(c)){
					possibilities[x, y].Remove(c);
				}
			}
		}
	}

	private char[,] GetSolutionRecur(char[,] board, int x, int y, HashSet<char>[,] possibilities, int level){
		var copy = board.Clone() as char[,];
		for(int i=x; i<9; i++){
			for(int j=y; j<9; j++){
				if(level == 0){
					Console.WriteLine($"{i} {j}");
				}

				y = 0;
				if(copy[i, j] == '.'){
					var nextX = j==8 ? i+1 : i;
					var nextY = j==8 ? 0 : j+1;
					for(int n=0; n<possibilities[i,j].Count; n++){
						var c = possibilities[i,j].ToList()[n];
						copy[i, j] = c;
						var response = GetSolutionRecur(copy, nextX, nextY, possibilities, level+1);

						if(response != null){
							return response;
						}
					}
				}
			}
		}

		return isBoardRight(copy) ? copy : null;
	}

	private bool isBoardRight(char[,] board){
		var columnSet = new HashSet<char>();
		var boxSet = new HashSet<char>();

		for(int i=0; i<9; i++){
			var hash = new HashSet<char>();
			for(int j=0; j<9; j++){
				if(hash.Contains(board[i,j])){
					return false;
				}

				hash.Add(board[i,j]);
			}
		}

		for(int i=0; i<9; i++){
			var hash = new HashSet<char>();
			for(int j=0; j<9; j++){
				if(hash.Contains(board[j,i])){
					return false;
				}

				hash.Add(board[j,i]);
			}
		}

		for(int x=0; x<3; x++){
			for(int y=0; y<3; y++){
				var hash = new HashSet<char>();
				for(int i=x*3; i<x*3+3; i++){
					for(int j=y*3; j<y*3+3; j++){
						if(hash.Contains(board[i,j])){
							return false;
						}

						hash.Add(board[i,j]);
					}
				}
			}
		}

		return true;
	}

	private HashSet<char>[,] CreatePossibilitiesMap(){
		var returns = new HashSet<char>[9,9];
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				returns[i,j] = new HashSet<char>();
				returns[i,j].UnionWith(Enumerable.Range(1, 9).Select(x => Convert.ToChar(x+'0')).ToList());
			}
		}

		return returns;
	}

}
