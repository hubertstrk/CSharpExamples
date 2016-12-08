using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProcessor.Processor
{
	public class OnBeforeDownloadArgs
	{
		public FileInfo FileInfo { get; set; }
	}

	public class OnAfterDownloadArgs
	{
		public byte[] Image { get; set; }
	}

	public class OnBeforeProcessingArgs
	{
		public FileInfo FileInfo { get; set; }

		public byte[] Image { get; set; }
	}

	public class OnAfterProcessingArgs
	{
		public FileInfo FileInfo { get; set; }

		/// <summary>
		/// Milliseconds. 
		/// </summary>
		public long Elapsed { get; set; }
	}
}
