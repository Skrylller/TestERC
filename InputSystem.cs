
public static class InputSystem
{
    public static T ValueInput<T>()
    {
        T obj = default(T);
        string numInput;
        bool isTrueInput = false;

        do
        {
            numInput = Console.ReadLine();

            try
            {
                obj = (T)Convert.ChangeType(numInput, typeof(T));
                isTrueInput = true;
            }
            catch
            {
                Console.WriteLine($"Введен неверный тип данных, введите значение типа {typeof(T)}: ");
            }
        }
        while (!isTrueInput);

        return obj;
    }

    public static bool CheckInput()
    {
        const ConsoleKey keyTrue = ConsoleKey.Y;
        const ConsoleKey keyFalse = ConsoleKey.N;

        Console.WriteLine($"{ConsoleKey.Y} - Да / {ConsoleKey.N} - Нет");

        ConsoleKeyInfo key;
        bool inputValue;

        do
        {
            key = Console.ReadKey();
            Console.WriteLine();

            switch (key.Key)
            {
                case keyTrue:
                    return true;
                    break;

                case keyFalse:
                    return false;
                    break;

                default:
                    Console.WriteLine($"Нажата неверная клавиша. (Нажмите: {ConsoleKey.Y} - Да / {ConsoleKey.N} - Нет)");
                    break;
            }
        }
        while (true);
    }
}
