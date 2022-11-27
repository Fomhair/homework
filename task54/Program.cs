// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

using System;

namespace Lesson.Math
{
  public class MathFunction
  {
    public static int Sum(int[] arr)
    {
      int res = 0;
      for(int i = 0; i < arr.Length; i++)
      {
        res += arr[i];
      }
      return res;
    }
    
    public static int[] RowSumAndNumber(int[,] numbers, bool findMax = true)
    {
      int[] sumsAndNums = new int[numbers.GetLength(0)];
      for(int i = 0; i < numbers.GetLength(0); i++)
      {
        int[] row = new int[numbers.GetLength(1)];
        for(int j = 0; j < numbers.GetLength(1); j++)
        {
          row[j] = numbers[i,j];
        }
        sumsAndNums[i] = Sum(row);
      }
      if(findMax) return FindMax(sumsAndNums);
      else return FindMin(sumsAndNums);
    }

    public static int[] FindMax(int[] numbers)
    {
      int[] result = new int[2];
      ref int maxIndex = ref result[0];
      ref int max = ref result[1];
      maxIndex = 0;
      max = numbers[0];
      for(int i = 1; i < numbers.Length; i++)
      {
        if(numbers[i] > max)
        {
          maxIndex = i;
          max = numbers[i];
        }
      }
      return result;
    }
    public static int[] FindMin(int[] numbers)
    {
      int[] result = new int[2];
      ref int minIndex = ref result[0];
      ref int min = ref result[1];
      minIndex = 0;
      min = numbers[0];
      for(int i = 1; i < numbers.Length; i++)
      {
        if(numbers[i] < min)
        {
          minIndex = i;
          min = numbers[i];
        }
      }
      return result;
    }
  }


  public static class Generator
  {
    public static int[] RandomNumbers(int length = 3, int min = 0, int max = 9)
    {
      int[] randomNumbers = new int[length];
      for (int i = 0; i < length; i++) 
      {
        randomNumbers[i] = RandomNumber(min, max);
      }
      return randomNumbers;
    }
    public static double[] RandomNumbers(int length = 3, double min = 0.0, double max = 10.0)
    {
      double[] randomNumbers = new double[length];
      for (int i = 0; i < length; i++) 
      {
        randomNumbers[i] = RandomNumber(min, max);
      }
      return randomNumbers;
    }

    public static int RandomNumber(int min = 0, int max = 9)
    {
      return new Random().Next(min, max);
    }
    public static double RandomNumber(double min = 0.0, double max = 10.0)
    {
      return new Random().NextDouble() * (max - min) + min;
    }

    public static int[,] RandomNumberArray(List<int> arguments, int min = 0, int max = 10)
    {
      int[,] row;
      if (arguments.Count > 1)
      {
        row = new int[arguments[0], arguments[1]];
        for (int i = 0; i < arguments[0]; i++)
        {
          for (int j = 0; j < arguments[1]; j++)
          {
            row[i,j] = RandomNumber(min: min, max: max);
          }
        }
      }
      else
      {
        row = new int[0,0];
        Console.WriteLine("NO DATA!");
      }
      return row;
    }
  }

  public static class Sort
  {
    // Рекурсивно по одному элементу.
    public static int[,] Recursive(int[,] array)
    {
      bool state = false;
      for(int i = 0; i < array.GetLength(0); i++)
      {
        for(int j = 1; j < array.GetLength(1); j++)
        {
          if(array[i,j] > array[i,j-1])
          {
            int tmp = array[i,j-1];
            array[i,j-1] = array[i,j];
            array[i,j] = tmp;
            state = true;
          }
        }
      }
      Console.Write($"{state} ");
      if(state) return Recursive(array);
      Console.WriteLine(string.Empty);
      return array;
    }

    // Рекурсивно по два элемента - результат оптимизации предыдущего метода. Никуда не подглядывал, но кажется получилась пузырьковая сортировка.
    public static int[,] FastRecursive(int[,] array)
    {
      bool state = false;
      for(int i = 0; i < array.GetLength(0); i++)
      {
        for(int j = array.GetLength(1)/2; j < array.GetLength(1); j++)
        {
          if(array[i,j] > array[i,j-1])
          {
            int tmp = array[i,j-1];
            array[i,j-1] = array[i,j];
            array[i,j] = tmp;
            state = true;
          }
          int k = array.GetLength(1) - j - 1;
          if(array[i,k] < array[i,k+1])
          {
            int tmp = array[i,k+1];
            array[i,k+1] = array[i,k];
            array[i,k] = tmp;
            state = true;
          }
        }
      }
      Console.Write($"{state} ");
      if(state) return FastRecursive(array);
      Console.WriteLine(string.Empty);
      return array;
    }
  }

