using Oracle.DataAccess.Client;
using ProdTracking.Business.Interfaces;
using ProdTracking.Common;
using ProdTracking.Models.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace ProdTracking.Business.Services
{
    public class HomeServices : BaseServices, IHomeServices
    {
        public IEnumerable<ProdListModel> ProdListModelRead(string Type,string PlantCode)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(LMESConnectionString))
                {
                    connection.Open();

                    OracleCommand command = new OracleCommand("PKG_PRODTRACKING_WEB.SELECT_PROD_LIST_V2", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("ARG_TYPE", OracleDbType.Varchar2).Value = Type;
                    command.Parameters.Add("ARG_COMPANY", OracleDbType.Varchar2).Value = UserInfo.CompanyCode;
                    command.Parameters.Add("ARG_LINE", OracleDbType.Varchar2).Value = PlantCode;
                    command.Parameters.Add("OUT_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (DataTable dt = new DataTable())
                    {
                        (new OracleDataAdapter(command)).Fill(dt);
                        return dt.ToList<ProdListModel>();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
