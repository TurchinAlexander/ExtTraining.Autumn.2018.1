using System;
using NUnit.Framework;

namespace BookLibrary.Tests
{
	[TestFixture]
    public class BookTests
    {
		[Test]
		public void Book_GlobalFormat_ReturnFormat()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "Jon Skeet, C# in Depth";

			string actual = book.ToString("G");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Book_GlobalYearFormat_ReturnFormat()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "Jon Skeet, C# in Depth, 2019";

			string actual = book.ToString("GY");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Book_GlobalEditionFormat_ReturnFormat()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "Jon Skeet, C# in Depth, 4";

			string actual = book.ToString("GE");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Book_FullFormat_ReturnFormat()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "Jon Skeet, C# in Depth, 2019, Manning, 4, 900, 40$";

			string actual = book.ToString("F");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Book_TitleFormat_ReturnFormat()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "C# in Depth";

			string actual = book.ToString("T");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Book_TitleYearFormat_ReturnFormat()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "C# in Depth, 2019";

			string actual = book.ToString("TY");

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Book_TitleYearPublishingFormat_ReturnFormat()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "C# in Depth, 2019, Manning";

			string actual = book.ToString("TYP");

			Assert.AreEqual(expected, actual);
		}

	}
}
