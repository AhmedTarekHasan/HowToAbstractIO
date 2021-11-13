using System.Collections.Generic;
using IOAbstraction.DataManager.Model;

namespace IOAbstraction.DataManager
{
    public interface IDataManager
    {
        IEnumerable<DataEntry> GetAllData();
        void AddNewDataEntry(DataEntry newEntry);
        void RemoveLastDataEntryText();
    }
}