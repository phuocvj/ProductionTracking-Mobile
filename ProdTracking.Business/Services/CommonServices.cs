using Oracle.DataAccess.Client;
using ProdTracking.Business.Interfaces;
using ProdTracking.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace ProdTracking.Business.Services
{
    public class CommonServices : BaseServices, ICommonServices
    {
       
       
        #region get Plant
        public List<SelectListItem> GetPlantList(string type)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                using (OracleConnection connection = new OracleConnection(LMESConnectionString))
                {
                    connection.Open();

                    OracleCommand command = new OracleCommand("PKG_PRODTRACKING_WEB.SELECT_LINE_LIST", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("ARG_TYPE", OracleDbType.Varchar2).Value = type;
                    command.Parameters.Add("ARG_FACTORY", OracleDbType.Varchar2).Value = UserInfo.CompanyCode;
                    command.Parameters.Add("OUT_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (DataTable dt = new DataTable())
                    {
                        (new OracleDataAdapter(command)).Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            result.Add(new SelectListItem() { Text = row["LINE_NM"].ToString(), Value = row["LINE_CD"].ToString() });
                        }
                    }
                }
            }
            catch { }

            return result;
        }
        #endregion
    }
}