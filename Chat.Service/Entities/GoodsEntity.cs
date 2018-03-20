using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class GoodsEntity:BaseEntity
    {
        public string GoodsCode { get; set; }
        public string GoodsName { get; set; }
        public decimal Price { get; set; }
        public decimal RealityPrice { get; set; }
        public string Standard { get; set; }
        public int? IsHave { get; set; }
        public int? TypeID { get; set; }
        public int? GoodsType { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        public string Summary { get; set; }
        public string Remarks { get; set; }
        public DateTime AddTime { get; set; }
        public int? Goods001 { get; set; }
        public int? Goods002 { get; set; }
        public string Goods003 { get; set; }
        public string Goods004 { get; set; }
        public decimal? Goods005 { get; set; }
        public decimal? Goods006 { get; set; }
        public DateTime? Goods007 { get; set; }
        public DateTime? Goods008 { get; set; }
        public string GoodsName_en { get; set; }
        public string Remarks_en { get; set; }
        public decimal? FLH1 { get; set; }
        public decimal? FLH2 { get; set; }
        public decimal? FLH3 { get; set; }
        public decimal? FLJ1 { get; set; }
        public decimal? FLJ2 { get; set; }
        public decimal? FLJ3 { get; set; }
        public decimal? FLT1 { get; set; }
        public decimal? FLT2 { get; set; }
        public decimal? FLT3 { get; set; }
    }
}
