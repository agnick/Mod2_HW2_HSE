/*
   Студент:     Агафонов Никита Максимович    
   Группа:      БПИ234
   Вариант:     19
   Дата:        15.11.2023
*/
namespace Task_19v
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                // User input of absolute file path.
                Console.Write("Введите абсолютный путь к файлу с csv-данными: ");
                string? path = Console.ReadLine();

                // Assigning the class field a user-entered file name.
                Processing.CsvProcessing.FPath = path;

                string[] rowData = null;

                // Сhecking for exceptions.
                try
                {
                    // Calling a method to validate and read a user-supplied csv file.
                    rowData = Processing.CsvProcessing.Read();
                }
                catch (ArgumentNullException ex)
                {
                    // Calling a method that outputs a red - marked error.
                    Methods.PrintBeautyError(ex.ParamName);
                }

                // Сhecking that the returned array is not null and not empty.
                if (rowData is not null && rowData.Length != 0)
                {
                    // Calling a method that calls the on-screen menu.
                    Menu.OpenMenu(rowData);
                }

                // Repeating the solution at the user's request.
                Console.Write("Для выхода из программы нажмите клавишу ESC, для перезапуска программы нажмите любую другую клавишу: ");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) { break; }
            }
        }
    }
}