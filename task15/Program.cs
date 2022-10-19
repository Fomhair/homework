// Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.

// 6 -> да
// 7 -> да
// 1 -> нет

// Задача показалась слишком простой, поэтому я немного поэкспериментировал.
void IsWeekend() {
  // Тут я решил проверить как пользоваться многомерными массивами в C#

  bool dayOff = false;

  string[] days = {"monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"};

  var daysOfWeek = new Dictionary<string, bool>() {
    {days[0], dayOff}, 
    {days[1], dayOff},
    {days[2], dayOff},
    {days[3], dayOff},
    {days[4], dayOff},
    {days[5], !dayOff},
    {days[6], !dayOff}
  };

  

  int num = RequestNum(days, "Enter the day of the week: ") - 1;
  Console.WriteLine("Is weekend?");
  if (num <= 7) {
    if (daysOfWeek[days[num]]) {
      Console.Write("Yeah, it's {0}", days[num]);
      Console.WriteLine(" :)");
    } else {
      Console.Write("Nope, it's {0}", days[num]);
      if (num == 2) {
        Console.WriteLine(", my dude");
      } else {
        Console.WriteLine(" :(");
      }
    }
  }
}

// Запрос числа из консоли
int RequestNum(string[] arg, string msg = "Enter number: ") {
  Console.Write(msg);
  string value = Console.ReadLine().ToLower();
  int digit;

  // Проверка, является ли вводимое значение числом
  if (int.TryParse(value, out digit)) { 
    digit = Convert.ToInt32(value);
    return digit;
  } else if (arg.Contains(value)) {
    return Array.IndexOf(arg, value) + 1;
  } else {
    Console.WriteLine("Not a number or too long");
    return -1;
  }
}

// Некое подобие интерфейса
void Method() {
  IsWeekend();
}

// Оболочка, запускающая метод
void Main() {
  string state = "y";
  while(state.ToLower() == "y"){
    Method();
    Console.WriteLine("");
    Console.Write("Enter any key to exit or Y to restart: ");
    state = Console.ReadLine();
  }
}

// Запуск программы
Main();
