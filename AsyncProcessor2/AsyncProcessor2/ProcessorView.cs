using AsyncProcessor.Model;
using AsyncProcessor.Processor;
using AsyncProcessor.Scheduler;
using Quartz;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProcessor
{
	public partial class ProcessorView : Form, IDisposable
	{
		private JobScheduler m_Scheduler;
		private IJobDetail m_Job;
		private Consumer m_Consumer;
		private DateTime m_LastProcessedUtc = new DateTime( 1900, 1, 1 );

		public ProcessorView()
		{
			InitializeComponent();

			InitializeScheduler();

			m_LblSchedulerStatusResult.Text = "Not running";
			m_LblLastRuntimeResult.Text = string.Empty;
		}

		#region Scheduler

		private void InitializeScheduler()
		{
			m_Scheduler = new JobScheduler();
			m_Scheduler.SchedulerAction += Scheduler_SchedulerAction;
			m_Scheduler.JobExecuted += Scheduler_JobExecuted;
		}

		private void InitializeQueue()
		{
			m_Consumer = new Consumer();
			m_Consumer.LastProcessed += Consumer_LastProcessed;
			m_Consumer.InfoMessage += Consumer_InfoMessage;
			m_Consumer.QueueCount += Consumer_QueueCount;

			m_Consumer.Start( delegate (string fullName)
			{
				byte[] image = ReadImage( fullName );
				Thread.Sleep( 2000 );
			} );
		}

		private void Consumer_QueueCount(object sender, int e)
		{
			Action action = delegate ()
			{
				m_LblQueueCountResult.Text = e.ToString();
			};

			if (InvokeRequired)
			{
				BeginInvoke( action );
			}
			else
				action.Invoke();
		}

		private void Consumer_InfoMessage(object sender, string e)
		{
			Action action = delegate ()
			{
				m_LblProcessorStatusResult.Text = e;
			};

			if (InvokeRequired)
			{
				BeginInvoke( action );
			}
			else
				action.Invoke();
		}

		private void Consumer_LastProcessed(object sender, DateTime e)
		{
			m_LastProcessedUtc = e;

			Action action = delegate ()
			{
				int index = m_GridProcessor.Rows.Add();
				m_GridProcessor.Rows[index].Cells["m_GridProcessor_Col_Icon"].Value = Image.FromFile( @"ico/correct.ico" );
				m_GridProcessor.Rows[index].Cells["m_GridProcessor_Col_EventTime"].Value = e.ToLocalTime();
				m_GridProcessor.Rows[index].Cells["m_GridProcessor_Col_Message"].Value = "Processing complete";
			};

			if (InvokeRequired)
			{
				BeginInvoke( action );
			}
			else
				action.Invoke();
		}

		public byte[] ReadImage(string _FileName)
		{
			Thread.Sleep( 500 );
			byte[] buffer = null;

			using (FileStream fs = new FileStream( _FileName, FileMode.Open, FileAccess.Read ))
			{
				using (BinaryReader br = new BinaryReader( fs ))
				{
					long _TotalBytes = new FileInfo( _FileName ).Length;
					buffer = br.ReadBytes( (Int32)_TotalBytes );
				}
			}

			return buffer;
		}

		private void Scheduler_JobExecuted(object sender, SchedulerEventArgs e)
		{
			Action action = delegate ()
			{
				m_LblLastRuntimeResult.Text = e.Runtime.ToLocalTime().ToString();
			};

			if (InvokeRequired)
			{
				BeginInvoke( action );
			}
			else
				action.Invoke();
		}

		private void Scheduler_SchedulerAction(object sender, SchedulerEventArgs e)
		{
			Action action = delegate ()
			{
				int index = m_GridScheduler.Rows.Add();
				m_GridScheduler.Rows[index].Cells["m_GridScheduler_Col_Icon"].Value = Image.FromFile( @"ico/information.ico" );
				m_GridScheduler.Rows[index].Cells["m_GridScheduler_Col_EventTime"].Value = e.Runtime.ToLocalTime();
				m_GridScheduler.Rows[index].Cells["m_GridScheduler_Col_Message"].Value = e.Message;
			};

			if (InvokeRequired)
			{
				BeginInvoke( action );
			}
			else
				action.Invoke();
		}
		
		private IJobDetail CreateDownloadJob()
		{
			// define the job and tie it to our HelloJob class
			IJobDetail job = JobBuilder.Create<Job>()
				.WithIdentity( Guid.NewGuid().ToString(), "DownloadGroup" )
				.StoreDurably()
				.Build();

			job.JobDataMap.Put( "lastProcessed", m_LastProcessedUtc.Ticks );
			job.JobDataMap.Put( "queue", m_Consumer.Queue );
			return job;
		}

		private ITrigger CreateDownloadTrigger()
		{
			// Trigger the job to run now, and then repeat every 10 seconds
			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity( "Trigger_" + Guid.NewGuid().ToString(), "DownloadGroup" )
				.ForJob( m_Job.Key )
				.WithSimpleSchedule( x => x
					 .WithIntervalInSeconds( 1 )
					 .RepeatForever())
				.Build();
			return trigger;
		}

		#endregion

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InitializeQueue();

			// create new job because there is no other way to stop the trigger than removing and re-adding
			// removing a job also removes the associated trigger
			m_Job = CreateDownloadJob();
			ITrigger trigger = CreateDownloadTrigger();
			m_Scheduler.Add( m_Job, trigger );

			m_LblSchedulerStatusResult.Text = "Running";
			m_LblLastRuntimeResult.Text = DateTime.Now.ToString();
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// there is no other way to stop the trigger than removing and re-adding
			// removing a job also removes the associated trigger
			m_Scheduler.Delete( m_Job );
			m_LblSchedulerStatusResult.Text = "Not running";

			// in case user presses 'stop' a second time
			if (m_Consumer != null)
			{
				m_Consumer.LastProcessed -= Consumer_LastProcessed;
				m_Consumer.InfoMessage -= Consumer_InfoMessage;
				m_Consumer.QueueCount -= Consumer_QueueCount;
				m_Consumer.Stop();

				// wait for processing task to stop
				Task.WaitAll( new List<Task>() { m_Consumer.ConsumerTask, m_Consumer.WatcherTask }.ToArray() );

				m_Consumer.Dispose();
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
