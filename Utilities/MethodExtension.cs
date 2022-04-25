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
        public static bool? ToNullableBool(this object o)
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
        public static bool ToBool(this object o)
        {
            try
            {
                return o.ToBool();
            }
            catch
            {
                return false;
            }
        }
    }
}
