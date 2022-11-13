// Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]


using System;

namespace Lesson.Math
{

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

    public static string[] RequestStringArr(string msg = "Enter values separated by space or commas: ", int length = 8)
    {
      Console.Write(msg);

      string[] temp = new string[length];
      string value = Console.ReadLine() ?? string.Empty;
      int count = 0;

      if (value != string.Empty)
      {
        string[] values = value.Split(',', ' ');
        for(int i = 0; i < values.Length && i < length; i++)
        {
          temp[i] = values[i];
          count++;
        }
      }
      string[] result = new string[count];
      for(int j = 0; j < count; j++)
      {
        result[j] = temp[j];
      }
      return result;
    }
  }

  class Program
  {
    static void Start()
    {
      Console.WriteLine("To exit enter q.");
      while (true)
      {
        string[] value = IOfunc.RequestStringArr();
        if(IOfunc.Exit(value[0])) break;
        Console.Write(" -> [");
        for(int i = 0; i < value.Length; i++)
        {
          if(i < value.Length - 1) 
          {
            Console.Write("{0}, ", value[i]);
          }
          else
          {
            Console.WriteLine("{0}]", value[i]);
          }
        }
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}