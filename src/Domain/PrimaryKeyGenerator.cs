using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain
{
    internal class PrimaryKey
    {
        public static string GetUniqueNumStr()
        {
            return Guid.NewGuid().GetHashCode().ToString().Trim('-');
        }

        public static int GetUniqueNum()
        {
            return Guid.NewGuid().GetHashCode();
        }

        public static string GetGuidStr()
        {
            return Guid.NewGuid().GetHashCode().ToString();
        }

        public static Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}