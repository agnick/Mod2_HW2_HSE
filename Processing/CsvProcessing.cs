using System.Globalization;

namespace Processing
{
    public static class CsvProcessing
    {
        // Static field that stores the path to the file.
        static string fPath = string.Empty;
        // Сonstants that store the first and second lines of the file.
        const string firstLine = "\"ID\";\"LibraryName\";\"AdmArea\";\"District\";\"Address\";\"NumberOfAccessPoints\";\"WiFiName\";\"CoverageArea\";\"FunctionFlag\";\"AccessFlag\";\"Password\";\"Latitude_WGS84\";\"Longitude_WGS84\";\"global_id\";\"geodata_center\";\"geoarea\";";
        const string secondLine = "\"Код\";\"Наименование библиотеки\";\"Административный округ\";\"Район\";\"Адрес\";\"Количество точек доступа\";\"Имя Wi-Fi сети\";\"Зона покрытия, в метрах\";\"Признак функционирования\";\"Условия доступа\";\"Пароль\";\"Широта в WGS-84\";\"Долгота в WGS-84\";\"global_id\";\"geodata_center\";\"geoarea\";";

        // Assignment property and getting the file path.
        public static string FPath
        {
            get { return fPath; }
            set
            {
                // Сhecking that the passed path to the file is not null and not empty.
                if (!string.IsNullOrEmpty(value))
                {
                    fPath = value;
                }
            }
        }

        /// <summary>
        /// A method that reads a csv file and checks its compliance with the variant.
        /// </summary>
        /// <returns>An array of strings read from a file.</returns>
        /// <exception cref="ArgumentNullException">The exception that a method throws for various errors.</exception> 
        public static string[] Read()
        {
            string[] rowData;

            // Сhecking that the file exists.
            if (!File.Exists(fPath))
            {
                throw new ArgumentNullException("Файл с таким названием не существует.");
            }

            // Сhecking for exceptions.
            try
            {
                rowData = File.ReadAllLines(fPath);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentNullException("Введено некорректное название файла.");
            }
            catch (IOException ex)
            {
                throw new ArgumentNullException("Возникла ошибка при открытии файла и записи структуры.");
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("Возникла непредвиденная ошибка.");
            }

            // Calling a method that checks the structure of the transferred file.
            CheckFileStructure(rowData);

            return rowData;
        }

        /// <summary>
        /// A method that checks the structure of the transmitted file.
        /// </summary>
        /// <param name="rowData">An array of strings read from a file.</param>
        /// <exception cref="ArgumentNullException">An exception that is thrown when the file structure is violated.</exception>
        private static void CheckFileStructure(string[] rowData)
        {
            // Checking that the transferred file is not empty.
            if (rowData.Length == 0)
            {
                throw new ArgumentNullException("Передан пустой файл.");
            }

            // Checking that the first two lines of the transferred file correspond to the first two lines of the variant file.
            if (rowData[0] != firstLine || rowData[1] != secondLine)
            {
                throw new ArgumentNullException("Поля переданного csv файла не соответствуют полям варианта.");
            }

            // Checking each subsequent line of the transferred file for compliance with the variant file.
            foreach (string line in rowData[2..])
            {
                // Forming an array of elements from a file line separated by a semicolon.
                string[] splitted = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                // Checking that the number of elements in the line corresponds to the number of elements in the line of the variant file.
                if (splitted.Length != 16)
                {
                    throw new ArgumentNullException("Данные в файле не соответствуют варианту.");
                }

                // Checking the data type of each line element against the variant file.
                for (int i = 0; i < splitted.Length; i++)
                {
                    // Removing quotes from a string.
                    string dataElement = splitted[i].Replace("\"", "");
                    // An array storing field numbers, elements that have numeric values.
                    int[] toCheck = { 0, 5, 7, 11, 12, 13 };
                    // Сhecking only those elements that have numerical values ​​in the variant file, like the rest of the lines.
                    if (toCheck.Contains(i))
                    {
                        if (dataElement != "" && !double.TryParse(dataElement, NumberStyles.Float, CultureInfo.InvariantCulture, out double _))
                        {
                            throw new ArgumentNullException("Данные в файле не соответствуют варианту.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A method that adds a line to a csv file.
        /// </summary>
        /// <param name="line">The line to be added to the csv file.</param>
        /// <param name="nPath">The path to the file.</param>
        /// <exception cref="ArgumentException">The exception that the method throws when the file path is incorrectly specified.</exception>
        /// <exception cref="IOException">The exception that the method throws when the file is opened incorrectly and the structure is written.</exception>
        /// <exception cref="Exception">The exception that a method throws when unexpected errors occur.</exception>
        public static void Write(string line, string nPath)
        {
            // Checking if the file extension is csv.
            if (!nPath.Contains(".csv"))
            {
                throw new ArgumentException("Введено некорректное название для файла.");
            }

            // Сhecking for exceptions.
            try
            {
                // If the file does not exist, then when creating a new one, the first two lines of the variant file are written.
                if (!File.Exists(nPath))
                {
                    File.WriteAllText(nPath, $"{firstLine}\n{secondLine}\n");
                }
                // Adding a line to a file.
                File.AppendAllText(nPath, line);
                Console.WriteLine("Данные успешно записаны в файл.");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Введено некорректное название для файла.");
            }
            catch (IOException ex)
            {
                throw new IOException("Возникла ошибка при открытии файла и записи структуры.");
            }
            catch (Exception ex)
            {
                throw new Exception("Возникла непредвиденная ошибка.");
            }
        }

        /// <summary>
        /// A method that rewrites an array of strings to a file.
        /// </summary>
        /// <param name="lines">Lines that need to be written to the file.</param>
        /// <param name="nPath">The path to the file.</param>
        /// <exception cref="ArgumentException">The exception that the method throws when the file path is incorrectly specified.</exception>
        /// <exception cref="IOException">The exception that the method throws when the file is opened incorrectly and the structure is written.</exception>
        /// <exception cref="Exception">The exception that a method throws when unexpected errors occur.</exception>
        public static void Write(string[] lines, string nPath)
        {
            // Checking if the file extension is csv.
            if (!nPath.Contains(".csv"))
            {
                throw new ArgumentException("Введено некорректное название для файла.");
            }

            // Сhecking for exceptions.
            try
            {
                // Writing all lines to a file.
                File.WriteAllLines(nPath, lines);
                Console.WriteLine("Данные успешно записаны в файл.");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Введено некорректное название для файла.");
            }
            catch (IOException ex)
            {
                throw new IOException("Возникла ошибка при открытии файла и записи структуры.");
            }
            catch (Exception ex)
            {
                throw new Exception("Возникла непредвиденная ошибка.");
            }
        }
    }
}