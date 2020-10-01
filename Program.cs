using System;

namespace CrossZero
{
    class Program
    {
        static readonly string[] array = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static string str = null;
        static int count = 0;
        static bool win = false;

        private void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("-------------------");
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"|  {array[i * 3] }  " + $"|  {array[1 + i * 3]}  |" + $"  {array[2 + i * 3] }  |");
                Console.WriteLine("-------------------");
            }
        }

        private void TakeInput(string str)
        {
            int position;

            Console.Write($"Куда поставим {str} ? : ");
            position = Convert.ToInt32(Console.ReadLine());

            if ("XO".Contains(array[position - 1]))
                return;

            array[position - 1] = str;
            count++;
        }

        private void GetWinner()
        {
            var subArray = new int[8, 3] 
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

            for (var i = 0; i < 8; i++)
            {
                if (array[subArray[i, 0]] == array[subArray[i, 1]] && array[subArray[i, 1]] == array[subArray[i, 2]])
                {
                    str = array[subArray[i, 0]];
                    win = true;
                }
            }
        }

        private void StartGame()
        {
            while (!win)
            {
                DrawBoard();
                if (count == 9 && !win)
                {
                    Console.WriteLine("Ничья!!!");
                    break;
                }
                else
                {
                    if (count > 4)
                        GetWinner();

                    if (!win)
                        TakeInput(count % 2 == 0 ? "X" : "O");
                    else
                        Console.WriteLine($"Выиграл {str} !!!");
                }
            }
        }

        private static void Main()
        {
            new Program().StartGame();
        }
    }
}
