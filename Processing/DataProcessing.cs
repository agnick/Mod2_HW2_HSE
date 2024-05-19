using System.Globalization;

namespace Processing
{
    public static class DataProcessing
    {
        /// <summary>
        /// A method that generates a selection based on the name of the passed field.
        /// </summary>
        /// <param name="rowData">Array of lines read from a file.</param>
        /// <param name="selectValue">The name of the field to generate the selection by.</param>
        /// <returns>Array of rows of the selection result.</returns>
        public static string[] GenerateSelection(string[] rowData, string selectValue)
        {
            // Entering the specific value of the field for which you want to make a selection.
            string userValue;
            while (true)
            {
                Console.WriteLine($"Введите конкретное значение поля {selectValue} для организации выборки:");
                userValue = Console.ReadLine();

                // Checking that the entered value is not empty and is not null.
                if (!string.IsNullOrEmpty(userValue))
                {
                    break;
                }

                Console.WriteLine("Пустое значение поля, повторите ввод.");
            }

            // Converting the entered value to the file values format.
            userValue = $"\"{userValue}\"";

            // Splitting the first line by delimiter.
            string[] fistRow = rowData[0].Split(';', StringSplitOptions.RemoveEmptyEntries);
            // Finding the index of the transmitted field. 
            int indexOfSelection = Array.IndexOf(fistRow, selectValue);

            // Counting the number of rows (starting from the third line) where the value of the passed field corresponds to the value entered by the user.
            int n = 0;
            foreach (string row in rowData[2..])
            {
                // Splitting the line by delimiter.
                string[] data = row.Split(';', StringSplitOptions.RemoveEmptyEntries);
                // Checking that the passed field corresponds to the value entered by the user.
                if (data[indexOfSelection] == userValue)
                {
                    n++;
                }
            }

            // Returns null if the result the number of rows in the selection is zero.
            if (n == 0)
            {
                return null;
            }

            // Initialization a reference to a new array of strings of size n + 2 (taking into account the first two rows).
            string[] selection = new string[n + 2];
            selection[0] = rowData[0];
            selection[1] = rowData[1];

            // Filling in a new array according to the same rules as when checking for compliance.
            int i = 2;
            foreach (string row in rowData[2..])
            {
                // Splitting the line by delimiter.
                string[] data = row.Split(';', StringSplitOptions.RemoveEmptyEntries);
                // Checking that the passed field corresponds to the value entered by the user.
                if (data[indexOfSelection] == userValue)
                {
                    selection[i++] = row;
                }
            }

            return selection;
        }

        /// <summary>
        /// A method that generates a selection based on the name of the passed fields.
        /// </summary>
        /// <param name="rowData">Array of lines read from a file.</param>
        /// <param name="selectValue1">The name of the fisrt field to generate the selection by.</param>
        /// <param name="selectValue2">The name of the second field to generate the selection by.</param>
        /// <returns>Array of rows of the selection result.</returns>
        public static string[] GenerateSelection(string[] rowData, string selectValue1, string selectValue2)
        {
            // Entering the fisrt specific value of the field for which you want to make a selection.
            string userValue1;
            while (true)
            {
                Console.WriteLine($"Введите конкретное значение поля {selectValue1} для организации выборки:");
                userValue1 = Console.ReadLine();

                // Checking that the entered first value is not empty and is not null.
                if (!string.IsNullOrEmpty(userValue1))
                {
                    break;
                }

                Console.WriteLine("Пустое значение поля, повторите ввод.");
            }

            // Entering the second specific value of the field for which you want to make a selection.
            string userValue2;
            while (true)
            {
                Console.WriteLine($"Введите конкретное значение поля {selectValue2} для организации выборки:");
                userValue2 = Console.ReadLine();

                // Checking that the entered second value is not empty and is not null.
                if (!string.IsNullOrEmpty(userValue2))
                {
                    break;
                }

                Console.WriteLine("Пустое значение поля, повторите ввод.");
            }

            // Converting the entered values to the file values format.
            userValue1 = $"\"{userValue1}\"";
            userValue2 = $"\"{userValue2}\"";

            // Splitting the first line by delimiter.
            string[] firstRow = rowData[0].Split(';', StringSplitOptions.RemoveEmptyEntries);
            // Finding the indexes of the transmitted fields. 
            int indexOfSelection1 = Array.IndexOf(firstRow, selectValue1);
            int indexOfSelection2 = Array.IndexOf(firstRow, selectValue2);

            // Counting the number of rows (starting from the third line) where the values of the passed field corresponds to the values entered by the user.
            int n = 0;
            foreach (string row in rowData[2..])
            {
                // Splitting the line by delimiter.
                string[] data = row.Split(';', StringSplitOptions.RemoveEmptyEntries);
                // Checking that the passed fields corresponds to the values entered by the user.
                if (data[indexOfSelection1] == userValue1 && data[indexOfSelection2] == userValue2)
                {
                    n++;
                }
            }

            // Returns null if the result the number of rows in the selection is zero.
            if (n == 0)
            {
                return null;
            }

            // Initialization a reference to a new array of strings of size n + 2 (taking into account the first two rows).
            string[] selection = new string[n + 2];
            selection[0] = rowData[0];
            selection[1] = rowData[1];

            // Filling in a new array according to the same rules as when checking for compliance.
            int i = 2;
            foreach (string row in rowData[2..])
            {
                // Splitting the line by delimiter.
                string[] data = row.Split(';', StringSplitOptions.RemoveEmptyEntries);
                // Checking that the passed fields corresponds to the values entered by the user.
                if (data[indexOfSelection1] == userValue1 && data[indexOfSelection2] == userValue2)
                {
                    selection[i++] = row;
                }
            }

            return selection;
        }

