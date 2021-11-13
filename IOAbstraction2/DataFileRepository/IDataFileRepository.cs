namespace IOAbstraction.DataFileRepository
{
    public interface IDataFileRepository
    {
        string GetAllDataText();
        void AddNewDataEntryText(string dataEntryLine);
        void RemoveLastDataEntryText();
    }
}