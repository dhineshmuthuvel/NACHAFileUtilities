using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NACHAFileUtilities
{
    public static class NACHAEntryGenerator
    {
        public static string GetEntry<T>(T entryObject)
        {
            StringBuilder entryLine = new StringBuilder(94);
            entryLine.Append(' ', 94);

            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                FileFieldLayoutAttribute layoutAttribute = pi.GetCustomAttributes(typeof(FileFieldLayoutAttribute), false)
                                        .FirstOrDefault() as FileFieldLayoutAttribute;

                if (layoutAttribute == null) continue;

                entryLine.Insert(layoutAttribute.Start - 1, pi.GetValue(entryObject).ToString());
            }

            return entryLine.ToString();
        }
    }
}
