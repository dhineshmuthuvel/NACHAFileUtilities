using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities.Batch
{
    public class BatchHeaderCompany
    {
        public string OriginatingDfiIdentification { get; private set; }
        public DateTime CompanyDescriptiveDate { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyDiscretionaryData { get; private set; }
        public string CompanyIdentification { get; private set; }

        public string CompanyEntryDescription { get; private set; }

        public BatchHeaderCompany(string companyName, string companyDiscretionaryData, 
            string companyIdentification,string companyEntryDescription, DateTime companyDescriptiveDate, string originatingDFIIdentification)
        {
            OriginatingDfiIdentification = originatingDFIIdentification;
            CompanyDescriptiveDate = companyDescriptiveDate;
            CompanyName = companyName;
            CompanyDiscretionaryData = companyDiscretionaryData;
            CompanyIdentification = companyIdentification;
            CompanyEntryDescription = companyEntryDescription;

        }
    }
}
