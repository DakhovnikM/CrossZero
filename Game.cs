using System;

namespace CrossZero;

class Game
{
    private readonly string[] positions = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    private readonly int[,] winningCombinations = new int[8, 3]
    {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
    };

    private string Player => count % 2 == 0 ? "X" : "O";
    private int count = 0;
    private bool gameOver = false;

    public void CursorAction()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var str = positions[i + j * 3];

                if (str == "X")
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                if (str == "O")
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.SetCursorPosition(i, j);
                Console.Write($"{str}");
            }
        }
        Console.WriteLine("\n");
    }

    private void DrawBoard()
    {
        Console.Clear();

        #region поле с клетками

        //Console.WriteLine("-------------------");
        //for (var i = 0; i < 3; i++)
        //{
        //    Console.Write($"|  {positions[i * 3] }  ");
        //    Console.Write($"|  {positions[1 + i * 3]}  ");
        //    Console.Write($"|  {positions[2 + i * 3] }  |");
        //    Console.WriteLine();
        //    Console.WriteLine("-------------------");
        //}
        #endregion


        #region поле без клеток

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(i, j);

                var str = positions[i + j * 3];

                if (str == "X")
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                if (str == "O")
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write($"{str}");
            }
        }
        Console.WriteLine("\n"); ;
        #endregion


        if (count == 9)
            Console.WriteLine("Ничья!!!");
        else
        if (gameOver)
            Console.WriteLine($"Выиграл игрок {Player} !!!");
        else
            Console.Write($"Куда поставим {Player} ? : ");
    }

    private void SelectPosition()
    {
        var isNum = int.TryParse(Console.ReadLine(), out int num);

        if (!isNum) return;
        if (num < 1 || num > 9) return;
        if ("XO".Contains(positions[num - 1])) return;

        positions[num - 1] = Player;
        count++;
    }

    private void CheckWinner()
    {
        if (count <= 4) return;

        if (count == 9)
        {
            gameOver = true;
            count--;
            return;
        }

        for (var i = 0; i < 8; i++)
        {
            if (positions[winningCombinations[i, 0]] == positions[winningCombinations[i, 1]]
                && positions[winningCombinations[i, 1]] == positions[winningCombinations[i, 2]])
            {
                gameOver = true;
                count--;
            }
        }
    }

    public void Start()
    {
        while (!gameOver)
        {
            DrawBoard();
            SelectPosition();
            CheckWinner();
        }

        DrawBoard();
    }
}
