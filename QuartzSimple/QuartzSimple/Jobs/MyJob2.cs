using Quartz;
using System;

namespace QuartzSimple.Jobs
{
    public class MyJob2 : IJob
    {
        public void Execute( IJobExecutionContext context )
        {
            //Console.WriteLine( "MyJob2 execution" );
        }
    }
}
