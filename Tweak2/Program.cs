using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Tweak3
{
    internal class Program
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

            // Читаем все строки из файла
            string[] lines = File.ReadAllLines(filePath);

            // Флаг, указывающий, было ли произведено изменение
            bool modificationMade = false;

            // Проходим по каждой строке
            for (int i = 0; i < lines.Length; i++)
            {
                // Используем регулярное выражение для поиска и замены значения параметра
                string pattern = @"(""cl_usenewbob""\s*"")true("")";
                string replacement = "$1false$2";
                string modifiedLine = Regex.Replace(lines[i], pattern, replacement);

                // Если строка была изменена, обновляем ее
                if (modifiedLine != lines[i])
                {
                    lines[i] = modifiedLine;
                    modificationMade = true;
                    break; // Выходим из цикла после первого изменения
                }
            }

            // Если было произведено изменение, записываем измененные строки обратно в файл
            if (modificationMade)
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Значение параметра успешно изменено.");
            }
            else
            {
                Console.WriteLine("Не удалось найти параметр для изменения.");
            }
        }
    }
}
