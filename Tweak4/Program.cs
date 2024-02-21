using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Tweak4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yami", "CfgCreator");
            string filePath = Path.Combine(directory, "merged_config.cfg");

            string nameValue = "User";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (line.Contains("\"name\""))
                    {
                        nameValue = GetValueByName(line, "name");
                        break;
                    }
                }
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    return;
                }

                string[] linesToAdd = {
                    "",
                    "//Say Hello",
                    "",
                    "echo",
                    "echo Config is loaded..",
                    $"echo --- Welcome back, {nameValue}! ---",
                    "echo",
                    ""
                };

                File.AppendAllLines(filePath, linesToAdd);

                Console.WriteLine("New lines added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static string GetValueByName(string line, string name)
        {
            var result = line.Substring(line.IndexOf($"\"{name}\"") + 6);
            result = result.Substring(result.IndexOf("\"") + 1);
            result = result.Substring(0, result.IndexOf("\""));
            return result;
        }
    }
}
