using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using Quartz;
using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SDMS.Web.Jobs
{
    public class TakeBonusJob : IJob
    {
        private static ILog log = LogManager.GetLogger(typeof(TakeBonusJob));
        public void Execute(IJobExecutionContext context)
        {
            log.Debug("准备定向分红");
            try
            {
                var container = AutofacDependencyResolver.Current.ApplicationContainer;
                using (container.BeginLifetimeScope())
                {
                    ISetShareBonusService setShareBonusService = container.Resolve<ISetShareBonusService>();
                    IShareBonusService shareBonusService = container.Resolve<IShareBonusService>();
                    if(setShareBonusService.GetSetPattern())
                    {
                        log.Debug("开始定向分红");
                    }
                    else
                    {
                        log.Debug("定向分红已暂停");
                    }
                }                
                log.Debug("定向分红完成");
            }
            catch (Exception ex)
            {
                log.Error("定向分红出错", ex);
            }
        }
    }
}