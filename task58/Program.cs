// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

using System;

namespace Lesson.Math
{
  public class MathFunction
  {

    public static int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
    {
      int[,] result = new int[matrix1.GetLength(0),matrix1.GetLength(0)];
      for(int i = 0; i < matrix1.GetLength(0); i++)
        for(int j = 0; j < matrix2.GetLength(1); j++)
          for(int k = 0; k < matrix2.GetLength(0); k++)
            result[i,j] += matrix1[i,k]*matrix2[k,j];
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
          
          int n, m;
          n = Generator.RandomNumber(min: 2, max: 7);
          m = Generator.RandomNumber(min: 2, max: 7);
          List<int> arguments1 = new List<int> {n, m};
          List<int> arguments2 = new List<int> {m, n};

          IOfunc.Description(new string[] {"\nFirst array has ", arguments1[0].ToString(), " rows and ", arguments1[1].ToString(), " columns. Generate array..."});
          int[,] rndNums1 = Generator.RandomNumberArray(min: 0, max: 100, arguments: arguments1);
          AddToDescriptions(rndNums1);
          descriptions.Clear();

          IOfunc.Description(new string[] {"\nSecond array has ", arguments1[1].ToString(), " rows and ", arguments1[0].ToString(), " columns. Generate array..."});
          int[,] rndNums2 = Generator.RandomNumberArray(min: 0, max: 100, arguments: arguments2);
          AddToDescriptions(rndNums2);
          descriptions.Clear();

          Console.WriteLine("\nMultiply: ");
          int[,] result = MathFunction.MultiplyMatrix(rndNums1, rndNums2);
          AddToDescriptions(result);


          

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