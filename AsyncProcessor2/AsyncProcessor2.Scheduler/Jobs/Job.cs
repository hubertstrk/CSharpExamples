using Quartz;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AsyncProcessor.Scheduler
{
	[DisallowConcurrentExecution]
	[PersistJobDataAfterExecution]
	public class Job : IJob
	{
		private string DownloadSourceFolder = @"C:\Temp\DownloadSource";

		public void Execute(IJobExecutionContext context)
		{
			BlockingCollection<string> queue = (BlockingCollection<string>)context.JobDetail.JobDataMap["queue"];
			DateTime lastProcessed = new DateTime( (long) context.JobDetail.JobDataMap["lastProcessed"] );

			List<FileInfo> newestFiles = SearchNewestFile( lastProcessed );
			if (newestFiles != null && newestFiles.Count() > 0)
			{
				foreach (FileInfo fi in newestFiles)
				{
					// only add to queue in case queue is still open
					if (!queue.IsAddingCompleted)
					{
						queue.Add( fi.FullName );
					}
				}

				// get job and set last processed time for the job
				context.JobDetail.JobDataMap.Put( "lastProcessed", newestFiles.Last().CreationTimeUtc.Ticks );

				// job must be added again to make the changes
				// true => override job
				context.Scheduler.AddJob( context.JobDetail, true );
			}
		}

		private List<FileInfo> SearchNewestFile(DateTime lastProcessed )
		{
			DirectoryInfo dir = new DirectoryInfo( DownloadSourceFolder );

			IEnumerable<FileInfo> fileList = dir.GetFiles( "*.*", SearchOption.AllDirectories );

			IEnumerable<FileInfo> fileQuery =
				from file in fileList
				where file.Extension == ".ARW"
				orderby file.Name
				select file;

			var newestFile =
				(from file in fileQuery
				 orderby file.CreationTime
				 select file).Where( f => f.CreationTimeUtc > lastProcessed ).ToList();

			return newestFile;
		}
	}
}
