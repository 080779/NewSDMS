using Autofac;
using Autofac.Integration.Mvc;
using SDMS.Web.App_Start;
using SDMS.IService;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SDMS.IService.Interface;
using SDMS.Service.Service;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using SDMS.Web.Jobs;

namespace SDMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {        
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(string), new TrimToDBCModelBinder());
            ModelBinders.Binders.Add(typeof(int), new TrimToDBCModelBinder());
            ModelBinders.Binders.Add(typeof(long), new TrimToDBCModelBinder());
            ModelBinders.Binders.Add(typeof(double), new TrimToDBCModelBinder());

            log4net.Config.XmlConfigurator.Configure();

            var builder = new ContainerBuilder();//把当前程序集中的 Controller 都注册,不要忘了.PropertiesAutowired()            
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            Assembly[] assemblies = new Assembly[] { Assembly.Load("SDMS.Service") };// 获取所有相关类库的程序集
            builder.RegisterAssemblyTypes(assemblies).
                Where(type => !type.IsAbstract && typeof(IServiceSupport).IsAssignableFrom(type)).AsImplementedInterfaces().PropertiesAutowired();
            //type1.IsAssignableFrom(type2):Assign赋值，type1类型的变量是否可以指向type2类型的对象。也就是type2是否实现type1接口/type2是否继承自type1

            //注册系统级别的 DependencyResolver，这样当 MVC 框架创建 Controller 等对象的时候都是管 Autofac 要对象。            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalFilters.Filters.Add(new SYSExceptionFilter());
            GlobalFilters.Filters.Add(new JsonNetActionFilter());
            //GlobalFilters.Filters.Add(new SYSAuthorizationFilter());
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            StartQuartz();
        }
        IScheduler sched;
        private void StartQuartz()
        {
            sched = new StdSchedulerFactory().GetScheduler();
            //定向分红开始
            JobDetailImpl TakeBonusJob = new JobDetailImpl("TakeBonusJob", typeof(TakeBonusJob));
            IMutableTrigger triggerTakeBouns = CronScheduleBuilder.DailyAtHourAndMinute(17,03).Build();//每天 23:45 执行一次
            triggerTakeBouns.Key = new TriggerKey("triggerTakeBouns");
            sched.ScheduleJob(TakeBonusJob, triggerTakeBouns);
            //定向分红结束

            sched.Start();
        }
        protected void Application_End(object sender, EventArgs e)
        {
            Response.Redirect("/admin/manager/login");
            if (sched != null)
            {
                sched.Shutdown(true);
            }
        }
    }
}
