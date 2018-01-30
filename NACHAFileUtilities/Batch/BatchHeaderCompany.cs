using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities.Batch
{
    public class BatchHeaderCompany
    {
        private readonly string _companyName;
        private readonly string _companyDiscretionaryData;
        private readonly string _companyIdentification;
        private readonly string _companyEntryDescription;

        public BatchHeaderCompany(string companyName, string companyDiscretionaryData, 
            string companyIdentification,string companyEntryDescription)
        {
            _companyName = companyName;
            _companyDiscretionaryData = companyDiscretionaryData;
            _companyIdentification = companyIdentification;
            _companyEntryDescription = companyEntryDescription;
        }
    }
}
