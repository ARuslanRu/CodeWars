using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.UnitTests
{
    [TestFixture]
    class PaginationTest
    {
        List<int> values;
        List<int> random;
        List<string> books;

        [OneTimeSetUp]
        public void Init()
        {
            values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            random = new List<int>();

            var rnd = new Random();
            for (int i = 0; i < 45; i++) random.Add(rnd.Next(1, 12345));

            books = new List<string>()
    {
      "Watership Down, Richard Adams",
      "Brave New World, Aldous Huxley",
      "1984, George Orwell",
      "Fahrenheit 451, Ray Bradbury",
      "Non-Violent Resistance: Satyagraha, Mohandas K. Gandhi",
      "The Wonderful Story of Henry Sugar and Six More, Roald Dahl",
      "Island, Aldous Huxley",
      "Green Shadows, White Whale, Ray Bradbury",
      "In the Penal Colony, Franz Kafka",
      "The Catcher in the Rye, J. D. Salinger",
      "The Last Battle, C. S. Lewis",
      "Borderliners, Peter Hoeg",
      "Animal Farm, George Orwell",
      "Our Town, Thornton Wilder",
      "Beware the Fish!, Gordon Korman",
      "One Day in the Life of Ivan Denisovich, Alexander Solzhenitsyn",
      "The Mouse That Roared (series), Leonard Wibberly",
      "Night, Elie Wiesel",
      "Cat’s Cradle, Kurt Vonnegut Jr.",
      "The Short Stories, Ernest Hemingway",
      "The Great Gatsby, F. Scott Fitzgerald",
      "Antigone, Sophocles",
      "I Sing the Body Electric!, Ray Bradbury",
      "Trout Fishing in America, Richard Brautigan",
      "All Creatures Great and Small (series), James Herriot",
      "Babar’s Anniversary Book, Jean and Laurent de Brunhoff",
      "Pigs Might Fly, Dick King-Smith",
      "James and the Giant Peach, Roald Dahl",
      "The Jungle Book, Rudyard Kipling",
      "Gandhi on Non-Violence, Mohandas K. Gandhi",
      "The Little History of the Wide World, Mable Pyne"
    };
        }

        [Test]
        public void ValuesPage1Test()
        {
            var p = new Pagination<int>(values);

            Assert.AreEqual(1, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(23, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(3, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }

        [Test]
        public void ValuesPage2Test()
        {
            var p = new Pagination<int>(values);

            p.CurrentPage = 2;

            Assert.AreEqual(2, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(23, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(3, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(new List<int>() { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }

        [Test]
        public void ValuesPage3Test()
        {
            var p = new Pagination<int>(values);

            p.CurrentPage = 3;

            Assert.AreEqual(3, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(23, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(3, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(new List<int>() { 21, 22, 23 }),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }

        [Test]
        public void BooksPage1Test()
        {
            var p = new Pagination<string>(books);

            p.CurrentPage = 1;
            p.ItemsPerPage = 5;

            Assert.AreEqual(1, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(31, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(7, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(books.GetRange(0, 5)),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }

        [Test]
        public void BooksPage2Test()
        {
            var p = new Pagination<string>(books);

            p.CurrentPage = 2;
            p.ItemsPerPage = 5;

            Assert.AreEqual(2, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(31, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(7, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(books.GetRange(5, 5)),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }

        [Test]
        public void BooksPage3Test()
        {
            var p = new Pagination<string>(books);

            p.CurrentPage = 3;
            p.ItemsPerPage = 5;

            Assert.AreEqual(3, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(31, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(7, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(books.GetRange(10, 5)),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }

        [Test]
        public void RandomTest()
        {
            var p = new Pagination<int>(random);

            var rnd = new Random();

            int items = rnd.Next(1, random.Count);
            int totalpages = (int)Math.Ceiling(random.Count / (decimal)items);
            int page = rnd.Next(1, totalpages);

            p.CurrentPage = page;
            p.ItemsPerPage = items;

            Assert.AreEqual(page, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(random.Count, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(totalpages, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(random.GetRange((page - 1) * items, items)),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }

        [Test]
        public void GettableSettable()
        {
            Assert.IsFalse(
              typeof(Pagination<string>).GetProperty("Items").CanWrite
              || typeof(Pagination<string>).GetProperty("Total").CanWrite
              || typeof(Pagination<string>).GetProperty("TotalPages").CanWrite,
              "Properties Items, Total and TotalPages should only be gettable"
            );
        }

        [Test]
        public void DefaultPropertyValues()
        {
            var p = new Pagination<int>(values);

            Assert.AreEqual(1, p.CurrentPage, "Default value incorrect (CurrentPage)");
            Assert.AreEqual(10, p.ItemsPerPage, "Default value incorrect (ItemsPerPage)");
        }

        [Test]
        public void InvalidPropertyValues()
        {
            var p = new Pagination<int>(values);

            p.CurrentPage = -1;
            Assert.AreEqual(1, p.CurrentPage, "Property should use default if set to invalid (CurrentPage)");

            p.ItemsPerPage = -1;
            Assert.AreEqual(10, p.ItemsPerPage, "Property should use default if set to invalid (ItemsPerPage)");
        }

        [Test]
        public void EmptyOnHigherThanTotalPages()
        {
            var p = new Pagination<int>(values);

            p.CurrentPage = p.TotalPages + 1;
            Assert.IsTrue(p.Items.Count() == 0, "Items should be empty if CurrentPage > TotalPages");
        }
    }
}