  public static class IOfunc
  {
    public static string RequestString(string msg = "Input your value: ")
    {
      Console.Write(msg);
      string value = Console.ReadLine();
      return value ?? string.Empty;
    }

    public static string OptimizeString(string value)
    {
      string newStr = value.Replace("  "," ");
      newStr = newStr.Replace(",,",",");
      
      if(newStr.Contains("  ") || newStr.Contains(",,")) return OptimizeString(newStr);
      return newStr;
    }

    public static double StringToNumber(string value)
    {
      double result;
      double.TryParse(value, out result);
      return result;
    }

    // Метод раскрашивающий текст
    public static void Description(string[] funcInfo) {
      for (int i = 0; i < funcInfo.Length; i++)
      {
        if(i % 2 == 0) Console.Write(funcInfo[i]);
        else 
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write(funcInfo[i]);
          Console.ForegroundColor = ConsoleColor.White;
        }
      }
      Console.WriteLine(string.Empty);
    }

    public static bool Exit() 
    {
      ConsoleKeyInfo exitKey = Console.ReadKey(true);
      if(exitKey.Key == ConsoleKey.Escape || exitKey.Key == ConsoleKey.Q)
      { return true; }
      else
      { return false; }
    }
  }

  class Program
  {
    static void Start()
    {
      while (true)
      {
        List<string[]> descriptions = new List<string[]> {};
        try
        {
          List<int> arguments = new List<int> {Generator.RandomNumber(min: 5, max: 10), Generator.RandomNumber(min: 5, max: 20)};

          IOfunc.Description(new string[] {"Start with ", arguments[0].ToString(), " rows and ", arguments[1].ToString(), " columns. Generate new array...\n"});

          Action<int[,]> AddToDescriptions = (int[,] rndNums) => {
            for(int i = 0; i < rndNums.GetLength(0); i++)
            {
              string[] strRow = new string[rndNums.GetLength(1)];
              for(int j = 0; j < rndNums.GetLength(1); j++)
              {
                strRow[j] = rndNums[i,j].ToString() + " ";
              }
              descriptions.Add(strRow);
            }
            foreach(string[] el in descriptions)
            {
              IOfunc.Description(el);
            }
          };
          
          Console.WriteLine("Unsorted");
          int[,] rndNums = Generator.RandomNumberArray(min: 0, max: 100, arguments: arguments);
          AddToDescriptions(rndNums);
          descriptions.Clear();

          Console.WriteLine(string.Empty);
          Console.WriteLine("Sorted slow");
          int[,] sortedNums = Sort.Recursive(rndNums);
          AddToDescriptions(sortedNums);
          int[] rowSum = MathFunction.RowSumAndNumber(sortedNums, findMax: false);
          IOfunc.Description(new string[] {"Min sum: ", rowSum[1].ToString(), " in the line ", (rowSum[0] + 1).ToString()});
          rowSum = MathFunction.RowSumAndNumber(sortedNums);
          IOfunc.Description(new string[] {"Max sum: ", rowSum[1].ToString(), " in the line ", (rowSum[0] + 1).ToString(), "\n"});
          descriptions.Clear();


          Console.WriteLine(string.Empty);
          Console.WriteLine("*************************");
          Console.WriteLine("Unsorted 2");
          rndNums = Generator.RandomNumberArray(min: 0, max: 100, arguments: arguments);
          AddToDescriptions(rndNums);
          descriptions.Clear();

          Console.WriteLine(string.Empty);
          Console.WriteLine("Sorted fast");
          int[,] sortedNums2 = Sort.FastRecursive(rndNums);
          AddToDescriptions(sortedNums2);
          rowSum = MathFunction.RowSumAndNumber(sortedNums2, findMax: false);
          IOfunc.Description(new string[] {"Min sum: ", rowSum[1].ToString(), " in the line ", (rowSum[0] + 1).ToString()});
          rowSum = MathFunction.RowSumAndNumber(sortedNums2);
          IOfunc.Description(new string[] {"Max sum: ", rowSum[1].ToString(), " in the line ", (rowSum[0] + 1).ToString(), "\n"});
          

          Console.WriteLine("\nPress enter to try again or q to exit ");
          if(IOfunc.Exit()) break;
        }
        catch(IndexOutOfRangeException e)
        {
          Console.WriteLine("Incorrect values: " + e);
        }
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}