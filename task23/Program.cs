// Задача 23. Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125

using System;

namespace Lesson.Progression
{
  public class Program
  {
    // Запрашиваем строку и проверяем на null.
    static string RequestString(string msg = "Enter value: ")
    {
      Console.Write(msg);
      string value = Console.ReadLine();
      return value ?? string.Empty;
    }

    // Преобразование строки в int
    public static int StringToInt(string str)
    {
      int result;
      if(int.TryParse(str, out result))
      {
        result = Convert.ToInt32(str);
        return result;
      }
      else
      {
        return 0;
      }
    }    

    // Оболочка программы
    static void Start()
    {
      while(true)
      {
        string str = RequestString();
        int number = StringToInt(str);
        if (number > 0)
        {
          Int64[] result = new Int64[number];
          Console.Write(number + " -> ");
          for(int i = 1; i < number; i++)
          {
            result[i] = Convert.ToInt64(Math.Pow(i, 3));
            Console.Write(result[i] + " ");
            i++;
          }
          Console.WriteLine(string.Empty);
        }
        
        Console.WriteLine("Press \"q\" to exit or any key to try again.");
        ConsoleKeyInfo key = Console.ReadKey(true);
        if(key.Key == ConsoleKey.Q)
        {
          break; // выход из программы 
        }
      }
    }

    static void Main(string[] args) 
    {
      Start();
    }
  }
}