using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Algorithms;

public class SudokuSolver
{
	static int bruteCount = 0;

	public static char[,] GetSolution(char[,] board){
		var possibilities = CreatePossibilitiesMap();
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				var c = board[i,j];
				if(c == '.'){
					continue;
				}

				possibilities[i,j].Clear();

				updatePossibilitiesForCell(board, i, j, c, possibilities);
			}
		}

		bool change = true;
		while(change){
			change = updateCells(board, possibilities) || updatePossibilities(possibilities);
		}

		return GetBruteSolution(board, 0, 0, possibilities, 0);
	}

	private static bool updatePossibilities(HashSet<char>[,] possibilities){
		bool updates = false;
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				if(possibilities[i,j].Count == 0){
					continue;
				}

				updates = updatePossibilitiesRow(possibilities, i, j)
					|| updatePossibilitiesColumn(possibilities, i, j)
					|| updatePossibilitiesBox(possibilities, i, j);
			}
		}

		return updates;
	}

	private static bool updatePossibilitiesRow(HashSet<char>[,] possibilities, int i, int j){
		var counter = 0;
		var list = Enumerable.Range(0, 9).ToList();
		for(int k=0; k<9; k++){
			if(k == j){
				list.Remove(k);
				continue;
			}

			if(possibilities[i,j].SetEquals(possibilities[i,k])){
				counter++;
				list.Remove(k);
			}
		}

		if(counter != 8 && possibilities[i,j].Count == counter+1){
			for(int k=0; k<list.Count; k++){
				possibilities[i,list[k]].RemoveWhere(x => possibilities[i,j].Contains(x));
			}

			return true;
		}

		return false;
	}

	private static bool updatePossibilitiesColumn(HashSet<char>[,] possibilities, int i, int j){
		var counter = 0;
		var list = Enumerable.Range(0, 9).ToList();
		for(int k=0; k<9; k++){
			if(k == i){
				list.Remove(k);
				continue;
			}

			if(possibilities[i,j].SetEquals(possibilities[k,j])){
				counter++;
				list.Remove(k);
			}
		}

		if(counter != 8 && possibilities[i,j].Count == counter+1){
			for(int k=0; k<list.Count; k++){
				possibilities[list[k], j].RemoveWhere(x => possibilities[i,j].Contains(x));
			}

			return true;
		}

		return false;
	}

	private static bool updatePossibilitiesBox(HashSet<char>[,] possibilities, int i, int j){
		var counter = 0;
		var list = Enumerable.Range(0, 9).ToList();
		var boxX = (i/3)*3;
		var boxY = (j/3)*3;
		for(int k=0; k<9; k++){
			var x = boxX+(k/3);
			var y = boxY+(k/3);
			if(x == i && y == j){
				list.Remove(k);
				continue;
			}

			if(possibilities[i,j].SetEquals(possibilities[x,y])){
				counter++;
				list.Remove(k);
			}
		}

		if(counter != 8 && possibilities[i,j].Count == counter+1){
			for(int k=0; k<list.Count; k++){
				var x = boxX+(list[k]/3);
				var y = boxY+(list[k]/3);
				possibilities[x, y].RemoveWhere(x => possibilities[i,j].Contains(x));
			}

			return true;
		}

		return false;
	}

	private static bool updateCells(char[,] board, HashSet<char>[,] possibilities){
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
						
						updates |= updateCellRow(board, possibilities, i, j, c);
						if(updates){
							continue;
						}

						updates |= updateCellColumn(board, possibilities, i, j, c);
						if(updates){
							continue;
						}

						updates |= updateCellBox(board, possibilities, i, j, c);
					}
				}
			}
		}

		// print(board, possibilities);
		return updates;
	}

	private static bool updateCellRow(char[,] board, HashSet<char>[,] possibilities, int i, int j, char c){
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
			return true;
		}

		return false;
	}

	private static bool updateCellColumn(char[,] board, HashSet<char>[,] possibilities, int i, int j, char c){
		var possible = false;
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
			return true;
		}

		return false;
	}

	private static bool updateCellBox(char[,] board, HashSet<char>[,] possibilities, int i, int j, char c){
		var possible = false;
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
			return true;
		}

		return false;
	}

	private static void updateCell(char[,] board, int i, int j, char c, HashSet<char>[,] possibilities){
		board[i,j] = c;
		possibilities[i,j].Clear();
		updatePossibilitiesForCell(board, i, j, c, possibilities);
	}

	private static void updatePossibilitiesForCell(char[,] board, int i, int j, char c, HashSet<char>[,] possibilities){
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

	private static HashSet<char>[,] CreatePossibilitiesMap(){
		var returns = new HashSet<char>[9,9];
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				returns[i,j] = new HashSet<char>();
				returns[i,j].UnionWith(Enumerable.Range(1, 9).Select(x => Convert.ToChar(x+'0')).ToList());
			}
		}

		return returns;
	}

	private static char[,] GetBruteSolution(char[,] board, int x, int y, HashSet<char>[,] possibilities, int level){
		// bruteCount++;
		// if(bruteCount%10000 == 0){
		// 	Console.WriteLine(bruteCount);
		// 	printBoard(board);
		// }

		if(x == 9){
			return board;
		}

		var bCopy = board.Clone() as char[,];
		var nextX = y==8 ? x+1 : x;
		var nextY = y==8 ? 0 : y+1;
		if(bCopy[x,y] != '.'){
			var response = GetBruteSolution(bCopy, nextX, nextY, possibilities, level+1);
			if(response != null){
				return response;
			}
		}

		if(possibilities[x,y].Count == 0){
			return null;
		}

		for(int n=0; n<possibilities[x,y].Count; n++){
			var c = possibilities[x,y].ToList()[n];
			var pCopy = getPossibilitiesCopy(possibilities);

			updateCell(bCopy, x, y, c, pCopy);

			var response = GetBruteSolution(bCopy, nextX, nextY, pCopy, level+1);
			if(response != null){
				return response;
			}
		}

		return x==8 && y==8 ? bCopy : null;
	}

	private static HashSet<char>[,] getPossibilitiesCopy(HashSet<char>[,] possibilities){
		var returns = new HashSet<char>[9,9];
		for(int i=0; i<possibilities.GetLength(0); i++){
			for(int j=0; j<possibilities.GetLength(1); j++){
				returns[i,j] = new HashSet<char>(possibilities[i,j]);
			}
		}

		return returns;
	}

	private static bool isSudokuSolution(char[,] board){
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

	private static bool isValidSudoku(char[,] board){
		for(int i=0; i<9; i++){
			for(int j=0; j<9; j++){
				if(board[i,j]=='0' || !char.IsAsciiDigit(board[i,j]) && board[i,j]!='.'){
					return false;
				}
			}
		}

		for(int i=0; i<9; i++){
			var hash = new HashSet<char>();
			for(int j=0; j<9; j++){
				if(hash.Contains(board[i,j])){
					return false;
				}

				if(board[i,j] != '.'){
					hash.Add(board[i,j]);
				}
			}
		}

		for(int i=0; i<9; i++){
			var hash = new HashSet<char>();
			for(int j=0; j<9; j++){
				if(hash.Contains(board[j,i])){
					return false;
				}

				if(board[j,i] != '.'){
					hash.Add(board[j,i]);
				}
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

						if(board[i,j] != '.'){
							hash.Add(board[i,j]);
						}
					}
				}
			}
		}

		return true;
	}

	private static void print(char[,] board, HashSet<char>[,] possibilities){
		printBoard(board);
		printPossibilities(possibilities);
	}

	public static void printBoard(char[,] board){
		var count = 0;
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				Console.Write(board[i, j] + (j%3==2 ? " " : ""));
				if(board[i,j] == '.'){
					count++;
				}
			}

			Console.WriteLine();
			if(i<8 && i%3 == 2){
				Console.WriteLine();
			}
		}

		Console.WriteLine($"'.': {count}");
	}

	private static void printPossibilities(HashSet<char>[,] possibilities){
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				Console.Write(possibilities[i, j].Count + (j%3==2 ? " " : ""));
			}

			Console.WriteLine();
			if(i%3 == 2){
				Console.WriteLine();
			}
		}
	}

