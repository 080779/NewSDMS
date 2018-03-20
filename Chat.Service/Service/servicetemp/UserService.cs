using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.DTO.Model;
using System.Data.Entity;

namespace SDMS.Service.Service
{
    public class UserService //: IUserService
    {
        /*
        #region MyRegion
        public List<UserDTO> GetLayerModelList(int lay1, int lay2)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                return cs.GetAll().Where(p => p.Layer > lay1 && p.Layer < lay2).ToList().Select(r =>
                new UserDTO
                {
                    UserCode = r.UserCode,
                    AddGLTime = r.AddGLTime,
                    AgentsID = r.AgentsID,
                    Address = r.Address,
                    AllBonusAccount = r.AllBonusAccount,
                    BankAccount = r.BankAccount,
                    BankAccountUser = r.BankAccountUser,
                    BankBranch = r.BankBranch,
                    BankInCity = r.BankInCity,
                    BankInProvince = r.BankInProvince,
                    BankName = r.BankName,
                    BillCount = r.BillCount,
                    BonusAccount = r.BonusAccount,
                    CenterBalance = r.CenterBalance,
                    CenterNewScore = r.CenterNewScore,
                    CenterScore = r.CenterScore,
                    CenterZT = r.CenterZT,
                    CreateTime = r.CreateTime,
                    Emoney = r.Emoney,
                    Gender = r.Gender,
                    GLmoney = r.GLmoney,
                    ID = r.ID,
                    IdenCode = r.IdenCode,
                    IsAgent = r.IsAgent,
                    IsLock = r.IsLock,
                    IsOpend = r.IsOpend,
                    Layer = r.Layer,
                    LeftBalance = r.LeftBalance,
                    LeftNewScore = r.LeftNewScore,
                    LeftScore = r.LeftScore,
                    LeftZT = r.LeftZT,
                    LevelID = r.LevelID,
                    Location = r.Location,
                    NiceName = r.NiceName,
                    OpenTime = r.OpenTime,
                    ParentCode = r.ParentCode,
                    ParentID = r.ParentID,
                    Password = r.Password,
                    PhoneNum = r.PhoneNum,
                    QQnumer = r.QQnumer,
                    RecommendCode = r.RecommendCode,
                    RecommendGenera = r.RecommendGenera,
                    RecommendID = r.RecommendID,
                    RecommendPath = r.RecommendPath,
                    RegMoney = r.RegMoney,
                    RegTime = r.RegTime,
                    RightBalance = r.RightBalance,
                    RightNewScore = r.RightNewScore,
                    RightScore = r.RightScore,
                    RightZT = r.RightZT,
                    SafetyCodeAnswer = r.SafetyCodeAnswer,
                    SafetyCodeQuestion = r.SafetyCodeQuestion,
                    SecondPassword = r.SecondPassword,
                    ShopAccount = r.ShopAccount,
                    StockAccount = r.StockAccount,
                    StockMoney = r.StockMoney,
                    ThreePassword = r.ThreePassword,
                    TrueName = r.TrueName,
                    User001 = r.User001,
                    User002 = r.User002,
                    User003 = r.User003,
                    User004 = r.User004,
                    User005 = r.User005,
                    User006 = r.User006,
                    User007 = r.User007,
                    User008 = r.User008,
                    User009 = r.User009,
                    User010 = r.User010,
                    User011 = r.User012,
                    User013 = r.User013,
                    User014 = r.User014,
                    User015 = r.User015,
                    User016 = r.User016,
                    User017 = r.User017,
                    User018 = r.User018,
                    User012 = r.User012,
                    UserPath = r.UserPath
                }).ToList();
            }
        }
        #endregion
        public List<UserDTO> GetRecommendModelList(long RecommendID)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                return cs.GetAll().Where(p => p.RecommendID == RecommendID).ToList().Select(r =>
                new UserDTO
                {
                    UserCode = r.UserCode,
                    AddGLTime = r.AddGLTime,
                    AgentsID = r.AgentsID,
                    Address = r.Address,
                    AllBonusAccount = r.AllBonusAccount,
                    BankAccount = r.BankAccount,
                    BankAccountUser = r.BankAccountUser,
                    BankBranch = r.BankBranch,
                    BankInCity = r.BankInCity,
                    BankInProvince = r.BankInProvince,
                    BankName = r.BankName,
                    BillCount = r.BillCount,
                    BonusAccount = r.BonusAccount,
                    CenterBalance = r.CenterBalance,
                    CenterNewScore = r.CenterNewScore,
                    CenterScore = r.CenterScore,
                    CenterZT = r.CenterZT,
                    CreateTime = r.CreateTime,
                    Emoney = r.Emoney,
                    Gender = r.Gender,
                    GLmoney = r.GLmoney,
                    ID = r.ID,
                    IdenCode = r.IdenCode,
                    IsAgent = r.IsAgent,
                    IsLock = r.IsLock,
                    IsOpend = r.IsOpend,
                    Layer = r.Layer,
                    LeftBalance = r.LeftBalance,
                    LeftNewScore = r.LeftNewScore,
                    LeftScore = r.LeftScore,
                    LeftZT = r.LeftZT,
                    LevelID = r.LevelID,
                    Location = r.Location,
                    NiceName = r.NiceName,
                    OpenTime = r.OpenTime,
                    ParentCode = r.ParentCode,
                    ParentID = r.ParentID,
                    Password = r.Password,
                    PhoneNum = r.PhoneNum,
                    QQnumer = r.QQnumer,
                    RecommendCode = r.RecommendCode,
                    RecommendGenera = r.RecommendGenera,
                    RecommendID = r.RecommendID,
                    RecommendPath = r.RecommendPath,
                    RegMoney = r.RegMoney,
                    RegTime = r.RegTime,
                    RightBalance = r.RightBalance,
                    RightNewScore = r.RightNewScore,
                    RightScore = r.RightScore,
                    RightZT = r.RightZT,
                    SafetyCodeAnswer = r.SafetyCodeAnswer,
                    SafetyCodeQuestion = r.SafetyCodeQuestion,
                    SecondPassword = r.SecondPassword,
                    ShopAccount = r.ShopAccount,
                    StockAccount = r.StockAccount,
                    StockMoney = r.StockMoney,
                    ThreePassword = r.ThreePassword,
                    TrueName = r.TrueName,
                    User001 = r.User001,
                    User002 = r.User002,
                    User003 = r.User003,
                    User004 = r.User004,
                    User005 = r.User005,
                    User006 = r.User006,
                    User007 = r.User007,
                    User008 = r.User008,
                    User009 = r.User009,
                    User010 = r.User010,
                    User011 = r.User012,
                    User013 = r.User013,
                    User014 = r.User014,
                    User015 = r.User015,
                    User016 = r.User016,
                    User017 = r.User017,
                    User018 = r.User018,
                    User012 = r.User012,
                    UserPath = r.UserPath
                }).ToList();
            }
        }
        /// <summary>
        /// 根据ID查询用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserDTO GetModel(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                UserEntity r = cs.GetById(Id);
                if (r != null)
                {
                    return new UserDTO
                    {
                        UserCode = r.UserCode,
                        AddGLTime = r.AddGLTime,
                        AgentsID = r.AgentsID,
                        Address = r.Address,
                        AllBonusAccount = r.AllBonusAccount,
                        BankAccount = r.BankAccount,
                        BankAccountUser = r.BankAccountUser,
                        BankBranch = r.BankBranch,
                        BankInCity = r.BankInCity,
                        BankInProvince = r.BankInProvince,
                        BankName = r.BankName,
                        BillCount = r.BillCount,
                        BonusAccount = r.BonusAccount,
                        CenterBalance = r.CenterBalance,
                        CenterNewScore = r.CenterNewScore,
                        CenterScore = r.CenterScore,
                        CenterZT = r.CenterZT,
                        CreateTime = r.CreateTime,
                        Emoney = r.Emoney,
                        Gender = r.Gender,
                        GLmoney = r.GLmoney,
                        ID = r.ID,
                        IdenCode = r.IdenCode,
                        IsAgent = r.IsAgent,
                        IsLock = r.IsLock,
                        IsOpend = r.IsOpend,
                        Layer = r.Layer,
                        LeftBalance = r.LeftBalance,
                        LeftNewScore = r.LeftNewScore,
                        LeftScore = r.LeftScore,
                        LeftZT = r.LeftZT,
                        LevelID = r.LevelID,
                        Location = r.Location,
                        NiceName = r.NiceName,
                        OpenTime = r.OpenTime,
                        ParentCode = r.ParentCode,
                        ParentID = r.ParentID,
                        Password = r.Password,
                        PhoneNum = r.PhoneNum,
                        QQnumer = r.QQnumer,
                        RecommendCode = r.RecommendCode,
                        RecommendGenera = r.RecommendGenera,
                        RecommendID = r.RecommendID,
                        RecommendPath = r.RecommendPath,
                        RegMoney = r.RegMoney,
                        RegTime = r.RegTime,
                        RightBalance = r.RightBalance,
                        RightNewScore = r.RightNewScore,
                        RightScore = r.RightScore,
                        RightZT = r.RightZT,
                        SafetyCodeAnswer = r.SafetyCodeAnswer,
                        SafetyCodeQuestion = r.SafetyCodeQuestion,
                        SecondPassword = r.SecondPassword,
                        ShopAccount = r.ShopAccount,
                        StockAccount = r.StockAccount,
                        StockMoney = r.StockMoney,
                        ThreePassword = r.ThreePassword,
                        TrueName = r.TrueName,
                        User001 = r.User001,
                        User002 = r.User002,
                        User003 = r.User003,
                        User004 = r.User004,
                        User005 = r.User005,
                        User006 = r.User006,
                        User007 = r.User007,
                        User008 = r.User008,
                        User009 = r.User009,
                        User010 = r.User010,
                        User011 = r.User012,
                        User013 = r.User013,
                        User014 = r.User014,
                        User015 = r.User015,
                        User016 = r.User016,
                        User017 = r.User017,
                        User018 = r.User018,
                        User012 = r.User012,
                        UserPath = r.UserPath
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public UserDTO GetModel(string usercode)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                UserEntity r = cs.GetAll().Where(p => p.UserCode == usercode).SingleOrDefault();
                if (r != null)
                {
                    return new UserDTO
                    {
                        UserCode = r.UserCode,
                        AddGLTime = r.AddGLTime,
                        AgentsID = r.AgentsID,
                        Address = r.Address,
                        AllBonusAccount = r.AllBonusAccount,
                        BankAccount = r.BankAccount,
                        BankAccountUser = r.BankAccountUser,
                        BankBranch = r.BankBranch,
                        BankInCity = r.BankInCity,
                        BankInProvince = r.BankInProvince,
                        BankName = r.BankName,
                        BillCount = r.BillCount,
                        BonusAccount = r.BonusAccount,
                        CenterBalance = r.CenterBalance,
                        CenterNewScore = r.CenterNewScore,
                        CenterScore = r.CenterScore,
                        CenterZT = r.CenterZT,
                        CreateTime = r.CreateTime,
                        Emoney = r.Emoney,
                        Gender = r.Gender,
                        GLmoney = r.GLmoney,
                        ID = r.ID,
                        IdenCode = r.IdenCode,
                        IsAgent = r.IsAgent,
                        IsLock = r.IsLock,
                        IsOpend = r.IsOpend,
                        Layer = r.Layer,
                        LeftBalance = r.LeftBalance,
                        LeftNewScore = r.LeftNewScore,
                        LeftScore = r.LeftScore,
                        LeftZT = r.LeftZT,
                        LevelID = r.LevelID,
                        Location = r.Location,
                        NiceName = r.NiceName,
                        OpenTime = r.OpenTime,
                        ParentCode = r.ParentCode,
                        ParentID = r.ParentID,
                        Password = r.Password,
                        PhoneNum = r.PhoneNum,
                        QQnumer = r.QQnumer,
                        RecommendCode = r.RecommendCode,
                        RecommendGenera = r.RecommendGenera,
                        RecommendID = r.RecommendID,
                        RecommendPath = r.RecommendPath,
                        RegMoney = r.RegMoney,
                        RegTime = r.RegTime,
                        RightBalance = r.RightBalance,
                        RightNewScore = r.RightNewScore,
                        RightScore = r.RightScore,
                        RightZT = r.RightZT,
                        SafetyCodeAnswer = r.SafetyCodeAnswer,
                        SafetyCodeQuestion = r.SafetyCodeQuestion,
                        SecondPassword = r.SecondPassword,
                        ShopAccount = r.ShopAccount,
                        StockAccount = r.StockAccount,
                        StockMoney = r.StockMoney,
                        ThreePassword = r.ThreePassword,
                        TrueName = r.TrueName,
                        User001 = r.User001,
                        User002 = r.User002,
                        User003 = r.User003,
                        User004 = r.User004,
                        User005 = r.User005,
                        User006 = r.User006,
                        User007 = r.User007,
                        User008 = r.User008,
                        User009 = r.User009,
                        User010 = r.User010,
                        User011 = r.User012,
                        User013 = r.User013,
                        User014 = r.User014,
                        User015 = r.User015,
                        User016 = r.User016,
                        User017 = r.User017,
                        User018 = r.User018,
                        User012 = r.User012,
                        UserPath = r.UserPath
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public bool UpdatePath(UserDTO model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var usermodel = dbc.User.Where(p => p.ID == model.ID).First();
                usermodel.UserPath = model.UserPath;
                usermodel.RecommendPath = model.RecommendPath;
                int count = dbc.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        /// <summary>
        /// 根据ID查询用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserDTO GetModelCode(string code)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                UserEntity r = cs.GetAll().SingleOrDefault(p => p.UserCode == code);
                if (r != null)
                {
                    return new UserDTO
                    {
                        UserCode = r.UserCode,
                        AddGLTime = r.AddGLTime,
                        AgentsID = r.AgentsID,
                        Address = r.Address,
                        AllBonusAccount = r.AllBonusAccount,
                        BankAccount = r.BankAccount,
                        BankAccountUser = r.BankAccountUser,
                        BankBranch = r.BankBranch,
                        BankInCity = r.BankInCity,
                        BankInProvince = r.BankInProvince,
                        BankName = r.BankName,
                        BillCount = r.BillCount,
                        BonusAccount = r.BonusAccount,
                        CenterBalance = r.CenterBalance,
                        CenterNewScore = r.CenterNewScore,
                        CenterScore = r.CenterScore,
                        CenterZT = r.CenterZT,
                        CreateTime = r.CreateTime,
                        Emoney = r.Emoney,
                        Gender = r.Gender,
                        GLmoney = r.GLmoney,
                        ID = r.ID,
                        IdenCode = r.IdenCode,
                        IsAgent = r.IsAgent,
                        IsLock = r.IsLock,
                        IsOpend = r.IsOpend,
                        Layer = r.Layer,
                        LeftBalance = r.LeftBalance,
                        LeftNewScore = r.LeftNewScore,
                        LeftScore = r.LeftScore,
                        LeftZT = r.LeftZT,
                        LevelID = r.LevelID,
                        Location = r.Location,
                        NiceName = r.NiceName,
                        OpenTime = r.OpenTime,
                        ParentCode = r.ParentCode,
                        ParentID = r.ParentID,
                        Password = r.Password,
                        PhoneNum = r.PhoneNum,
                        QQnumer = r.QQnumer,
                        RecommendCode = r.RecommendCode,
                        RecommendGenera = r.RecommendGenera,
                        RecommendID = r.RecommendID,
                        RecommendPath = r.RecommendPath,
                        RegMoney = r.RegMoney,
                        RegTime = r.RegTime,
                        RightBalance = r.RightBalance,
                        RightNewScore = r.RightNewScore,
                        RightScore = r.RightScore,
                        RightZT = r.RightZT,
                        SafetyCodeAnswer = r.SafetyCodeAnswer,
                        SafetyCodeQuestion = r.SafetyCodeQuestion,
                        SecondPassword = r.SecondPassword,
                        ShopAccount = r.ShopAccount,
                        StockAccount = r.StockAccount,
                        StockMoney = r.StockMoney,
                        ThreePassword = r.ThreePassword,
                        TrueName = r.TrueName,
                        User001 = r.User001,
                        User002 = r.User002,
                        User003 = r.User003,
                        User004 = r.User004,
                        User005 = r.User005,
                        User006 = r.User006,
                        User007 = r.User007,
                        User008 = r.User008,
                        User009 = r.User009,
                        User010 = r.User010,
                        User011 = r.User012,
                        User013 = r.User013,
                        User014 = r.User014,
                        User015 = r.User015,
                        User016 = r.User016,
                        User017 = r.User017,
                        User018 = r.User018,
                        User012 = r.User012,
                        UserPath = r.UserPath
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public long Add(UserDTO model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                UserEntity usermodel = new UserEntity();
                usermodel.UserCode = model.UserCode;
                usermodel.AddGLTime = model.AddGLTime;
                usermodel.AgentsID = model.AgentsID;
                usermodel.Address = model.Address;
                usermodel.AllBonusAccount = model.AllBonusAccount;
                usermodel.BankAccount = model.BankAccount;
                usermodel.BankAccountUser = model.BankAccountUser;
                usermodel.BankBranch = model.BankBranch;
                usermodel.BankInCity = model.BankInCity;
                usermodel.BankInProvince = model.BankInProvince;
                usermodel.BankName = model.BankName;
                usermodel.BillCount = model.BillCount;
                usermodel.BonusAccount = model.BonusAccount;
                usermodel.CenterBalance = model.CenterBalance;
                usermodel.CenterNewScore = model.CenterNewScore;
                usermodel.CenterScore = model.CenterScore;
                usermodel.CenterZT = model.CenterZT;
                usermodel.CreateTime = model.CreateTime;
                usermodel.Emoney = model.Emoney;
                usermodel.Gender = model.Gender;
                usermodel.GLmoney = model.GLmoney;
                //usermodel.ID = model.ID;
                usermodel.IdenCode = model.IdenCode;
                usermodel.IsAgent = model.IsAgent;
                usermodel.IsLock = model.IsLock;
                usermodel.IsOpend = model.IsOpend;
                usermodel.Layer = model.Layer;
                usermodel.LeftBalance = model.LeftBalance;
                usermodel.LeftNewScore = model.LeftNewScore;
                usermodel.LeftScore = model.LeftScore;
                usermodel.LeftZT = model.LeftZT;
                usermodel.LevelID = model.LevelID;
                usermodel.Location = model.Location;
                usermodel.NiceName = model.NiceName;
                usermodel.OpenTime = model.OpenTime;
                usermodel.ParentCode = model.ParentCode;
                usermodel.ParentID = model.ParentID;
                usermodel.Password = model.Password;
                usermodel.PhoneNum = model.PhoneNum;
                usermodel.QQnumer = model.QQnumer;
                usermodel.RecommendCode = model.RecommendCode;
                usermodel.RecommendGenera = model.RecommendGenera;
                usermodel.RecommendID = model.RecommendID;
                usermodel.RecommendPath = model.RecommendPath;
                usermodel.RegMoney = model.RegMoney;
                usermodel.RegTime = model.RegTime;
                usermodel.RightBalance = model.RightBalance;
                usermodel.RightNewScore = model.RightNewScore;
                usermodel.RightScore = model.RightScore;
                usermodel.RightZT = model.RightZT;
                usermodel.SafetyCodeAnswer = model.SafetyCodeAnswer;
                usermodel.SafetyCodeQuestion = model.SafetyCodeQuestion;
                usermodel.SecondPassword = model.SecondPassword;
                usermodel.ShopAccount = model.ShopAccount;
                usermodel.StockAccount = model.StockAccount;
                usermodel.StockMoney = model.StockMoney;
                usermodel.ThreePassword = model.ThreePassword;
                usermodel.TrueName = model.TrueName;
                usermodel.User001 = model.User001;
                usermodel.User002 = model.User002;
                usermodel.User003 = model.User003;
                usermodel.User004 = model.User004;
                usermodel.User005 = model.User005;
                usermodel.User006 = model.User006;
                usermodel.User007 = model.User007;
                usermodel.User008 = model.User008;
                usermodel.User009 = model.User009;
                usermodel.User010 = model.User010;
                usermodel.User011 = model.User012;
                usermodel.User013 = model.User013;
                usermodel.User014 = model.User014;
                usermodel.User015 = model.User015;
                usermodel.User016 = model.User016;
                usermodel.User017 = model.User017;
                usermodel.User018 = model.User018;
                usermodel.User012 = model.User012;
                usermodel.UserPath = model.UserPath;
                dbc.User.Add(usermodel);
                dbc.SaveChanges();
                return usermodel.ID;

            }
        }
        public UserDTO GetLocationModel(int Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                UserEntity r = cs.GetAll().Where(p => p.IsOpend == 2 && p.Location == 1 && p.ParentID == Id).SingleOrDefault();
                if (r != null)
                {
                    return new UserDTO
                    {
                        UserCode = r.UserCode,
                        AddGLTime = r.AddGLTime,
                        AgentsID = r.AgentsID,
                        Address = r.Address,
                        AllBonusAccount = r.AllBonusAccount,
                        BankAccount = r.BankAccount,
                        BankAccountUser = r.BankAccountUser,
                        BankBranch = r.BankBranch,
                        BankInCity = r.BankInCity,
                        BankInProvince = r.BankInProvince,
                        BankName = r.BankName,
                        BillCount = r.BillCount,
                        BonusAccount = r.BonusAccount,
                        CenterBalance = r.CenterBalance,
                        CenterNewScore = r.CenterNewScore,
                        CenterScore = r.CenterScore,
                        CenterZT = r.CenterZT,
                        CreateTime = r.CreateTime,
                        Emoney = r.Emoney,
                        Gender = r.Gender,
                        GLmoney = r.GLmoney,
                        ID = r.ID,
                        IdenCode = r.IdenCode,
                        IsAgent = r.IsAgent,
                        IsLock = r.IsLock,
                        IsOpend = r.IsOpend,
                        Layer = r.Layer,
                        LeftBalance = r.LeftBalance,
                        LeftNewScore = r.LeftNewScore,
                        LeftScore = r.LeftScore,
                        LeftZT = r.LeftZT,
                        LevelID = r.LevelID,
                        Location = r.Location,
                        NiceName = r.NiceName,
                        OpenTime = r.OpenTime,
                        ParentCode = r.ParentCode,
                        ParentID = r.ParentID,
                        Password = r.Password,
                        PhoneNum = r.PhoneNum,
                        QQnumer = r.QQnumer,
                        RecommendCode = r.RecommendCode,
                        RecommendGenera = r.RecommendGenera,
                        RecommendID = r.RecommendID,
                        RecommendPath = r.RecommendPath,
                        RegMoney = r.RegMoney,
                        RegTime = r.RegTime,
                        RightBalance = r.RightBalance,
                        RightNewScore = r.RightNewScore,
                        RightScore = r.RightScore,
                        RightZT = r.RightZT,
                        SafetyCodeAnswer = r.SafetyCodeAnswer,
                        SafetyCodeQuestion = r.SafetyCodeQuestion,
                        SecondPassword = r.SecondPassword,
                        ShopAccount = r.ShopAccount,
                        StockAccount = r.StockAccount,
                        StockMoney = r.StockMoney,
                        ThreePassword = r.ThreePassword,
                        TrueName = r.TrueName,
                        User001 = r.User001,
                        User002 = r.User002,
                        User003 = r.User003,
                        User004 = r.User004,
                        User005 = r.User005,
                        User006 = r.User006,
                        User007 = r.User007,
                        User008 = r.User008,
                        User009 = r.User009,
                        User010 = r.User010,
                        User011 = r.User012,
                        User013 = r.User013,
                        User014 = r.User014,
                        User015 = r.User015,
                        User016 = r.User016,
                        User017 = r.User017,
                        User018 = r.User018,
                        User012 = r.User012,
                        UserPath = r.UserPath
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 获取层数
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int NodeNun(long UserID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<UserEntity> csr = new CommonService<UserEntity>(dbcontext);
                UserEntity model = csr.GetById(UserID);
                if (model != null)
                {
                    return model.Layer;
                }
                else
                {
                    return 0;
                }
            }
        }

        public long CheckLogin(string userCode, string password)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                var user = cs.GetAll().SingleOrDefault(u => u.UserCode == userCode);
                if (user == null)
                {
                    return -1;//用户不存在
                }
                if (user.Password != password)
                {
                    return -2;//密码错误
                }
                return user.ID;
            }
        }

        #region 收件箱获得代理编号
        /// <summary>
        /// 收件箱获得代理编号
        /// </summary>
        /// <param name="id">代理id</param>
        /// <param name="type">代理类型1：代理2：管理员</param>
        /// <returns></returns>
        public string GetUserCodeForMessage(long id, int type)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {

                if (type == 1)
                {
                    CommonService<UserEntity> csr = new CommonService<UserEntity>(dbcontext);
                    UserEntity model = csr.GetById(id);
                    if (model == null)
                    {
                        return "";
                    }
                    return model.UserCode;
                }
                else if (type == 2)
                {
                    CommonService<AdminEntity> csr = new CommonService<AdminEntity>(dbcontext);
                    AdminEntity model = csr.GetById(id);
                    if (model == null)
                    {
                        return "";
                    }
                    return model.UserName;
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion
        public bool UpdateLoginInfo(UserDTO model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var usermodel = dbc.User.Where(p => p.ID == model.ID).First();
                usermodel.PhoneNum = model.PhoneNum;
                //usermodel.RecommendPath = model.RecommendPath;
                int count = dbc.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool UpdateLogPwd(UserDTO model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var usermodel = dbc.User.Where(p => p.ID == model.ID).First();
                usermodel.Password = model.Password;
                //usermodel.RecommendPath = model.RecommendPath;
                int count = dbc.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool UpdateScodePwd(UserDTO model)
        {

            using (MyDbContext dbc = new MyDbContext())
            {
                var usermodel = dbc.User.Where(p => p.ID == model.ID).First();
                usermodel.SecondPassword = model.SecondPassword;
                //usermodel.RecommendPath = model.RecommendPath;
                int count = dbc.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool UpdateBaseInfo(UserDTO model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var usermodel = dbc.User.Where(p => p.ID == model.ID).First();
                usermodel.TrueName = model.TrueName;
                usermodel.BankAccount = model.BankAccount;
                usermodel.BankName = model.BankName;
                usermodel.BankBranch = model.BankBranch;
                usermodel.BankAccountUser = model.BankAccountUser;
                usermodel.IdenCode = model.IdenCode;
                //usermodel.RecommendPath = model.RecommendPath;
                int count = dbc.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool UpdateEmoney(UserDTO model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var usermodel = dbc.User.Where(p => p.ID == model.ID).First();
                usermodel.Emoney = model.Emoney;
                //usermodel.RecommendPath = model.RecommendPath;
                int count = dbc.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #region 统计会员增加数量
        public List<UserRegCount> IncreaseCount()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                //var a = (from b in dbc.User.AsEnumerable()
                //         where b.IsDeleted.Equals(false)
                //         group b by b.RegTime.ToString("yyyy-MM") into g
                //         orderby g.Key descending
                //         select new UserRegCount { RegTime = g.Key, Count = g.Count() }).Take(15);
                //return a.ToList();

                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                return cs.GetAll().AsEnumerable().GroupBy(u => u.RegTime.ToString("yyyy-MM-dd")).OrderBy(g => g.Key).Select(g => new UserRegCount { RegTime = g.Key, Count = g.LongCount() }).Take(15).ToList();                
            }
        }
        #endregion

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> GetList()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                return cs.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }

        #region 转换到DTO
        public UserDTO ToDTO(UserEntity model)
        {
            UserDTO dto = new UserDTO();

            dto.UserCode = model.UserCode;
            dto.AddGLTime = model.AddGLTime;
            dto.AgentsID = model.AgentsID;
            dto.Address = model.Address;
            dto.AllBonusAccount = model.AllBonusAccount;
            dto.BankAccount = model.BankAccount;
            dto.BankAccountUser = model.BankAccountUser;
            dto.BankBranch = model.BankBranch;
            dto.BankInCity = model.BankInCity;
            dto.BankInProvince = model.BankInProvince;
            dto.BankName = model.BankName;
            dto.BillCount = model.BillCount;
            dto.BonusAccount = model.BonusAccount;
            dto.CenterBalance = model.CenterBalance;
            dto.CenterNewScore = model.CenterNewScore;
            dto.CenterScore = model.CenterScore;
            dto.CenterZT = model.CenterZT;
            dto.CreateTime = model.CreateTime;
            dto.Emoney = model.Emoney;
            dto.Gender = model.Gender;
            dto.GLmoney = model.GLmoney;
            dto.ID = model.ID;
            dto.IdenCode = model.IdenCode;
            dto.IsAgent = model.IsAgent;
            dto.IsLock = model.IsLock;
            dto.IsOpend = model.IsOpend;
            dto.Layer = model.Layer;
            dto.LeftBalance = model.LeftBalance;
            dto.LeftNewScore = model.LeftNewScore;
            dto.LeftScore = model.LeftScore;
            dto.LeftZT = model.LeftZT;
            dto.LevelID = model.LevelID;
            dto.Location = model.Location;
            dto.NiceName = model.NiceName;
            dto.OpenTime = model.OpenTime;
            dto.ParentCode = model.ParentCode;
            dto.ParentID = model.ParentID;
            dto.Password = model.Password;
            dto.PhoneNum = model.PhoneNum;
            dto.QQnumer = model.QQnumer;
            dto.RecommendCode = model.RecommendCode;
            dto.RecommendGenera = model.RecommendGenera;
            dto.RecommendID = model.RecommendID;
            dto.RecommendPath = model.RecommendPath;
            dto.RegMoney = model.RegMoney;
            dto.RegTime = model.RegTime;
            dto.RightBalance = model.RightBalance;
            dto.RightNewScore = model.RightNewScore;
            dto.RightScore = model.RightScore;
            dto.RightZT = model.RightZT;
            dto.SafetyCodeAnswer = model.SafetyCodeAnswer;
            dto.SafetyCodeQuestion = model.SafetyCodeQuestion;
            dto.SecondPassword = model.SecondPassword;
            dto.ShopAccount = model.ShopAccount;
            dto.StockAccount = model.StockAccount;
            dto.StockMoney = model.StockMoney;
            dto.ThreePassword = model.ThreePassword;
            dto.TrueName = model.TrueName;
            dto.User001 = model.User001;
            dto.User002 = model.User002;
            dto.User003 = model.User003;
            dto.User004 = model.User004;
            dto.User005 = model.User005;
            dto.User006 = model.User006;
            dto.User007 = model.User007;
            dto.User008 = model.User008;
            dto.User009 = model.User009;
            dto.User010 = model.User010;
            dto.User011 = model.User012;
            dto.User013 = model.User013;
            dto.User014 = model.User014;
            dto.User015 = model.User015;
            dto.User016 = model.User016;
            dto.User017 = model.User017;
            dto.User018 = model.User018;
            dto.User012 = model.User012;
            dto.UserPath = model.UserPath;
            return dto;
        }
        #endregion

        public List<UserAllCountModel> GetMemberNumGroupbyTime()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var a = from u in dbc.User.AsEnumerable()
                        where u.IsDeleted=true
                        group u by u.RegTime.ToString("yyyy-MM-dd") into c
                        orderby c.Key 
                        select new UserAllCountModel
                        {
                            regtime = c.Key,
                            Pnum = c.Count()
                        };
                return a.ToList();
            }
        }
        */
        public long Add(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public long CheckLogin(string userCode, string password)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetLayerModelList(int lay1, int lay2)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetLocationModel(int Id)
        {
            throw new NotImplementedException();
        }

        public List<UserAllCountModel> GetMemberNumGroupbyTime()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetModel(long Id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetModel(string usercode)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetModelCode(string userCode)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetRecommendModelList(long RecommendID)
        {
            throw new NotImplementedException();
        }

        public string GetUserCodeForMessage(long id, int type)
        {
            throw new NotImplementedException();
        }

        public List<UserRegCount> IncreaseCount()
        {
            throw new NotImplementedException();
        }

        public int NodeNun(long UserID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBaseInfo(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmoney(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLoginInfo(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLogPwd(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePath(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateScodePwd(UserDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
