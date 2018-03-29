using SDMS.Service.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service
{
    /// <summary>
    /// EntityFramework操作类
    /// </summary>
    class MyDbContext : DbContext
    {
        private static ILog log = LogManager.GetLogger(typeof(MyDbContext));

        public MyDbContext() : base("name=connStr") //“connStr”数据库连接字符串
        {
            //Database.SetInitializer<MyDbContext>(null);
            this.Database.Log = sql => log.DebugFormat("EF执行SQL：{0}", sql);//用log4NET记录数据操作日志
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AdminEntity> Admin { get; set; }        
        public DbSet<HolderEntity> Holder { get; set; }
        public DbSet<JournalEntity> Journal { get; set; }       
        public DbSet<JournalTypeEntity> JournalTypes { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<PowerEntity> Power { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<PermissionEntity> Permission { get; set; }
        public DbSet<StockItemEntity> StockItems { get; set; }
        public DbSet<SetShareBonusEntity> SetShareBonus { get; set; }
        public DbSet<TakeCashEntity> TakeCashs { get; set; }
        public DbSet<SettingsEntity> Settings { get; set; }
        public DbSet<AdminLogEntity> AdminLogs { get; set; }
        public DbSet<ReadNumberEntity> ReadNumbers { get; set; }
        public DbSet<AdImgLinkEntity> AdImgLinks { get; set; }
        public DbSet<TakeCashStateEntity> TakeCashStates { get; set; }
    }
}