/*
easy:
..6.5..4.
....1.5.2
.4.9..18.
..45..8.1
.5....76.
.7.......
9...6..2.
38.7.....
.....9...

medium:
1........
...6.....
.6.935...
..234..6.
3....1..2
.......84
.5..6....
..1..2.9.
8......71

hard:
.5..7..83
..4....6.
....5....
83.6.....
...9..1..
.........
5.7...4..
...3.2...
1........
*/
	// public static void Main(string[] args)
	// {
	// 	var board = SudokuSolver.GetBoard();

	// 	if(!SudokuSolver.isValidSudoku(board)){
	// 		Console.WriteLine("Invalid Sudoku:");
	// 		SudokuSolver.printBoard(board);
	// 		return;
	// 	}

	// 	var response = SudokuSolver.GetSolution(board);

	// 	if(SudokuSolver.isSudokuSolution(response)){
	// 		Console.WriteLine("Solution:");
	// 		SudokuSolver.printBoard(response);
	// 		Console.WriteLine(bruteCount);
	// 	}
	// 	else{
	// 		Console.WriteLine("Bad Sudoku:");
	// 		SudokuSolver.printBoard(board);
	// 	}
	// }

	public static char[,] GetBoard()
	{
		// var board = new char[9,9];
		// for(int i=0; i<9; i++){
		// 	var line = Console.ReadLine().ToArray();
		// 	for(int j=0; j<9; j++){
		// 		board[i,j] = line[j];
		// 	}
		// }

		// Console.WriteLine();
		// Console.WriteLine("Input:");
		// printBoard(board);
		// Console.WriteLine();

		// return board;

		// // easy
		// return new char[,] {
		// 	{ '.','.','6', '.','5','.', '.','4','.' },
		// 	{ '.','.','.', '.','1','.', '5','.','2' },
		// 	{ '.','4','.', '9','.','.', '1','8','.' },

		// 	{ '.','.','4', '5','.','.', '8','.','1' },
		// 	{ '.','5','.', '.','.','.', '7','6','.' },
		// 	{ '.','7','.', '.','.','.', '.','.','.' },

		// 	{ '9','.','.', '.','6','.', '.','2','.' },
		// 	{ '3','8','.', '7','.','.', '.','.','.' },
		// 	{ '.','.','.', '.','.','9', '.','.','.' }
		// };

		// // medium
		// return new char[,] {
		// 	{ '1','.','.', '.','.','.', '.','.','.' },
		// 	{ '.','.','.', '6','.','.', '.','.','.' },
		// 	{ '.','6','.', '9','3','5', '.','.','.' },

		// 	{ '.','.','2', '3','4','.', '.','6','.' },
		// 	{ '3','.','.', '.','.','1', '.','.','2' },
		// 	{ '.','.','.', '.','.','.', '.','8','4' },

		// 	{ '.','5','.', '.','6','.', '.','.','.' },
		// 	{ '.','.','1', '.','.','2', '.','9','.' },
		// 	{ '8','.','.', '.','.','.', '.','7','1' }
		// };

		// hard
		return new char[,] {
			{ '.','5','.', '.','7','.', '.','8','3' },
			{ '.','.','4', '.','.','.', '.','6','.' },
			{ '.','.','.', '.','5','.', '.','.','.' },

			{ '8','3','.', '6','.','.', '.','.','.' },
			{ '.','.','.', '9','.','.', '1','.','.' },
			{ '.','.','.', '.','.','.', '.','.','.' },

			{ '5','.','7', '.','.','.', '4','.','.' },
			{ '.','.','.', '3','.','2', '.','.','.' },
			{ '1','.','.', '.','.','.', '.','.','.' }
		};
	}

}
