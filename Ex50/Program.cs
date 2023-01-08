// Задача 50.Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
//  и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

int[] GetUserInputNumbersInt(string userInputNumberString)
{
    Console.WriteLine(userInputNumberString);
    string[] stringArray = Console.ReadLine().Split(",");
    int[] numberArray = new int[stringArray.Length];
    for (int i = 0; i < numberArray.Length; i++)
    {
        if (stringArray[i] == string.Empty || stringArray[i] == " "
           || Convert.ToInt32(stringArray[i]) == null)
        {
            Console.WriteLine("Ошибка ввода данных. Попробуйте еще раз запустить программу и ввести данные корректно.");
            Environment.Exit(0);
        }
        else numberArray[i] = Convert.ToInt32(stringArray[i]);
    }
    return numberArray;
}

void FillMatrixTwoDimensionalInt(int[,] matrixTwoDimensional,
                                int minIntervalValue, int maxIntervalValue)
{
    Random randomDouble = new Random();
    for (int i = 0; i < matrixTwoDimensional.GetLength(0); i++)
    {
        for (int j = 0; j < matrixTwoDimensional.GetLength(1); j++)
        {
            matrixTwoDimensional[i, j] = randomDouble.Next(minIntervalValue, maxIntervalValue);
        }
    }
}

void PrintMatrixTwoDimensional(int[,] matrixTwoDimensional)
{
    for (int i = 0; i < matrixTwoDimensional.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < matrixTwoDimensional.GetLength(1); j++)
        {
            if (matrixTwoDimensional[i, j] >= 0)
                Console.Write($" {matrixTwoDimensional[i, j]} ");
            else Console.Write($"{matrixTwoDimensional[i, j]} ");
        }
        Console.Write(" ]");
        Console.WriteLine();
    }
}

void PrintResult(int[] array, int[,] matrix)
{
    int i = 0;
    int j = 1;
    while (i < array.Length)
    {
        if (array[i] < matrix.GetLength(0) + 1
            && array[i] < matrix.GetLength(1) + 1
            && array[i] > 0)
        {
            Console.WriteLine($"Значение {j}го (позиция {array[i]}, {array[i + 1]}) интересующего Вас элемента: {matrix[array[i] - 1, array[i + 1] - 1]}");
        }
        else
        {
            Console.WriteLine($"Элемента в позиции {array[i]}, {array[i + 1]} нет в данном массиве.");
        }
        i = i + 2;
        j++;
    }
}

Console.Clear();
int[] RowColum = GetUserInputNumbersInt("Введите количество строк и столбцов массива через запятую: ");
int[] arrayInteralMinMax = GetUserInputNumbersInt("Введите интервал значений массива: ");
int[,] matrix = new int[RowColum[0], RowColum[1]];
FillMatrixTwoDimensionalInt(matrix, arrayInteralMinMax[0], arrayInteralMinMax[1]);
PrintMatrixTwoDimensional(matrix);
int[] arrayRowColumn = GetUserInputNumbersInt("Введите номер строки и стобца интересующего Вас элемента матрицы через запятую: ");
PrintResult(arrayRowColumn, matrix);
