// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)



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

  // Функции
    public static double Function0(double[] args, double x = 0, double y = 0, bool findX = false)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];

      if(findX) return (y-b)/k-a; 
      else return k*(x+a)+b;      
    }                             
    public static List<double[]> Function0(List<double[]> arguments)
    {
      double[] cur;
      List<double[]> result = new List<double[]> {};

      for(int i = 0; i < arguments.Count; i++)
      {
        double[] args = arguments[i];
        if((int)args[0] == 0)
        {
          for(int j = 0; j < arguments.Count; j++)
          {
            if((int)arguments[j][0] == 0 && j != i)
            {
              double[] xy = new double[10];
              
              cur = arguments[j];
              xy[0] = (-args[1]*args[2] + cur[1]*cur[2] - args[3] + cur[3]) / (args[1] - cur[1]);
              xy[1] = args[1]*(xy[0]+args[2])+args[3];
              xy[2] = args[0]; // 
              xy[3] = args[1]; // 
              xy[4] = args[2]; // 
              xy[5] = args[3]; // Метаданные по пересекающимся линиям
              xy[6] = cur[0];  // 
              xy[7] = cur[1];  // 
              xy[8] = cur[2];  // 
              xy[9] = cur[3];  // 
              result.Add(xy);
            } 
          }
          arguments.Remove(args);
          List<double[]> tmp = Function0(arguments);
          foreach(double[] xy in tmp)
          {
            result.Add(xy);
          }
          break;
        }
      }
  
      return result;
    }

    public static double Function1(double[] args, double x = 0, double y = 0, bool findX = false)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];

      if(findX) return System.Math.Cbrt(y*k*k)/k-a-b; 
      else return (x+a)*(x+a)*(x+a)*k+b;
    }
    public static double Function2(double[] args, double x = 0, double y = 0, bool findX = false)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];

      double tmp1 = (x+a)*(x+a)*k+b;
      double tmp2 = (x+1+a)*(x+1+a)*k+b;
      if(findX) 
      { 
        if (tmp1 > tmp2) return -(a*k+System.Math.Sqrt(k*(y-b)))/k; 
        else return -(a*k-System.Math.Sqrt(k*(y-b)))/k; 
      } 
      else return (x+a)*(x+a)*k+b;
    }

    public static double Function3(double[] args, double x = 0, double y = 0, bool findX = false)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];
      
      if(findX) 
      { 
        if(x != 0) return k/(y-b)-a;
        else return .0;
      } 
      else 
      {
        if(x != 0) return k/(x+a) + b;
        else return .0;
      }
    }

    public static double Function4(double[] args, double x = 0, double y = 0, bool findX = false)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];

      if(findX) return System.Math.Acos(y/k-b/k)-a;
      else return k*System.Math.Cos(x+a)+b;
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

  public class Graphic
  {
    private int height;
    private int width;
    private int value;
    private int[,,] coords;

    public Graphic(int width = 40, int height = 20)
    {
      this.height = height;
      this.width = width;
      this.value = 2;
      this.coords = new int[height,width,this.value];
    }

    // Выводит символы в консоль
    public void ShowGraph()
    {
      for (int i = 0; i < this.height; i++)
      {
        for (int j = 0; j < this.width; j ++)
        {
          if(this.coords[i,j,0] == 0)
          {
            Console.Write("  ");
          }
          else if(this.coords[i,j,0] == 1)
          {
            Console.Write(" +");
          }
          else if(this.coords[i,j,0] == 2)
          {
            switch(this.coords[i,j,1])
            {
              case 0: 
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
              case 1: 
                Console.ForegroundColor = ConsoleColor.Red;
                break;
              case 2: 
                Console.ForegroundColor = ConsoleColor.Green;
                break;
              case 3: 
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
              case 4: 
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            }
            Console.Write("88");
            Console.ForegroundColor = ConsoleColor.White;
          }
          else if(this.coords[i,j,0] == 3)
          {
            Console.Write("[]");
          }
        }
        Console.Write("\n");
      }
    }

    // Функция запускающая заполнение сетки экрана и устанавливающая центровку.
    public void FillGraph(List<double[]> arguments) 
    {
      for (int i = 0; i < this.height; i++)
      {
        for (int j = 0; j < this.width; j++)
        {
          DrawGridElement(i, j);
          int offsetX = this.height/2 - (this.height-this.width)/2;
          int offsetY = this.width/2 + (this.height-this.width)/2;
          int x = offsetX - j;
          int y = -(i - offsetY);
          DrawGraphic(i, j, x, y, arguments);
        }
      }
    }

    // Функция заполняет элементы сетки
    private void DrawGridElement(int i, int j)
    {
      if(j == this.width/2 || i == this.height/2) this.coords[i,j,0] = 1;
      else this.coords[i,j,0] = 0;
    }

    // Функция рисующая графику
    private void DrawGraphic(int i, int j, int x, int y, List<double[]> arguments)
    {
      bool[] functionResults = new bool[arguments.Count];
      int count = 0;
      foreach(double[] args in arguments) 
      {
        functionResults[count] = DrawFunctions((double)x, (double)y, args);
        if(functionResults[count]) 
        {
          this.coords[i,j,0] = 2;
          this.coords[i,j,1] = (int)args[0];
        }
        count++;
      }
      count = 0;
      foreach(bool el in functionResults)
      {
        if(el) count++;
      }
      if(count > 1) this.coords[i,j,0] = 3; // Показывает пересечения
    }

    // Метод, вызывающий математические функции для установки точек. 
    // В зависимости от положения на координатной плоскости вызывается прямая или обратная функции, это даёт непрерывную картинку
    // Если обратной функции нет, то выглядеть будет как в Function, отображающей косинус. 
    // Можно поэкспериментировать с дробными иксами, но пока не буду.
    public bool DrawFunctions(double x, double y, double[] args)
    {
      double functionResult = 0.0;
      // y = System.Math.Round(y); в текущей версии тут приходят целые, так что нет нужды
      switch((int)args[0])
      {
        case 0:
        default:
          if(args[1] > 1 || args[1] < -1) 
          { functionResult = MathFunction.Function0(args, x, y, findX: true); 
            return x == System.Math.Floor(functionResult); }
          else 
          { functionResult = MathFunction.Function0(args, x, y); 
            return y == System.Math.Floor(functionResult); }
          
        case 1:
          if(args[1] > 0.1 || args[1] < -0.1) 
          { functionResult = MathFunction.Function1(args, x, y, findX: true); 
            return x == System.Math.Floor(functionResult); }
          else 
          { functionResult = MathFunction.Function1(args, x, y); 
            return y == System.Math.Floor(functionResult); }

        case 2:
          if(args[1] > 0.1 || args[1] < -0.1) 
          { functionResult = MathFunction.Function2(args, x, y, findX: true); 
            return x == System.Math.Floor(functionResult); }
          else 
          { functionResult = MathFunction.Function2(args, x, y); 
            return y == System.Math.Floor(functionResult); }

        case 3:
          if(System.Math.Abs(x-args[2]) - System.Math.Abs(y-args[3]) < 0.0) 
          { functionResult = MathFunction.Function3(args, x, y, findX: true); 
            if(functionResult == 0) return false;
            return x == System.Math.Floor(functionResult); }
          else 
          { functionResult = MathFunction.Function3(args, x, y); 
            if(functionResult == 0) return false;
            return y == System.Math.Floor(functionResult); }

        case 4:
          functionResult = MathFunction.Function4(args, x, y); 
          if(System.Math.Abs(x) - System.Math.Floor(System.Math.Abs(x)) > 0) return true;
          return y == System.Math.Floor(functionResult);
      }
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
    static Graphic SetBoard()
    {
      Console.WriteLine("Press 1 jor 2 to choose bigger screen or press any key to cancel changes: ");
      while (true)
      {
        ConsoleKeyInfo screenNumber = Console.ReadKey(true);
        if (screenNumber.Key == ConsoleKey.D1)
        { return new Graphic(60, 40); }
        else if(screenNumber.Key == ConsoleKey.D2)
        { return new Graphic(80, 60); }
        else
        { return new Graphic(); }
      }  
    }


    static void PrintIntersections(List<double[]> intersections)
    {
      Console.WriteLine("\nSorry! For this moment program only shows line intersections.\n");
      if(intersections.Count > 0) 
      {
        foreach(double[] xy in intersections)
        {
          string k1 = xy[3].ToString();
          string a1 = xy[4].ToString();
          string b1 = xy[5].ToString();
          string firstFunc = $"{k1} * (x +({a1})) + ({b1})";
          
          string k2 = xy[7].ToString();
          string a2 = xy[8].ToString();
          string b2 = xy[9].ToString();
          string secondFunc = $"{k2} * (x + ({a2})) + ({b2})";
          
          Console.WriteLine($"{firstFunc} intersect with {secondFunc} function in ({System.Math.Round(xy[0], 2)}, {System.Math.Round(xy[1], 2)})");
        }
      }
      {
        Console.WriteLine("No intersections");
      }
    }

    static void Start()
    {
      List<double[]> arguments = new List<double[]> {};

      // Демо графики с предустановленными значениями
      double[] demo0 = {4.0, 2.0, 0.0, 0.0};
      arguments.Add(demo0);
      double[] demo1 = {3.0, 24.1, 0.0, 0.0};
      arguments.Add(demo1);
      double[] demo2 = {1.0, 0.05, 0.0, 0.0};
      arguments.Add(demo2);
      Graphic board = new Graphic();
      board.FillGraph(arguments);
      board.ShowGraph();

      while (true)
      {
        arguments.Clear();
        board = SetBoard();
        
        int count = 0;
        while(count < 4)
        {
          // Метод раскрашивающий текст
          Action<string[]> Description = (string[] funcInfo) => {
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
          };
          
          List<string[]> descriptions = new List<string[]> {};
          
          descriptions.Add(new string[] {"You can set ", (4 - count).ToString(), " more functions.\n"});
          descriptions.Add(new string[] {"Press ", "any key ", "for ", "k * (x + a) + b"});
          descriptions.Add(new string[] {"Press ", "1 ", "for ", "(x + a)^3 * k+ b"});
          descriptions.Add(new string[] {"Press ", "2 ", "for ", "(x + a)^2 * k + b"});
          descriptions.Add(new string[] {"Press ", "3 ", "for ", "k / (x + a) + b"});
          descriptions.Add(new string[] {"Press ", "4 ", "for ", "k * cos(x + a) + b"});
          descriptions.Add(new string[] {"Or press ", "Esc ", "to stop."});

          foreach(string[] el in descriptions)
          {
            Description(el);
          }

          Console.Write("Your choice: ");

          double funcNumber = 0.0;
          double k, a, b;
          bool esc = false;
          while (true)
          {
            ConsoleKeyInfo funcCode = Console.ReadKey(true);
            if (funcCode.Key == ConsoleKey.Escape)
            { Console.WriteLine("stop!");
              esc = true;
              break; }
            else if (funcCode.Key == ConsoleKey.D1)
            { Console.WriteLine("1");
              funcNumber = 1.0;
              break; }
            else if(funcCode.Key == ConsoleKey.D2)
            { Console.WriteLine("2");
              funcNumber = 2.0;
              break; }
            if (funcCode.Key == ConsoleKey.D3)
            { Console.WriteLine("3");
              funcNumber = 3.0;
              break; }
            if (funcCode.Key == ConsoleKey.D4)
            { Console.WriteLine("4");
              funcNumber = 4.0;
              break; }
            else
            { Console.WriteLine("default.");
              break; }
          }
          if(esc) break; 
          else
          {
            Console.WriteLine(string.Empty);
            k = IOfunc.StringToNumber(IOfunc.RequestString("Enter k: "));
            a = IOfunc.StringToNumber(IOfunc.RequestString("Enter a: "));
            b = IOfunc.StringToNumber(IOfunc.RequestString("Enter b: "));
            Console.WriteLine(string.Empty);

            double[] args = {funcNumber, k, a, b};
            arguments.Add(args);
          }
          count++;
        }

        board.FillGraph(arguments);
        board.ShowGraph();

        List<double[]> intersections = MathFunction.Function0(arguments);
        PrintIntersections(intersections);

        Console.WriteLine("\nPress enter to show graphics or q to exit ");
        if(IOfunc.Exit()) break;
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}