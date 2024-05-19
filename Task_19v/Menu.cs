public class Menu
{
    /// <summary>
    /// A method that contains the basic logic of the console application calls the necessary methods depending on the user's choice.
    /// </summary>
    /// <param name="rowData">Array of file lines.</param>
    public static void OpenMenu(string[] rowData)
    {
        // Entering the menu item number of the user's choice.
        int n;
        while (true)
        {
            // Displaying the main user menu.
            Console.Write("1. Произвести выборку по значению AdmArea\r\n2. Произвести выборку по значению WiFiName\r\n3. Произвести выборку по значению FunctionFlag и AccessFlag\r\n4. Отсортировать таблицу по значению LibraryName (по алфавиту)\r\n5. Отсортировать таблицу по значению CoverageArea (по убыванию)\r\n6. Выйти из программы\r\n");
            Console.Write("Укажите номер пункта меню для запуска действия: ");

            // Checking the correctness of the entered data.
            if (int.TryParse(Console.ReadLine(), out n) && n >= 1 && n <= 6)
            {
                break;
            }

            // Calling a method that outputs a red-marked error.
            Methods.PrintBeautyError("Неизвестная команда, повторите ввод.");
        }

        // Array for storing data selection.
        string[] selection;
        // Array for storing data sorting.
        string[] sorting;

        // Performing actions depending on user input.
        switch (n)
        {
            case 1:
                // Calling a method that returns a selection based on the passed AdmArea field.
                selection = Processing.DataProcessing.GenerateSelection(rowData, "\"AdmArea\"");
                // Calling a method that checks the result of the selection and based on it calls other methods for outputting the table and writing the result to a file.
                Methods.ProcessSelection(selection, "\"AdmArea\"");
                break;
            case 2:
                // Calling a method that returns a selection based on the passed WiFiName field.
                selection = Processing.DataProcessing.GenerateSelection(rowData, "\"WiFiName\"");
                // Calling a method that checks the result of the selection and based on it calls other methods for outputting the table and writing the result to a file.
                Methods.ProcessSelection(selection, "\"WiFiName\"");
                break;
            case 3:
                // Calling a method that returns a selection based on the passed FunctionFlag and AccessFlag fields.
                selection = Processing.DataProcessing.GenerateSelection(rowData, "\"FunctionFlag\"", "\"AccessFlag\"");
                // Calling a method that checks the result of the selection and based on it calls other methods for outputting the table and writing the result to a file.
                Methods.ProcessSelection(selection, "\"FunctionFlag\"", "\"AccessFlag\"");
                break;
            case 4:
                // Calling a method that returns a sorting based on the passed LibraryName field.
                sorting = Processing.DataProcessing.GenerateSorting(rowData, "\"LibraryName\"");
                // Calling a method that calls other methods for outputting the sorted table and writing the result to a file.
                Methods.ProcessSorting(sorting, "\"LibraryName\"");
                break;
            case 5:
                // Calling a method that returns a sorting based on the passed CoverageArea field.
                sorting = Processing.DataProcessing.GenerateSorting(rowData, "\"CoverageArea\"");
                // Calling a method that calls other methods for outputting the sorted table and writing the result to a file.
                Methods.ProcessSorting(sorting, "\"CoverageArea\"");
                break;
            case 6:
                // End of the program.
                Console.WriteLine("Программа завершена.");
                break;
        }
    }

    /// <summary>
    /// A method that allows the user to choose whether to save the file or not.
    /// </summary>
    /// <param name="data">The transmitted result of the selection or sorting.</param>
    public static void SaveDataMenu(string[] data)
    {
        // Entering the menu item number of the user's choice.
        int n;
        while (true)
        {
            // Displaying the user menu.
            Console.WriteLine("Укажите номер пункта меню для запуска действия:");
            Console.WriteLine("1. Записать результат в файл\r\n2. Завершить программу");

            if (int.TryParse(Console.ReadLine(), out n) && n >= 1 && n <= 2)
            {
                break;
            }

            // Calling a method that outputs a red - marked error.
            Methods.PrintBeautyError("Неизвестная команда, повторите ввод.");
        }

        // If the user wants to save the result to a file.
        if (n == 1)
        {
            // Entering the menu item number of the user's choice.
            int k;
            while (true)
            {
                // Displaying the user menu.
                Console.WriteLine("Укажите номер пункта меню для запуска действия:");
                Console.WriteLine("1. Дописать результат в конец файла\r\n2. Перезаписать результат в файл");

                if (int.TryParse(Console.ReadLine(), out k) && k >= 1 && k <= 2)
                {
                    break;
                }

                // Calling a method that outputs a red - marked error
                Methods.PrintBeautyError("Неизвестная команда, повторите ввод.");
            }

            string? nPath;

            while (true)
            {
                Console.Write("Введите название файла для сохранения результата. Пример ввода: MyFile.csv: ");
                nPath = Console.ReadLine();
                // Сhecking for exceptions.
                try
                {
                    // Calling write methods of the user's choice.
                    if (k == 1)
                    {
                        // Calling a method that appends a string to a file.
                        Processing.CsvProcessing.Write(Methods.CreateString(data), nPath);
                    }
                    else
                    {
                        // Calling a method that writes an array of strings to a file.
                        Processing.CsvProcessing.Write(data, nPath);
                    }
                    break;
                }
                catch (Exception ex)
                {
                    // Calling a method that outputs a red - marked error.
                    Methods.PrintBeautyError($"{ex.Message} Повторите ввод.");
                }
            }

        }

        // Termination of the method if the user does not want to save the result to a file.
        return;
    }
}
