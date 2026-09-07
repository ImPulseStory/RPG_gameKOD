namespace RPG_gameKOD;

static class GameBetter
{
    public static void main()
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
        
        double heroHp = 100;
        double bossHp = 100;
        int potions = 3;
        bool valid = false;

        Console.Clear(); // Очищаем экран от заставки
        Console.WriteLine("=== БОЙ ===");
        Console.WriteLine($"Герой: {heroHp} HP");
        Console.WriteLine($"Босс:  {bossHp} HP");
        Console.WriteLine("==================");

        while (heroHp > 0 && bossHp > 0)
        {
            // === ШАГ 3: Выбор действия
            valid = false;
            
            while (!valid)
            {
                Console.WriteLine($"Зелья: {potions}");
                int action = actions();
            
                Console.Clear();

                if (action == 1)
                {
                    int damage = rnd.Next(10, 21);
                    int crit = rnd.Next(1, 5);
                    if (crit == 2)
                    {
                        bossHp -= damage * 1.5;
                    }
                    else
                    {
                        bossHp -= damage;
                    }
                    Console.WriteLine($"Ты нанес Гоблину {damage} урона!");
                    valid = true;
                }
                else if (action == 2)
                {
                    if (potions > 0)
                    {
                        heroHp += 20;
                        Console.WriteLine("Ты восстановил 20 HP!");
                        potions--;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("У тебя кончились зелья!");
                        valid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Напиши корректное число.");
                    valid = false;
                }
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
            
            if (heroHp < 0) heroHp = 0;
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Герой: {heroHp} HP");
            Console.ResetColor();
            Console.WriteLine();

            if (bossHp < 0) bossHp = 0;
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Босс:  {bossHp} HP");
            Console.ResetColor();
            Console.WriteLine();


            if (heroHp <= 0 && bossHp > 0)
            {
                Console.WriteLine("\nТы пал в бою... Игра окончена.");
            } else if (heroHp >= 0 && bossHp <= 0)
            {
                Console.WriteLine("\nТы победил! Игра окончена.");
            } else if (heroHp <= 0 && bossHp <= 0)
            {
                Console.WriteLine("\nНичья... Игра окончена.");
            }

        }
    }

    public static int actions()
    {

        Console.WriteLine("\nТвой ход!");
        Console.WriteLine("1. Ударить мечом (урон 15-25)");
        Console.WriteLine("2. Выпить зелье (лечение 20)");
        Console.Write("Введи номер действия: ");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            return -1;
        }
    }
}