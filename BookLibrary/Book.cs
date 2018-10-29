using System;
using System.Text;
using System.Globalization;

namespace BookLibrary
{
    public class Book : IFormattable
    {
		public string Title { get; private set; }
		public string Author { get; private set; }
		public int Year { get; private set; }
		public string PublishingHours { get; private set; }
		public int Edition { get; private set; }
		public int Pages { get; private set; }
		public int Price { get; private set; }

		public Book(string title, string author, int year, string publishingHours int edition, int pages, int price)
		{
			Title = title;
			Author = author;
			Year = year;
			PublishingHours = publishingHours;
			Edition = edition;
			Pages = pages;
			Price = price;
		}

		public string ToString(string format)
		{
			return this.ToString(format, CultureInfo.CurrentCulture);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			if (string.IsNullOrEmpty(format)) format = "G";

			if (provider == null) provider = CultureInfo.CurrentCulture;

			StringBuilder bookRecord = new StringBuilder();

			switch(format.ToUpperInvariant())
			{
				case "G":
					return $"{Author}, {Title}";

				case "GYP":
					return $"{Author}, {Title}, {Year}";

				case "GE":
					return $"{Author}, {Title}, {Edition}";

				case "F":
					return $"{Author}, {Title}, {Year}, {PublishingHours}, {Edition}, {Pages}, {Price.ToString("C")}";

				case "T":
					return $"{Title}";

				case "TYP":
					return $"{Title}, {Year}, {PublishingHours}";

				default:
					throw new FormatException(String.Format("The {0} format string is not supported.", format));
			}
		}
	}
}
