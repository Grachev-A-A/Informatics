using System;
namespace Informatics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ИКБО-10-18. Грачев Александр. Вариант 8.\n\r" +
                "\n\rВведите размер стороны матрицы (целое число из диапозона [2; 5]).");
            int N;
            while (!(int.TryParse(Console.ReadLine(), out N)&&N>1 &&N<6))
                Console.WriteLine("Введено некорректное число! Введите целое число из диапозона [2; 5].");
            int[,] arr = new int[N, N];
            Console.WriteLine("Пустая матрица размера " + N.ToString() + "*" + N.ToString() +
                " создана!\n\rЗаполнить (0) случайными числами или (1) вручную?");
            while (true)
            {
                string s = Console.ReadLine();
                if (s == "0")
                {
                    randFill(arr);
                    break;
                }
                else if (s == "1")
                {
                    userFill(arr);
                    break;
                }
                else
                    Console.WriteLine("Пожалуйста, введите корректную команду.\n\r" +
                        "0 - заполнение случайными числами,\n\r" +
                        "1 - пользовательский ввод.");
            }
            Console.WriteLine("Матрица заполнена:");
            showMatrix(arr);
            sortMx(arr);
            mulMx(arr);
            Console.WriteLine("Полученная матрица:");
            showMatrix(arr);
            Console.ReadKey();
        }
        private static void sortMx(int[,] arr)
        {
            int N = (int)Math.Sqrt(arr.Length);
            int a = N, l = 0;
            while (a != 0)
                l += a--;
            int[] tmp = new int[l];
            int i= 0;
            for (int x = 0; x < N; x++)
            {
                for(int y = 0; y<N-x; y++)
                {
                    tmp[i] = arr[x, y];
                    i++;
                }
            }
            for(i=0; i<l;i++)
                for(int j=l-1; j>i;j--)
                    if (tmp[j - 1] > tmp[j])
                    {
                        int t = tmp[j];
                        tmp[j] = tmp[j - 1];
                        tmp[j - 1] = t;
                    }
            i = 0;
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N - x; y++)
                {
                    arr[x, y] = tmp[i];
                    i++;
                }
            }
        }
        private static void mulMx(int[,] arr)
        {
            int N = (int)Math.Sqrt(arr.Length);
            for (int x = 1; x<N; x++)
            {
                for (int y = 1; y <= x; y++)
                    arr[x, N - y] = -arr[x, N - y];
            }
        }
        private static void showMatrix(int[,] arr)
        {
            int N = (int)Math.Sqrt(arr.Length);
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    Console.Write(arr[x, y].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }
        private static void userFill(int[,] arr)
        {
            int N = (int)Math.Sqrt(arr.Length);
            for (int x = 1; x <= N; x++)
                for (int y = 1; y <= N; y++)
                {
                    Console.WriteLine("Заполнение ячейки [" + x.ToString() + "," + y.ToString() + "]");
                    int c;
                    if (!int.TryParse(Console.ReadLine(), out c))
                    {
                        Console.WriteLine("Введите целое число!");
                        y--;
                        continue;
                    }
                    if (c < 1 || c > 100){
                        Console.WriteLine("Допускаются значения в диапазоне [1, 100]!");
                        y--;
                        continue;
                    }
                    arr[x-1, y-1] = c;
                }
        }
        private static void randFill(int[,] arr)
        {
            int N = (int)Math.Sqrt(arr.Length);
            Random r = new Random();
            for(int x=0; x<N; x++)
                for (int y = 0; y < N; y++)
                {
                    arr[x, y] = r.Next(1, 101);
                }
        }
    }
}
