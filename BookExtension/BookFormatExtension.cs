using System;
using System.Globalization;

using BookLibrary;

namespace BookExtension
{
	public class BookFormatExtension : IFormatProvider, ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(ICustomFormatter))
				return this;
			else
				return null;
				
		}

		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			string uformat = format.ToUpper();

			// The condition if an user wrote not BookFormat's format.
			if (uformat != "GI")
			{
				return HandleOtherFormats(format, arg);
			}

			// If an user wrote our format, then we casting to Book class.
			Book book = (Book)arg;

			// And then just return our format string.
			return $"{book.Title}, {book.Author}";
		}

		public string HandleOtherFormats(string format, object arg)
		{
			// If format implement IFormattable interfase, then we call IFormattable.ToString().
			if (arg is IFormattable)
			{
				return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
			}
			// Else just call standard method ToString().
			else if (arg != null)
			{
				return arg.ToString();
			}
			// And if we have null, then we have nothing to convert to string.
			else
			{
				return string.Empty;
			}
		}
		
	}
}
