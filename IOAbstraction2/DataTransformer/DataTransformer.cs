using System;
using System.Collections.Generic;
using System.Linq;
using IOAbstraction.DataManager.Model;

namespace IOAbstraction.DataTransformer
{
    public class DataTransformer : IDataTransformer
    {
        public IEnumerable<DataEntry> CombinedTextToDataEntries(string combinedText)
        {
            var result = new List<DataEntry>();

            var lines = combinedText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line) && line.Contains(","))
                {
                    result.Add(TextToDataEntry(line));
                }
            }

            return result.Where(r => r != null);
        }

        public DataEntry TextToDataEntry(string text)
        {
            DataEntry result = null;

            if (!string.IsNullOrEmpty(text) && text.Contains(","))
            {
                var parts = text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var name = parts[0];
                var age = parts[1];
                var profession = parts[2];

                result = new DataEntry(name, age, profession);
            }

            return result;
        }

        public string DataEntryToText(DataEntry dataEntry)
        {
            return $"{dataEntry.Name},{dataEntry.Age},{dataEntry.Profession}";
        }
    }
}