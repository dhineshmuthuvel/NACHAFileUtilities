using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NACHAFileUtilities.Batch;

namespace NACHAFileUtilities
{
    public class NACHAFileWriter
    {
        private NachaFileHeader _header;

        private Dictionary<int, NachaFileBatchHeader> _batchHeaders = new Dictionary<int, NachaFileBatchHeader>();

        public NACHAFileWriter()
        {
            
        }


        public void CreateHeader(string immediateOrigin,
            string immediateOriginName, string immediateDestination,
            string immediateDestinationName)
        {
            _header = new NachaFileHeader(immediateOriginName, immediateDestinationName, immediateOrigin, immediateDestination);
        }


        public int CreateBatchHeader(ServiceClassCode serviceClassCode, BatchHeaderCompany batchHeaderCompany, 
            StandardEntryClassCode standardEntryClassCode, DateTime effectiveEntryDate, DateTime settlementDate)
        {
            int newBatchHeaderId = _batchHeaders.Count + 1;
            NachaFileBatchHeader header = new NachaFileBatchHeader(serviceClassCode, batchHeaderCompany,
                standardEntryClassCode, effectiveEntryDate, settlementDate,newBatchHeaderId);

            _batchHeaders.Add(newBatchHeaderId, header);

            return newBatchHeaderId;
        }


        public List<string> GetFileContent()
        {
            List<string> result = new List<string>();

            result.Add(_header.GetEntry());

            foreach (NachaFileBatchHeader nachaFileBatchHeader in _batchHeaders.OrderBy(a => a.Key).Select(a => a.Value))
            {
                result.Add(nachaFileBatchHeader.GetEntry());
            }

            return result;
        }

    }
}
