using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities.Batch
{
    public class NachaFileBatchHeader : IFileEntry
    {
        [FileFieldLayout(1,1)]
        public char RecordTypeCode { get; set; }

        [FileFieldLayout(2, 3)]
        public string ServiceClassCode { get; set; }

        [FileFieldLayout(5, 16)]
        public string CompanyName { get; set; }

        [FileFieldLayout(21, 20)]
        public string CompanyDiscretionaryData { get; set; }

        [FileFieldLayout(41, 10)]
        public string CompanyIdentification { get; set; }

        [FileFieldLayout(51, 3)]
        public string StandardEntryClassCode { get; set; }

        [FileFieldLayout(54, 10)]
        public string CompanyEntryDescription { get; set; }

        [FileFieldLayout(64, 6)]
        public string CompanyDescriptiveDate { get; set; }

        [FileFieldLayout(70, 6)]
        public string EffectiveEntryDate { get; set; }

        [FileFieldLayout(76, 3)]
        public string SettlementDate { get; set; }

        [FileFieldLayout(79, 1)]
        public char OriginatorStatusCode { get; set; }

        [FileFieldLayout(80, 8)]
        public string OriginatingDFIIdentification { get; set; }

        [FileFieldLayout(88, 7)]
        public string BatchNumber { get; set; }

        public string GetEntry()
        {
            return NACHAEntryGenerator.GetEntry(this);
        }

        public NachaFileBatchHeader()
        {
            
        }

        public NachaFileBatchHeader(ServiceClassCode serviceClassCode, BatchHeaderCompany batchHeaderCompany, 
                    StandardEntryClassCode standardEntryClassCode, DateTime effectiveEntryDate, DateTime settlementDate, int batchNumber)
        {
            this.RecordTypeCode = '5';
            this.ServiceClassCode = serviceClassCode.Code;

            this.CompanyName = batchHeaderCompany.CompanyName;
            this.CompanyDiscretionaryData = batchHeaderCompany.CompanyDiscretionaryData;
            this.CompanyIdentification = batchHeaderCompany.CompanyIdentification;
            this.StandardEntryClassCode = standardEntryClassCode.Code;

            this.CompanyEntryDescription = batchHeaderCompany.CompanyEntryDescription;
            this.CompanyDescriptiveDate = batchHeaderCompany.CompanyDescriptiveDate.ToString("yyMMdd");
            this.OriginatingDFIIdentification = batchHeaderCompany.OriginatingDfiIdentification;

            this.EffectiveEntryDate = effectiveEntryDate.ToString("yyMMdd");
            this.SettlementDate = settlementDate.ToString("yyMMdd");
            this.BatchNumber = batchNumber.ToString();

            this.OriginatorStatusCode = '1';
        }
    }
}
