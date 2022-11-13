// Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

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
        double number = IOfunc.StringToNumber(value);
        value = IOfunc.RequestString("Exponentiation of a number: ");
        if(IOfunc.Exit(value)) break;
        int exp = (int)IOfunc.StringToNumber(value);
        Console.WriteLine(MathFunction.Power(number, exp));
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}