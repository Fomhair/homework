// Задача 2: Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.
// a = 5; b = 7 -> max = 7
// a = 2; b = 10 -> max = 10
// a = -9; b = -3 -> max = -3

string state = "y";

while(state.ToLower() == "y"){
  Console.Write("Enter first number: ");
  int value1 = Convert.ToInt32(Console.ReadLine());
  Console.Write("Enter second number: ");
  int value2 = Convert.ToInt32(Console.ReadLine());

  if (value1 < value2) {
    Console.WriteLine("a = " + value1 + "; b = " + value2 + " -> max = " + value2);
  } else if (value1 > value2) {
    Console.WriteLine("a = " + value1 + "; b = " + value2 + " -> max = " + value1);
  } else {
    Console.WriteLine("a = " + value1 + "; b = " + value2 + " -> a = b");
  }
  Console.Write("Enter any key to exit or Y to restart: ");
  state = Console.ReadLine();
}
