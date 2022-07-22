
public class Utilite
{
    public readonly decimal tariff;
    public readonly decimal norm;
    public readonly string name;
    public readonly string unit;

    protected decimal _previousMeter;

    public Utilite(decimal tariff, decimal norm, string name, string unit)
    {
        this.tariff = tariff;
        this.norm = norm;
        this.name = name;
        this.unit = unit;

        this._previousMeter = 0;
    }

    public virtual string Name() { return name; }
    public virtual string Unit() { return unit; }
    public virtual decimal PreviousMeter() { return _previousMeter; }

    public virtual void ResetPreviousMeter()
    {
        _previousMeter = 0;
    }

    public virtual decimal UtilityBills(decimal currentMeter)
    {
        return Volume(currentMeter) * tariff;
    }

    public virtual decimal UtilityBillsNonReading(int peopleNum)
    {
        return VolumeBillsNonReading(peopleNum) * tariff;
    }

    public virtual decimal Volume(decimal currentMeter)
    {
        decimal volume = currentMeter - _previousMeter;
        _previousMeter = currentMeter;
        return volume;
    }

    public virtual decimal VolumeBillsNonReading(int peopleNum)
    {
        return peopleNum * norm;
    }
}

public class GVS : Utilite
{

    public readonly Utilite gvsCoolant;

    public GVS(decimal tariff, decimal norm, string name, string unit, Utilite gvsCoolant) : base(tariff, norm, name, unit)
    {
        this.gvsCoolant = gvsCoolant;
    }
    public override string Name() { return gvsCoolant.Name(); }
    public override string Unit() { return gvsCoolant.Unit(); }
    public override decimal PreviousMeter() { return gvsCoolant.PreviousMeter(); }

    public override void ResetPreviousMeter()
    {
        gvsCoolant.ResetPreviousMeter();
    }

    public override decimal UtilityBills(decimal currentMeter)
    {
        decimal gvsCoolantVolume = gvsCoolant.Volume(currentMeter);
        return Volume(gvsCoolantVolume) * tariff + gvsCoolantVolume * gvsCoolant.tariff;
    }

    public override decimal UtilityBillsNonReading(int peopleNum)
    {
        return VolumeBillsNonReading(peopleNum) * tariff + gvsCoolant.UtilityBillsNonReading(peopleNum);
    }

    public override decimal Volume(decimal gvsCoolantVolume)
    {
        return gvsCoolantVolume * norm;
    }

    public override decimal VolumeBillsNonReading(int peopleNum)
    {
        return gvsCoolant.VolumeBillsNonReading(peopleNum) * norm;
    }
}
