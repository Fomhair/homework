// Задача 8: Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
// 5 -> 2, 4
// 8 -> 2, 4, 6, 8

string state = "y";

while(state.ToLower() == "y"){
  Console.Write("Enter number: ");
  int value = Convert.ToInt32(Console.ReadLine());
  int i = 0;

  Console.Write(value + " ->  ");

  while(i < value - 1) {
    i += 2;
    Console.Write(i + " ");
  }
  Console.WriteLine("");
  Console.Write("Enter any key to exit or Y to restart: ");
  state = Console.ReadLine();
}



