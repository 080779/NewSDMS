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

        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<AdminEntity> Admin { get; set; }
        public DbSet<AgentEntity> Agent { get; set; }
        public DbSet<AreaEntity> Area { get; set; }
        public DbSet<BankNameEntity> BankName { get; set; }
        public DbSet<BonusEntity> Bonus { get; set; }
        public DbSet<BonusTypeEntity> BonusType { get; set; }
        public DbSet<CashbuyEntity> Cashbuy { get; set; }
        public DbSet<CashcreditEntity> Cashcredit { get; set; }
        public DbSet<CashorderEntity> Cashorder { get; set; }
        public DbSet<CashPoundageEntity> CashPoundage { get; set; }
        public DbSet<CashsellEntity> Cashsell { get; set; }
        public DbSet<ChangeEntity> Change { get; set; }
        public DbSet<CityEntity> City { get; set; }
        public DbSet<CountryEntity> Country { get; set; }
        public DbSet<CurrencyRateEntity> CurrencyRate { get; set; }
        public DbSet<GlobeParamEntity> GlobeParam { get; set; }
        public DbSet<GoodsEntity> Goods { get; set; }
        public DbSet<JournalEntity> Journal { get; set; }
        public DbSet<LeaveMsgEntity> LeaveMsg { get; set; }
        public DbSet<LeaveReMsgEntity> LeaveReMsg { get; set; }
        public DbSet<LevelEntity> Level { get; set; }
        public DbSet<LinkEntity> Link { get; set; }
        public DbSet<MessageEntity> Message { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<OrderDetailEntity> OrderDetail { get; set; }

        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<PowerEntity> Power { get; set; }
        public DbSet<ProduceTypeEntity> ProduceType { get; set; }
        public DbSet<ProvinceEntity> Province { get; set; }
        public DbSet<RechargeEntity> Recharge { get; set; }
        public DbSet<RemitEntity> Remit { get; set; }
        public DbSet<SalesRoomEntity> Sales { get; set; }
        public DbSet<SecurityEntity> Security { get; set; }
        public DbSet<ServiceQQEntity> ServiceQQ { get; set; }
        public DbSet<SetSystemEntity> SetSystem { get; set; }
        public DbSet<SMSEntity> SMS { get; set; }
        public DbSet<StockBuyEntity> StockBuy { get; set; }
        public DbSet<StockChartEntity> StockChart { get; set; }
        public DbSet<StockDetailEntity> StockDetail { get; set; }
        public DbSet<StockEntity> Stock { get; set; }
        public DbSet<StockLssueEntity> StockLssue { get; set; }
        public DbSet<StockorderEntity> Stockorder { get; set; }
        public DbSet<StockSellEntity> StockSell { get; set; }
        public DbSet<StockSplitDetailEntity> StockSplitDetail { get; set; }
        public DbSet<StockSplitEntity> StockSplit { get; set; }
        public DbSet<SysLogEntity> SysLog { get; set; }
        public DbSet<SystemBankEntity> SystemBank { get; set; }
        public DbSet<SystemMoneyEntity> SystemMoney { get; set; }
        public DbSet<TakeMoneyEntity> TakeMoney { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserProEntity> UserPro { get; set; }
        public DbSet<UserRecordEntity> UserRecord { get; set; }
        public DbSet<WealthEntity> Wealth { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<PermissionEntity> Permission { get; set; }
    }
}
