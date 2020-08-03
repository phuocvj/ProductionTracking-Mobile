using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdTracking.Models.Home
{
    public class ProdListModel
    {
        public string PLANT { get; set; }
        public string MLINE { get; set; }
        public decimal CNT_SPAN { get; set; }
        public string TARGET { get; set; }
        public string RPLAN { get; set; }
        public string ACT { get; set; }
        public string RATIO { get; set; }
        public string STYLESHEET { get; set; }
        public string REASON_NM { get; set; }
    }
}
