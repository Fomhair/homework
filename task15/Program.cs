// Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.

// 6 -> да
// 7 -> да
// 1 -> нет

// Задача показалась слишком простой, поэтому я немного поэкспериментировал.
void IsWeekend() {
  // Тут я решил проверить как пользоваться многомерными массивами в C#
  string[,] daysOfWeek = {
    {"Monday", "No"}, 
    {"Tuesday", "No"},
    {"Wednesday", "No"},
    {"Thursday", "No"},
    {"Friday", "No"},
    {"Saturday", "Yes"},
    {"Sunday", "Yes"}
  };
  int num = requestNum("Enter number of the day of the week: ") - 1;
  Console.WriteLine("Is weekend?");
  if (num <= 7) {
    Console.Write("{0} -> {1}, it's {2}", num, daysOfWeek[num, 1], daysOfWeek[num, 0]);
    if (daysOfWeek[num, 1] == "No") {
      if (num == 2) {
        Console.WriteLine(", my dude");
      } else {
        Console.WriteLine(" :(");
      }
    } else {
      Console.WriteLine(" :)");
    }
  } 
}

// Запрос числа из консоли
int requestNum(string msg = "Enter number: ") {
  Console.Write(msg);
  string value = Console.ReadLine();
  int digit;

  // Проверка, является ли вводимое значение числом
  if (int.TryParse(value, out digit)) { 
    digit = Convert.ToInt32(value);
    // Добавил поддержку отрицательных чисел
    if (digit < 0) {
      digit *= -1;
    }
    return digit;
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
