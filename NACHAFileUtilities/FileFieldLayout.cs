using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileFieldLayoutAttribute: Attribute
    {
        public int Start { get; }

        public int Length { get; }

        public FileFieldLayoutAttribute(int start, int length)
        {
            Start = start;
            Length = length;
        }
    }
}
