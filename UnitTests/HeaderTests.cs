using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NACHAFileUtilities;
using Shouldly;

namespace UnitTests
{
    [TestClass]
    public class HeaderTests
    {
        [TestMethod]
        public void CheckHeaderFields()
        {
            NachaFileHeader header = new NachaFileHeader("LBC","LBC", "RBC", "RBC");
            header.RecordTypeCode.ShouldBe('1');
            header.ImmediateOrigin.ShouldBe("LBC");
            header.ImmediateOriginName.ShouldBe("LBC");

            header.ImmediateDestination.ShouldBe("RBC");
            header.ImmediateDestinationName.ShouldBe("RBC");
        }

        [TestMethod]
        public void CheckImmediateOriginDestination()
        {
            string immediateOrigin = "LBCOriginasdfsdafsadf";
            string immediateDestination = "RBC";
            NachaFileHeader header = new NachaFileHeader(immediateOrigin,"LBC",immediateDestination,"RBC");
            string entry = header.GetEntry();

            entry.ShouldNotBeNull();
            
            Console.WriteLine(entry);
            
            string recordTypeCode = entry.Substring(0, 1);
            recordTypeCode.ShouldBe("1");

            string actualImmediateDestination = entry.Substring(3, 10).Trim();
            immediateDestination.ShouldStartWith(actualImmediateDestination);

            string actualImmediateOrigin = entry.Substring(13, 10).Trim();
            immediateOrigin.ShouldStartWith(actualImmediateOrigin);
        }
    }
}
