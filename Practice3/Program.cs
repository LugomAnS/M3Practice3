using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
	/// <summary>
	/// Программа практического задания 3, разбитая на 5 блоков
	/// </summary>
	class Program
	{
		/// <summary>
		/// Точка старта
		/// </summary>
		/// <param name="args">Параметры</param>
		static void Main(string[] args)
		{
			
			do
			{
				Console.WriteLine("Практическое задание №3 состоящее из 5 задач:");
				Console.WriteLine("1. Определение четного или нечетного числа пользовательского ввода.");
				Console.WriteLine("2. Подсчет суммы карт в игре '21'.");
				Console.WriteLine("3. Проверка на простое число.");
				Console.WriteLine("4. Нахождение наименьшего элемента в последовательности.");
				Console.WriteLine("5. Игра 'Угадай число'.");
				Console.WriteLine("Для выбора задачи введите число соответствующее задаче.");
				Console.WriteLine("Для выхода из программы нажмите клавишу пробел.");

				bool userInputCheck = false;
				int userTaskChoice;
				string userInput;
				do
				{
					Console.WriteLine("\nВведите номер задачи: ");
					userInput = Console.ReadLine().ToString();
					// проверка на выход из программы
					if (userInput.Equals(" "))
					{
						return;
					}
					userInputCheck = int.TryParse(userInput, out userTaskChoice);
				}while (!userInputCheck);
				
                // запуск выбранной задачи
                switch (userTaskChoice)
                {
					case 1:
						Number();
						break;
					case 2:
						Blackjack();
						break;
					case 3:
						SimpleNumberCheck();
						break;
					case 4:
						LowestNumberInRow();
						break;
					case 5:
						GuessNumber();
						break;
                    default:
						Console.Clear();
						Console.WriteLine("Задачи с таким номером не существует\n");
						break;
                }

            } while (true);
			
		}
		/// <summary>
		/// Определение четного или нечетного числа пользовательского ввода
		/// </summary>
		private static void Number()
		{
			#region 1. Определение четного или нечетного числа пользовательского ввода
			Console.Clear();
			Console.WriteLine("Задача №1. Определение чётное или нечётное число");
			// запросить у пользователя ввод целого числа и проверить
			int userInput = int.MinValue;
			bool userInputCheck;

			do
			{
				Console.WriteLine("\nВведите целое число: ");
				 userInputCheck = int.TryParse(Console.ReadLine(), out userInput);
			} while (!userInputCheck);
			// осуществить проверку делением с остатком
			if (userInput % 2 == 0)
			{
				Console.WriteLine("\nВведенное число чётное");
			}
			else Console.WriteLine("\nВведенное число нечётное");
			// вывести результат число четное или нечетное
			Console.ReadKey(true);
			Console.Clear();

			#endregion
		}
		/// <summary>
		/// Подсчет суммы карт в игре '21'
		/// </summary>
		private static void Blackjack()
		{
			#region 2. Подсчет сумы карт в игре "21"
			Console.Clear();
			Console.WriteLine("Задача №2. Подсчет суммы карт в игре '21'");
			// поприветствовать пользователя и запросить количество карт на руках (целое число)
			Console.WriteLine("\nПриветствуем Вас в нашей игре '21''");
			// считать и проверить число карт
			int userCardsCount = int.MinValue;
			bool userInputCheck;
			do
			{
				Console.WriteLine("Введите количество карт у Вас на руках: ");
				userInputCheck = int.TryParse(Console.ReadLine(), out userCardsCount);
			} while (!(userInputCheck && (userCardsCount > -1)));

			if (userCardsCount == 0)
			{
				Console.WriteLine("\nУ Вас нет карт на руках, Ваши очки равны нулю");
				Console.ReadKey(true);
			}
			else
			{
				Console.WriteLine("\nНеобходимо ввести значения Ваших карт");
				Console.WriteLine("Для карт с числовым номиналом введите целое число от 1 до 10");
				Console.WriteLine("Для карты Валет символ: J");
				Console.WriteLine("Для карты Дама символ: Q");
				Console.WriteLine("Для карты Король символ: K");
				Console.WriteLine("Для карты Туз символ: T");

				int userScore = 0;
				// запрос номинала всех карт и их сумирование
				for (int cardIndex = 1; cardIndex <= userCardsCount; cardIndex++)
				{
					// проверить что ввел пользователь число,символ - если значение не верно повторный запрос ввода
					do
					{
						userInputCheck = false;
						Console.WriteLine($"Введите значение карты № {cardIndex}: ");
						// проверить число ли
						string userCardInput = Console.ReadLine();
						int userCardValue;
						if (int.TryParse(userCardInput, out userCardValue))
						{
							if (userCardValue > 0 && userCardValue < 11)
							{
								userInputCheck = true;
								userScore += userCardValue;
							}
							else
							{
								Console.WriteLine("Числовой номинал карты должен быть в диапазоне от 1 до 10");
							}
						}
						// пользователь ввел символ, проверить корректный он или нет и просуммировать
						else
						{
							switch (userCardInput)
							{
								case "J":
									userInputCheck = true;
									userScore += 10;
									break;
								case "Q":
									userInputCheck = true;
									userScore += 10;
									break;
								case "K":
									userInputCheck = true;
									userScore += 10;
									break;
								case "T":
									userInputCheck = true;
									userScore += 10;
									break;
								default:
									Console.WriteLine("Введенные символы не являются значениями карт");
									break;
							}
						}
					} while (!userInputCheck);
					
				}
				// вывести номинал всех карт на руках
				Console.WriteLine($"\nСумма очков Ваших карт: {userScore}");
				Console.ReadKey(true);
				Console.Clear();
			}
			#endregion			
		}
		/// <summary>
		/// Проверка является ли число простым
		/// </summary>
		private static void SimpleNumberCheck()
		{
			#region 3. Проверка на простое число
			Console.Clear();
			Console.WriteLine("Задача №3. Проверка является ли число простым");
			// запросить у пользовател целое число
			int userInput = 0;
			bool userInputCheck;
			do
			{
				Console.WriteLine("\nВведите целое число: ");
				userInputCheck = int.TryParse(Console.ReadLine(), out userInput);
			} while (!(userInputCheck && userInput != 0));
			// проверить является ли число простым

			bool numberSimpleCheck = false;

			for (int numberIndex = 2; numberIndex < userInput - 1; numberIndex++)
			{
				if (userInput % numberIndex == 0)
				{
					numberSimpleCheck = true;
				}
			}
			// вывод информации о проверке

			if (numberSimpleCheck)
			{
				Console.WriteLine("Введенное число не является простым");
			}
			else
			{
				Console.WriteLine("Введенное число является простым");
			}
			Console.ReadKey(true);
			#endregion
		}
		/// <summary>
		/// Нахождение наименьшего элемента в последовательности
		/// </summary>
		private static void LowestNumberInRow()
		{
			#region 4. Нахождение наименьшего элемента в последовательности
			Console.Clear();
			Console.WriteLine("Задача №4. Нахождение наименьшего элемента в последовательности");

			// запросить у пользователя длину последовательности
			int userNumberLenght = int.MinValue;
			bool userInputCheck;
			do
			{
				Console.WriteLine("\nВведите длину последовательности чисел: ");
				userInputCheck = int.TryParse(Console.ReadLine(), out userNumberLenght);
			} while (!(userInputCheck && (userNumberLenght > -1)));

			// запросить значения (целое число) каждого элемента в последовательности и найти наименьший элемент
			int userLowestElement = int.MaxValue;

			for (int indexNumbers = 1; indexNumbers < userNumberLenght; indexNumbers++)
			{
				userInputCheck = false;
				int userInputNumber;
				do
				{
					Console.WriteLine($"Введите целое число № {indexNumbers}: ");
					userInputCheck = int.TryParse(Console.ReadLine(), out userInputNumber);
				} while (!userInputCheck);

				if (userInputNumber < userLowestElement)
				{
					userLowestElement = userInputNumber;
				}
			}
			// вывести наименьший элемент послеовательности

			Console.WriteLine($"\nНаименьший элемент в последовательности: {userLowestElement}");
			Console.ReadKey(true);
			Console.Clear();
			#endregion
		}
		/// <summary>
		/// Игра 'Угадай число'
		/// </summary>
		private static void GuessNumber()
		{
			#region 5. Игра "Угадай число"
			Console.Clear();
			Console.WriteLine("Задание №5. Игра 'Угадай число'");
			// запросить целое число верхнего диапазона
			int userInput;
			bool userInputCheck;
			do
			{
				Console.WriteLine("\nВведите целое число для верхнего диапазона загадывания числа: ");
				userInputCheck = int.TryParse(Console.ReadLine(), out userInput);
			} while (!userInputCheck);
			// сгенерировать "случайное число" в диапазоне от 0 до введенного числа
			Random numberRandomGenerator = new Random();

			if (userInput == 0)
			{
				Console.WriteLine("Верхний диапазон равен 0, игра не имеет смысла");
				Console.ReadKey(true);
			}
			else
			{
				int numberToGuess = userInput;
				if (userInput > 0)
				{
					numberToGuess = numberRandomGenerator.Next(0, userInput + 1);
				}
				else
				{
					numberToGuess = numberRandomGenerator.Next(0, userInput - 1);
				}
				// запрашивать у пользователя целые числа пока он не угадает
				int attemptsToGuess = 0;
				Console.WriteLine("Начните угадывать введя целое число");
				Console.WriteLine("Если устанете угадывать нажмите пробел для выхода");
				while (true)
				{
					int userNumberGuess = int.MinValue;
					do
					{
						Console.WriteLine("Введите целое число: ");
						string userGuess = Console.ReadLine().ToString();
						// завершение когда устал вводом ' ' и показом загаданного числа
						if (userGuess.Equals(" "))
                        {
							Console.WriteLine($"\nЗагаданное число - {numberToGuess}");
							Console.ReadKey(true);
							Console.Clear();
							return;
                        }
						userInputCheck = int.TryParse(userGuess, out userNumberGuess);
					} while (!userInputCheck);
					attemptsToGuess++;
                    //проверка угадал ли число
                    if (userNumberGuess > numberToGuess)
                    {
						Console.WriteLine("Введенное число больше загаданного");
                    }
                    else if (userNumberGuess < numberToGuess)
                    {
						Console.WriteLine("Введенное число меньше загаданного");
                    }
                    else 
					{
						// завершении при выигрыш
						Console.WriteLine($"\nПоздравляю Вы угадали. Число попыток {attemptsToGuess} ");
						Console.ReadKey(true);
						break;
					}

                }				
			}
			Console.Clear();

			#endregion
		}
	}
}



