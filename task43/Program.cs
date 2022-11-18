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

    public static bool Functions(double x, double y, double[] args)
    {
      int functionsNumber = 4;
      double tmp = .0;
      switch((int)args[0])
      {
        case 0:
        default:
          tmp = Function0(x, args);
          return y == System.Math.Round(tmp);
        case 1:
          tmp = Function1(x, args);
          return y == System.Math.Round(tmp);
        case 2:
          tmp = Function2(x, args);
          return y == System.Math.Round(tmp);
        case 3:
          tmp = Function3(x, args);
          return y == System.Math.Round(tmp);
        case 4:
          tmp = Function4(x, args);
          return y == System.Math.Round(tmp);
      }
    }
    public static double Function0(double x, double[] args)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];
      return (x+a)*(x+a)*(x+a)/k+b;
    }
    public static double Function1(double x, double[] args)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];
      return k*(x+a)+b;
    }
    public static double Function2(double x, double[] args)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];
      return (x+a)*(x+a)/k+b;
    }
    public static double Function3(double x, double[] args)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];
      if(x != .0) {
        return k/(x+a) + b;
      }
      else
      {
        return .0;
      }
    }
    public static double Function4(double x, double[] args)
    {
      double k = args[1];
      double a = args[2];
      double b = args[3];
      return k*System.Math.Cos(x+a)+b;
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
    private int width;
    private int height;
    private int value;
    private int[,,] coords;

    public Graphic(int width = 20, int height = 20, int value = 1)
    {
      this.width = width;
      this.height = height;
      this.value = value;
      this.coords = new int[width,height,value];
    }

    public void ShowGraph()
    {
      for (int i = 0; i < this.width; i++)
      {
        for (int j = 0; j < this.height; j ++)
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
            Console.ForegroundColor = ConsoleColor.Yellow;
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
    public void FillGraph(List<double[]> arguments) 
    {
      double width = (double)this.width;
      double height = (double)this.height;
      for (double i = 0.0; i < width; i += 0.1)
      {
        for (double j = 0.0; j < height; j += 0.1)
        {
          DrawGridElement((int)i, (int)j);
          double offsetX = width/2.0 - (width-height)/2.0;
          double offsetY = height/2.0 + (width-height)/2.0;
          double x = offsetX - j;
          double y = -(i - offsetY);
          x = System.Math.Floor(x);
          y = System.Math.Round(y);
          DrawGraphic((int)i, (int)j, x, y, arguments);
        }
      }
    }
    private void DrawGridElement(int i, int j)
    {
      if(j == this.height/2 || i == this.width/2)
      {
        this.coords[i,j,0] = 1;
      }
      else
      {
        this.coords[i,j,0] = 0;
      }
    }
    private void DrawGraphic(int i, int j, double x, double y, List<double[]> arguments)
    {
      bool[] functionResults = new bool[arguments.Count];
      int count = 0;
      foreach(double[] args in arguments) 
      {
        functionResults[count] = MathFunction.Functions(x, y, args);
        if(functionResults[count]) this.coords[i,j,0] = 2;
        count++;
      }
      count = 0;
      foreach(bool el in functionResults)
      {
        if(el) count++;
      }
      if(count > 1) this.coords[i,j,0] = 3; // Показывает пересечения
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

    public static int StringToNumber(string value)
    {
      int result;
      int.TryParse(value, out result);
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
      while (true)
      {
        List<double[]> arguments = new List<double[]> {};
        
        double[] demo0 = {0.0, -16.0, 0.0, 0.0};
        arguments.Add(demo0);
        double[] demo1 = {4.0, 2.0, 0.0, 0.0};
        arguments.Add(demo1);
        Graphic graph1 = new Graphic(60,100);
        graph1.FillGraph(arguments);
        graph1.ShowGraph();



        if(IOfunc.Exit(IOfunc.RequestString("\nPress enter to generate numbers or q to exit "))) break;
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}