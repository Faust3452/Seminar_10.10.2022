// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
// 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)
int[,,] FillRandomThrDimMass(int dimensionOne, int dimensionTwo, int dimensionThree, int minArg, int maxArg)
{
    Random rnd = new Random();
    int[,,] res = new int[dimensionOne, dimensionTwo, dimensionThree];
    int[] check = new int [dimensionOne * dimensionTwo * dimensionThree];
    int count = 0;
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            for (int k = 0; k < res.GetLength(2); k++)
            {
                if (count > 0)
                {
                    int indicator = 0;
                    int tmp = 0;
                    while (indicator == 0)
                    {
                        tmp = rnd.Next(minArg, maxArg);
                        for (int cnt = 0; cnt < count; cnt++)
                        {
                            if (check[cnt] == tmp) indicator = -1;                            
                        }
                        if (indicator == -1) indicator = 0;
                        else indicator = 1;
                    }
                    res[i, j, k] = tmp;
                } 
                else res[i, j, k] = rnd.Next(minArg, maxArg);
                check[count] = res[i, j, k];
                count++;
            }
        }   
    }
    return res;
}

void PrintThDimArray(int[,,] array)
{   
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
            }
        }
        Console.WriteLine();   
    }
}

Console.Write("Введите первую размерность для трёхмерного массива: ");
int dimOne = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите вторую размерность для трёхмерного массива: ");
int dimTwo = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите третью размерность для трёхмерного массива: ");
int dimThree = Convert.ToInt32(Console.ReadLine());
int min = 10;
int max = 100;
int[,,] result = FillRandomThrDimMass(dimOne, dimTwo, dimThree, min, max);
Console.WriteLine("Сгенерированный массив: ");
PrintThDimArray(result);