        /// <summary>
        /// A method that generates a sorting based on the name of the passed field.
        /// </summary>
        /// <param name="rowData">Array of lines read from a file.</param>
        /// <param name="sortValue">The name of the field to generate the sorting by.</param>
        /// <returns>Array of rows of the sorting result.</returns>
        public static string[] GenerateSorting(string[] rowData, string sortValue)
        {
            // Splitting the first line by delimiter.
            string[] firstRow = rowData[0].Split(';', StringSplitOptions.RemoveEmptyEntries);
            // Finding the index of the transmitted field.
            int indexOfSorting = Array.IndexOf(firstRow, sortValue);

            // Initialization of a reference to an array of arrays with the size of the length of the transmitted array of file lines.
            string[][] rowDataSplitted = new string[rowData.Length][];
            // Filling an array of arrays with arrays consisting of elements of each line of the file.
            for (int i = 0; i < rowData.Length; i++)
            {
                rowDataSplitted[i] = rowData[i].Split(';', StringSplitOptions.RemoveEmptyEntries);
            }

            // An array storing field numbers, elements that have numeric values.
            int[] numbElements = { 0, 5, 7, 11, 12, 13 };
            // Selection of the sorting method depending on the value of the passed field.
            if (numbElements.Contains(indexOfSorting))
            {
                // Sorting in descending order of numerical values.
                BubbleSortDescending(rowDataSplitted, indexOfSorting);
            }
            else
            {
                // Sort alphabetically.
                BubbleSortAlph(rowDataSplitted, indexOfSorting);
            }

            // Initializing a reference to a new array that will contain the sorting result.
            string[] result = new string[rowDataSplitted.Length];
            // Filling in a new array.
            for (int i = 0; i < rowDataSplitted.Length; i++)
            {
                // Assigning a combined semicolon to a string consisting of elements of sorted strings.
                result[i] = string.Join(';', rowDataSplitted[i]) + ";";
            }

            return result;
        }

        /// <summary>
        /// A method that sorts an array of arrays by index (alphabetically).
        /// </summary>
        /// <param name="row">An array of arrays consisting of separated lines of a file.</param>
        /// <param name="sortByIndex">The index by which sorting will take place.</param>
        private static void BubbleSortAlph(string[][] row, int sortByIndex)
        {
            // Sorting.
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 2; i < row.Length - 1; i++)
                {
                    // Comparing rows by index field alphabetically.
                    if (row[i][sortByIndex].CompareTo(row[i + 1][sortByIndex]) > 0 || row[i][sortByIndex] == "")
                    {
                        // Exchange of lines.
                        string[] temp = row[i];
                        row[i] = row[i + 1];
                        row[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        /// <summary>
        /// A method that sorts an array of arrays by index (numerical values in descending order).
        /// </summary>
        /// <param name="row">An array of arrays consisting of separated lines of a file.</param>
        /// <param name="sortByIndex">The index by which sorting will take place.</param>
        private static void BubbleSortDescending(string[][] row, int sortByIndex)
        {
            // Sorting.
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 2; i < row.Length - 1; i++)
                {
                    // Comparing rows by index field (numerical values in descending order).
                    if (double.Parse(row[i][sortByIndex].Replace("\"", ""), CultureInfo.InvariantCulture) < double.Parse(row[i + 1][sortByIndex].Replace("\"", ""), CultureInfo.InvariantCulture) || row[i][sortByIndex] == "")
                    {
                        // Exchange of lines.
                        string[] temp = row[i];
                        row[i] = row[i + 1];
                        row[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

    }
}