using System;
using System.Diagnostics;
using System.Threading;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу: ");
            var filePath = Console.ReadLine();
            new Thread(() =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                FileToString.ReadFile(filePath);
                stopwatch.Stop();
                Console.WriteLine($"Время обработки запроса: {stopwatch.ElapsedMilliseconds}");
            }).Start();

            Console.WriteLine("Конец выполнения Main");
            while (true)
                Console.ReadKey();
        }
    }
}
