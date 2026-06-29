using HumorApp.Services;
using System;
using System.Threading.Tasks;

namespace HumorApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HumorApiService api = new HumorApiService();

            while (true)
            {
                Console.WriteLine("\n=== Humor API ===");
                Console.WriteLine("1 - Случайная шутка");
                Console.WriteLine("2 - Поиск шутки");
                Console.WriteLine("3 - Выход");
                Console.Write("Выберите: ");

                string choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        var joke = await api.GetRandomJokeAsync();
                        Console.WriteLine("\n" + joke.JokeText);
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите слово для поиска: ");
                        string keyword = Console.ReadLine();
                        var jokes = await api.SearchJokesAsync(keyword);

                        Console.WriteLine($"\n=== Найдено: {jokes.Count} ===\n");
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
                        Console.WriteLine("Неверный выбор, попробуй снова.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }
    }
}