// 1. В переменной string есть секретное сообщение, во второй есть пароль. 
// Пользователю программы даётся 3 попытки ввести пароль и увидеть секретное сообщение


// Генерируем секретныую фразу
string GenerateSecretPhrase(int phraseLengthMin = 4, int phraseLengthMax = 6) {
  string[] lib = {"lorem ", "ipsum ", "dolor sit ", "amet ", "consectetur ", "adipisci ", "velit ", "eius mod "};
  int phraseLength = RandomInt(phraseLengthMin, phraseLengthMax);
  string secretPhrase = "";

  string tmp = lib[RandomInt(0, lib.Length - 1)];
  string nextWord = lib[RandomInt(0, lib.Length - 1)];

  for(int i = 0; i < phraseLength; i++) {
    // Проверяем предыдущее добавленное во фразу слово на совпадение со следующим
    while (nextWord == tmp) {
      nextWord = lib[RandomInt(0, lib.Length - 1)];
    }
    secretPhrase += nextWord;
    tmp = nextWord;
  }
  return secretPhrase;
}

// Создаём массив секретных фраз
string[] GenerateSecretPhraseCollection(int length) {
  string[] secretPhraseCollection = new string[length];

  for(int i = 0; i < length; i++) {
    secretPhraseCollection[i] = GenerateSecretPhrase();
  }
  return secretPhraseCollection;
}

// Создаём словарь секретных фраз с соответствующими паролями
Dictionary<string, string> CreateDictionary(string[] keys, string[] secrets) {
  var secretDict = new Dictionary<string, string>() {};

  for(int i = 0; i < secrets.Length; i++) {
    secretDict.Add(keys[i], secrets[i]);
  }
  return secretDict;
}

// Проверяем пароль на корректность
void CheckPass(int arg, Dictionary<string, string> dict) {
  int i = 0;

  // Цикл, ограничивающий количество попыток
  while (i < arg) {
    string password = RequestValue("Enter password: ");
    if(password == "exit") {
      break;
    } else if(dict.ContainsKey(password)) {
      Console.WriteLine("The secret phrase is: {0}", dict[password].ToUpper());
      i = 0; // Обнуляем счётчик при успешном вводе пароля
    } else if ((arg - i - 1)  > 0) {
      i++;
      Console.WriteLine("Wrong password, {0} tries left", (arg - i) );
    } else {
      i++;
      Console.WriteLine("Try again later!");
    }
  }
}

// Генератор случайного целого числа
int RandomInt(int min, int max) {
  int rnd = new Random().Next(min, max);
  return rnd;
}

// Запрос строкового значения, параметр register определяет регистронезависимость
string RequestValue(string msg = "Enter value: ", bool register = true) {
  Console.Write(msg);
  string value;
  // Получаем данные
  if (register) {
    value = Console.ReadLine().ToLower();
  } else {
    value = Console.ReadLine();
  }
  return value;
}

// Главная функция
void Start() {
  string[] pass = {"pass1", "pass2", "pass3", "pass4"};
  string[] secrets = GenerateSecretPhraseCollection(pass.Length);
  var secretWords = CreateDictionary(pass, secrets);
  Console.WriteLine("Enter your password to learn the secret phrase. \nTo close the program type \"exit\".");
  CheckPass(3, secretWords);
}

// Запуск программы
Start();