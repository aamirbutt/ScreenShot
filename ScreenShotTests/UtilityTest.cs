using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Screenshot;
using System.Drawing;

namespace ScreenShotTests
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void GetSizeBasedOnBitmapSizeTest_FirstScreen()
        {
            //Arrange
            Size size = new Size(800, 600);
            var expected = new Size(1366, 768);
            //Act
            var actual = Utility.GetSizeBasedOnBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetSizeBasedOnBitmapSizeTest_SecondScreen()
        {
            //Arrange
            Size size = new Size(800, 900);
            var expected = new Size(1920, 1080);
            //Act
            var actual = Utility.GetSizeBasedOnBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetSizeBasedOnBitmapSizeTest_NoScreenFits1()
        {
            //Arrange
            Size size = new Size(2200, 600);
            var expected = new Size(3286, 1080);
            //Act
            var actual = Utility.GetSizeBasedOnBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetSizeBasedOnBitmapSizeTest_NoScreenFits2()
        {
            //Arrange
            Size size = new Size(2200, 900);
            var expected = new Size(3286, 1080);
            //Act
            var actual = Utility.GetSizeBasedOnBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSizeBasedOnBitmapSizeTest_SecondScreen2()
        {
            //Arrange
            Size size = new Size(1400, 600);
            var expected = new Size(1920, 1080);
            //Act
            var actual = Utility.GetSizeBasedOnBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void GetFormLocationFromBitmapSizeTest_FirstScreen()
        {
            //Arrange
            Size size = new Size(800, 600);
            var expected = new Point(0, 0);
            //Act
            var actual = Utility.GetFormLocationFromBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFormLocationFromBitmapSizeTest_SecondScreen()
        {
            //Arrange
            Size size = new Size(800, 900);
            var expected = new Point(1366, 0);
            //Act
            var actual = Utility.GetFormLocationFromBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFormLocationFromBitmapSizeTest_SecondScreen2()
        {
            //Arrange
            Size size = new Size(1400, 600);
            var expected = new Point(1366, 0);
            //Act
            var actual = Utility.GetFormLocationFromBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFormLocationFromBitmapSizeTest_NoScreenFits1()
        {
            //Arrange
            Size size = new Size(2200, 600);
            var expected = new Point(0, 0);
            //Act
            var actual = Utility.GetFormLocationFromBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFormLocationFromBitmapSizeTest_NoScreenFits2()
        {
            //Arrange
            Size size = new Size(2200, 900);
            var expected = new Point(0, 0);
            //Act
            var actual = Utility.GetFormLocationFromBitmapSize(size);
            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
