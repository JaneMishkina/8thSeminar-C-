/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
2*3 + 4*3 2*4 + 4*3
3*3 + 2*3 3*4 + 2*3*/


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
                    matrix[i, j] = rnd.Next(0, 10);
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

int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
{
    {
    int sumMultipleElements = 0;
    int[,] multipliedMatrixs = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            sumMultipleElements = 0;
            for (int h = 0; h < matrix2.GetLength(0); h++)
            {
                sumMultipleElements += matrix1[i, h] * matrix2[h, j];
            }
            multipliedMatrixs[i, j] = sumMultipleElements;
        }
    }
    return multipliedMatrixs;
    }
}

int rows1 = GetNaturalNumber("Введите количество строк: ");
int columns1 = GetNaturalNumber("Введите количество столбцов: ");
int[,] matrix1 = InitMatrix(rows1, columns1);
PrintMatrix(matrix1);

int rows2 = GetNaturalNumber("Введите количество строк: ");
int columns2 = GetNaturalNumber("Введите количество столбцов: ");
int[,] matrix2 = InitMatrix(rows2, columns2);
PrintMatrix(matrix2);

if (matrix1.GetLength(1) == matrix2.GetLength(0))
{
int[,] multipliedMatrixs = MultiplyMatrix(matrix1, matrix2);
    Console.WriteLine("Произведение матриц:");
    PrintMatrix(multipliedMatrixs);
}
else
{
    Console.WriteLine("Произведение матриц невозможно, потому что число столбцов первой матрицы не равно числу строк второй");
}


