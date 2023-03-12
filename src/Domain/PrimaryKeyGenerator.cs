namespace ProjectTemplate.Domain
{
    internal class PrimaryKey
    {
        public static string GetUniqueNumStr()
        {
            return GetGuid().GetHashCode().ToString().Trim('-');
        }

        public static int GetUniqueNum()
        {
            return GetGuid().GetHashCode();
        }

        public static string GetGuidStr()
        {
            return GetGuid().GetHashCode().ToString();
        }

        public static Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}