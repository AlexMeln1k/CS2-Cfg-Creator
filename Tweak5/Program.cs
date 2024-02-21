using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Tweak6
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yami/CfgCreator/merged_config.cfg");

            // Проверяем, существует ли файл
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл merged_config.cfg не найден.");
                return;
            }

            // Читаем весь файл в строку
            string fileContent = File.ReadAllText(filePath);

            // Используем регулярное выражение для поиска и замены значения параметра
            string pattern = @"(""r_drawtracers_firstperson""\s+)""([^""]+)""";
            string replacement = "$1\"false\"";
            string modifiedContent = Regex.Replace(fileContent, pattern, replacement);

            // Проверяем, были ли произведены изменения
            if (modifiedContent != fileContent)
            {
                // Перезаписываем измененное содержимое обратно в файл
                File.WriteAllText(filePath, modifiedContent);
                Console.WriteLine("Значение параметра успешно изменено.");
            }
            else
            {
                Console.WriteLine("Не удалось найти параметр для изменения.");
            }
        }
    }
}
