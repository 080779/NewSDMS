using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class DataBaseService : IDataBaseService
    {
        public int DataBaseClear()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                return dbc.Database.ExecuteSqlCommand("exec DelAll");
            }
        }
    }
}
