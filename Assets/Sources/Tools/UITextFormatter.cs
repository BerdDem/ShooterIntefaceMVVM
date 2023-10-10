using System.Globalization;

namespace Sources.Tools
{
    public static class UITextFormatter
    {
        private const string space = " ";

        public static readonly CultureInfo cultureNumber = new CultureInfo("ru-RU")
        {
            NumberFormat =
            {
                NumberGroupSeparator = space
            }
        };
    }
}