using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Web.Script.Serialization;

namespace System
{
    /// <summary>
    /// Author      : CSI.VJ
    /// Create date : 
    /// Description : System Extension
    /// Latest
    /// Modifier    : PHUOC.IT
    /// Modify date : 
    /// Remark      : 
    /// </summary>
    public static class SystemExtension
    {
        private static string _BasekeyString = "@phuocit";

        private static byte[] Encrypt(string PlainText)
        {
            DESCryptoServiceProvider key = new DESCryptoServiceProvider();

            key.Key = System.Text.Encoding.Default.GetBytes(_BasekeyString);
            key.IV = System.Text.Encoding.Default.GetBytes(_BasekeyString);

            // Create a memory stream.
            MemoryStream ms = new MemoryStream();

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key.
            CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(), CryptoStreamMode.Write);

            // Create a StreamWriter to write a string
            // to the stream.
            StreamWriter sw = new StreamWriter(encStream);

            // Write the plaintext to the stream.
            sw.WriteLine(PlainText);

            // Close the StreamWriter and CryptoStream.
            sw.Close();

            encStream.Close();

            // Get an array of bytes that represents
            // the memory stream.
            byte[] buffer = ms.ToArray();

            // Close the memory stream.
            ms.Close();

            // Return the encrypted byte array.
            return buffer;
        }

        public static string ToEncryptString(this string PlainText)
        {
            if (string.IsNullOrEmpty(PlainText)) return PlainText;

            byte[] buffer = Encrypt(PlainText);

            return Convert.ToBase64String(buffer, 0, buffer.Length);
        }

        private static string Decrypt(byte[] CypherText)
        {
            DESCryptoServiceProvider key = new DESCryptoServiceProvider();

            key.Key = System.Text.Encoding.Default.GetBytes(_BasekeyString);
            key.IV = System.Text.Encoding.Default.GetBytes(_BasekeyString);

            // Create a memory stream to the passed buffer.
            MemoryStream ms = new MemoryStream(CypherText);

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key. 
            CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);

            // Create a StreamReader for reading the stream.
            StreamReader sr = new StreamReader(encStream);

            // Read the stream as a string.
            string val = sr.ReadLine();

            // Close the streams.
            sr.Close();

            encStream.Close();

            ms.Close();

            return val;
        }

        public static string ToDecryptString(this string CypherText)
        {
            if (string.IsNullOrEmpty(CypherText)) return CypherText;

            byte[] buffer = Convert.FromBase64String(CypherText);

            return Decrypt(buffer).ToString();
        }

        public static List<TSource> ToJavaScriptList<TSource>(this string JavaScriptText)
        {
            return new JavaScriptSerializer().Deserialize<List<TSource>>(JavaScriptText);
        }

        public static string ToArrayString(this string[] array)
        {
            string text = null;

            foreach (string item in array)
            {
                text += (text == null ? "" : ",") + item;
            }
            return text;
        }

        public static string ToListString(this List<string> list)
        {
            string text = null;

            if (list == null) return text;

            foreach (string item in list)
            {
                text += (text == null ? "" : ",") + item;
            }
            return text;
        }

        public static string ToBoolString(this bool value)
        {
            return value ? "1" : "0";
        }

        public static int? ToNullableInt(this object value)
        {
            try
            {
                if (ToNullableDouble(value) == null)
                {
                    return null;
                }
                else
                {
                    return (int?)Math.Truncate(ToDouble(value));
                }
            }
            catch
            {
                return null;
            }
        }

        public static double? ToNullableDouble(this object value)
        {
            try
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return null;
                }
                else
                {
                    return Convert.ToDouble(value.ToString());
                }
            }
            catch
            {
                return null;
            }
        }

        public static int ToInt(this object value)
        {
            try
            {
                return (int)Math.Truncate(ToDouble(value));
            }
            catch
            {
                return (int)0;
            }
        }

        public static double ToDouble(this object value)
        {
            try
            {
                return Convert.ToDouble(value.ToString());
            }
            catch
            {
                return (double)0;
            }
        }

        public static List<string> ToStringList(this string text)
        {
            List<string> list = new List<string>();

            if (text == null) return list;

            foreach (string item in text.Split(','))
            {
                list.Add(item);
            }
            return list;
        }


        public static DateTime TodayFirstTime(this DateTime dt)
        {
            {
                return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
            }
        }

        public static DateTime TodayLastTime(this DateTime dt)
        {
            {
                return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            }
        }

        public static DateTime FirstDayOfMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, (int)1);
        }

        public static DateTime LastDayOfMonth(this DateTime datetime)
        {
            return datetime.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfYear(this DateTime datetime)
        {
            return new DateTime(datetime.Year, (int)1, (int)1);
        }

        public static DateTime LastDayOfYear(this DateTime datetime)
        {
            return new DateTime(datetime.Year, (int)12, (int)31);
        }

        public static DateTime LastDayOfMaxYear(this DateTime datetime)
        {
            return new DateTime((int)2099, (int)12, (int)31);
        }
    }
}