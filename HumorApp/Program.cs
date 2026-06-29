using HumorApp.Services;
using System;
using System.Threading.Tasks;

namespace HumorApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Создаем объект для работы с Humor API
            HumorApiService api = new HumorApiService();

            // Основной цикл программы. Работает до тех пор, пока пользователь не выберет выход.
            while (true)
            {
                Console.WriteLine("\n Humor API ");
                Console.WriteLine("1 - Случайная шутка");
                Console.WriteLine("2 - Поиск шутки");
                Console.WriteLine("3 - Выход");
                Console.Write("Выберите: ");

                string choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        // Запрашиваем случайную шутку у API
                        var joke = await api.GetRandomJokeAsync();
                        Console.WriteLine("\n" + joke.JokeText);
                    }
                    else if (choice == "2")
                    {
                        // Пользователь вводит ключевое слово для поиска
                        Console.Write("Введите слово для поиска: ");
                        string keyword = Console.ReadLine();

                        // Получаем список подходящих шуток
                        var jokes = await api.SearchJokesAsync(keyword);

                        Console.WriteLine($"\n=== Найдено: {jokes.Count} ===\n");

                        // Выводим все найденные шутки
                        foreach (var j in jokes)
                        {
                            Console.WriteLine("- " + j.JokeText);
                        }
                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine("Пока!");
                        break;
                    }
                    else
                    {
                        // Обработка неверного пункта меню
                        Console.WriteLine("Неверный выбор, попробуй снова.");
                    }
                }
                catch (Exception ex)
                {
                    // Вывод сообщения об ошибке при проблемах с API или сетью
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }
    }
}