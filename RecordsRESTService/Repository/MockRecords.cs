using EntityLibary;
using RecordsRESTService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordsRESTService.Repository
{
    public class MockRecords : IRecords
    {
        private static readonly List<Record> records = new()
        {
            new Record { Id = 1, Artist = "Dunes", Duration = 40, Title = "Dunning in the night", Year = 1998 },
            new Record { Id = 4, Artist = "Dunes", Duration = 40, Title = "Dunning in the Morning", Year = 1999 },
            new Record { Id = 2, Artist = "PlaceHolders", Duration = 100, Title = "Holding The Place", Year = 2001 },
            new Record { Id = 3, Artist = "Rikke And the Gang", Duration = 120, Title = "Getting your grove on", Year = 2021 }
        };
        public List<Record> GetRecords(string searchingCriteria = null, string sortBy = null)
         {
             List<Record> theRecords = new List<Record>(records);
            // copy constructor
            // Callers should not get a reference to the Data object, but rather get a copy

            if (searchingCriteria != null)
            {   
                        theRecords = theRecords.FindAll(Record => Record.Artist != null && Record.Artist.StartsWith(searchingCriteria));
            }
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "title":
                        theRecords = theRecords.OrderBy(Record => Record.Title).ToList();
                        break;
                    case "year":
                        theRecords = theRecords.OrderBy(Record => Record.Year).ToList();
                        break;
                        // skip any other properties in the query string
                }
            }
            return theRecords;
        }

        public void CreateRecord(Record record)
        {
            records.Add(record);
                
        }
       
    }
    
}
