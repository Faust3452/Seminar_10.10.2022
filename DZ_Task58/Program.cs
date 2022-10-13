// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

bool CheckPossibilityOfMultiplie(int[,] matrOne, int[,] matrTwo)
{
    return (matrOne.GetLength(1) == matrTwo.GetLength(0));
}

int[,] Multiplie(int[,] matrOne, int[,] matrTwo)
{
    int[,]res = new int[matrOne.GetLength(0), matrTwo.GetLength(1)];
    for (int i = 0; i < matrOne.GetLength(0); i++)
    {
        for (int j = 0; j < matrTwo.GetLength(1); j++)
        {
            int multRes = default;
            for (int k = 0; k < matrOne.GetLength(1); k++)
            {
                multRes += matrOne[i, k] * matrTwo[k, j];
            }
            res[i, j] = multRes;
        }
    }
    return res;
}

Console.Write("Введите количество строк в матрице 1: ");
int rowSizeOne = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов в матрице 1: ");
int columnSizeOne = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество строк в матрице 2: ");
int rowSizeTwo = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов в матрице 2: ");
int columnSizeTwo = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите минимальное значение для генерации элементов в матрицах: ");
int min = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите максимальное значение для генерации элементов в матрицах: ");
int max = Convert.ToInt32(Console.ReadLine());
if (min > max) Console.WriteLine("Максимальное значение меньше минимального, повторите ввод!");
else
{
    int[,] matrixOne = FillRandomDDimMass(rowSizeOne, columnSizeOne, min, max);
    int[,] matrixTwo = FillRandomDDimMass(rowSizeTwo, columnSizeTwo, min, max);
    Console.WriteLine("Первая матрица: ");
    PrintDDimArray(matrixOne);
    Console.WriteLine("Вторая матрица: ");
    PrintDDimArray(matrixTwo);
    Console.WriteLine();
    if (CheckPossibilityOfMultiplie(matrixOne, matrixTwo))
    {
        int[,] resultMatrix = Multiplie(matrixOne, matrixTwo);
        PrintDDimArray(resultMatrix);
    }
    else Console.WriteLine("Данные матрицы не могут быть перемножены! Повторите ввод!");
    
}