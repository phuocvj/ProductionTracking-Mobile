using System;
using System.Configuration;

namespace ProdTracking.Business.Services
{
    /// <summary>
    /// Author      : CSI.VJ
    /// Create date : 2020-03-05
    /// Description : Base Services
    /// Latest
    /// Modifier    : PHUOC.IT
    /// Modify date : 2020-03-05
    /// Remark      : 
    /// </summary>
    public class BaseServices
    {
        #region Variables

        private static readonly string _CMMSVJConnectionString = ConfigurationManager.ConnectionStrings["CSI.VJ.CMMS"].ToString();

        private static readonly string _HUBICVJConnectionString = ConfigurationManager.ConnectionStrings["HUBICVJ"].ToString();

        private static readonly string _LMESConnectionString = ConfigurationManager.ConnectionStrings["LMES"].ToString();

        private static readonly string _SEPHIROTHConnectionString = ConfigurationManager.ConnectionStrings["SEPHIROTH"].ToString();
        
        #endregion

        #region Properties

        protected string CMMSVJConnectionString
        {
            get { return _CMMSVJConnectionString; }
        }

        protected string HUBICVJConnectionString
        {
            get { return _HUBICVJConnectionString; }
        }

        protected string LMESConnectionString
        {
            get { return _LMESConnectionString; }
        }

        protected string SEPHIROTHConnectionString
        {
            get { return _SEPHIROTHConnectionString; }
        }
        #endregion

        #region Methods

        public object GetDBNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        #endregion
    }
}