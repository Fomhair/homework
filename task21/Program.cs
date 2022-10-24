// Задача 21. Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

using System;

namespace Lesson.Distance3D
{
  // Класс, описывающий положение точки в пространстве.
  public class PointPosition
  {
    // Список идентификаторов точек
    private static List<string> idList = new List<string>{};
    public string id;
    public int x;
    public int y;
    public int z;
    public PointPosition(int x = 0, int y = 0, int z = 0, string id = "")
    {
      if (id == string.Empty) {
        this.id = GenerateId(); // Генерация нового ID 
      } else {
        this.id = id;
      }

      this.x = x;
      this.y = y;
      this.z = z;
    }

    // Функция установки соординат
    public static PointPosition SetPosition(string[] str) {
      if (str != null)
      {
        int[] coords = new int[str.Length];
        for(int i = 0; i < str.Length; i++)
        {
          coords[i] = Lesson.Distance3D.Program.StringToInt(str[i]);
        }
        PointPosition a = new PointPosition(coords[0], coords[1], coords[2]);
        return a;
      }
      else
      {
        PointPosition a = new PointPosition();
        return a;
      }
    }

    // Выводит информацию о положении точки и её ID
    public void ShowPosition() {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("{0}:({1}, {2}, {3}) ", this.id, this.x, this.y, this.z);
      Console.ForegroundColor = ConsoleColor.White;
    }

    // Генерирует новый идентификатор, если в поле ID конструктора ничего не введено
    public string GenerateId() {
      // Список базовых префиксов
      string[] abc = new string[] {"A", "B", "C", "D", "E"};
      string generatedId = string.Empty;

      // Добавление порядкового номера к префиксу
      if (idList.Count - 1 >= 0) 
      {
        string tmp = abc[(idList.Count) % abc.Length] + Convert.ToString((idList.Count)/ abc.Length);
        generatedId += tmp;
      }
      else
      {
        generatedId = abc[0]+"0";
      }
      idList.Add(generatedId);
      return generatedId;
    }

    // Очищает список сгенерированных ID 
    public static void ClearIdList()
    {
      idList.Clear();
    }
  }

  // Класс для измерения дистанции между объектами класса PointPosition
  public static class Distance 
  {
    // Вычисление дистанции между двумя точками в трёхмерном пространстве с заданной точностью
    public static double MeasureDistance(PointPosition a, PointPosition b, int round = 2)
    {
      double x_dist = AxisDist(a.x, b.x);
      double y_dist = AxisDist(a.y, b.y);
      double z_dist = AxisDist(a.z, b.z);
      double xy_dist = Hypotenuse(x_dist, y_dist);
      double distance = Hypotenuse(xy_dist, z_dist);
      return Math.Round(distance, round);
    }

    public static double Hypotenuse(double cathetus1, double cathetus2)
    {
      return Math.Sqrt(Math.Pow(cathetus1, 2) + Math.Pow(cathetus2, 2));
    }
    public static double AxisDist(int x1, int x2) {
      return Convert.ToDouble(Math.Abs(x1 - x2));
    }
  }

  public class Program
  {
    // Запрашиваем строку и проверяем на null.
    static string RequestString(string msg = "Enter value: ")
    {
      Console.Write(msg);
      string value = Console.ReadLine();
      return value ?? string.Empty;
    }

    // Запрос массива строковых значенийб печечисленных через пробел или через запятую
    public static string[] RequestStringArr(int length = 3, string msg = "Enter values separated by space or commas: ")
    {
      Console.Write(msg);

      string[] result = new string[length];
      string value = Console.ReadLine() ?? string.Empty;

      if (value != string.Empty)
      {
        string[] values = value.Split(',', ' ');
        for(int i = 0; i < values.Length && i < length; i++)
        {
          result[i] = values[i];
        }
        return result;
      }
      else 
      {
        result[0] = value;
        return result;
      }
      
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
      Console.WriteLine("Enter \"q\" to exit");
      while(true)
      {
        string[] str = RequestStringArr();
        if (str[0].ToLower() == "q") break; // выход из программы


        // Задаём список точек
        List<PointPosition> points = new List<PointPosition> {};
        points.Add(PointPosition.SetPosition(str));
        while(true)
        {
          Console.WriteLine("Press Enter to set another position or Esc to complete");
          ConsoleKeyInfo key = Console.ReadKey(true);
          if(key.Key == ConsoleKey.Escape)
          {
            break;
          }
          else
          {
            str = RequestStringArr();
            points.Add(PointPosition.SetPosition(str));
          }
        }


        double fullDistance = 0.0;

        // Выводим точки с расстояниями между ними
        points[0].ShowPosition();
        for(int i = 1; i < points.Count; i++)
        {
          double distance = Distance.MeasureDistance(points[i-1], points[i]);
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("---{0}--- ", distance);
          Console.ForegroundColor = ConsoleColor.White;
          points[i].ShowPosition();
          fullDistance += distance;
        }
        Console.WriteLine(string.Empty);  
        Console.WriteLine("Full way is " + fullDistance);
        Console.WriteLine(string.Empty);
        PointPosition.ClearIdList();
      }
    }

    static void Main(string[] args) 
    {
      Start();
    }
  }
}