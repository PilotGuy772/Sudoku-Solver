using System;
using System.Collections.Generic;
using Utils;

class Sudoku
{
    public struct 
        Unit
    {
        public int Sector;  // 3x3 board sector
        public int Value;   // Numerical value 1-9 of the unit, 0 if empty
        public int Type;    // Current 'status' of the unit, 0 = empty, 1 = starting number, 2 = placed by auto-solver, 3 = placed by user
    }

    public static void 
        Main (string[] args)
    {
        Unit[,] board = new Unit[9,9]; // assign the main array for the board

        for(int i = 0; i < 9; i++) //populate with empty spaces
        {
            for(int j = 0; j < 9; j++)
            {
                board[i, j] = new Unit{
                    Sector = FindSector(i, j),
                    Value = 0,
                    Type = 0
                };
            }
        }

        Console.Clear();
        
        AcceptInput(ref board);   //allow user input    
    }

    private static void 
        AcceptInput(ref Unit[,] board)
    {   //allows user to input the starting condition for the board
        
        while(true) // loops until user inputs 'done'
        {
            ConsoleUtils.ColorLine("Please input starting conditions\n", ConsoleColor.Green);
            OutputBoard(ref board, ConsoleColor.Blue);

            ConsoleUtils.ColorWrite("  >", ConsoleColor.Green);
            string input = Console.ReadLine() ?? "done";
            if(input == "done")
            {
                return;
            }

            string[] letters = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I"};
            input = input.ToUpper();
            
            int y; int x; int value;

            try
            {
                y = Array.IndexOf(letters, input[0].ToString()); //gets y value from array of letters by searching for the letter and using the index
                x = ( Convert.ToInt32(input[1].ToString())) - 1; //gets x value by directly converting input then sibtracting 1 to get 0-index

                Console.WriteLine($"({x}, {y})");

                if(input[3] == 'E') // the input of 'e' will reset the position to empty
                {
                    board[x,y].Value = 0;
                    board[x,y].Type = 0;
                }else{
                    value = Convert.ToInt32(input[3].ToString());
                    board[x,y].Value = value;
                    board[x,y].Type = 1;
                }

                
            }catch
            {
                ConsoleUtils.ColorWrite("ERROR: ", ConsoleColor.Red);
                Console.Write("Improper format.\n  use format [y][x] [val], ex. A7 3\n\n");
                return;
            }        

            
            Console.Clear();
            
        }
            

    }

    public static void
        OutputBoard(ref Unit[,] board, ConsoleColor type1color = ConsoleColor.White, ConsoleColor type2color = ConsoleColor.White, ConsoleColor type3color = ConsoleColor.White)
    {
        int x;
        int y;
        const string spacer = "|-----------|-----------|-----------|\n"; // top spacer = "|--1--2--3--|--4--5--6--|--7--8--9--|"
        const string letters = "ABCDEFGHI";

        Console.WriteLine("|--1--2--3--|--4--5--6--|--7--8--9--|");
        for(y = 1; y <= 9; y++)
        {
            Console.Write(letters[y-1]);Console.Write(" ");
            
            for(x = 1; x <= 9; x++)
            {
                if(board[x-1,y-1].Type == 0)
                {
                    Console.Write(" + ");
                }else{
                    switch(board[x-1,y-1].Type)
                    {
                        case 1:
                            ConsoleUtils.ColorWrite($" {board[x-1,y-1].Value} ", type1color);
                            break;
                        case 2:
                            ConsoleUtils.ColorWrite($" {board[x-1,y-1].Value} ", type2color);
                            break;
                        case 3:
                            ConsoleUtils.ColorWrite($" {board[x-1,y-1].Value} ", type3color);
                            break;
                    }
                }

                if(x % 3 == 0)
                {
                    Console.Write(" | ");
                }
            }

            Console.Write("\n");

            if(y % 3 == 0)
            {
                Console.Write(spacer);
            }
        }
        
    }

    public static int 
        FindSector(int column, int row)
    {
        switch(column)
        {
            case >= 1 and <= 3:
                switch(row)
                {
                    case >= 1 and <= 3:
                        return 1;
                        
                    case >= 4 and <= 6:
                        return 4;

                    case >= 7 and <= 9:
                        return 7;

                }

                break;
            case >= 4 and <= 6:
                switch(row)
                {
                    case >= 1 and <= 3:
                        return 2;
                        
                    case >= 4 and <= 6:
                        return 5;

                    case >= 7 and <= 9:
                        return 8;

                }
                break;
            case >= 7 and <= 9:
                switch(row)
                {
                    case >= 1 and <= 3:
                        return 3;
                        
                    case >= 4 and <= 6:
                        return 6;

                    case >= 7 and <= 9:
                        return 9;

                }
                break;
        }

        return -1;
    }
    
}

