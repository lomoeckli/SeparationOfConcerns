namespace SeparationOfConcerns
{
    public class MultiplicationTable
    {
        // Öffentliche Methode, die die Multiplikationstabelle für eine Liste von Zahlen druckt
        public static void For(List<int> numbers)
        {
            // Eingabe validieren
            ValidateInput(numbers);

            // Bestimme die größte Zahl und das größte Ergebnis
            var biggest = GetBiggestNumber(numbers);
            var biggestResult = biggest * biggest;

            // Berechne die Magnitude (Breite der Spalten)
            var magnitude = GetMagnitude(biggestResult);

            // Erzeuge und drucke die Tabelle
            PrintTable(numbers, magnitude);
        }

        // Validierung der Eingabewerte
        private static void ValidateInput(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("Die Liste darf nicht leer sein.");
            }

            foreach (var number in numbers)
            {
                if (number < 0)
                {
                    throw new ArgumentException("Negative Zahlen sind nicht unterstützt.");
                }
            }
        }

        // Bestimmt die größte Zahl aus der Liste
        public static int GetBiggestNumber(List<int> numbers)
        {
            var biggest = int.MinValue;
            foreach (var number in numbers)
            {
                if (number > biggest)
                {
                    biggest = number;
                }
            }
            return biggest;
        }

        // Berechnet die Magnitude, also die benötigte Spaltenbreite
        public static int GetMagnitude(int biggestResult)
        {
            var magnitude = 0;
            // Berechne die Anzahl der Ziffern des größten Ergebnisses
            while (biggestResult > 0)
            {
                magnitude++;
                biggestResult /= 10;
            }
            return magnitude; // Keine zusätzliche Erhöhung mehr
        }


        // Gibt die Multiplikationstabelle aus
        private static void PrintTable(List<int> numbers, int magnitude)
        {
            // Drucke die Titelzeile
            var titleRow = GenerateTitleRow(numbers, magnitude);
            Console.WriteLine(titleRow);

            // Drucke die Trennlinie
            PrintSeparator(titleRow.Length);

            // Drucke die Multiplikationstabelle
            foreach (var row in numbers)
            {
                PrintRow(row, numbers, magnitude);
            }
        }

        // Generiert die Titelzeile
        private static string GenerateTitleRow(List<int> numbers, int magnitude)
        {
            var titleRow = "*".PadLeft(magnitude) + " ||";
            foreach (var col in numbers)
            {
                titleRow += $"{col}".PadLeft(magnitude) + " |";
            }
            return titleRow;
        }

        // Druckt eine Trennlinie basierend auf der Länge der Titelzeile
        private static void PrintSeparator(int length)
        {
            for (var i = 0; i < length; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        // Druckt eine einzelne Zeile der Tabelle
        private static void PrintRow(int row, List<int> numbers, int magnitude)
        {
            Console.Write($"{row}".PadLeft(magnitude) + " ||");
            foreach (var col in numbers)
            {
                var product = row * col;
                Console.Write($"{product}".PadLeft(magnitude) + " |");
            }
            Console.WriteLine();
        }
    }
}
