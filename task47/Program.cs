// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

using System;

namespace Lesson.Math
{

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

    public static double[,] RandomNumberArray(List<int> arguments, double min = 0.0, double max = 10.0, int round = 2)
    {
      double[,] row;
      if (arguments.Count > 1)
      {
        row = new double[arguments[0], arguments[1]];
        for (int i = 0; i < arguments[0]; i++)
        {
          for (int j = 0; j < arguments[1]; j++)
          {
            row[i,j] = System.Math.Round(RandomNumber(min: min, max: max), round);
          }
        }
      }
      else
      {
        row = new double[0,0];
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
          string[] values = IOfunc.OptimizeString(IOfunc.RequestString("Set m and n separated by comma or spacebar:")).Split(' ', ',');

          descriptions.Add(new string[] {"You set m: ", values[0], "and n: ", values[1], " Generate new array...\n"});
          

          List<int> arguments = new List<int> {};
          foreach(string val in values)
          {
            int number;
            if(int.TryParse(val, out number)) arguments.Add(number);
          }
          
          if(arguments.Count > 1) 
          {
            double[,] rndNums = Generator.RandomNumberArray(arguments: arguments);
            for(int j = 0; j < arguments[0]; j++)
            {
              string[] strRow = new string[arguments[1]];
              for(int i = 0; i < arguments[1]; i++)
              {
                strRow[i] = rndNums[j,i].ToString() + " ";
              }
              descriptions.Add(strRow);
            }
          }
        
          foreach(string[] el in descriptions)
          {
            IOfunc.Description(el);
          }


          Console.WriteLine("\nPress enter to show array or q to exit ");
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