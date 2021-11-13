using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace IOAbstraction.SystemFileOperationsManager
{
    [ExcludeFromCodeCoverage]
    public class NtfsOperationsManager : ISystemFileOperationsManager
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            File.WriteAllLines(path, contents);
        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}