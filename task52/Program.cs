// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.


using System;

namespace Lesson.Math
{
  public class MathFunction
  {
    public static bool IsEven(int number)
    {
      return number % 2 == 0;
    }
    public static bool IsOdd(int number)
    {
      return number % 2 != 0;
    }
    public static int Power(int a, int b)
    {
      int res = a;
      if(b > 1) {
        b--;
        res = Power(a, b) * a;
      }
      return res;
    }
    public static int Sum(int[] arr)
    {
      int res = 0;
      for(int i = 0; i < arr.Length; i++)
      {
        res += arr[i];
      }
      return res;
    }
    public static double Average(int[] arr)
    {
      return (double)Sum(arr) / arr.Length;
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
    public static void Description (string[] funcInfo) {
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
          List<int> arguments = new List<int> {Generator.RandomNumber(min: 2, max: 6), Generator.RandomNumber(min: 2, max: 6)};

          IOfunc.Description(new string[] {"Start with rows: ", arguments[0].ToString(), " and columns: ", arguments[1].ToString(), " Generate new array...\n"});
          
          int[,] rndNums = Generator.RandomNumberArray(min: 0, max: 100, arguments: arguments);
          

          for(int i = 0; i < arguments[0]; i++)
          {
            string[] strRow = new string[arguments[0]];
            for(int j = 0; j < arguments[1]; j++)
            {
              strRow[j] = rndNums[i,j].ToString() + " ";
            }
            descriptions.Add(strRow);
          }

          foreach(string[] el in descriptions)
          {
            IOfunc.Description(el);
          }


          
          double[] res = new double[arguments[1]];

          for(int i = 0; i < arguments[1]; i++)
          {
            int[] tmp = new int[arguments[0]];
            for(int j = 0; j < arguments[0]; j++)
            {
              tmp[j] = rndNums[j, i];
            }
            res[i] = MathFunction.Average(tmp);
          }
          
          foreach(double el in res)
          {
            Console.Write($"{el} ");
          }
          Console.WriteLine(string.Empty);

          Console.WriteLine("\nPress enter to try again or q to exit ");
          if(IOfunc.Exit()) break;
        }
        catch(IndexOutOfRangeException e)
        {
          Console.WriteLine("Incorrect values ");
        }
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}