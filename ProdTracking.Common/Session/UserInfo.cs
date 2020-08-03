using System;
using System.Data;
using System.Web;

namespace ProdTracking.Common
{
    /// <summary>
    /// Author      : CSI.VJ
    /// Create date : 2018-07-17
    /// Description : User Information
    /// Latest
    /// Modifier    : HA-SEUNGMIN
    /// Modify date : 2019-03-06
    /// Remark      : 
    /// </summary>
    public class UserInfo
    {
        #region System Properties

        public static string DefaultCulture { get; set; }

        public static string Culture
        {
            get
            {
                if (string.IsNullOrEmpty(string.Format("{0}", HttpContext.Current.Session["USER_CULTURE"])))
                {
                    HttpContext.Current.Session["USER_CULTURE"] = DefaultCulture;
                }

                return HttpContext.Current.Session["USER_CULTURE"] as string;
            }
            set
            {
                HttpContext.Current.Session["USER_CULTURE"] = value;
            }
        }

        public static string FullDateTimePattern
        {
            get
            {
                return HttpContext.Current.Session["FullDateTimePattern"] as string;
            }
            set
            {
                HttpContext.Current.Session["FullDateTimePattern"] = value;
            }
        }

        public static string FullDateTimePattern_g
        {
            get
            {
                return HttpContext.Current.Session["FullDateTimePattern_g"] as string;
            }
            set
            {
                HttpContext.Current.Session["FullDateTimePattern_g"] = value;
            }
        }

        public static string LongDatePattern
        {
            get
            {
                return HttpContext.Current.Session["LongDatePattern"] as string;
            }
            set
            {
                HttpContext.Current.Session["LongDatePattern"] = value;
            }
        }

        public static string ShortDatePattern
        {
            get
            {
                return HttpContext.Current.Session["ShortDatePattern"] as string;
            }
            set
            {
                HttpContext.Current.Session["ShortDatePattern"] = value;
            }
        }

        public static string LongTimePattern
        {
            get
            {
                return HttpContext.Current.Session["LongTimePattern"] as string;
            }
            set
            {
                HttpContext.Current.Session["LongTimePattern"] = value;
            }
        }

        public static string ShortTimePattern
        {
            get
            {
                return HttpContext.Current.Session["ShortTimePattern"] as string;
            }
            set
            {
                HttpContext.Current.Session["ShortTimePattern"] = value;
            }
        }

        public static string MonthDayPattern
        {
            get
            {
                return HttpContext.Current.Session["MonthDayPattern"] as string;
            }
            set
            {
                HttpContext.Current.Session["MonthDayPattern"] = value;
            }
        }

        public static string YearMonthPattern
        {
            get
            {
                return HttpContext.Current.Session["YearMonthPattern"] as string;
            }
            set
            {
                HttpContext.Current.Session["YearMonthPattern"] = value;
            }
        }

        #endregion

        #region User Properties

        public static string UserID
        {
            get
            {
                return HttpContext.Current.Session["USER_ID"] as string;
            }
            set
            {
                HttpContext.Current.Session["USER_ID"] = value;
            }
        }

        public static string UserName
        {
            get
            {
                return HttpContext.Current.Session["USER_NM"] as string;
            }
            set
            {
                HttpContext.Current.Session["USER_NM"] = value;
            }
        }

        public static string UserMail
        {
            get
            {
                return HttpContext.Current.Session["USER_MAIL"] as string;
            }
            set
            {
                HttpContext.Current.Session["USER_MAIL"] = value;
            }
        }

        public static string GroupCode
        {
            get
            {
                return HttpContext.Current.Session["GROUP_CD"] as string;
            }
            set
            {
                HttpContext.Current.Session["GROUP_CD"] = value;
            }
        }

        public static string CompanyCode
        {
            get
            {
                return HttpContext.Current.Session["COMPANY_CD"] as string;
            }
            set
            {
                HttpContext.Current.Session["COMPANY_CD"] = value;
            }
        }

