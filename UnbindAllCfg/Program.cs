using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Management;

namespace UnbindAllCfg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Путь к файлу
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yami", "CfgCreator", "merged_config.cfg");

            try
            {
                // Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден: " + filePath);
                    return;
                }

                string freq = GetRefreshRate();
                string core = GetPhysicalCoreCount();

                if (!string.IsNullOrEmpty(freq))
                    freq = $"-freq {freq} -refresh {freq}";
                else
                    freq = "";
                if (Convert.ToInt32(core) <= 0)
                    core = "";
                else
                    core = $"-threads {int.Parse(core) + 1}";

                // Строки для добавления в начало файла
                string[] linesToAdd = {
                    "//CS2 config",
                    $"Launch options: -novid {core} {freq} -nod3d9ex1 -limitvconst -nojoy",
                    "",
                    "//Set to Default",
                    "unbindall",
                    "binddefaults",
                    ""
                };

                // Читаем остальное содержимое файла
                string fileContents = File.ReadAllText(filePath);

                // Совмещаем новые строки с остальным содержимым файла
                fileContents = string.Join(Environment.NewLine, linesToAdd.Concat(new[] { fileContents }));

                // Перезаписываем файл с новым содержимым
                File.WriteAllText(filePath, fileContents);

                Console.WriteLine("Новые строки успешно добавлены в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        private static string GetPhysicalCoreCount()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT NumberOfCores FROM Win32_Processor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    int numberOfCores = Convert.ToInt32(obj["NumberOfCores"]);
                    return numberOfCores.ToString();
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Ошибка при получении информации о процессоре: " + e.Message);
            }
            return "0";
        }

        private static string GetRefreshRate()
        {
            try
            {
                // Используем запрос WMI (Windows Management Instrumentation) для получения информации о мониторах
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

                foreach (ManagementObject mo in searcher.Get())
                {
                    // Получаем частоту обновления монитора
                    object refreshRate = mo["CurrentRefreshRate"];

                    if (refreshRate != null)
                    {
                        return refreshRate.ToString();
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
