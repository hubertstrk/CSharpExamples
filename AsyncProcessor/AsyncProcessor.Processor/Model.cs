using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProcessor.Processor
{
	public class ItemDownload
	{
		public FileInfo FileInfo { get; set; }
	}

	public class ItemProcessor
	{
		public FileInfo FileInfo { get; set; }
		public byte[] Data { get; set; }
	}
}
