using System;

namespace AnalisadorDeBytes.App.Extensao
{
    public static class TimeSpanExt
    {
        public static string ToTimeFormat(this TimeSpan time)
        {
            return time.ToString(@"hh\:mm\:ss\.fff");
        }
    }
}
