using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class SalesRoomEntity:BaseEntity
    {
        public int SaID { get; set; }
        public int? SaPrId { get; set; }
        public string SaPrName { get; set; }
        public string SaPrConent { get; set; }
        public decimal? SaPrUsually { get; set; }
        public string SaPrImage { get; set; }
        public decimal? SaPrice { get; set; }
        public string SaNumber { get; set; }
        public int? SaTypeID { get; set; }
        public int? SaJinpaiSate { get; set; }
        public int? SuccessUserID { get; set; }
        public DateTime? RegTime1 { get; set; }
        public DateTime? RegTime2 { get; set; }
        public int? SaTargetPoint { get; set; }
        public int? SaWeiPoint { get; set; }
        public int? SaSanPoint { get; set; }
        public int? SaSanTargetPoint { get; set; }
        public int? SaWeiTargetPoint { get; set; }
        public int? SaState { get; set; }
        public DateTime? SaBeginTime { get; set; }
        public DateTime? SaTurnoverTime { get; set; }
        public int? SaClapTime { get; set; }
        public string Sa001 { get; set; }
        public decimal? Sa002 { get; set; }
        public DateTime? SaAddTime { get; set; }
        public string SaPrName_en { get; set; }
        public string SaPrConent_en { get; set; }
    }
}
