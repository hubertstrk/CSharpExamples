using Quartz;
using System;
using System.Threading;

namespace QuartzSimple.Jobs
{
    public class MyJob1 : IJob
    {
        public void Execute( IJobExecutionContext context )
        {
			JobArgs args = (JobArgs) context.JobDetail.JobDataMap["args"];	
            try
            {
				Console.WriteLine( "Executing Job" );
            }
            catch ( Exception e )
            {
                Console.WriteLine( "Error in Job 1" );
                JobExecutionException e2 = new JobExecutionException( e );
                e2.UnscheduleFiringTrigger = true;
                throw e2;
            }
        }
    }
}
