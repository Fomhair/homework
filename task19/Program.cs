// Задача 19. Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

using System;

namespace Lesson.Palindrome
{
  class Program
  {
    // Запрашиваем строку и проверяем на null.
    static string RequestString(string msg = "Enter value: ")
    {
      Console.Write(msg);
      string value = Console.ReadLine();
      return value ?? string.Empty;
    }

    // Конвертируем строку в int[] { <число>, <длина числа> }
    // p.s. это не лучшая идея, но мне интересно явно использовть null в качестве результата ошибки
    static int[] StringToInt(string str)
    {
      int[] result = new int[2];
      if(int.TryParse(str, out result[0]))
      {
        result[0] = Convert.ToInt32(str);
        result[1] = str.Length;
        return result;
      }
      else
      {
        Console.WriteLine("Not a number!");
        return null;
      }
    }

    // Функция можно было сделать более универсальной, 
    // но вследствии предыдущих экспериментов что получилось то получилось))
    static bool CheckInt32Palindrome(int[] number)
    {
      int len = number[1];
      int[] sequence = new int[len];
      int n = number[0];
      int i = 0;

      while(n > 0)
      {
        sequence[i] = n % 10;
        n /= 10;
        i++;
      }
      for (int count = i; count > len/2; count--) 
      {
        if(sequence[count - 1] != sequence[(len - count)]) return false;
      }
      return true;
    }

    // Оболочка программы
    static void Start()
    {
      Console.WriteLine("Enter \"q\" to exit");
      while(true)
      {
        string str = RequestString();

        if (str.ToLower() == "q") break; // выход из программы

        if (str != string.Empty)
        {
          int[] number = StringToInt(str) ?? new int[0]; // эксперименты с оператором null-объединения
          if (number.Length > 0)
          {
            if (CheckInt32Palindrome(number)) { Console.WriteLine("Palindrome"); } // проверяем палиндром
            else { Console.WriteLine("Not a palindrome"); }
          }
        }
        else { Console.WriteLine("No data! Try again or enter \"q\" to exit."); } // вывод, если строка пуста
        Console.WriteLine(string.Empty);
      }
    }

    static void Main(string[] args) 
    {
      Start();
    }
  }
}