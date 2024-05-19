public class Methods
{
    /// <summary>
    /// A method that processes the selection result and performs actions based on it.
    /// </summary>
    /// <param name="selection">The resulting selection.</param>
    /// <param name="selectField">The name of the field for which the selection was made.</param>
    public static void ProcessSelection(string[] selection, string selectField)
    {
        // Сhecking that the selection is empty (equal to null in the context).
        if (selection is null)
        {
            Console.WriteLine("Результат выборки пуст.");
        }
        else
        {
            Console.WriteLine("Результат выборки (выведены не все поля, для нормального отображения):");
            // Calling a method that prints a table of values in the console.
            PrintTable(selection, selectField);
            // Calling a method that prompts the user to save data.
            Menu.SaveDataMenu(selection);
        }
    }

    /// <summary>
    /// A method that processes the selection result and performs actions based on it.
    /// </summary>
    /// <param name="selection">The resulting selection.</param>
    /// <param name="selectField1">The name of the first field for which the selection was made.</param>
    /// <param name="selectField2">The name of the second field for which the selection was made.</param>
    public static void ProcessSelection(string[] selection, string selectField1, string selectField2)
    {
        // Сhecking that the selection is empty (equal to null in the context).
        if (selection is null)
        {
            Console.WriteLine("Результат выборки пуст.");
        }
        else
        {
            Console.WriteLine("Результат выборки (выведены не все поля, для нормального отображения):");
            // Calling a method that prints a table of values in the console.
            PrintTable(selection, selectField1, selectField2);
            // Calling a method that prompts the user to save data.
            Menu.SaveDataMenu(selection);
        }
    }

    /// <summary>
    /// A method that processes the sorting.
    /// </summary>
    /// <param name="sorting">The resulting sorting.</param>
    /// <param name="sortField">The name of the field for which the sorting was made.</param>
    public static void ProcessSorting(string[] sorting, string sortField)
    {
        Console.WriteLine("Результат сортировки (выведены не все поля, для нормального отображения):");
        // Calling a method that prints a table of values in the console.
        PrintTable(sorting, sortField);
        // Calling a method that prompts the user to save data.
        Menu.SaveDataMenu(sorting);
    }

    /// <summary>
    /// A method that outputs the result of sampling or sorting by one field.
    /// </summary>
    /// <param name="data">The transmitted result of the selection or sorting.</param>
    /// <param name="field">The name of the field for which the selection or sorting was made.</param>
    public static void PrintTable(string[] data, string field)
    {
        // Splitting the first line by delimiter.
        string[] firstRow = data[0].Split(";", StringSplitOptions.RemoveEmptyEntries);
        // Finding the index of the transmitted field.
        int fieldIndex = Array.IndexOf(firstRow, field);

        // Calling a method that finds the maximum string length of the all fields.
        int[] maxLength = GetMaxElementLength(data);

        // Outputting of field values in tabular form.
        foreach (string row in data)
        {
            // Splitting the line by delimiter.
            string[] splitted = row.Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitted.Length; i++)
            {
                // Outputting only the values of the first and transmitted field because of console size.
                if (i == 0 || i == fieldIndex)
                {
                    // Adding an empty string to the value for a beautiful output, the length of which is equal to the maximum length of the field value minus the length of the current string.
                    Console.Write($"| {splitted[i] + new string(' ', maxLength[i] - splitted[i].Length)} ");
                }
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// A method that outputs the result of sampling or sorting by two fields.
    /// </summary>
    /// <param name="data">The transmitted result of the selection or sorting.</param>
    /// <param name="field1">The name of the first field for which the selection or sorting was made.</param>
    /// <param name="field2">The name of the second field for which the selection or sorting was made.</param>
    public static void PrintTable(string[] data, string field1, string field2)
    {
        // Splitting the first line by delimiter.
        string[] firstRow = data[0].Split(";", StringSplitOptions.RemoveEmptyEntries);
        // Finding the index of the transmitted firts field.
        int fieldIndex1 = Array.IndexOf(firstRow, field1);
        // Finding the index of the transmitted second field.
        int fieldIndex2 = Array.IndexOf(firstRow, field2);

        // Calling a method that finds the maximum string length of the all fields.
        int[] maxLength = GetMaxElementLength(data);

        // Outputting of field values in tabular form.
        foreach (string row in data)
        {
            // Splitting the line by delimiter.
            string[] splitted = row.Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitted.Length; i++)
            {
                // Outputting only the values of the first and transmitted fields because of console size.
                if (i == 0 || i == fieldIndex1 || i == fieldIndex2)
                {
                    // Adding an empty string to the value for a beautiful output, the length of which is equal to the maximum length of the field value minus the length of the current string.
                    Console.Write($"| {splitted[i] + new string(' ', maxLength[i] - splitted[i].Length)} ");
                }
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// A method that finds the maximum length of a row in the corresponding column of a field.
    /// </summary>
    /// <param name="data">The transmitted result of the selection or sorting.</param>
    /// <returns>Array of maximum string lengths.</returns>
    public static int[] GetMaxElementLength(string[] data)
    {
        // Splitting the first line by delimiter.
        string[] firstRow = data[0].Split(";", StringSplitOptions.RemoveEmptyEntries);
        // Creating a reference to an array of the length of the number of fields of a line.
        int[] maxLength = new int[firstRow.Length];
        // Filling an array.
        for (int n = 0; n < data.Length; n++)
        {
            // Splitting the line by delimiter.
            string[] splittedValues = data[n].Split(";", StringSplitOptions.RemoveEmptyEntries);
            // Loop over each element of the string.
            for (int k = 0; k < splittedValues.Length; k++)
            {
                // Updating the maximum field length.
                maxLength[k] = Math.Max(maxLength[k], splittedValues[k].Length);
            }
        }
        return maxLength;
    }

    /// <summary>
    /// A method that combines the rows of a selection or sorting result into one.
    /// </summary>
    /// <param name="data">The transmitted result of the selection or sorting.</param>
    /// <returns>A new string consisting of the combined rows of the result of the selection or sorting.</returns>
    public static string CreateString(string[] data)
    {
        // Declaring a link to a new common string.
        string result = "";
        // Adding a selection or sorting result row to a new shared string.
        foreach (string row in data[2..])
        {
            result += $"{row}\n";
        }
        return result;
    }

    /// <summary>
    /// A method that outputs a red - marked error.
    /// </summary>
    /// <param name="errorMessage">Transmitted error message.</param>
    public static void PrintBeautyError(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();
    }
}