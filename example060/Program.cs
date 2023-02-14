/*Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

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

int[,,] InitMatrix(int axisX, int axisY, int axisZ)
{
    int[,,] matrix = new int[axisZ, axisX, axisY];
    Random random = new Random();
    for (int z = 0; z < axisZ; z++)
    {
        for (int x = 0; x < axisX; x++)
        {
            for (int y = 0; y < axisY; y++)
            {
                matrix[z, x, y] = random.Next(10, 99);
            }
        }
    }
    return matrix;
}

void ChangeRepeatedElements(int[,,] matrix)
{
    Dictionary<int, int> digitElelment = new Dictionary<int, int>();
    Random rnd = new Random();
    for (int z = 0; z < matrix.GetLength(0); z++)
    {
        for (int x = 0; x < matrix.GetLength(1); x++)
        {
            for (int y = 0; y < matrix.GetLength(2); y++)
            {
                while(digitElelment.ContainsKey(matrix[z, x, y]))
                { 
                    matrix[z, x, y]=rnd.Next(10, 99); 
                }  
                    digitElelment.Add(matrix[z, x, y],1);
             
            }
        }
    }
}

void PrintMatrix(int[,,] matrix)
{
    for (int z = 0; z < matrix.GetLength(0); z++)
    {
        for (int x = 0; x < matrix.GetLength(1); x++)
        {
            for (int y = 0; y < matrix.GetLength(2); y++)
            {
                Console.Write($"{matrix[z, x, y]}({z},{x},{y}) ");
            }
            Console.WriteLine();
        }
    }
}

int y = GetNaturalNumber("Введите количество строк массива ");
int x = GetNaturalNumber("Введите количество столбцов массива ");
int z = GetNaturalNumber("Введите количество уровней массива ");

int[,,] matrix = InitMatrix(x, y, z);
ChangeRepeatedElements(matrix);
PrintMatrix(matrix);