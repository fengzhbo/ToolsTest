using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace ToolsTest.FrontEnd.QuartzTest
{
    public class QuartzHelloWordJob:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            String name = dataMap.GetString("name");

            var ex = new JobExecutionException();

        }

        public void WriteFile(String msg) {

            String path = "";

        }
    }
}
