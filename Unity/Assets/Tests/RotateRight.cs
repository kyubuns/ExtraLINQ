using NUnit.Framework;

namespace ExtraLinq.Tests
{
    public class RotateRightTests
    {
        [Test]
        public static void Plus()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateRight(1));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateRight(2));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateRight(3));
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateRight(4));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateRight(5));
        }

        [Test]
        public static void Over()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateRight(6));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateRight(7));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateRight(8));
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateRight(9));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateRight(10));
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateRight(11));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateRight(12));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateRight(13));
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateRight(14));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateRight(15));
        }

        [Test]
        public static void Zero()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateRight(0));
        }

        [Test]
        public static void Minus()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 1 }, numbers.RotateRight(-1));
            CollectionAssert.AreEqual(new[] { 3, 4, 5, 1, 2 }, numbers.RotateRight(-2));
            CollectionAssert.AreEqual(new[] { 4, 5, 1, 2, 3 }, numbers.RotateRight(-3));
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4 }, numbers.RotateRight(-4));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers.RotateRight(-5));
        }
    }
}
