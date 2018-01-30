using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NACHAFileUtilities;
using NACHAFileUtilities.Batch;

namespace UnitTests
{
    [TestClass]
    public class NachaFileWriterTests
    {
        [TestMethod]
        public void CreateHeader()
        {
            NACHAFileWriter writer = new NACHAFileWriter();

            writer.CreateHeader("LBC", "RBC", "LBC", "RBC");
        }

        [TestMethod]
        public void CreateBatchHeader()
        {
            NACHAFileWriter writer = new NACHAFileWriter();

            ServiceClassCode mixedDebitsAndCredits = ServiceClassCode.GetMixedDebitsAndCredits();
            BatchHeaderCompany batchHeaderCompany = new BatchHeaderCompany("LBC", "LBC Express", "1231231", "Payroll");
            StandardEntryClassCode standardEntryClassCode = StandardEntryClassCode.GetWebAuthorizationEntries();

            //writer.CreateBatchHeader(mixedDebitsAndCredits,
            //    batchHeaderCompany,standardEntryClassCode);
        }
    }
}
