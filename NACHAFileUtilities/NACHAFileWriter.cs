using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities
{
    public class NACHAFileWriter
    {
        private NachaFileHeader _header;
        
        public NACHAFileWriter()
        {
            
        }


        public void CreateHeader(string immediateOrigin,
            string immediateOriginName, string immediateDestination,
            string immediateDestinationName)
        {
            _header = new NachaFileHeader(immediateOriginName, immediateDestinationName, immediateOrigin, immediateDestination);
        }


    }
}
