// Доп. задача 55**: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. В случае, если это невозможно, 
// программа должна вывести сообщение для пользователя. Решить НЕ используя второй массив

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

    public static void ColoredRows(List<string[]> descriptions, int N, int M) {
      for (int i = 0; i < descriptions.Count; i++)
      {
        if((N - M) >= 0)
        {
          if(i % 2 != 0 && i < M) 
          {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(string el in descriptions[i]) Console.Write(el);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Empty);
          }
            else if(i >= M)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach(string el in descriptions[i]) Console.Write(el);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Empty);
          }
          else
          {
            foreach(string el in descriptions[i]) Console.Write(el);
            Console.WriteLine(string.Empty);
          }
        }
        else
        {
          if(i % 2 != 0) 
          {
            for(int j = 0; j < descriptions[i].Length; j++)
            {
              if(j < N) Console.ForegroundColor = ConsoleColor.Yellow;
              else Console.ForegroundColor = ConsoleColor.Red;
              Console.Write(descriptions[i][j]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Empty);
          }
          else
          {
            for(int j = 0; j < descriptions[i].Length; j++)
            {
              if(j < N) Console.ForegroundColor = ConsoleColor.White;
              else Console.ForegroundColor = ConsoleColor.Red;
              Console.Write(descriptions[i][j]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Empty);
          }
        }
      }
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
    static void RevertArray(int[,] array)
    {

      int N = array.GetLength(0);
      int M = array.GetLength(1);
      int side;
      if((N - M) >= 0) side = M;
      else side = N;
      for(int i = 0; i < side*2; i++)
      {
        if(i < side)
        {
          int k = 0;
          for(int j = i; j >= 0; j--)
          {
            if(j > k)
            {
              int tmp = array[k, j];
              array[k, j] = array[j, k];
              array[j, k] = tmp;
            }
            k++;
          }
        }
        else
        {
          int k = side-1;
          for(int j = 1; j < side; j++)
          {
            if(k > j)
            {
              int tmp = array[k, j];
              array[k, j] = array[j, k];
              array[j, k] = tmp;
            }
          }
        }
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

          Action<int[,], bool, int, int> AddToDescriptions = (int[,] rndNums, bool columns, int N, int M) => {
            for(int i = 0; i < rndNums.GetLength(0); i++)
            {
              string[] strRow = new string[rndNums.GetLength(1)];
              for(int j = 0; j < rndNums.GetLength(1); j++)
              {
                if(rndNums[i,j] < 10) strRow[j] = rndNums[i,j].ToString() + "   ";
                else if(rndNums[i,j] < 100) strRow[j] = rndNums[i,j].ToString() + "  ";
                else strRow[j] = rndNums[i,j].ToString() + " ";
              }
              descriptions.Add(strRow);
            }
            if(columns)
            {
              foreach(string[] el in descriptions)
              {
                IOfunc.Description(el);
              }
            }
            else
            {
              IOfunc.ColoredRows(descriptions, N, M);
            }
          };
          
          int N = IOfunc.StringToNumber(IOfunc.RequestString(msg: "Input N: "));
          int M = IOfunc.StringToNumber(IOfunc.RequestString(msg: "Input M: "));

          List<int> arguments = new List<int> {N, M};

          if((N - M) != 0) 
          {
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't fully revert array with different sides");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Empty);
          }
          
          
          
          int[,] rndNums = Generator.RandomNumberArray(min: 0, max: 100, arguments: arguments);
          AddToDescriptions(rndNums, true, N, M);
          descriptions.Clear();
          
          Console.WriteLine(string.Empty);
          
          RevertArray(rndNums);

          AddToDescriptions(rndNums, false, N, M);


          

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