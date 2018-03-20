using SDMS.IService.Interface;
using SDMS.Service.Entities;
using SDMS.Common;
using System.Linq;

namespace SDMS.Service.Service
{
    public class AdminLoginServive : IAdminLoginService
    {
        public int AdminLogin(string usercode, string password)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                //var user = dbc.User.Select(s=>s.UserCode).Any();
                var admin = cs.GetAll().SingleOrDefault(a => a.UserName == usercode);
                //cs.GetAll().Any(u => u.UserName == usercode);
                if (admin == null)
                {
                    return 1;//账户不存在
                }
                if (admin.Password != CommonHelper.GetMD5(password))
                {
                    return 2;//密码错误
                }
                return 0;
            }
        }
    }
}