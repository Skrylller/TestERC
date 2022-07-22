
public class Data
{
    private static Utilite hvs = new Utilite(35.78M, 4.85M, "ХВС", "М^3");
    private static Utilite gvs = new Utilite(158.98M, 4.01M, "ГВС", "М^3");
    private static Utilite ee = new Utilite(4.28M, 164M, "ЭЭ", "КВт/Час");
    private static Utilite eeDay = new Utilite(4.9M, 0, "ЭЭ Дневной", "КВт/Час");
    private static Utilite eeNight = new Utilite(2.31M, 0, "ЭЭ Ночной", "КВт/Час");
    private static GVS gvsTermal = new GVS(998.69M, 0.05349M, "ГВС ТЭ", "Гкал", new Utilite(35.78M, 4.01M, "ГВС ТН", "М^3"));

    public static Meter hvsMeter = new Meter("ХВС", hvs);
    public static GVSMeter gvsMeter = new GVSMeter("ГВС", gvs, gvsTermal);
    public static EEMeter eeMeter = new EEMeter("ЭЭ", ee, eeDay, eeNight);
}
