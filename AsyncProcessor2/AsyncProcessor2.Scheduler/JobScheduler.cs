using AsyncProcessor.Model;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;

namespace AsyncProcessor.Scheduler
{
	public class JobScheduler : IDisposable, IJobListener
	{
		public IScheduler Scheduler = StdSchedulerFactory.GetDefaultScheduler();
		public event EventHandler<SchedulerEventArgs> SchedulerAction;
		public event EventHandler<SchedulerEventArgs> JobExecuted;

		public JobScheduler()
		{
			Scheduler.ListenerManager.AddJobListener( this, GroupMatcher<JobKey>.AnyGroup() );
			Scheduler.Start();
		}

		public void Add(IJobDetail job, ITrigger trigger)
		{
			Scheduler.ScheduleJob( job, trigger );
		}

		public void Delete(IJobDetail job)
		{
			if (job == null)
				return;
			Scheduler.DeleteJob( job.Key );
		}

		public void JobExecutionVetoed(IJobExecutionContext context)
		{
			SchedulerEventArgs args = new SchedulerEventArgs() { State = SchedulerState.Information,
				Message = "Job to be vetoed",
				Runtime = DateTime.UtcNow };

			EventHandler<SchedulerEventArgs> handler = SchedulerAction;
			if (handler != null)
				handler.Invoke( this, args );
		}

		public void JobToBeExecuted(IJobExecutionContext context)
		{
			SchedulerEventArgs args = new SchedulerEventArgs() { State = SchedulerState.Information,
				Message = "Job to be executed",
				Runtime = DateTime.UtcNow
			};

			//EventHandler<SchedulerEventArgs> handler = SchedulerAction;
			//if (handler != null)
			//	handler.Invoke( this, args );
		}

		public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
		{
			SchedulerEventArgs args = new SchedulerEventArgs() { State = SchedulerState.Information,
				Message = "Job was executed",
				Runtime = DateTime.UtcNow
			};

			EventHandler<SchedulerEventArgs> executedHandler = JobExecuted;
			if (executedHandler != null)
				executedHandler.Invoke( this, args );

			EventHandler<SchedulerEventArgs> actionHandler = SchedulerAction;
			if (actionHandler != null)
				actionHandler.Invoke( this, args );
		}

		#region Dispose

		bool disposed = false;

		public string Name
		{
			get
			{
				return "SchedulerBase";
			}
		}

		public void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				if (Scheduler != null)
				{
					Scheduler.Shutdown();
				}
			}

			disposed = true;
		}

		#endregion
	}
}
