using System;

namespace SV
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] grid1 = {
            new char[] {'5', '3', '4', '6', '7', '8', '9', '1', '2'},
            new char[] {'6', '7', '2', '1', '9', '5', '3', '4', '8'},
            new char[] {'1', '9', '8', '3', '4', '2', '5', '6', '7'},
            new char[] {'8', '5', '9', '7', '6', '1', '4', '2', '3'},
            new char[] {'4', '2', '6', '8', '5', '3', '7', '9', '1'},
            new char[] {'7', '1', '3', '9', '2', '4', '8', '5', '6'},
            new char[] {'9', '6', '1', '5', '3', '7', '2', '8', '4'},
            new char[] {'2', '8', '7', '4', '1', '9', '6', '3', '5'},
            new char[] {'3', '4', '5', '2', '8', '6', '1', '7', '9'}
        };

            char[][] grid2 = {
            new char[] {'5', '3', '4', '6', '7', '8', '9', '1', '2'},
            new char[] {'6', '7', '2', '1', '9', '0', '3', '4', '8'},
            new char[] {'1', '0', '0', '3', '4', '2', '5', '6', '0'},
            new char[] {'8', '5', '9', '7', '6', '1', '0', '2', '0'},
            new char[] {'4', '2', '6', '8', '5', '3', '7', '9', '1'},
            new char[] {'7', '1', '3', '9', '2', '4', '8', '5', '6'},
            new char[] {'9', '0', '1', '5', '3', '7', '2', '8', '4'},
            new char[] {'2', '8', '7', '4', '1', '9', '6', '3', '5'},
            new char[] {'3', '0', '0', '2', '8', '6', '1', '7', '9'}
        };

            var sudoku1 = new Sudoku(grid1);
            Console.WriteLine(sudoku1.validSolution());
            var sudoku2 = new Sudoku(grid2);
            Console.WriteLine(sudoku2.validSolution());
        }
    }

    public class Sudoku
    {
        char[][] _grid;

        public Sudoku(char[][] grid)
        {
            _grid = grid;
        }

        public bool validSolution()
        {
            return RowsAreValid()
                && ColumnsAreValid()
                && SquaresAreValid();
        }

        bool RowsAreValid()
        {
            return ValidateSolution(GetNumberFromRow);
        }

        bool ColumnsAreValid()
        {
            return ValidateSolution(GetNumberFromColumn);
        }

        bool SquaresAreValid()
        {
            return ValidateSolution(GetNumberFromSquare);
        }

        bool ValidateSolution(Func<int, int, int> numberGetter)
        {
            for (var row = 0; row < 9; row++)
            {
                var usedNumbers = new bool[10];
                for (var column = 0; column < 9; column++)
                {
                    var number = numberGetter(row, column);
                    if (number != 0 && usedNumbers[number] == true)
                    {
                        return false;
                    }

                    usedNumbers[number] = true;
                }
            }

            return true;
        }

        int GetNumberFromRow(int row, int column)
        {
            return ToNumber(_grid[row][column]);
        }

        int GetNumberFromColumn(int row, int column)
        {
            return ToNumber(_grid[column][row]);
        }

        int GetNumberFromSquare(int block, int index)
        {
            var column = 3 * (block % 3) + index % 3;
            var row = index / 3 + 3 * (block / 3);
            return ToNumber(_grid[row][column]);
        }

        int ToNumber(char c)
        {
            if (c == '0')
                return 1;
            return (int)(c - '0');
        }
    }
}
