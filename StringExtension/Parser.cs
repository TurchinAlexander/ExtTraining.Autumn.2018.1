using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (source.Length == 0) throw new ArgumentException(nameof(source));
			if ((@base < 2) || (@base > 16)) throw new ArgumentOutOfRangeException(nameof(@base));

			CheckStringForBase(source, @base);

			return ConvertToDecimal(source, @base);
        }

		private static int ConvertToDecimal(string source, int @base)
		{
			string sourceBase = source.ToUpper();
			string digits = "0123456789ABCDEF";
			int result = 0;

			for (int i = 0; i < sourceBase.Length; i++)
			{
				int digit = digits.IndexOf(sourceBase[i]);

				if (((int.MaxValue - digit) / @base) >= result)
				{
					result = (result * @base + digit);
				}
				else
				{
					throw new OverflowException(nameof(source));
				}

				
			}

			return result;
		}

		private static void CheckStringForBase(string source, int @base)
		{
			string sourceBase = source.ToUpper();
			string digits = "0123456789ABCDEF";
			bool isValid = true;

			for (int i = 0; (i < sourceBase.Length) && isValid; i++)
			{
				int index = digits.IndexOf(sourceBase[i]);
				isValid = ((index >= 0) && (index < @base));
			}

			if (!isValid) throw new ArgumentException(nameof(@base));
		}
	}
}
