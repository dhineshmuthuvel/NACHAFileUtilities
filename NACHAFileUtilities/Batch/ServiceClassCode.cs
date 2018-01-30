using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities.Batch
{
    public class ServiceClassCode
    {
        public string Code { get; }
        private ServiceClassCode(string serviceClassCode)
        {
            Code = serviceClassCode;
        }

        public static ServiceClassCode GetMixedDebitsAndCredits()
        {
            return new ServiceClassCode("200");
        }

        public static ServiceClassCode GetCredits()
        {
            return new ServiceClassCode("220");
        }

        public static ServiceClassCode GetDebits()
        {
            return new ServiceClassCode("225");
        }
    }

   
}
