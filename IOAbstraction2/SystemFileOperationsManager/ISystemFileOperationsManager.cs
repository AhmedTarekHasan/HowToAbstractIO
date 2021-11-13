using System.Collections.Generic;

namespace IOAbstraction.SystemFileOperationsManager
{
    public interface ISystemFileOperationsManager
    {
        string[] ReadAllLines(string path);
        string ReadAllText(string path);
        void WriteAllText(string path, string contents);
        void WriteAllLines(string path, IEnumerable<string> contents);
    }
}