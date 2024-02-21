using System;
using System.IO;
using System.Text;

namespace ReBindCfg
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

                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(filePath);

                // Ищем комментарий "//cs2_user_keys_0_slot0.vcfg"
                int startIndex = Array.IndexOf(lines, "//cs2_user_keys_0_slot0.vcfg");

                if (startIndex != -1)
                {
                    // Начиная с найденного комментария, ищем блок команд до следующего комментария или конца файла
                    StringBuilder commandsBuilder = new StringBuilder();
                    int endIndex = Array.IndexOf(lines, "//", startIndex + 1);
                    if (endIndex == -1) endIndex = lines.Length;

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        if (lines[i].Trim() != "")
                        {
                            // Обработка команд: преобразование формата
                            string[] parts = lines[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length == 2)
                            {
                                string key = parts[0].Trim('\"');
                                string value = parts[1].Trim('\"');
                                if (value != "<unbound>")
                                    commandsBuilder.AppendLine($"bind \"{key}\" \"{value}\"");
                                else
                                    commandsBuilder.AppendLine($"unbind \"{key}\"");
                            }
                        }
                    }

                    // Получаем строку с новыми командами
                    string commands = commandsBuilder.ToString().Trim();

                    // Выводим измененные команды
                    Console.WriteLine(commands);

                    // Заменяем в файле старую часть на новую
                    string newContent = string.Join(Environment.NewLine, lines, 0, startIndex) + Environment.NewLine + "//cs2_user_keys_0_slot0.vcfg" + Environment.NewLine + commands + Environment.NewLine + string.Join(Environment.NewLine, lines, endIndex, lines.Length - endIndex);

                    // Перезаписываем файл
                    File.WriteAllText(filePath, newContent);

                    Console.WriteLine("Файл успешно изменен.");
                }
                else
                {
                    Console.WriteLine("Комментарий не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
