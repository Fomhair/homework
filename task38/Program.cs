// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным значениями элементов массива.

// [3 7 22 2 78] -> 76



using System;

namespace Lesson.Math
{
  public class MathFunction
  {
    public static bool IsEven(int number) { return number % 2 == 0; }
    public static bool IsOdd(int number) { return number % 2 != 0; }

    public static int Max(int value1, int value2) 
    { 
      if(value1 >= value2)
      {
        return value1;
      }
      else
      {
        return value2;
      }
    }
    public static double Max(double value1, double value2) 
    { 
      if(value1 >= value2)
      {
        return value1;
      }
      else
      {
        return value2;
      }
    }
    
    public static int Min(int value1, int value2) 
    { 
      if(value1 <= value2)
      {
        return value1;
      }
      else
      {
        return value2;
      }
    }
    public static double Min(double value1, double value2) 
    { 
      if(value1 <= value2)
      {
        return value1;
      }
      else
      {
        return value2;
      }
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
    public static double Sum(double[] arr)
    {
      double res = 0.0;
      for(int i = 0; i < arr.Length; i++)
      {
        res += arr[i];
      }
      return res;
    }
  }

  public class Operator
  {
    public delegate bool BoolOperation(int value1);
    public delegate bool BoolOperationDouble(double value1);
    public delegate int CompareInt(int value1, int value2 = 2);
    public delegate double CompareDouble(double value1, double value2 = 2.0);
    public delegate int Modification(int value1, int value2);
    

    public static int[] Find(int[] data, BoolOperation operation)
    {
      int length = Count(data, operation);
      if(length != 0)
      {
        int[] result = new int[length];
        int count = 0;
        for(int i = 0; i < data.Length; i++)
        {
          if(operation.Invoke(data[i])) 
          {
            result[count] = data[i];
            count++;
          }
        }
        return result;
      }
      else { return null; }
    }

    public static double Find(double[] data, CompareDouble operation)
    {
      double result = operation.Invoke(data[0], data[1]);;
      double tmp;
      for(int i = 1; i < data.Length-1; i++)
      {
          tmp = operation.Invoke(data[i], data[i+1]);
          result = operation.Invoke(result, tmp);
      }
      return result;
    }

    public static int Find(int[] data, CompareInt operation)
    {
      int result = operation.Invoke(data[0], data[1]);;
      int tmp;
      for(int i = 1; i < data.Length-1; i++)
      {
          tmp = operation.Invoke(data[i], data[i+1]);
          result = operation.Invoke(result, tmp);
      }
      return result;
    }
  
    public static int Count(int[] data, BoolOperation operation)
    {
      int count = 0;
      foreach(int element in data)
      {
        if(operation.Invoke(element)) count++;
      }
      return count;
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
      if (data != null) 
      {
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
    }

    public static void Output(double[] data, string msg = "Output: ")
    {
      string[] format = new string[] {"[", ", ", "]", " => "};
      if (data != null) 
      {
        Console.Write("{0}{1}", msg, format[0]);
        foreach(double element in data) 
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
        double[] rndNum = Generator.RandomNumbers(Generator.RandomNumber(3,9), min: 0.0, max: 1000.0);
        IOfunc.Output(data: rndNum);
        double min = Operator.Find(rndNum, MathFunction.Min);
        double max = Operator.Find(rndNum, MathFunction.Max);
        Console.Write("{0}, {1}", min, max);
        Console.Write(" => {0}\n", (max - min));

        int[] rndInt = Generator.RandomNumbers(Generator.RandomNumber(3,9), min: 0, max: 999);
        IOfunc.Output(data: rndInt, msg: "Output integers");
        int minInt = Operator.Find(rndInt, MathFunction.Min);
        int maxInt = Operator.Find(rndInt, MathFunction.Max);
        Console.Write("{0}, {1}", minInt, maxInt);
        Console.Write(" => {0}\n", (maxInt - minInt));

        int[] findOdd = Operator.Find(rndInt, MathFunction.IsOdd) ?? new int[]{0};
        IOfunc.Output(data: findOdd);
        if (findOdd.Length > 1)
        {
          minInt = Operator.Find(findOdd, MathFunction.Min);
          maxInt = Operator.Find(findOdd, MathFunction.Max);
          Console.Write("{0}, {1}", minInt, maxInt);
          Console.Write(" => {0}\n", (maxInt - minInt));
        }
        else
        {
          Console.WriteLine("Too few elements");
        }
        if(IOfunc.Exit(IOfunc.RequestString("\nPress enter to generate numbers or q to exit "))) break;
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}