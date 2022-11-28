// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"

// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N. Выполнить с помощью рекурсии.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29


using System;

namespace Lesson.Math
{
  public class MathFunction
  {
    public static void NaturalRange(int N)
    {
      if (N > 1)
      {
        Console.Write($"{N}, ");
        NaturalRange(N-1);
      }
      else Console.Write($"{N}");
    }
    public static int NaturalSum(int M, int N)
    {
      if (M < N-1) return M + NaturalSum(M+1, N);
      else if (M-1 > N) return M + NaturalSum(M, N+1);
      else return M+N;
    }
    public static int Akkerman(int m, int n)
    {
      if(m == 0) return n+1;
      else if(n == 0) return Akkerman(m-1, 1);
      else
      {
        int tmp = Akkerman(m, n-1);
        return Akkerman(m-1, tmp);
      }
    }
  }

  public static class Generator
  {
    public static int RandomNumber(int min = 0, int max = 9)
    {
      return new Random().Next(min, max);
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
    static void Start()
    {
      while (true)
      {
        try
        {
          int N = Generator.RandomNumber(min: 1, max: 15);
          int M = Generator.RandomNumber(min: 1, max: 15);

          Console.WriteLine($"Task 64:");
          Console.Write($"N = {N} -> ");
          MathFunction.NaturalRange(N);

          Console.WriteLine($"\n\nTask 66:");
          Console.Write($"M = {M}; N = {N} -> {MathFunction.NaturalSum(M, N)}");


          Console.WriteLine($"\n\nTask 68:");
          int m = IOfunc.StringToNumber(IOfunc.RequestString("Input m: "));
          int n = IOfunc.StringToNumber(IOfunc.RequestString("Input n: "));
          Console.Write($"M = {m}; N = {n} -> A(m, n) = {MathFunction.Akkerman(m, n)}");


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