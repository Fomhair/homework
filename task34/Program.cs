// Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.

// [345, 897, 568, 234] -> 2


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
  }

  public class Operator
  {
    public delegate bool Operation(int value1);
    public delegate int Modification(int value1, int value2);

    public static int Count(int[] data, Operation operation)
    {
      int count = 0;
      foreach(int element in data)
      {
        if(operation.Invoke(element)) count++;
      }
      return count;
    }

    public static void Modify(int[] data, Modification operation)
    {
      for(int i = 0; i < data.Length; i++)
      {
        data[i] = operation.Invoke(data[i], 2);
      }
    }
  }

  public static class Generator
  {
    public static int[] RandomNumbers(int length = 3, int min = 0, int max = 9)
    {
      int[] randomNumbers = new int[length];
      for (int i = 0; i < length; i++) 
      {
        randomNumbers[i] = new Random().Next(min, max);
      }
      return randomNumbers;
    }
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

    public static double StringToNumber(string value)
    {
      double result;
      double.TryParse(value, out result);
      return result;
    }

    public static void Output(int[] data, string msg = "Output: ")
    {
      string[] format = new string[] {"[", ", ", "]", " => "};
      Console.Write("{0}{1}", msg, format[0]);
      foreach(int element in data) 
      {
        if (Array.IndexOf(data, element) == data.Length - 1)
        {
          Console.Write("{0}{1}{2}", element, format[2], format[3]);
        }
        else
        {
          Console.Write("{0}{1}", element, format[1]);
        }
      }
    }

    public static bool Exit(string value) 
    {
      if(value.ToLower() == "q")
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }

  class Program
  {
    static void Start()
    {
      while (true)
      {
        int[] rndNum = Generator.RandomNumbers(Generator.RandomNumber(3,9), min: 100, max: 999);
        int countEvens = Operator.Count(rndNum, MathFunction.IsEven);
        IOfunc.Output(data: rndNum);
        Console.WriteLine(countEvens + " even numbers");
        Operator.Modify(rndNum, MathFunction.Power);
        countEvens = Operator.Count(rndNum, MathFunction.IsOdd);
        IOfunc.Output(data: rndNum, msg: "Squared: ");
        Console.WriteLine(countEvens + " odd numbers");
        if(IOfunc.Exit(IOfunc.RequestString("\nPress enter to generate numbers or q to exit "))) break;
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}