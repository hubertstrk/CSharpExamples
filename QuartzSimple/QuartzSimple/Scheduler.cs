using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzSimple
{
    public class Scheduler : IDisposable, IJobListener, ISchedulerListener
    {
        public IScheduler _Scheduler = StdSchedulerFactory.GetDefaultScheduler();

        public Scheduler()
        {
            _Scheduler.Start();
            _Scheduler.ListenerManager.AddJobListener( this, GroupMatcher<JobKey>.AnyGroup() );
            _Scheduler.ListenerManager.AddSchedulerListener( this );
        }

        public void Add( IJobDetail job, ITrigger trigger )
        {
            _Scheduler.ScheduleJob( job, trigger );
        }

        #region Job Listener

        public string Name
        {
            get
            {
                return "SchedulerBase";
            }
        }

        public void JobExecutionVetoed( IJobExecutionContext context )
        {
            
        }

        public void JobToBeExecuted( IJobExecutionContext context )
        {
            //Console.WriteLine( string.Format( "Job {0} is about to be executed", context.JobDetail.JobType.Name ) );
        }

        public void JobWasExecuted( IJobExecutionContext context, JobExecutionException jobException )
        {
            //Console.WriteLine( string.Format( "Job {0} has executed ({1} ms)", context.JobDetail.JobType.Name, context.JobRunTime.TotalMilliseconds ) );
        }

        #endregion
        
        #region Scheduler Listener

        public void JobScheduled( ITrigger trigger )
        {
            //Console.WriteLine( "Job scheduled" );
        }

        public void JobUnscheduled( TriggerKey triggerKey )
        {
			//Console.WriteLine( "Job unscheduled" );
		}

        public void TriggerFinalized( ITrigger trigger )
        {
            throw new NotImplementedException();
        }

        public void TriggerPaused( TriggerKey triggerKey )
        {
            throw new NotImplementedException();
        }

        public void TriggersPaused( string triggerGroup )
        {
            throw new NotImplementedException();
        }

        public void TriggerResumed( TriggerKey triggerKey )
        {
            throw new NotImplementedException();
        }

        public void TriggersResumed( string triggerGroup )
        {
            throw new NotImplementedException();
        }

        public void JobAdded( IJobDetail jobDetail )
        {
            //Console.WriteLine( "Job added to scheduler." );
        }

        public void JobDeleted( JobKey jobKey )
        {
			//Console.WriteLine( "Job deleted." );
		}

        public void JobPaused( JobKey jobKey )
        {
			Console.WriteLine( "Job paused." );
		}

        public void JobsPaused( string jobGroup )
        {
            throw new NotImplementedException();
        }

        public void JobResumed( JobKey jobKey )
        {
			Console.WriteLine( "Job resumed." );
		}

        public void JobsResumed( string jobGroup )
        {
            throw new NotImplementedException();
        }

        public void SchedulerError( string msg, SchedulerException cause )
        {
            Console.WriteLine( string.Format( "Scheduler has a problem: {0}", cause.InnerException.Message ) );
        }

        public void SchedulerInStandbyMode()
        {
            Console.WriteLine( "Scheduler went into standby mode." );
        }

        public void SchedulerStarted()
        {
            Console.WriteLine( "Scheduler started." );
        }

        public void SchedulerStarting()
        {
			Console.WriteLine( "Scheduler starting." );
		}

        public void SchedulerShutdown()
        {
            Console.WriteLine( "Scheduler shutdown." );
        }

        public void SchedulerShuttingdown()
        {
            Console.WriteLine( "Scheduler shutting down." );
        }

        public void SchedulingDataCleared()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            if ( _Scheduler != null )
            {
                // shut down the scheduler when you are ready to close your program
                _Scheduler.Shutdown();
            }
        }

        #endregion
    }
}
