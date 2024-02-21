using System;
using System.IO;

namespace Counter_StrikeCfgCreator
{
    public class ConfigMerger
    {
        public event Action<int> ProgressChanged;
        public void MergeConfigs(string[] fileNames, string outputFileName)
        {
            using (StreamWriter sw = new StreamWriter(outputFileName))
            {
                foreach (string fileName in fileNames)
                {
                    if (File.Exists(fileName))
                    {
                        string[] lines = File.ReadAllLines(fileName);
                        foreach (string line in lines)
                        {
                            sw.WriteLine(line);
                        }
                        sw.WriteLine(); // Добавляем пустую строку между содержимым каждого файла
                    }
                    else
                    {
                        Console.WriteLine($"File {fileName} does not exist.");
                    }
                }
            }
        }
    }
}