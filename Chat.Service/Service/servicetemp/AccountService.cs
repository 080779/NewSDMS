using SDMS.IService.Interface;
using SDMS.Service.Entities;
using SDMS.Common;
using System.Linq;


namespace SDMS.Service.Service
{
    public class AccountService : IAccountService
    {
        /*
        /// <summary>
        /// 获得总收入
        /// </summary>
        /// <returns></returns>
        public decimal GetIncomeTotal()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserRecordEntity> cs = new CommonService<UserRecordEntity>(dbc);

                var money = cs.GetAll().Where(s => s.ReType == 2).Sum(m => m.ReMoney);
                
                return money;
            }

        }
        /// <summary>
        /// 获得总支出
        /// </summary>
        /// <returns></returns>
        public decimal GetPayTotal()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<BonusEntity> cs = new CommonService<BonusEntity>(dbc);

                var money = cs.GetAll().Sum(m => m.Sf);

                return money;
            }
            
        }
        */
        public decimal GetIncomeTotal()
        {
            throw new System.NotImplementedException();
        }

        public decimal GetPayTotal()
        {
            throw new System.NotImplementedException();
        }
    }
}
