/*Pадача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

int GetNaturalNumber(string message)
{
  int result = 0;

  while (true)
  {
    Console.Write(message);

    if (int.TryParse(Console.ReadLine(), out result) && result > 0)
    {
      break;
    }
    else
    {
      Console.WriteLine("Ввели не число или некорректное число. Повторите ввод!");
    }
  }

  return result;
}

int[,] InitMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(0, 100);
                }
            }

            return matrix;
        }

void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }


int[] GetSumValues(int[,] matrix)
{
  int[] sum = new int[matrix.GetLength(0)];

  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    int result = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
      result += matrix[i, j];
    }
    sum[i] = result;
  }
  return sum;
}

void PrintValuesArray(int[] matrix)
{
  Console.Write($"(");
  for (int i = 0; i < matrix.Length; i++)
  {
    if (i == matrix.Length - 1) 
    {
      Console.Write($"{matrix[i]}");
    }
    else Console.Write($"{matrix[i]}; ");
  }
  Console.Write($")");
}

int GetMinValue(int[] matrix)
{
  int result = matrix[0];
  int row = 1;

  for (int i = 0; i < matrix.Length; i++)
  {
    if (result > matrix[i])
    {
      result = matrix[i];
      row++;
    }
  }
  return row;
}

int rows = GetNaturalNumber("Введите количество строк: ");
int columns = GetNaturalNumber("Введите количество столбцов: ");
int[,] matrix = InitMatrix(rows, columns);
PrintMatrix(matrix);

int[] sum = GetSumValues(matrix);
Console.Write("Суммы значений строк матрицы: ");
PrintValuesArray(sum);
Console.WriteLine();
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {GetMinValue(sum)}");


