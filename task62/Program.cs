

using System;

namespace Lesson.Math
{

  public static class Generator
  {
    public static int RandomNumber(int min = 0, int max = 9)
    {
      return new Random().Next(min, max);
    }
    public static int[,] RandomNumberArray(List<int> arguments, int min = 0, int max = 10)
    {
      if (arguments.Count > 1)
      {
        int[,] d2matrix = new int[arguments[0], arguments[1]];
        for (int i = 0; i < arguments[0]; i++)
        {
          for (int j = 0; j < arguments[1]; j++)
          {
            d2matrix[i,j] = RandomNumber(min: min, max: max);
          }
        }
        return d2matrix;
      }
      else
      {
        Console.WriteLine("NO DATA!");
        return new int[0,0];
      }
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
    public void ShowGraph(string value)
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
            string text = value;
            Console.Write(text);
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
    public void FillGraph(List<int[,]> arguments) 
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
    private void DrawGraphic(int i, int j, int x, int y, List<int[,]> arguments)
    {
      bool functionResults = false;
      foreach(int[,] args in arguments) 
      {
        functionResults = DrawMatrix(x, y, args);
        if(functionResults) 
        {
          this.coords[i,j,0] = 2;
          this.coords[i,j,1] = Generator.RandomNumber(0,5);
        }
      }
    }
    private bool DrawMatrix(int x, int y, int[,] args)
    {
      // int positionX = x - (args.GetLength(1) * 2);
      // int positionY = y - (args.GetLength(0) * 2);
      if(x < args.GetLength(1) && 
         x >= -(args.GetLength(1)) && 
         y < args.GetLength(0) && 
         y >= -(args.GetLength(0)) && 
         x % 2 == 0 && 
         y % 2 == 0)
      {
        if(args[y/2 + (args.GetLength(0)/2 ),x/2 + (args.GetLength(1)/2)] > 0) return true;
        return false;
      }
      return false;
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

    public static string OptimizeString(string value)
    {
      string newStr = value.Replace("  "," ");
      newStr = newStr.Replace(",,",",");
      
      if(newStr.Contains("  ") || newStr.Contains(",,")) return OptimizeString(newStr);
      return newStr;
    }

    public static double StringToNumber(string value)
    {
      double result;
      double.TryParse(value, out result);
      return result;
    }

    // Метод раскрашивающий текст
    public static void Description(string[] funcInfo) {
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
    
    static int[] Direction(int value, int startPos, int lastPos, int limit, int[,] matrix, List<int[,]> DataSet, char dir)
    {
      int pos;
      switch(dir)
      {
        case 'l':
          for(pos = startPos; pos < lastPos; pos++)
          {
            matrix[limit, pos] = value;
            DataSet.Add(matrix);
            AddAndDraw(DataSet, value);
            value++;
            if(value <= matrix.GetLength(0)*matrix.GetLength(1)) Console.Clear();
            else break;
            if(pos == lastPos-1) 
            {
              lastPos = startPos;
              startPos = pos;
            }
            
          }
          limit++;
          break;
        case 't':
          for(pos = startPos; pos < lastPos; pos++)
          {
            matrix[pos, limit] = value;
            DataSet.Add(matrix);
            AddAndDraw(DataSet, value);
            value++;
            if(value <= matrix.GetLength(0)*matrix.GetLength(1)) Console.Clear();
            else break;
            if(pos == lastPos-1) 
            {
              lastPos = startPos;
              startPos = pos;
            }
            
          }
          limit--;
          break;
        case 'r':
          for(pos = startPos; pos >= lastPos; pos--)
          {
            matrix[limit, pos] = value;
            DataSet.Add(matrix);
            AddAndDraw(DataSet, value);
            value++;
            if(value <= matrix.GetLength(0)*matrix.GetLength(1)) Console.Clear();
            else break;
            if(pos == lastPos) 
            {
              lastPos = startPos + 1;
              startPos = pos;
            }
            
          }
          limit--;
          break;
        case 'b':
          for(pos = startPos; pos >= lastPos; pos--)
          {
            matrix[pos, limit] = value;
            DataSet.Add(matrix);
            AddAndDraw(DataSet, value);
            value++;
            if(value <= matrix.GetLength(0)*matrix.GetLength(1)) Console.Clear();
            else break;
            if(pos == lastPos) 
            {
              lastPos = startPos + 1;
              startPos = pos;
            }
            
          }
          limit++;
          break;
      }
      
      return new int[] {startPos, lastPos, limit, value};
    }
    public static void AddAndDraw(List<int[,]> DataSet, int value)
    {
      Graphic field = new Graphic();
      field.FillGraph(DataSet);
      string text = string.Empty;
      if(value < 10) text += "0" + value.ToString();
      else text = value.ToString();
      field.ShowGraph(text);
      Thread.Sleep(300);
      DataSet.Clear();
    }

    static void Start()
    {
      while (true)
      {
        List<string[]> descriptions = new List<string[]> {};
        try
        {
          Action<int[,]> AddToDescriptions = (int[,] rndNums) => {
            for(int i = 0; i < rndNums.GetLength(0); i++)
            {
              string[] strRow = new string[rndNums.GetLength(1)];
              for(int j = 0; j < rndNums.GetLength(1); j++)
              {
                if(rndNums[i,j] < 10) strRow[j] = rndNums[i,j].ToString() + "   ";
                else if(rndNums[i,j] < 100) strRow[j] = rndNums[i,j].ToString() + "  ";
                else strRow[j] = rndNums[i,j].ToString() + " ";
              }
              descriptions.Add(strRow);
            }
            foreach(string[] el in descriptions)
            {
              IOfunc.Description(el);
            }
          };
          
          int n, m;
          n = Generator.RandomNumber(min: 3, max: 10);
          m = Generator.RandomNumber(min: 3, max: 10);
          List<int> arguments = new List<int> {n, m};

          List<int[,]> DataSet = new List<int[,]>{};
          IOfunc.Description(new string[] {"\nField has ", arguments[0].ToString(), " rows and ", arguments[1].ToString(), " columns. Generate..."});
          int[,] matrix = new int[arguments[0],arguments[1]];
          Console.Clear();
          Console.CursorVisible = false;


          int startHorizontalPos = 0;
          int startVerticalPos = 0;
          int lastHorizontalPos = matrix.GetLength(1);
          int lastVerticalPos = matrix.GetLength(0);
          int[] tmp;
          // char[] dir = {'l', 't', 'r', 'b'};
          int value = 1;


          while(value < arguments[0]*arguments[1])
          {
            tmp = Direction(value, startHorizontalPos, lastHorizontalPos, startVerticalPos, matrix, DataSet, 'l');
            startHorizontalPos = tmp[0];
            lastHorizontalPos = tmp[1];
            startVerticalPos = tmp[2];
            value = tmp[3];

            tmp = Direction(value, startVerticalPos, lastVerticalPos, startHorizontalPos, matrix, DataSet, 't');
            startVerticalPos = tmp[0];
            lastVerticalPos = tmp[1];
            startHorizontalPos = tmp[2];
            value = tmp[3];

            tmp = Direction(value, startHorizontalPos, lastHorizontalPos, startVerticalPos, matrix, DataSet, 'r');
            startHorizontalPos = tmp[0];
            lastHorizontalPos = tmp[1];
            startVerticalPos = tmp[2];
            value = tmp[3];

            tmp = Direction(value, startVerticalPos, lastVerticalPos, startHorizontalPos, matrix, DataSet, 'b');
            startVerticalPos = tmp[0];
            lastVerticalPos = tmp[1];
            startHorizontalPos = tmp[2];
            value = tmp[3];
          }

          AddToDescriptions(matrix);

          Console.WriteLine("\nPress enter to try again or q to exit ");
          Console.CursorVisible = true;
          if(IOfunc.Exit()) break;
        }
        catch(IndexOutOfRangeException e)
        {
          Console.WriteLine("Incorrect values: " + e);
        }
      }
    }
    static void Main(string[] args)
    {
      Start();
    }
  }
}