using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod]
        public void ColourConstructor()
        {
            Colour c = new Colour(0x12, 0x34, 0x56, 0x78);

            Assert.AreEqual<UInt32>(0x12345678, c.colour);
        }

        [TestMethod]
        public void ColourGetRed()
        {
            Colour c = new Colour(0x12, 0x34, 0x56, 0x78);

            Assert.AreEqual<byte>(0x12, c.Red);
        }

        [TestMethod]
        public void ColourGetGreen()
        {
            Colour c = new Colour(0x12, 0x34, 0x56, 0x78);

            Assert.AreEqual<byte>(0x34, c.Green);
        }

        [TestMethod]
        public void ColourGetBlue()
        {
            Colour c = new Colour(0x12, 0x34, 0x56, 0x78);

            Assert.AreEqual<byte>(0x56, c.Blue);
        }

        [TestMethod]
        public void ColourGetAlpha()
        {
            Colour c = new Colour(0x12, 0x34, 0x56, 0x78);

            Assert.AreEqual<byte>(0x78, c.Alpha);
        }

        [TestMethod]
        public void ColourSetRed()
        {
            Colour c = new Colour();
            c.Red = 0x12;

            Assert.AreEqual<UInt32>(0x12000000, c.colour);
        }

        [TestMethod]
        public void ColourSetGreen()
        {
            Colour c = new Colour();
            c.Green = 0x34;

            Assert.AreEqual<UInt32>(0x00340000, c.colour);
        }

        [TestMethod]
        public void ColourSetBlue()
        {
            Colour c = new Colour();
            c.Blue = 0x56;

            Assert.AreEqual<UInt32>(0x00005600, c.colour);
        }

        [TestMethod]
        public void ColourSetAlpha()
        {
            Colour c = new Colour();
            c.Alpha = 0x78;

            Assert.AreEqual<UInt32>(0x00000078, c.colour);
        }

        [TestMethod]
        public void ColourGetSetAll()
        {
            Colour c = new Colour(0x12, 0x34, 0x56, 0x78);
            c.Red = 0x12;
            c.Green = 0x34;
            c.Blue = 0x56;
            c.Alpha = 0x78;

            Assert.AreEqual<byte>(c.Red, 0x12);
            Assert.AreEqual<byte>(c.Green, 0x34);
            Assert.AreEqual<byte>(c.Blue, 0x56);
            Assert.AreEqual<byte>(c.Alpha, 0x78);
        }
    }
}
