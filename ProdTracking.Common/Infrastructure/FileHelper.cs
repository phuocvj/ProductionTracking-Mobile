using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;

namespace ProdTracking.Common
{
    /// <summary>
    /// Author      : CSI.VJ
    /// Create date : 2020-07-27
    /// Description : File Helper
    /// Latest
    /// Modifier    : pHUOC.IT
    /// Modify date : 2020-07-27
    /// Remark      : 
    /// </summary>
    public class FileHelper
    {
        public static string UploadPath
        {
            get { return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString()).Replace("\\", "/"); }
        }

        public static int UploadMaxSize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["UploadMaxSize"].ToString()); }
        }

        public static string GetNewFileName(string path)
        {
            string fileName;
            while (true)
            {
                fileName = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                
                if (!File.Exists(string.Format("{0}/{1}", path, fileName)))
                {
                    break;
                }
            }
            return fileName;
        }

        public static string CreateDirectory(string path, string folder)
        {
            string pullpath = string.Format("{0}/{1}", path, folder);

            if (!Directory.Exists(pullpath))
            {
                Directory.CreateDirectory(pullpath);
            }
            return pullpath;
        }

        public static void FileDelete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static bool UploadFileDelete(string folder, string filename)
        {
            try
            {
                string pullpath = string.Format("{0}/{1}/{2}", UploadPath, folder, filename);

                if (File.Exists(pullpath))
                {
                    File.Delete(pullpath);
                }

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static DataTable ExcelToDataTable(string path)
        {
            using (DataTable dt = new DataTable())
            {
                try
                {
                    using (OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"", path)))
                    {
                        connection.Open();

                        using (DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" }))
                        {
                            foreach (DataRow row in schemaTable.Rows)
                            {
                                if (row["TABLE_NAME"].ToString().ToUpper().Equals("SHEET1$"))
                                {
                                    OleDbCommand command = new OleDbCommand(string.Format("SELECT * FROM [{0}]", row["TABLE_NAME"].ToString()), connection);
                                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                                    adapter.Fill(dt);
                                    adapter.Dispose();
                                    command.Dispose();
                                }
                            }
                        }
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}