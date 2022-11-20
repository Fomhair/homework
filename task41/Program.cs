// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

// 0, 7, 8, -2, -2 -> 2

// 1, -7, 567, 89, 223-> 3

static string RequestString(string msg = "Input your value: ")
{
  Console.Write(msg);
  string value = Console.ReadLine();
  return value ?? string.Empty;
}

string OptimizeString(string val)
{
  string newStr = val.Replace("  "," ");
  newStr = newStr.Replace(",,",",");

  if(newStr.Contains("  ") || newStr.Contains(",,")) return OptimizeString(newStr);
  return newStr;
}

string text = OptimizeString(Console.ReadLine());
string[] values = text.Split(' ');
List<double> M = new List<double> {};
int count = 0;

foreach (string str in values)
{
  double tmp;
  if(double.TryParse(str, out tmp)) 
  {
    if(tmp > 0) count++;
    M.Add(tmp);
  }
}

for(int i = 0; i < M.Count; i++)
{
  if(i < M.Count-1) Console.Write($"{M[i]}, ");
  else Console.Write($"{M[i]} -> {count}\n");
}



