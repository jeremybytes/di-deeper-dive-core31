using Common;
using System.Collections.Generic;

namespace PersonReader.SQL
{
    public class SQLReaderProxy : IPersonReader
    {
        string sqlFileName;

        public SQLReaderProxy(string sqlFileName)
        {
            this.sqlFileName = sqlFileName;
        }

        public IReadOnlyCollection<Person> GetPeople()
        {
            using (var reader = new SQLReader(sqlFileName))
            {
                return reader.GetPeople();
            }
        }

        public Person GetPerson(int id)
        {
            using (var reader = new SQLReader(sqlFileName))
            {
                return reader.GetPerson(id);
            }
        }
    }
}
