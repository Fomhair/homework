// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

using System;

namespace Lesson.Math
{
  public class MathFunction
  {
    public static double Power(double a, int b)
    {
      double res = a;
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

    // перегрузка метода
    public static int[] StringToNumber(char[] chars)
    {
      char[] numbers = {'0','1','2','3','4','5','6','7','8','9'};
      int[] temp = new int[chars.Length];
      int count = 0;

      for(int i = 0; i < chars.Length; i++)
      {
        for(int j = 0; j < numbers.Length; j++ )
        {
          if(chars[i] == numbers[j])
          {
            temp[count] = Convert.ToInt32(chars[i]) - 48;
            count++;
          }
        }
      }
      int[] result = new int[count];
      for(int i = 0; i < count; i++)
      {
        result[i] = temp[i];
      }
      return result;
    }

    public static int[] StringToIntArray(string value)
    {
      char[] chars = value.ToCharArray();
      int[] numbers = StringToNumber(chars);
      return numbers;
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
      Console.WriteLine("To exit enter q.");
      while (true)
      {
        string value = IOfunc.RequestString();
        if(IOfunc.Exit(value)) break;
        int[] numbers = IOfunc.StringToIntArray(value);
        Console.WriteLine(MathFunction.Sum(numbers));
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}