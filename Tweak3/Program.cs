using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Tweak3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Путь к файлу конфигурации
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Yami\CfgCreator\merged_config.cfg";

            // Проверка наличия файла
            if (File.Exists(filePath))
            {
                try
                {
                    // Чтение содержимого файла
                    string fileContent = File.ReadAllText(filePath);

                    // Изменение значений для "func_break_max_pieces" и "cl_ragdoll_limit"
                    fileContent = Regex.Replace(fileContent, @"(""func_break_max_pieces""\s*""\d+"")", "\"func_break_max_pieces\" \"0\"");
                    fileContent = Regex.Replace(fileContent, @"(""cl_ragdoll_limit""\s*""\d+"")", "\"cl_ragdoll_limit\" \"0\"");

                    // Запись изменений обратно в файл
                    File.WriteAllText(filePath, fileContent);

                    Console.WriteLine("Значения успешно изменены.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Файл конфигурации не найден.");
            }

        }
    }
}
