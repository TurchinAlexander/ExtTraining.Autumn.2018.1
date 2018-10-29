using System;
using NUnit.Framework;

using BookLibrary;

namespace BookExtension.Tests
{
	[TestFixture]
	public class BookFormatExtensionTests
	{
		[Test]
		public void BookExtention_StandartGlobal_ReturnString()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "Jon Skeet, C# in Depth";
			BookFormatExtension bookExtention = new BookFormatExtension();

			string actual = String.Format(bookExtention, "{0:G}", book);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BookExtention_StandartGlobalYear_ReturnString()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "Jon Skeet, C# in Depth, 2019";
			BookFormatExtension bookExtention = new BookFormatExtension();

			string actual = String.Format(bookExtention, "{0:GY}", book);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BookExtention_StandartTitle_ReturnString()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "C# in Depth";
			BookFormatExtension bookExtention = new BookFormatExtension();

			string actual = String.Format(bookExtention, "{0:T}", book);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BookExtention_ProviderGlobalInversion_ReturnString()
		{
			Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
			string expected = "C# in Depth, Jon Skeet";
			BookFormatExtension bookExtention = new BookFormatExtension();

			string actual = String.Format(bookExtention, "{0:GI}", book);

			Assert.AreEqual(expected, actual);
		}

		
	}
}
