using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
    public class BankNameService : IBankNameService
    {
        /*
        /// <summary>
        /// 添加银行信息
        /// </summary>
        /// <param name="bankName"></param>
        /// <param name="bankNameEn"></param>
        /// <returns></returns>
        public long AddBankName(string bankName, string bankNameEn)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                BankNameEntity entity = new BankNameEntity();
                entity.BankName = bankName;
                entity.BankNameEn = bankNameEn;
                dbcontext.BankName.Add(entity);
                dbcontext.SaveChanges();
                return entity.ID;
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<BankNameDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<BankNameEntity> csr = new CommonService<BankNameEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }

        /// <summary>
        /// 删除 0：删除成功，1：删除失败，2：已删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(long ID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<BankNameEntity> csr = new CommonService<BankNameEntity>(dbcontext);
                BankNameEntity re = csr.GetById(ID);
                if (re != null)
                {
                    re.IsDeleted = true;
                    int num = dbcontext.SaveChanges();
                    if (num > 0)
                    {
                        return 0;//删除成功
                    }
                    else
                    {
                        return 1;//删除失败
                    }
                }
                else
                {
                    return 2;//已删除
                }
            }
        }

        public BankNameDTO ToDTO(BankNameEntity model)
        {
            BankNameDTO dto = new BankNameDTO();
            dto.BankName = model.BankName;
            dto.BankNameEn = model.BankNameEn;
            dto.ID = model.ID;
            dto.CreateTime = model.CreateTime;
            return dto;
        }
    
        public List<BankNameDTO> GetAllList()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<BankNameEntity> cs = new CommonService<BankNameEntity>(dbc);
                return cs.GetAll().ToList().Select(r =>
                new BankNameDTO
                {
                    BankNameEn = r.BankNameEn,
                    BankName = r.BankName
                }).ToList();
            }
        }
        */
        public long AddBankName(string bankName, string bankNameEn)
        {
            throw new NotImplementedException();
        }

        public int Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<BankNameDTO> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<BankNameDTO> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
