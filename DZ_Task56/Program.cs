// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

int MinRowSumFind(int[,] array)
{
    int result = default;
    int sum = default;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sumRow = default;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumRow += array[i, j];
        }
        if (i == 0) sum = sumRow;
        if (sumRow < sum) 
        {
            sum = sumRow;
            result = i;
        }
    }
    return (result + 1);
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
    Console.WriteLine();
    int result = MinRowSumFind(array);
    Console.WriteLine($"Строка с минимальной суммой элементов: {result}");
}