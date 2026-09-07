using System.Security.Cryptography;

namespace RPG_gameKOD;

static class Program
{
    public static void Main(string[] args)
    {
        bool valid = false;
        
        while (!valid)
        {
            Console.WriteLine("Выбери игру!");
            Console.WriteLine("1. Базовая игра (по ТЗ)");
            Console.WriteLine("2. Улучшенная (от меня)");
            Console.Write("Выбор: ");
            
            string inputs = Console.ReadLine();
            if (int.TryParse(inputs, out int actions))
            {
                if (actions == 2)
                {
                    GameBetter.main();
                    valid = true;
                } else if (actions == 1)
                {
                    game();
                    valid = true;
                }
            }
            Console.WriteLine("Выбери корректное число!");
        }
    }

    public static void game()
    {
        // === ШАГ 1: Экран загрузки ===
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=================================");
        Console.WriteLine("      АРЕНА ГЕРОЕВ: БИТВА      ");
        Console.WriteLine("=================================");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("   .-\"\"\"-.");
        Console.WriteLine("  /       \\");
        Console.WriteLine(" |  O   O  |  <- Кибер-Гоблин");
        Console.WriteLine(" |    ^    |");
        Console.WriteLine("  \\  ===  /");
        Console.WriteLine("   '-----'");
        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу для начала боя...");
        Console.ReadKey();
        
        // === ШАГ 2: Создание персонажей (Переменные) ===
        Random rnd = new Random();
        
        int heroHp = 100;
        int bossHp = 100;

        Console.Clear(); // Очищаем экран от заставки
        Console.WriteLine("=== БОЙ ===");
        Console.WriteLine($"Герой: {heroHp} HP");
        Console.WriteLine($"Босс:  {bossHp} HP");
        Console.WriteLine("==================");

        while (heroHp > 0 && bossHp > 0)
        {
            // === ШАГ 3: Выбор действия

            Console.WriteLine("\nТвой ход!");
            Console.WriteLine("1. Ударить мечом (урон 15-25)");
            Console.WriteLine("2. Выпить зелье (лечение 20)");
            Console.Write("Введи номер действия: ");

            string input = Console.ReadLine();
            int action = int.Parse(input);

            if (action == 1)
            {
                int damage = rnd.Next(10, 21);
                bossHp -= damage;
                Console.WriteLine($"Ты нанес Гоблину {damage} урона!");
            }
            else if (action == 2)
            {
                heroHp += 20;
                Console.WriteLine("Ты восстановил 20 HP!");
            }
        
        
            // === ШАГ 4: Ответный удар

            Console.WriteLine();

            if (bossHp > 0)
            {
                Console.WriteLine("--- Ответный ход Босса ---");
                int bossDamage = 15;
                heroHp -= bossDamage;
                Console.WriteLine($"Гоблин ударил тебя и нанес {bossDamage} урона!");
            }

            
            Console.WriteLine($"\n[ Конец хода ]");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Герой: {heroHp} HP");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Босс:  {bossHp} HP");
            Console.ResetColor();
            Console.WriteLine();


            if (heroHp <= 0)
            {
                Console.WriteLine("\nТы пал в бою... Игра окончена.");
            }

        }
    }
}