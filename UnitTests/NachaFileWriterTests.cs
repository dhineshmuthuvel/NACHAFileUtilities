using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NACHAFileUtilities;
using NACHAFileUtilities.Batch;
using Shouldly;

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
            List<string> fileContents = writer.GetFileContent();
            PrintFileContents(fileContents);
            
        }

        [TestMethod]
        public void CreateBatchHeader()
        {
            NACHAFileWriter writer = new NACHAFileWriter();

            writer.CreateHeader("LBC", "RBC", "LBC", "RBC");

            ServiceClassCode mixedDebitsAndCredits = ServiceClassCode.GetMixedDebitsAndCredits();
            BatchHeaderCompany batchHeaderCompany = 
                new BatchHeaderCompany("LBC", "LBC Express", "1231231", "Payroll", DateTime.Now, "000000000");
            StandardEntryClassCode standardEntryClassCode = StandardEntryClassCode.GetWebAuthorizationEntries();

            int batchHeaderId = writer.CreateBatchHeader(mixedDebitsAndCredits, batchHeaderCompany, standardEntryClassCode, DateTime.Now,
                DateTime.Now);

            batchHeaderId.ShouldBeGreaterThan(0);

            List<string> fileContents = writer.GetFileContent();
            PrintFileContents(fileContents);

        }

        private void PrintFileContents(List<string> fileContents)
        {
            foreach (string fileContent in fileContents)
            {
                Console.WriteLine(fileContent);
            }
        }
    }
}
