namespace MinecraftMapTransfer.Extensions;

public static class StringExtension
{
    public static string ToRegionCoordinate(this string mapCoordinate)
    {
        const int standard = 510;
        
        var axis = mapCoordinate.Split(',', StringSplitOptions.RemoveEmptyEntries);

        var x = Convert.ToDouble(axis[0]);
        var z =  Convert.ToDouble(axis[1]);
        
        return $"{RoundUp(x / standard)},{RoundUp(z / standard)}";
    }

    #region Private Method

    private static double RoundUp(double value)
    {
        return value > 0 ? Math.Ceiling(value) : Math.Floor(value);
    }

    #endregion
}