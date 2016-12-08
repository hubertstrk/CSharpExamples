using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProcessor.Model
{
	public enum SchedulerState
	{
		OK,
		Warning,
		Error,
		Information
	}

	[DataContract]
    public class SchedulerEventArgs
    {
		public SchedulerState State{ get; set; }

		public string Message { get; set; }

		public DateTime Runtime { get; set; }
	}
}
