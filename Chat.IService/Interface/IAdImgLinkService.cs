﻿using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IAdImgLinkService:IServiceSupport
    {
        AdImgLinkDTO[] GetPageList();
        bool Update(long id, string name, string url);
    }
}
