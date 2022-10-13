// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
string[,] FillSpiralMass(int startArg, int sizeOne, int sizeTwo)
{
    string[,] res = new string[sizeOne, sizeTwo];
    int one = 0;
    int two = 0;
    int oneStart = 0;
    int twoStart = 0;
    int oneFin = 1;
    int twoFin = 0;
    int maxEl = startArg + sizeOne*sizeTwo -1;
    while(startArg <= maxEl)
    {
        if (startArg < 10 && startArg > 0) res[one, two] = "0" + Convert.ToString(startArg);
        else res[one, two] = Convert.ToString(startArg);
        if ((one == oneStart) && (two < sizeTwo - twoFin - 1)) two++;
        else if ((one < sizeOne - oneFin) && (two == sizeTwo - twoFin - 1)) one++;
        else if ((one == sizeOne - oneFin) && (two > twoFin)) two--;
        else if ((one > oneFin) && (two == twoFin)) one--;
        if ((one == oneFin) && (two == twoFin))
        {
            oneStart++;
            twoStart++;
            twoFin++;
            oneFin++;
        }
        startArg++;
    }
    return res;  
}

void PrintDDimArray(string[,] arr)
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

Console.Write("Введите начальное значение для генерации значений массива: ");
int start = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите размерность строк для генерации массива: ");
int dimOne = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите размерность столбцов для генерации массива: ");
int dimTwo = Convert.ToInt32(Console.ReadLine());
string[,] result = FillSpiralMass(start, dimOne, dimTwo);
PrintDDimArray(result);