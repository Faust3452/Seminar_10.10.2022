// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
int[,] FillRandomDDimMass(int row, int col, int minArg, int maxArg)
{
    int[,] newArr = new int[row, col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            newArr[i, j] = new Random().Next(minArg, maxArg + 1);
        }
    }
    return newArr;
}

void PrintDDimArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
}

void DDimArraySortRow(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            int maxIndex = j;
            for (int k = j + 1; k < arr.GetLength(1); k++)
            {
                if (arr[i, maxIndex] < arr[i, k]) maxIndex = k;
            }
            if (maxIndex != j)
            {
                int tmp = arr[i, maxIndex];
                arr[i, maxIndex] = arr[i, j];
                arr[i, j] = tmp;
            }


        }
    }
}
Console.Write("Введите количество строк в массиве: ");
int rowSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов в массиве: ");
int columnSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите минимальное значение для генерации элементов в массиве: ");
int min = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите максимальное значение для генерации элементов в массиве: ");
int max = Convert.ToInt32(Console.ReadLine());
if (min > max) Console.WriteLine("Максимальное значение меньше минимального, повторите ввод!");
else
{
    int[,] array = FillRandomDDimMass(rowSize, columnSize, min, max);
    Console.WriteLine("Сгенерированный массив: ");
    PrintDDimArray(array);
    DDimArraySortRow(array);
    Console.WriteLine();
    PrintDDimArray(array);
}
