using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Algorithms;

public class SudokuSolve
{

	// static void Main(string[] args)
	// {
	// 	SudokuSolve sudokuSolve = new SudokuSolve();

	// 	char[,] board = sudokuSolve.GetBoard();

	// 	// sudokuSolve.IsSudokuSolvable(board);
	// 	sudokuSolve.GetSolution(board);

	// 	for (int i = 0; i < 9; i++)
	// 	{
	// 		for (int j = 0; j < 9; j++)
	// 		{
	// 			Console.Write(board[i, j] + (j%3==2 ? " " : ""));
	// 		}

	// 		Console.WriteLine();
	// 		if(i%3 == 2){
	// 			Console.WriteLine();
	// 		}
	// 	}
	// }

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
		// return new char[,] {
		// 	{ '5', '3', '.', '.', '7', '.', '.', '.', '.'},
		// 	{ '6', '.', '.', '1', '9', '5', '.', '.', '.'},
		// 	{ '.', '9', '8', '.', '.', '.', '.', '6', '.'},
		// 	{ '8', '.', '.', '.', '6', '.', '.', '.', '3'},
		// 	{ '4', '.', '.', '8', '.', '3', '.', '.', '1'},
		// 	{ '7', '.', '.', '.', '2', '.', '.', '.', '6'},
		// 	{ '.', '6', '.', '.', '.', '.', '2', '8', '.'},
		// 	{ '.', '.', '.', '4', '1', '9', '.', '.', '5'},
		// 	{ '.', '.', '.', '.', '8', '.', '.', '7', '9'}
		// };

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

		// return new char[,] {
		// 	{ '1', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '6', '.', '.', '.', '.', '.'},
		// 	{ '.', '6', '.', '9', '3', '5', '.', '.', '.'},
		// 	{ '.', '.', '2', '3', '4', '.', '.', '6', '.'},
		// 	{ '3', '.', '.', '.', '.', '1', '.', '.', '2'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '8', '4'},
		// 	{ '.', '5', '.', '.', '6', '.', '.', '.', '.'},
		// 	{ '.', '.', '1', '.', '.', '2', '.', '9', '.'},
		// 	{ '8', '.', '.', '.', '.', '.', '.', '7', '1'}
		// };

		return new char[,] {
			{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
			{ '.', '.', '.', '.', '.', '1', '2', '6', '9'},
			{ '2', '.', '.', '.', '5', '.', '.', '.', '1'},
			{ '.', '.', '.', '.', '8', '6', '9', '.', '.'},
			{ '.', '5', '.', '.', '4', '9', '.', '.', '.'},
			{ '.', '.', '.', '.', '.', '.', '.', '7', '.'},
			{ '.', '3', '8', '.', '7', '.', '6', '.', '.'},
			{ '.', '.', '5', '.', '.', '.', '.', '9', '7'},
			{ '.', '9', '.', '.', '.', '5', '.', '.', '4'}
		};

		// return new char[,] {
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'},
		// 	{ '.', '.', '.', '.', '.', '.', '.', '.', '.'}
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

				updatePossibilitiesForCell(board, i, j, c, possibilities);
			}
		}

		bool change = true;
		while(change){
			change = updateCells(board, possibilities) || updatePossibilities(possibilities);
		}

		// GetSolutionRecur(board, 0, 0, possibilities, 0);
		print(board, possibilities);

		return board;
	}

	private bool updatePossibilities(HashSet<char>[,] possibilities){
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

	private bool updatePossibilitiesRow(HashSet<char>[,] possibilities, int i, int j){
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

		if(possibilities[i,j].Count == counter+1){
			for(int k=0; k<list.Count; k++){
				possibilities[i,list[k]].RemoveWhere(x => possibilities[i,j].Contains(x));
			}

			return true;
		}

		return false;
	}

	private bool updatePossibilitiesColumn(HashSet<char>[,] possibilities, int i, int j){
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

		if(possibilities[i,j].Count == counter+1){
			for(int k=0; k<list.Count; k++){
				possibilities[list[k], j].RemoveWhere(x => possibilities[i,j].Contains(x));
			}

			return true;
		}

		return false;
	}

	private bool updatePossibilitiesBox(HashSet<char>[,] possibilities, int i, int j){
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

		if(possibilities[i,j].Count == counter+1){
			for(int k=0; k<list.Count; k++){
				var x = boxX+(list[k]/3);
				var y = boxY+(list[k]/3);
				possibilities[x, y].RemoveWhere(x => possibilities[i,j].Contains(x));
			}

			return true;
		}

		return false;
	}

	private bool updateCells(char[,] board, HashSet<char>[,] possibilities){
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

						updates |= checkPossibilitiesBox(board, possibilities, i, j, c);
					}
				}
			}
		}

		print(board, possibilities);
		return updates;
	}

	private bool updateCellRow(char[,] board, HashSet<char>[,] possibilities, int i, int j, char c){
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

	private bool updateCellColumn(char[,] board, HashSet<char>[,] possibilities, int i, int j, char c){
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

	private bool checkPossibilitiesBox(char[,] board, HashSet<char>[,] possibilities, int i, int j, char c){
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

	private void updateCell(char[,] board, int i, int j, char c, HashSet<char>[,] possibilities){
		board[i,j] = c;
		possibilities[i,j].Clear();
		updatePossibilitiesForCell(board, i, j, c, possibilities);
	}

	private void updatePossibilitiesForCell(char[,] board, int i, int j, char c, HashSet<char>[,] possibilities){
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

	private void print(char[,] board, HashSet<char>[,] possibilities){
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

		Console.WriteLine(count);

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

}
