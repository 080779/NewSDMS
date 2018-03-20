using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
    public class SystemBankService : ISystemBankService
    {
        /// <summary>
        /// 添加银行信息
        /// </summary>
        /// <param name="bankName"></param>
        /// <param name="bankNameEn"></param>
        /// <returns></returns>
        public long AddSystemBank(string bankName, string bankAccount, string bankAccountUser, string addr, int bankType = 0)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                SystemBankEntity entity = new SystemBankEntity();
                entity.BankName = bankName;
                entity.BankAccount = bankAccount;
                entity.BankAccountUser = bankAccountUser;
                entity.BankAddress = addr;
                entity.BankType = 0;
                entity.CreateTime = DateTime.Now;
                dbcontext.SystemBank.Add(entity);
                dbcontext.SaveChanges();
                return entity.ID;
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public SystemBankDTO[] GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SystemBankEntity> csr = new CommonService<SystemBankEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToArray();
            }
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SystemBankDTO GetDTOByID(long ID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SystemBankEntity> csr = new CommonService<SystemBankEntity>(dbcontext);
                SystemBankEntity entity = csr.GetById(ID);
                if(entity != null)
                {
                    return ToDTO(entity);
                }
                return null;
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
                CommonService<SystemBankEntity> csr = new CommonService<SystemBankEntity>(dbcontext);
                SystemBankEntity re = csr.GetById(ID);
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

        public SystemBankDTO ToDTO(SystemBankEntity model)
        {
            SystemBankDTO dto = new SystemBankDTO();
            dto.BankName = model.BankName;
            dto.BankAccount = model.BankAccount;
            dto.BankAccountUser = model.BankAccountUser;
            dto.BankAddress = model.BankAddress;
            dto.BankType = model.BankType;
            dto.ID = model.ID;
            dto.CreateTime = model.CreateTime;
            return dto;
        }
    }
}
