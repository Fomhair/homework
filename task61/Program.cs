// Доп. задача 61*: Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника

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
    public static int[,] GeneratePascal(int N)
    {
      int[,] pascal = new int[N,N];
      for(int i = 0; i < N; i++)
      {
        for(int j = 0; j < N; j++)
        {
          if(i > 0 && j > 0) pascal[i,j] = pascal[i-1,j] + pascal[i,j-1];
          else if(j > 0) pascal[i,j] = pascal[i,j-1] + i;
          else if(i > 0) pascal[i,j] = pascal[i-1,j] + j;
          else pascal[i,j] = 1;
        }
      }
      return pascal;
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
      return value;
    }

    public static string OptimizeString(string value)
    {
      string newStr = value.Replace("  "," ");
      newStr = newStr.Replace(",,",",");
      
      if(newStr.Contains("  ") || newStr.Contains(",,")) return OptimizeString(newStr);
      return newStr;
    }

    public static int StringToNumber(string value)
    {
      int result;
      int.TryParse(value, out result);
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
    static void DrawPascal(int[,] pascal)
    {
      for(int i = 0; i < pascal.GetLength(0); i++)
      {
        string space = new string(' ',(pascal.GetLength(0) - i));
        Console.Write(space);
        int k = 0;
        for(int j = i; j >= 0; j--)
        {
          Console.Write($"{pascal[k, j]} ");
          k++;
        }
        Console.WriteLine(string.Empty);
      }
    }
    static void Start()
    {
      while (true)
      {
        List<string[]> descriptions = new List<string[]> {};
        try
        {

          // IOfunc.Description(new string[] {"Start with ", arguments[0].ToString(), " rows and ", arguments[1].ToString(), " columns. Generate new array...\n"});

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
          
          int N = IOfunc.StringToNumber(IOfunc.RequestString(msg: "Input N: "));
          int[,] pascal = MathFunction.GeneratePascal(N);

          DrawPascal(pascal);
          descriptions.Clear();

          

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