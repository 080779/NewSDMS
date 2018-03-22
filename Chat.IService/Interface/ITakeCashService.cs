﻿using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface ITakeCashService:IServiceSupport
    {
        long Apply(long holderId,decimal Amount);
        int Confirm(long id, string message, string imgUrl, int flag);
        TakeCashSearchResult GetPageList(string name,string mobile,DateTime? startTime,DateTime? endTime,int pageIndex,int pageSize);

    }
    public class TakeCashSearchResult
    {
        public TakeCashDTO[] TakeCashs { get; set; }
        public long TotalCount { get; set; }
    }
}
