using SDMS.DTO.DTO;
using SDMS.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDMS.IService.Interface
{
    public interface IUserService: IServiceSupport
    {
        /// <summary>
        /// 获取层数
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        int NodeNun(long UserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<UserDTO> GetLayerModelList(int lay1, int lay2);
        List<UserDTO> GetRecommendModelList(long RecommendID);
        /// <summary>
        /// 根据ID查询用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UserDTO GetModel(long Id);
        UserDTO GetModel(string usercode);
        /// <summary>
        /// 查询父级用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UserDTO GetLocationModel(int Id);
        
        /// <summary>
        /// 根据UserCode查询用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        UserDTO GetModelCode(string userCode);
        
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        long Add(UserDTO model);
        /// <summary>
        /// 更新数据点位路径
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdatePath(UserDTO model);
        bool UpdateLoginInfo(UserDTO model);
        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateLogPwd(UserDTO model);
        /// <summary>
        /// 修改二级密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateScodePwd(UserDTO model);
        /// <summary>
        /// 更新银行信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateBaseInfo(UserDTO model);
        /// <summary>
        /// 获取收件人用户编号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetUserCodeForMessage(long id, int type);
        /// <summary>
        /// 检查用户登录，成功返回用户id
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        long CheckLogin(string userCode, string password);
        /// <summary>
        /// 更新币种
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateEmoney(UserDTO model);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        List<UserAllCountModel> GetMemberNumGroupbyTime();

        /// <summary>
        /// 统计会员增加数量
        /// </summary>
        /// <returns></returns>
        List<UserRegCount> IncreaseCount();
    }
}
