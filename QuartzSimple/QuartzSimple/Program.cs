using Quartz;
using Quartz.Impl;
using QuartzSimple.Jobs;
using System;
using System.Collections.Generic;

namespace QuartzSimple
{
    class Program
    {
        static void Main( string[] args )
        {
			IJobDetail job1 = null;
			ITrigger trigger1 = null;
			Scheduler scheduler = new Scheduler();

            try
            {
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };

				#region Job 1

				JobArgs jobArgs = new JobArgs() { Name = "Hubert", Age = 10 };
				IDictionary<string, object> dataMap = new Dictionary<string, object>();
				dataMap.Add( "args", jobArgs );

				JobDataMap jdm = new JobDataMap( dataMap );

                // define the job and tie it to our HelloJob class
                job1 = JobBuilder.Create<MyJob1>()
                    .WithIdentity( "job1", "group1" )
					.SetJobData( jdm )
                    .Build();
				

                // Trigger the job to run now, and then repeat every 10 seconds
                trigger1 = TriggerBuilder.Create()
                    .WithIdentity( "trigger1", "group1" )
                    .StartNow()
                    .WithSimpleSchedule( x => x
                         .WithIntervalInSeconds( 1 )
                         .RepeatForever() )
                    .Build();
                #endregion

                scheduler.Add( job1, trigger1 );
            }
            catch ( SchedulerException se )
            {
                Console.WriteLine( se );
            }

            //Console.WriteLine( "Press any key to close the scheduler" );
            Console.ReadKey();

			//scheduler._Scheduler.UnscheduleJob( trigger1.Key );
			scheduler._Scheduler.PauseJob( job1.Key );
			//scheduler._Scheduler.DeleteJob( job1.Key );

			//Console.WriteLine( "Press any key to close the application" );
			Console.ReadKey();

			//scheduler._Scheduler.AddJob( job1, true );
			//scheduler._Scheduler.ScheduleJob( trigger1 );

			scheduler._Scheduler.ResumeJob( job1.Key );

			Console.ReadKey();
		}
    }
}
