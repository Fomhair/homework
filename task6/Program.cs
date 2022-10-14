// Задача 6: Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).
// 4 -> да
// -3 -> нет
// 7 -> нет

string state = "y";

while(state.ToLower() == "y"){
  Console.Write("Enter number: ");
  int value = Convert.ToInt32(Console.ReadLine());

  if (value % 2 == 0) {
    Console.WriteLine(value + " -> even");
  } else {
    Console.WriteLine(value + " -> odd");
  }

  Console.Write("Enter any key to exit or Y to restart: ");
  state = Console.ReadLine();
}