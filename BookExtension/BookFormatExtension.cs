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

			if (uformat != "GI")
			{
				try
				{
					return HandleOtherFormats(format, arg);
				}
				catch (FormatException e)
				{
					throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
				}
			}

			Book book = (Book)arg;

			// Global Inverse
			return $"{book.Title}, {book.Author}";
		}

		public string HandleOtherFormats(string format, object arg)
		{
			if (arg is IFormattable)
			{
				return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
			}
			else if (arg != null)
			{
				return arg.ToString();
			}
			else
			{
				return string.Empty;
			}
		}
		
	}
}
