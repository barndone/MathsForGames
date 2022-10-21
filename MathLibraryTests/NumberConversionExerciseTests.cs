using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class NumberConversionExerciseTests
    {

        [TestMethod]
        public void QuestionThree()
        {
            Colour c = new Colour();
            c.Red = 94;

            Assert.AreEqual("10111100", Convert.ToString(c.Red, 2));
        }

        [TestMethod]
        public void QuestionFour()
        {
            Colour c = new Colour();
            c.Red = 94;

            Assert.AreEqual("10111100000000000000000000000000", 
                Convert.ToString(c.colour, 2));
        }

        [TestMethod]
        public void QuestionFive()
        {
            Colour c = new Colour();
            c.Red = 94;

            string colour = Convert.ToString(c.colour, 2);


            Assert.AreEqual(3154116608, Convert.ToUInt32(colour, 2));
        }

        [TestMethod]
        public void QuestionSix()
        {
            Colour c = new Colour();
            c.Red = 94;
            c.colour = (c.colour & 0x00ff0000) | (c.colour >> 8);

            Assert.AreEqual("00000000101111000000000000000000", 
                Convert.ToString(c.colour, 2));
            
        }


        [TestMethod]
        public void QuestionSeven()
        {
            Colour c = new Colour();
            c.Red = 94;
            c.colour = (c.colour & 0xff00ffff) | ((UInt32)c.colour >> 8);

            string colour = Convert.ToString(c.colour, 2);

            Assert.AreEqual((UInt32)12320768, Convert.ToUInt32(colour, 2));
        }
       
    }
}
