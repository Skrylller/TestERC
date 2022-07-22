
//Start program

int peopleNum;
Meter[] meters = new Meter[] { Data.hvsMeter, Data.gvsMeter, Data.eeMeter };

bool checkInput;

do
{
    for (int i = 0; i < meters.Length; i++)
    {
        meters[i].ResetPreviousMeter();
    }

    do
    {
        Console.Clear();
        Console.WriteLine($"Задайте начальные параметры.");
        Console.WriteLine($"Количесвто проживающих в помещении:");

        peopleNum = InputSystem.ValueInput<int>();

        for (int i = 0; i < meters.Length; i++)
        {
            meters[i].SetHave();
        }

        Console.Clear();
        Console.WriteLine($"Данные введены верно?");
        Console.WriteLine($"Количество человек в комнате - {peopleNum}:");

        for (int i = 0; i < meters.Length; i++)
        {
            Console.WriteLine($"{meters[i].name} - {meters[i].isHave}:");
        }

        checkInput = InputSystem.CheckInput();
    }
    while (!checkInput);

    do
    {
        Console.Clear();

        for (int i = 0; i < meters.Length; i++)
        {
            meters[i].CalculateMeter(peopleNum);
        }

        Console.Clear();

        for (int i = 0; i < meters.Length; i++)
        {
            Console.WriteLine($"Счет за {meters[i].name} - {meters[i].bills}");
        }

        Console.WriteLine($"Выполнить расчет на следующий месяц?");
        checkInput = InputSystem.CheckInput();
    }
    while (checkInput);

    Console.WriteLine($"Хотите выйти из программы?");
    checkInput = InputSystem.CheckInput();
} 
while (!checkInput);

Console.Clear();
Console.WriteLine($"Человеку который будет проверять:");
Console.WriteLine($"До этого я изучал язык C# исключительно в рамках игрового движка Unity.");
Console.WriteLine($"Поэтому могу допустить что в решении могли быть какие то недочеты, так как у движка своя экосистема, свое API, и свои правила.");
Console.WriteLine($"Не смотря на это у меня хорошая база по языку и имеется опыт разработки полноценных игр на движке.");
Console.WriteLine($"В любом случае если от меня потребуется смена стека я готов к этому, так как хочу найти работу в офисе с другими людьми.");
Console.WriteLine($"Удачного дня.");
Console.ReadLine();

//End program

