using System.Globalization;

namespace LMS.Business.Common
{
    public static class NumberHelper
    {
        public static decimal GetNumberFormatted(string amount)
        {
            if (string.IsNullOrEmpty(amount))
                amount = "0.00";

            return decimal.Parse(amount, NumberStyles.Currency);
        }

    }
}
