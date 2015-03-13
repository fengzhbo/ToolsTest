using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;

namespace ToolsTest.FrontEnd.QuartzTest
{
    public class QuartzGo
    {
        public void Init()
        {

            // 先创建一个调度工厂
            ISchedulerFactory schFactory = new StdSchedulerFactory();

            // 创建一个调度并开启
            IScheduler sch = schFactory.GetScheduler();
            sch.Start();

            // 创建一个作业
            IJobDetail job =
                JobBuilder.Create<QuartzHelloWordJob>()
                .WithIdentity("hellojob", "hellogroup")
                .UsingJobData("name", "feng")
                .Build();

            // 创建一个触发器
            ITrigger trigger =
                TriggerBuilder.Create()          
                
                .WithIdentity("hellotrigger", "hellogroup")
                .StartNow()
                
                .WithSimpleSchedule(x =>
                    x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                
                .Build();

            // 调度
            sch.ScheduleJob(job, trigger);

            //HolidayCalendar cal = new HolidayCalendar();
            //cal.AddExcludedDate(new DateTime(2015, 3, 11));

            //sch.AddCalendar("myHolidays", cal, false);

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("myTrigger")
            //    .ForJob("myJob")
                
            //    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(9, 30))
            //    .ModifiedByCalendar("myHolidays")
            //    .Build();


            //ITrigger ironTrigger = TriggerBuilder.Create()
            //    .WithCronSchedule("0 0/2 8-17 * * ?");



        }

    }
}
