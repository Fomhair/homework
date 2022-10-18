// Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет. (Использовать только математические операции, нельзя использовать число как строку по типу number[2])

// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6

// Слегка модифицированная функция из предыдущей задачи. Добавлена поддержка отрицательных чисел.
void DigitByPosition(int baseNum = 10) {
  int num = requestNum();
  if (num < 0) {
    num *= -1;
  }
  if (num < baseNum) {
    Console.WriteLine(num + " -> такого числа нет");
  } else {
    int result = ((num - (num % baseNum)) / baseNum ) % 10;
    Console.WriteLine(num + " -> " + result);
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
    return digit;
  } else {
    Console.WriteLine("Not a number or too long");
    return -1;
  }
}

// Некое подобие интерфейса
void Method() {
  DigitByPosition(100);
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