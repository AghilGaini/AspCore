using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class MethodExtension
    {
        public static long? ToNullableLong(this object o)
        {
            try
            {
                return Convert.ToInt64(o);
            }
            catch
            {
                return null;
            }
        }
        public static long ToLong(this object o)
        {
            try
            {
                return Convert.ToInt64(o);
            }
            catch
            {
                return 0;
            }
        }
        public static int? ToNullableInt(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return null;
            }
        }
        public static int ToInt(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return 0;
            }
        }
        public static string ToNullableString(this object o)
        {
            try
            {
                return o.ToString();
            }
            catch
            {
                return null;
            }
        }
        public static string ToString(this object o)
        {
            try
            {
                return o.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        public static bool IsNull(this object o)
        {
            try
            {
                return o == null;
            }
            catch
            {
                return true;
            }
        }
        public static bool IsNotNull(this object o)
        {
            try
            {
                return !(o == null);
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNull(this string s)
        {
            try
            {
                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                    return true;
                return false;
            }
            catch
            {
                return true;
            }
        }
        public static bool IsNotNull(this string s)
        {
            try
            {
                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool? ToNullableBoolean(this object o)
        {
            try
            {
                return Convert.ToBoolean(o);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool ToBoolean(this object o)
        {
            try
            {
                return Convert.ToBoolean(o);
            }
            catch
            {
                return false;
            }
        }
        public static bool IsEqual(this string s, string s1, bool caseSensistive = false)
        {
            try
            {
                if (caseSensistive)
                    return string.Equals(s, s1, StringComparison.Ordinal);
                else
                    return string.Equals(s, s1, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }
        public static string GetValueFromQueryString(this string s, string key)
        {
            if (s == null)
                return null;

            if (!s.Contains(key))
                return null;

            s = s.Replace("?", string.Empty);
            var values = s.Split('&');
            foreach (var item in values)
            {
                if (item.Contains(key))
                {
                    var foundValues = item.Split('=');
                    if (foundValues.Length > 1)
                        return foundValues[1];
                }
            }

            return null;

        }


    }
}
