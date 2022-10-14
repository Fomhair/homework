// Задача 4: Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
// 2 3 7 -> 7
// 44 5 78 -> 78
// 22 3 9 -> 22

string state = "y";

while(state.ToLower() == "y"){
  Console.Write("Enter first number: ");
  int value1 = Convert.ToInt32(Console.ReadLine());
  Console.Write("Enter second number: ");
  int value2 = Convert.ToInt32(Console.ReadLine());
  Console.Write("Enter third number: ");
  int value3 = Convert.ToInt32(Console.ReadLine());

  if (value1 >= value2) {
    if (value1 >= value3) {
      Console.WriteLine(value1 + " " + value2 + " " + value3 + " -> " + value1);
    } else {
      Console.WriteLine(value1 + " " + value2 + " " + value3 + " -> " + value3);
    }
  } else {
    if (value2 >= value3) {
      Console.WriteLine(value1 + " " + value2 + " " + value3 + " -> " + value2);
    } else {
      Console.WriteLine(value1 + " " + value2 + " " + value3 + " -> " + value3);
    }
  }

  Console.Write("Enter any key to exit or Y to restart: ");
  state = Console.ReadLine();
}