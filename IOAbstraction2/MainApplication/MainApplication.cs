using System.Collections.Generic;
using System.Linq;
using IOAbstraction.DataManager;
using IOAbstraction.DataManager.Model;

namespace IOAbstraction.MainApplication
{
    public class MainApplication
    {
        private readonly IDataManager m_DataManager;

        public MainApplication(IDataManager dataManager)
        {
            m_DataManager = dataManager;
        }

        public IEnumerable<string> GetAllToPresentInUi()
        {
            return m_DataManager
                   .GetAllData()
                   .Select(entry => $"Name: {entry.Name}, Age: {entry.Age}, Profession: {entry.Profession}")
                   .ToList();
        }

        public void Add(DataEntry entry)
        {
            m_DataManager.AddNewDataEntry(entry);
        }

        public void Remove()
        {
            m_DataManager.RemoveLastDataEntryText();
        }
    }
}