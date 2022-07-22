
public class Meter
{
    private Utilite _utilite;
    public readonly string name;
    public bool isHave { get; private set; }
    public decimal bills { get; protected set; }

    public Meter(string name, Utilite utilite)
    {
        _utilite = utilite;
        this.name = name;
        isHave = false;
    }

    public virtual void ResetPreviousMeter()
    {
        _utilite.ResetPreviousMeter();
    }

    public virtual void CalculateMeter(int peopleNum)
    {
        bills = UtiliteCalculate(_utilite, peopleNum);
    }

    public void SetHave()
    {
        Console.WriteLine($"Имеется ли прибор учета по услуге {name}:");
        isHave = InputSystem.CheckInput();
    }

    public decimal UtiliteCalculate(Utilite utilite, int peopleNum)
    {
        decimal utiliteBills = 0;

        if (isHave)
        {
            Console.WriteLine($"ВВедите текущие показатели счетчика {utilite.Name()} (указать в {utilite.Unit()}): ");

            decimal previousMeter;

            do
            {
                previousMeter = InputSystem.ValueInput<decimal>();

                if (previousMeter >= utilite.PreviousMeter())
                {
                    break;
                }

                Console.WriteLine($"Указанные показатели счетчика ниже показателей предыдущего месяца. Показатель предыдущего месяца - {utilite.PreviousMeter()} {utilite.Unit()}");
            }
            while (true);

            utiliteBills = utilite.UtilityBills(previousMeter);
        }
        else
        {
            utiliteBills = utilite.UtilityBillsNonReading(peopleNum);
        }

        return utiliteBills;
    }
}

public class GVSMeter : Meter
{
    private Utilite _gvs;
    private GVS _gvsTermal;

    public GVSMeter(string name, Utilite gvs, GVS gvsTermal) : base(name, null)
    {
        _gvs = gvs;
        _gvsTermal = gvsTermal;
    }

    public override void ResetPreviousMeter()
    {
        _gvsTermal.ResetPreviousMeter();
        _gvs.ResetPreviousMeter();
    }

    public override void CalculateMeter(int peopleNum)
    {

        Utilite gvsTemp;
        Console.WriteLine($"Расчет {_gvs.name} производить по двум услугам {_gvsTermal.gvsCoolant.name} и {_gvsTermal.name}?");

        if (InputSystem.CheckInput())
        {
            gvsTemp = _gvsTermal;
        }
        else
        {
            gvsTemp = _gvs;
        }

        bills = UtiliteCalculate(gvsTemp, peopleNum);

    }
}
public class EEMeter : Meter
{
    private Utilite _ee;
    private Utilite _eeDay;
    private Utilite _eeNight;

    public EEMeter(string name, Utilite ee, Utilite eeDay, Utilite eeNight) : base(name, null)
    {
        _ee = ee;
        _eeDay = eeDay;
        _eeNight = eeNight;
    }

    public override void ResetPreviousMeter()
    {
        _ee.ResetPreviousMeter();
        _eeDay.ResetPreviousMeter();
        _eeNight.ResetPreviousMeter();
    }

    public override void CalculateMeter(int peopleNum)
    {
        if (isHave)
        {
            Console.WriteLine($"Расчет {_ee.name} производить по двум шкалам {_eeDay.name} и {_eeNight.name}?");

            if (InputSystem.CheckInput())
            {
                bills = UtiliteCalculate(new Utilite[] { _eeDay, _eeNight }, peopleNum);
                return;
            }
        }

        bills = UtiliteCalculate(_ee, peopleNum);
    }

    public decimal UtiliteCalculate(Utilite[] utilites, int peopleNum)
    {
        decimal utiliteBills = 0;

        foreach (Utilite utilite in utilites)
        {
            utiliteBills += UtiliteCalculate(utilite, peopleNum);
        }

        return utiliteBills;
    }
}
