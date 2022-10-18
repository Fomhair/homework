// Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа. (Использовать только математические операции, нельзя использовать число как строку по типу number[1])

// 456 -> 5
// 782 -> 8
// 918 -> 1

// Функция по умолчанию выводит вторую цифру любого числа (не только трёхзначные).
// Изменяя значение baseNum (1, 10, 100, 1000, ...) можно получить цифру в соответствующей позиции
void DigitByPosition(int baseNum = 10) {
  int num = requestNum();
  int result = (num / baseNum ) % 10;
  Console.WriteLine(num + " -> " + result);
}

// Запрос числа из консоли
int requestNum(string msg = "Enter number: ") {
  Console.Write(msg);
  string value = Console.ReadLine();
  int digit;

  // Проверка, является ли вводимое значение числом
  if (int.TryParse(value, out digit)) { 
    digit = Convert.ToInt32(value);
    return digit;
  } else {
    Console.WriteLine("Not a number or too long");
    return -1;
  }
}

// Некое подобие интерфейса
void Method() {
  DigitByPosition();
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