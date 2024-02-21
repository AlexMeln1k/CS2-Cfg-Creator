using System;
using System.IO;

namespace Tweak1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Путь к файлу
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yami", "CfgCreator", "merged_config.cfg");

            string keyBind = args[0];

            try
            {
                // Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден: " + filePath);
                    return;
                }

                // Строки для добавления в конец файла
                string[] linesToAdd = {
                    "",
                    "//JumpThrow",
                    "",
                    "alias \"+jumpaction\" \"+jump;\"",
                    "alias \"+throwaction\" \"-attack; -attack2\"",
                    "alias \"-jumpaction\" \"-jump\"",
                    $"bind {keyBind} \"+jumpaction;+throwaction;\""
                };

                // Добавляем строки в конец файла
                File.AppendAllLines(filePath, linesToAdd);

                Console.WriteLine("Новые строки успешно добавлены в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
