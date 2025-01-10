using System;
using System.Collections.Generic;
using Xunit;

namespace SeparationOfConcerns.Test
{
    public class MultiplicationTableTest
    {
        // Testet die Eingabevalidierung, insbesondere negative Zahlen
        [Fact]
        public void TestNegativeNumberThrowsException()
        {
            // Arrange
            var numbers = new List<int> { 2, -3, 5 };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => MultiplicationTable.For(numbers));
            Assert.Equal("Negative Zahlen sind nicht unterstützt.", exception.Message);
        }

        // Testet die Eingabevalidierung, insbesondere leere Listen
        [Fact]
        public void TestEmptyListThrowsException()
        {
            // Arrange
            var numbers = new List<int>();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => MultiplicationTable.For(numbers));
            Assert.Equal("Die Liste darf nicht leer sein.", exception.Message);
        }

        // Testet die Berechnung der größten Zahl und Magnitude
        [Fact]
        public void TestMagnitudeCalculation()
        {
            // Arrange
            var numbers = new List<int> { 5, 3, 12, 7 };

            // Act
            var biggest = MultiplicationTable.GetBiggestNumber(numbers);
            var biggestResult = biggest * biggest;
            var magnitude = MultiplicationTable.GetMagnitude(biggestResult);

            // Assert
            Assert.Equal(12, biggest); // größte Zahl sollte 12 sein
            Assert.Equal(3, magnitude); // Die Magnitude für 12*12 = 144 sollte 3 sein
        }

        // Testet die Berechnung der Tabelle mit einer einfachen Liste
        [Fact]
        public void TestSimpleMultiplicationTable()
        {
            // Arrange
            var numbers = new List<int> { 2, 3, 4 };

            // Act & Assert
            var exception = Record.Exception(() => MultiplicationTable.For(numbers));

            // Es wird keine Ausnahme erwartet
            Assert.Null(exception);
        }

        // Testet die Ausgabe der Tabelle bei einer kleinen Liste
        [Fact]
        public void TestSingleRowMultiplicationTable()
        {
            // Arrange
            var numbers = new List<int> { 1 };

            // Act & Assert
            var exception = Record.Exception(() => MultiplicationTable.For(numbers));

            // Es wird keine Ausnahme erwartet
            Assert.Null(exception);
        }

        // Testet die Tabelle mit größeren Zahlen
        [Fact]
        public void TestLargeNumbers()
        {
            // Arrange
            var numbers = new List<int> { 100, 200, 300 };

            // Act & Assert
            var exception = Record.Exception(() => MultiplicationTable.For(numbers));

            // Es wird keine Ausnahme erwartet
            Assert.Null(exception);
        }
    }
}
