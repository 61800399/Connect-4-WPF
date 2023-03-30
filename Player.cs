using System;
using System.Collections.Generic;

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
		int p1_wins;
		int p2_wins;
        for (int y = 0; y < 6; y++)
		{
            p1_wins = 0;
            p2_wins = 0;
            for (int x = 0; x < 7; x++)
			{
				if (board[y][x] == "R")
				{
					p1_wins++;
					p2_wins = 0;
				}
				else if (board[y][x] == "Y")
				{
					p2_wins++;
					p1_wins = 0;
				}
			}
			if (p1_wins >= 4 || p2_wins >= 4)
			{
				return true;
			}
		}
		return false;
	}
	private static bool V_win(List<List<string>> board)
	{
		int p1_wins;
		int p2_wins;
		for (int x = 0; x < 7; x++)
		{
			p1_wins = 0;
			p2_wins = 0;
			for (int y = 0; y < 6; y++)
			{
                if (board[y][x] == "R")
                {
                    p1_wins++;
                    p2_wins = 0;
                }
				else if (board[y][x] == "Y")
				{
					p2_wins++;
                    p1_wins = 0;
                }
            }
            if (p1_wins >= 4 || p2_wins >= 4)
            {
                return true;
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
		string next_check1 = board[Coord_y - 1][Coord_x + 1];
        string next_check2 = board[Coord_y - 2][Coord_x + 2];
        string next_check3 = board[Coord_y - 3][Coord_x + 3];
		if (next_check1 == "R" && next_check2 == "R" && next_check3 == "R")
		{
			return true;
		}
		else if (next_check1 == "Y" && next_check2 == "Y" && next_check3 == "Y")
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
        string next_check1 = board[Coord_y + 1][Coord_x + 1];
        string next_check2 = board[Coord_y + 2][Coord_x + 2];
        string next_check3 = board[Coord_y + 3][Coord_x + 3];
        if (next_check1 == "R" && next_check2 == "R" && next_check3 == "R")
        {
            return true;
        }
        else if (next_check1 == "Y" && next_check2 == "Y" && next_check3 == "Y")
        {
            return true;
        }
        return false;
    }
}
