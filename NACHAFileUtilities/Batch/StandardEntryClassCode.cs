using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities.Batch
{
    public class StandardEntryClassCode
    {
        public string Code { get; private set; }

        private StandardEntryClassCode(string standardEntryClassCode)
        {
            Code = standardEntryClassCode;
        }


        public static StandardEntryClassCode GetPrearrangedPaymentsDepositEntries()
        {
            return new StandardEntryClassCode("PPD");
        }

        public static StandardEntryClassCode GetCashConcentrationDisbursementEntries()
        {
            return new StandardEntryClassCode("CCD");
        }

        public static StandardEntryClassCode GetCorporateTradeExchangeEntries()
        {
            return new StandardEntryClassCode("CTD");
        }

        public static StandardEntryClassCode GetTelephoneInitiatedEntries()
        {
            return new StandardEntryClassCode("TEL");
        }

        public static StandardEntryClassCode GetWebAuthorizationEntries()
        {
            return new StandardEntryClassCode("WEB");
        }
    }
}
