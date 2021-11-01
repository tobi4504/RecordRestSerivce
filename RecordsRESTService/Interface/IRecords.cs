using EntityLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordsRESTService.Interface
{
    public interface IRecords
    {
        public List<Record> GetRecords(string searchingCriteria = null, string sortBy = null);

        public void CreateRecord(Record record);

    }
}
