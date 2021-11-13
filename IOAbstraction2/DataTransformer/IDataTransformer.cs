using System.Collections.Generic;
using IOAbstraction.DataManager.Model;

namespace IOAbstraction.DataTransformer
{
    public interface IDataTransformer
    {
        IEnumerable<DataEntry> CombinedTextToDataEntries(string combinedText);
        DataEntry TextToDataEntry(string text);
        string DataEntryToText(DataEntry dataEntry);
    }
}