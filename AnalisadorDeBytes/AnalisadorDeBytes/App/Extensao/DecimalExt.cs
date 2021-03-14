using System;

namespace AnalisadorDeBytes.App.Extensao
{
    public static class DecimalExt
    {
        public static string ToMegaBytesString(this decimal bytes)
        {
            return $"{ Math.Round(bytes / 1024 / 1024, 2).ToString().Replace(',', '.') }mb";
        }
    }
}
