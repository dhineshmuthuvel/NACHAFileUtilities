using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities
{
    public class NachaFileHeader : IFileEntry
    {
        [FileFieldLayout(1,1)]
        public char RecordTypeCode { get; }

        [FileFieldLayout(2,2)]
        public string PriorityCode { get; }

        [FileFieldLayout(4,10)]
        public string ImmediateDestination { get; }

        [FileFieldLayout(14,10)]
        public string ImmediateOrigin { get; }

        [FileFieldLayout(24, 6)]
        public string FileCreationDate { get; }

        [FileFieldLayout(30, 4)]
        public string FileCreationTime { get; }

        [FileFieldLayout(34, 1)]
        public string FileIdModifier { get; }

        [FileFieldLayout(35, 3)]
        public string RecordSize { get; }

        [FileFieldLayout(38, 2)]
        public string BlockingFactor { get; }

        [FileFieldLayout(40, 1)]
        public string FormatCode { get; }

        [FileFieldLayout(41, 23)]
        public string ImmediateDestinationName { get; }

        [FileFieldLayout(64, 23)]
        public string ImmediateOriginName { get; }

        [FileFieldLayout(87, 8)]
        public string ReferenceCode { get; }

        public NachaFileHeader(string immediateOrigin,
            string immediateOriginName, string immediateDestination,
            string immediateDestinationName)
        {
            RecordTypeCode = '1';
            PriorityCode = "01";
            FileCreationDate = DateTime.Now.ToString("yyyyMMdd").Substring(2);
            FileCreationTime = DateTime.Now.ToString("HHmm");
            FileIdModifier = "";
            RecordSize = "094";
            BlockingFactor = "10";
            FormatCode = "1";
            ImmediateDestination = immediateDestination;
            ImmediateOrigin = immediateOrigin;
            ImmediateDestinationName = immediateDestinationName;
            ImmediateOriginName = immediateOriginName;
            ReferenceCode = string.Empty;
        }

        public string GetEntry()
        {
            return NACHAEntryGenerator.GetEntry(this);
        }
    }
}
