// Задача 60. ...Сформируйте трёхмерный массив из случайных неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

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

    public static int[,] RandomNumberArray(List<int> arguments, int min = 0, int max = 10)
    {
      if (arguments.Count > 1)
      {
        int[,] d2matrix = new int[arguments[0], arguments[1]];
        for (int i = 0; i < arguments[0]; i++)
        {
          for (int j = 0; j < arguments[1]; j++)
          {
            d2matrix[i,j] = RandomNumber(min: min, max: max);
          }
        }
        return d2matrix;
      }
      else
      {
        Console.WriteLine("NO DATA!");
        return new int[0,0];
      }
    }

    public static int[,,] RandomNumberArray3d(List<int> arguments, int min = 0, int max = 10)
    {
      if (arguments.Count > 2)
      {
        int[,,] d3matrix = new int[arguments[0], arguments[1], arguments[2]];
        int[] checkedNumbers = new int[arguments[0] * arguments[1] * arguments[2]];
        int index = 0;
        for (int i = 0; i < arguments[0]; i++)
        {
          for (int j = 0; j < arguments[1]; j++)
          {
            for (int k = 0; k < arguments[2]; k++)
            {
              checkedNumbers[index] = CheckMatches(checkedNumbers, index, min, max);
              d3matrix[i,j,k] = checkedNumbers[index];
              index++;
            }
          }
        }
        return d3matrix;
      }
      else
      {
        Console.WriteLine("NOT ENOUGH DATA!");
        return new int[0,0,0];
      }
    }
    public static int CheckMatches(int[] numbers, int index, int min, int max)
    {
      int tmp = RandomNumber(min: min, max: max);
      bool match = false;
      for(int i = 0; i < index; i++) 
       if(tmp == numbers[i]) match = true;

      if(match) return CheckMatches(numbers, index, min, max);
      return tmp;
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
          Action<int[,,]> AddToDescriptions = (int[,,] rndNums) => {
            for(int i = 0; i < rndNums.GetLength(0); i++)
            {
              descriptions.Add(new string[] {"\n",i.ToString(), " block **********"});
              for(int j = 0; j < rndNums.GetLength(1); j++)
              {
                string[] strRow = new string[rndNums.GetLength(2)];
                for(int k = 0; k < rndNums.GetLength(2); k++)
                {
                  strRow[k] = $"{rndNums[i,j,k].ToString()} ({i},{j},{k})  ";
                }
                descriptions.Add(strRow);
              }
            }
            foreach(string[] el in descriptions)
            {
              IOfunc.Description(el);
            }
          };
          
          int n, m, p;
          n = Generator.RandomNumber(min: 2, max: 7);
          m = Generator.RandomNumber(min: 2, max: 7);
          p = Generator.RandomNumber(min: 2, max: 7);
          List<int> arguments = new List<int> {n, m, p};

          IOfunc.Description(new string[] {"\nArray: ", arguments[0].ToString(), " blocks ", arguments[1].ToString(),", rows and ", arguments[2].ToString(), " columns. Generate array..."});
          int[,,] rndNums = Generator.RandomNumberArray3d(min: 0, max: n*m*p, arguments: arguments);
          AddToDescriptions(rndNums);
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