        public static string CompanyName
        {
            get
            {
                return HttpContext.Current.Session["COMPANY_NM"] as string;
            }
            set
            {
                HttpContext.Current.Session["COMPANY_NM"] = value;
            }
        }

        public static string FactoryCode
        {
            get
            {
                return HttpContext.Current.Session["FACTORY_CD"] as string;
            }
            set
            {
                HttpContext.Current.Session["FACTORY_CD"] = value;
            }
        }

        public static string OrganizationCode
        {
            get
            {
                return HttpContext.Current.Session["ORGN_CD"] as string;
            }
            set
            {
                HttpContext.Current.Session["ORGN_CD"] = value;
            }
        }

        public static string UserType
        {
            get
            {
                return HttpContext.Current.Session["USER_TYPE"] as string;
            }
            set
            {
                HttpContext.Current.Session["USER_TYPE"] = value;
            }
        }

        public static string DepartmentCode
        {
            get
            {
                return HttpContext.Current.Session["HUBIC_DEPT_CD"] as string;
            }
            set
            {
                HttpContext.Current.Session["HUBIC_DEPT_CD"] = value;
            }
        }

        public static string DepartmentName
        {
            get
            {
                return HttpContext.Current.Session["HUBIC_DEPT_NM"] as string;
            }
            set
            {
                HttpContext.Current.Session["HUBIC_DEPT_NM"] = value;
            }
        }

        public static string PositionCode
        {
            get
            {
                return HttpContext.Current.Session["HUBIC_POS_CD"] as string;
            }
            set
            {
                HttpContext.Current.Session["HUBIC_POS_CD"] = value;
            }
        }

        public static string PositionName
        {
            get
            {
                return HttpContext.Current.Session["HUBIC_POS_NM"] as string;
            }
            set
            {
                HttpContext.Current.Session["HUBIC_POS_NM"] = value;
            }
        }

        public static DateTime LoginDate
        {
            get
            {
                return (DateTime)HttpContext.Current.Session["LOGIN_DATE"];
            }
            set
            {
                HttpContext.Current.Session["LOGIN_DATE"] = value;
            }
        }

        public static string HostIP
        {
            get
            {
                return HttpContext.Current.Session["HOST_IP"] as string;
            }
            set
            {
                HttpContext.Current.Session["HOST_IP"] = value;
            }
        }

        public static bool isLogin
        {
            get
            {
                return !string.IsNullOrEmpty(string.Format("{0}", HttpContext.Current.Session["USER_ID"]));
            }
        }

        public static bool isAdmin
        {
            get
            {
                return HttpContext.Current.Session["ADMIN_YN"] == null ? false : (bool)HttpContext.Current.Session["ADMIN_YN"];
            }
            set
            {
                HttpContext.Current.Session["ADMIN_YN"] = value;
            }
        }

        public static bool isChief
        {
            get
            {
                return HttpContext.Current.Session["CHIEF_YN"] == null ? false : (bool)HttpContext.Current.Session["CHIEF_YN"];
            }
            set
            {
                HttpContext.Current.Session["CHIEF_YN"] = value;
            }
        }

        public static bool isManager
        {
            get
            {
                return HttpContext.Current.Session["MANAGER_YN"] == null ? false : (bool)HttpContext.Current.Session["MANAGER_YN"];
            }
            set
            {
                HttpContext.Current.Session["MANAGER_YN"] = value;
            }
        }

        public static bool isVJUser
        {
            get
            {
                return HttpContext.Current.Session["VJUSER_YN"] == null ? false : (bool)HttpContext.Current.Session["VJUSER_YN"];
            }
            set
            {
                HttpContext.Current.Session["VJUSER_YN"] = value;
            }
        }

        public static string PhotoLogicalPath
        {
            get
            {
                if (System.IO.File.Exists(string.Format("{0}/{1}/{2}.png", FileHelper.UploadPath, "Employee", UserID)))
                {
                    return string.Format("/Upload/Employee/{0}.png", UserID);
                }
                else
                {
                    return "/Images/no-avatar.png";
                }
            }
        }

