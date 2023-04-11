using System;
using System.Collections.Generic;
using System.Windows;

public class Player
{
	public static bool Check_Win(int player, List<List<string>> board)
	{
		/* 
		 * Board Grid 7x,6y
		 * 0, 0, 0, 0, 0, 0, 0,
		 * 0, 0, 0, 0, 0, 0, 0
		 * 0, 0, 0, 0, 0, 0, 0
		 * 0, 0, 0, 0, 0, 0, 0
		 * 0, 0, 0, 0, 0, 0, 0
		 * 0, 0, 0, 0, 0, 0, 0
		 */
		bool win = false;

		win = H_win(board) || V_win(board) || D_win(board);


		if (win & player == 1)
		{
			return true;
		}
		else if (win & player == 2)
		{

			return true;
		}
		else
		{
			return false;
		}

	}
	private static bool H_win(List<List<string>> board) // declares any wins by horizontal plane
	{
		for (int y = 0; y < 6; y++)
		{
			for (int x = 0; x < 4; x++)
			{
				if (board[y][x] == "R" || board[y][x] == "Y")
				{
					string current = board[y][x];
					if (board[y][x + 1] == current && board[y][x + 2] == current && board[y][x + 3] == current)
					{
						return true;
					}
				}
			}
		}
		return false;
	}
	private static bool V_win(List<List<string>> board)
	{
		uint wins = 0;
		for (int x = 0; x < 7; x++)
		{
			for (int y = 5; y >= 0; y--)
			{
				if (board[y][x] == "R" || board[y][x] == "Y")
				{
					if (y - 3 < 0)
					{
						continue;
					}
					string current = board[y][x];
					if (board[y - 1][x] == current && board[y - 2][x] == current && board[y - 3][x] == current)
					{
						return true;
					}
				}
			}
		}
		return false;
	}
	private static bool D_win(List<List<string>> board)
	{
		int y_ax = 5;
		int x_ax = 0;


		while (true)
		{
			if (x_ax > 6)
			{
				x_ax = 0;
				y_ax--;
			}
			if (y_ax > 5 || y_ax < 0)
			{
				break;
			}
			if (board[y_ax][x_ax] == "R" || board[y_ax][x_ax] == "Y")
			{
				if (Check_BLU(x_ax, y_ax, board))
				{
					return true;
				}
			}
			x_ax++;
		}

		y_ax = 0;
		while (true)
		{
			if (x_ax > 6)
			{
				x_ax = 0;
				y_ax++;
			}
			if (y_ax > 5 || y_ax < 0)
			{
				break;
			}
			if (board[y_ax][x_ax] == "R" || board[y_ax][x_ax] == "Y")
			{
				if (Check_TLD(x_ax, y_ax, board))
				{
					return true;
				}
			}
			x_ax++;
		}
		return false;




	}
	/// <summary>
	/// Checks if the player wins from a bottom left - top right
	/// </summary>
	/// <param name="Coord_x">X cordinate</param>
	/// <param name="Coord_y">Y cordinate</param>
	/// <param name="board">the board as the win is recorded</param>
	/// <returns></returns>
	private static bool Check_BLU(int Coord_x, int Coord_y, List<List<string>> board)
	{
		if (Coord_x > 3 || Coord_y < 3)
		{
			return false;
		}
		string current = board[Coord_y][Coord_x];
		string next_check1 = board[Coord_y - 1][Coord_x + 1];
		string next_check2 = board[Coord_y - 2][Coord_x + 2];
		string next_check3 = board[Coord_y - 3][Coord_x + 3];
		if (next_check1 == current && next_check2 == current && next_check3 == current)
		{
			return true;
		}
		return false;
	}
	private static bool Check_TLD(int Coord_x, int Coord_y, List<List<string>> board)
	{
		if (Coord_x > 3 || Coord_y > 2)
		{
			return false;
		}
		string current = board[Coord_y][Coord_x];
		string next_check1 = board[Coord_y + 1][Coord_x + 1];
		string next_check2 = board[Coord_y + 2][Coord_x + 2];
		string next_check3 = board[Coord_y + 3][Coord_x + 3];
		if (next_check1 == current && next_check2 == current && next_check3 == current)
		{
			return true;
		}
		return false;
	}
}
