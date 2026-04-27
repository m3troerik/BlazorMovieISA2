namespace Abc.Aids;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RandomAttribute(int min, int max) :Attribute {
    public int Min { get; private set; } = min;
    public int Max { get; private set; } = max;
    public sbyte? Scale { get; private set; }
    public string Chars { get; private set; }
    public RandomAttribute(int min, int max, sbyte scale): this(min, max) => Scale = scale;
    public RandomAttribute(int min, int max, string chars): this(min, max) => Chars = chars;
    public object CreateValue(Type t) {
        t = Nullable.GetUnderlyingType(t) ?? t;
        if (t == typeof(string)) return GetRandom.String((byte)Min, (byte)Max, Chars);
        if (t == typeof(DateTime)) return GetRandom.DateTime(date(Min), date(Max));
        if (t == typeof(double)) return round(GetRandom.Double(Min, Max));
        if (t == typeof(decimal)) return round(GetRandom.Decimal(Min, Max));
        if (t == typeof(int)) return GetRandom.Int32(Min, Max);
        return GetRandom.Value(t);
    }
    private static DateTime date(int y) => DateTime.Now.AddYears(y);
    private double round(double d) => Scale.HasValue ? Math.Round(d, Scale.Value) : d;
    private decimal round(decimal d) => Scale.HasValue ? Math.Round(d, Scale.Value) : d;
}


















/*
 
[AttributeUsage(AttributeTargets.Property)]
public sealed class RandomAttribute :Attribute {
    public string Min { get; private set; }
    public string Max { get; private set; }
    public string Chars { get; private set; }
    public int? Scale { get; private set; }
    public bool DateOnly { get; private set; }
    public int? YearsBack { get; private set; }
    public RandomAttribute(int min, int max) => set(min, max);
    public RandomAttribute(double min, double max) => set(min, max);
    public RandomAttribute(double min, double max, int scale) => set(min, max, scale);
    public RandomAttribute(DateTime min, DateTime max) => set(min, max);
    public RandomAttribute(DateTime min, DateTime max, bool dateOnly) => set(min, max, -1, dateOnly);
    public RandomAttribute(byte minLength, byte maxLength, string chars = null) {
        set(minLength, maxLength);
        Chars = chars;
    }
    public RandomAttribute(byte yearsBack, bool dateOnly = false) {
        YearsBack = yearsBack;
        DateOnly = dateOnly;
    }
    public object CreateValue(Type t) {
        t = Nullable.GetUnderlyingType(t) ?? t;
        if (t == typeof(string)) return GetRandom.String(toByte(Min), toByte(Max), Chars);
        if (t == typeof(DateTime)) return rndDt();
        if (t == typeof(double)) return rndDbl();
        if (t == typeof(decimal)) return rndDec();
        if (t == typeof(int)) return GetRandom.Int32(toInt(Min), toInt(Max));
        return GetRandom.ValueOf(t);
    }
    private static int toInt(string s) => Convert.ToInt32(s, invCulture);
    private static double toDbl(string s) => Convert.ToDouble(s, invCulture);
    private static decimal toDec(string s) => Convert.ToDecimal(s, invCulture);
    private static byte toByte(string s) => Convert.ToByte(s, invCulture);
    private double rndDbl() => round(GetRandom.Double(toDbl(Min), toDbl(Max)));
    private decimal rndDec() => round(GetRandom.Decimal(toDec(Min), toDec(Max)));
    private double round(double d) => Scale.HasValue ? Math.Round(d, Scale.Value) : d;
    private decimal round(decimal d) => Scale.HasValue ? Math.Round(d, Scale.Value) : d;
    private DateTime minDt => YearsBack.HasValue ? DateTime.Now : toDt(Min);
    private DateTime maxDt => YearsBack.HasValue ? DateTime.Now.AddDays(YearsBack.Value) : toDt(Max);
    private static DateTime toDt(string s) => DateTime.Parse(s, invCulture, DateTimeStyles.RoundtripKind);
    private DateTime rndDt() {
        var v = GetRandom.DateTime(minDt, maxDt);
        return DateOnly ? v.Date : v;
    }
    private void set<T>(T min, T max, int scale = -1, bool dateOnly = false) where T : IFormattable {
        Min = toStr(min);
        Max = toStr(max);
        Scale = scale >= 0 ? scale : null;
        DateOnly = dateOnly;
    }
}

 */