        public static string IndexPageName
        {
            get
            {
                return isManager ? "AnalysisIndex" : "Index";
            }
        }

        public static string IndexPageFullName
        {
            get
            {
                return isManager ? "/Home/AnalysisIndex" : "/Home/Index";
            }
        }

        #endregion

        #region Program Properties

        public static string ProgramID
        {
            get
            {
                return HttpContext.Current.Session["ProgramID"] as string;
            }
            set
            {
                HttpContext.Current.Session["ProgramID"] = value;
            }
        }

        public static string ProgramName
        {
            get
            {
                return HttpContext.Current.Session["ProgramName"] as string;
            }
            set
            {
                HttpContext.Current.Session["ProgramName"] = value;
            }
        }

        public static DataTable MenuTable
        {
            get
            {
                if (HttpContext.Current.Session["MenuTable"] == null)
                {
                    return (DataTable)null;
                }
                else
                {
                    return (DataTable)HttpContext.Current.Session["MenuTable"];
                }
            }
            set
            {
                HttpContext.Current.Session["MenuTable"] = value;
            }
        }

        public static bool IsAuthority
        {
            get
            {
                return HttpContext.Current.Session["IsAuthority"] != null && (bool)HttpContext.Current.Session["IsAuthority"];
            }
            set
            {
                HttpContext.Current.Session["IsAuthority"] = value;
            }
        }

        public static bool AuthorityNew
        {
            get
            {
                return HttpContext.Current.Session["Authority_New"] != null && (bool)HttpContext.Current.Session["Authority_New"];
            }
            set
            {
                HttpContext.Current.Session["Authority_New"] = value;
            }
        }

        public static bool AuthoritySave
        {
            get
            {
                return HttpContext.Current.Session["Authority_Save"] != null && (bool)HttpContext.Current.Session["Authority_Save"];
            }
            set
            {
                HttpContext.Current.Session["Authority_Save"] = value;
            }
        }

        public static bool AuthorityDelete
        {
            get
            {
                return HttpContext.Current.Session["Authority_Delete"] != null && (bool)HttpContext.Current.Session["Authority_Delete"];
            }
            set
            {
                HttpContext.Current.Session["Authority_Delete"] = value;
            }
        }

        public static bool AuthorityExcel
        {
            get
            {
                return HttpContext.Current.Session["Authority_Excel"] != null && (bool)HttpContext.Current.Session["Authority_Excel"];
            }
            set
            {
                HttpContext.Current.Session["Authority_Excel"] = value;
            }
        }

        public static bool AuthorityPrint
        {
            get
            {
                return HttpContext.Current.Session["Authority_Print"] != null && (bool)HttpContext.Current.Session["Authority_Print"];
            }
            set
            {
                HttpContext.Current.Session["Authority_Print"] = value;
            }
        }

        public static bool AuthorityEtc
        {
            get
            {
                return HttpContext.Current.Session["Authority_Etc"] != null && (bool)HttpContext.Current.Session["Authority_Etc"];
            }
            set
            {
                HttpContext.Current.Session["Authority_Etc"] = value;
            }
        }

        public static bool AuthorityClose
        {
            get
            {
                return HttpContext.Current.Session["Authority_Close"] != null && (bool)HttpContext.Current.Session["Authority_Close"];
            }
            set
            {
                HttpContext.Current.Session["Authority_Close"] = value;
            }
        }

        #endregion

        #region Methods

        public static void AuthorityClear()
        {
            ProgramID       = null;
            ProgramName     = null;
            IsAuthority     = false;
            AuthorityNew    = false;
            AuthoritySave   = false;
            AuthorityDelete = false;
            AuthorityExcel  = false;
            AuthorityPrint  = false;
            AuthorityEtc    = false;
            AuthorityClose  = false;
        }
        
        #endregion
    }
}