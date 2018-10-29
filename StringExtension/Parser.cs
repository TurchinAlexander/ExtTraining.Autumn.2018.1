using System;


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
			// The value of the digit is his index in the string;
			string digits = "0123456789ABCDEF";
			int result = 0;

			for (int i = 0; i < sourceBase.Length; i++)
			{
				int digit = digits.IndexOf(sourceBase[i]);

				// We check if the next interation of increasing digit won't cause his overflow.
				// It's like int.MaxValue >= result * base + digit
				if (((int.MaxValue - digit) / @base) >= result)
				{
					throw new OverflowException(nameof(source));
				}

				result = (result * @base + digit);
			}

			return result;
		}

		private static void CheckStringForBase(string source, int @base)
		{
			string sourceBase = source.ToUpper();
			// The value of the digit is his index in the string;
			string digits = "0123456789ABCDEF";
			bool isValid = true;

			for (int i = 0; (i < sourceBase.Length) && isValid; i++)
			{
				int index = digits.IndexOf(sourceBase[i]);
				// We check if digit is in standard set of digits and not bigger than his base.
				isValid = ((index >= 0) && (index < @base));
			}

			if (!isValid) throw new ArgumentException(nameof(@base));
		}
	}
}
