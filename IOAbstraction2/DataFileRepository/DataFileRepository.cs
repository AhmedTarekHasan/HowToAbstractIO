using System;
using System.Linq;
using IOAbstraction.SystemFileOperationsManager;

namespace IOAbstraction.DataFileRepository
{
    public class DataFileRepository : IDataFileRepository
    {
        private readonly ISystemFileOperationsManager m_SystemFileOperationsManager;
        private readonly string m_DataFileFullPath;

        public DataFileRepository(ISystemFileOperationsManager systemFileOperationsManager, string dataFileFullPath)
        {
            m_SystemFileOperationsManager = systemFileOperationsManager;
            m_DataFileFullPath = dataFileFullPath;
        }

        public string GetAllDataText()
        {
            return m_SystemFileOperationsManager.ReadAllText(m_DataFileFullPath);
        }

        public void AddNewDataEntryText(string dataEntryLine)
        {
            var line = Environment.NewLine + dataEntryLine;

            var text = TrimEndNewLine(m_SystemFileOperationsManager.ReadAllText(m_DataFileFullPath)) + line;

            m_SystemFileOperationsManager.WriteAllText(m_DataFileFullPath, text);
        }

        public void RemoveLastDataEntryText()
        {
            var lines = m_SystemFileOperationsManager.ReadAllLines(m_DataFileFullPath);
            m_SystemFileOperationsManager.WriteAllLines(m_DataFileFullPath, lines.Take(lines.Length - 1));
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