namespace IOAbstraction
{
    public interface IFileManager
    {
        string GetAllData(string dataFileFullPath);
        void AddNewDataEntry(string dataFileFullPath, string dataEntryLine);
        void RemoveLastDataEntry(string dataFileFullPath);
    }
}