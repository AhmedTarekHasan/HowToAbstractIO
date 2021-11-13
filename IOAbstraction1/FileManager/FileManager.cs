using System;
using System.IO;
using System.Linq;
using System.Text;

namespace IOAbstraction
{
    public class FileManager : IFileManager
    {
        public string GetAllData(string dataFileFullPath)
        {
            var lines = File.ReadAllLines(dataFileFullPath);

            var builder = new StringBuilder();

            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line) && line.Contains(","))
                {
                    var parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = parts[0];
                    var age = parts[1];
                    var profession = parts[2];
                    var message = $"Name: {name}, Age: {age}, Profession: {profession}.";

                    builder.AppendLine(message);
                }
            }

            return builder.ToString();
        }

        public void AddNewDataEntry(string dataFileFullPath, string dataEntryLine)
        {
            var line = Environment.NewLine + dataEntryLine;

            var text = TrimEndNewLine(File.ReadAllText(dataFileFullPath)) + line;

            File.WriteAllText(dataFileFullPath, text);
        }

        public void RemoveLastDataEntry(string dataFileFullPath)
        {
            var lines = File.ReadAllLines(dataFileFullPath);
            File.WriteAllLines(dataFileFullPath, lines.Take(lines.Length - 1));
        }

        private string TrimEndNewLine(string str)
        {
            var result = str;

            while (result.EndsWith(Environment.NewLine))
            {
                result = result.Substring(0, result.Length - Environment.NewLine.Length);
            }

            return result;
        }
    }
}