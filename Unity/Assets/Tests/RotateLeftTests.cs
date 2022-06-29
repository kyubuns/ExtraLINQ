using NUnit.Framework;

namespace ExtraLinq.Tests
{
    public class RotateLeftTests
    {
        [Test]
        public static void Plus()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateLeft(1));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateLeft(2));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateLeft(3));
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateLeft(4));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateLeft(5));
        }

        [Test]
        public static void Over()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateLeft(6));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateLeft(7));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateLeft(8));
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateLeft(9));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateLeft(10));
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateLeft(11));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateLeft(12));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateLeft(13));
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateLeft(14));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateLeft(15));
        }

        [Test]
        public static void Zero()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateLeft(0));
        }

        [Test]
        public static void Minus()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateLeft(-1));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateLeft(-2));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateLeft(-3));
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateLeft(-4));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateLeft(-5));
        }
    }
}
