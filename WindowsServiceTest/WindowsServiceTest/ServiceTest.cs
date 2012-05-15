using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceTest
{
	public partial class ServiceTest : ServiceBase
	{
		public ServiceTest()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
			{
				sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
			}
		}

		protected override void OnStop()
		{
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
			{
				sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Stop.");
			}
		}
	}
}
