using System.Collections.Generic;
using IOAbstraction.DataFileRepository;
using IOAbstraction.DataManager.Model;
using IOAbstraction.DataTransformer;

namespace IOAbstraction.DataManager
{
    public class DataManager : IDataManager
    {
        private readonly IDataFileRepository m_DataFileRepository;
        private readonly IDataTransformer m_DataTransformer;

        public DataManager(IDataFileRepository dataFileRepository, IDataTransformer dataTransformer)
        {
            m_DataFileRepository = dataFileRepository;
            m_DataTransformer = dataTransformer;
        }

        public IEnumerable<DataEntry> GetAllData()
        {
            return m_DataTransformer.CombinedTextToDataEntries(m_DataFileRepository.GetAllDataText());
        }

        public void AddNewDataEntry(DataEntry newEntry)
        {
            m_DataFileRepository.AddNewDataEntryText(m_DataTransformer.DataEntryToText(newEntry));
        }

        public void RemoveLastDataEntryText()
        {
            m_DataFileRepository.RemoveLastDataEntryText();
        }
    }
}