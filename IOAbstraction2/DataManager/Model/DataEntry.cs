namespace IOAbstraction.DataManager.Model
{
    public class DataEntry
    {
        public string Name { get; }
        public string Age { get; }
        public string Profession { get; }

        public DataEntry(string name, string age, string profession)
        {
            Name = name;
            Age = age;
            Profession = profession;
        }
    }
}