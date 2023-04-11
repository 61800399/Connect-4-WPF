using System;
using System.Collections.Generic;

public class Board
{
    public List<List<string>> Grid { get; set; }
    public int Player { get; set; } = 1;

    public Board()
	{
		Initilize();
    }
	public List<List<string>> Initilize()
	{
		Grid = new List<List<string>>();
		for (int y = 0; y < 6; y++)
		{
			List<string> X = new List<string>();
			for (int x = 0; x < 7; x++)
			{
				X.Add(" ");
			}
			Grid.Add(X);
		}
		return Grid;
	}
    public int Ask_Column()
    {
        Console.Write("What column are you dropping your piece?: ");
        string column = Console.ReadLine();
        int.TryParse(column, out int x);
        if (x > 7)
        {
            throw new Exception();
        }
        return x - 1;
    }
    public static int Get_Y(int x, List<List<string>> board, int Player, bool place)
    {
        int y_pos = 0;
        for (int y = 0; y < 6; y++)
        {
            if (board[0][x] != " ")
            {
                return 48;
            }
            else if (y >= 5 || board[y + 1][x] != " ")
            {
                y_pos = y;
                break;
            }
        }
        if (place)
        {
            if (Player == 1)
            {
                board[y_pos][x] = "R";
            }
            else
            {
                board[y_pos][x] = "Y";
            }
        }
        
        
        return y_pos;
    }
    public static int Switch_Player(int Player)
    {
        if (Player == 1)
        {
            Player = 2;
            return Player;
        }
        else
        {
            Player = 1;
            return Player;
        }
    }
}
