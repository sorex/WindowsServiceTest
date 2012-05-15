using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ServiceProcess;

namespace WindowsServiceTestUI
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnInstall_Click(object sender, RoutedEventArgs e)
		{
			string CurrentDirectory = System.Environment.CurrentDirectory;
			System.Environment.CurrentDirectory = CurrentDirectory + "\\Service";
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.FileName = "Install.bat";
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			lblLog.Text = "安装成功";
			System.Environment.CurrentDirectory = CurrentDirectory;
		}

		private void btnUninstall_Click(object sender, RoutedEventArgs e)
		{
			string CurrentDirectory = System.Environment.CurrentDirectory;
			System.Environment.CurrentDirectory = CurrentDirectory + "\\Service";
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.FileName = "Uninstall.bat";
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			lblLog.Text = "卸载成功";
			System.Environment.CurrentDirectory = CurrentDirectory;
		}

		private void btnCheckStatus_Click(object sender, RoutedEventArgs e)
		{
			ServiceController serviceController = new ServiceController("ServiceTest");
			lblCheckStatus.Text = serviceController.Status.ToString();
		}

		private void btnStart_Click(object sender, RoutedEventArgs e)
		{
			ServiceController serviceController = new ServiceController("ServiceTest");
			serviceController.Start();
			lblStatus.Text = "服务已启动";
		}

		private void btnStop_Click(object sender, RoutedEventArgs e)
		{
			ServiceController serviceController = new ServiceController("ServiceTest");
			if (serviceController.CanStop)
			{
				serviceController.Stop();
				lblStatus.Text = "服务已停止";
			}
			else
				lblStatus.Text = "服务不能停止";
		}

		private void btnPauseContinue_Click(object sender, RoutedEventArgs e)
		{
			ServiceController serviceController = new ServiceController("ServiceTest");
			if (serviceController.CanPauseAndContinue)
			{
				if (serviceController.Status == ServiceControllerStatus.Running)
				{
					serviceController.Pause();
					lblStatus.Text = "服务已暂停";
				}
				else if (serviceController.Status == ServiceControllerStatus.Paused)
				{
					serviceController.Continue();
					lblStatus.Text = "服务已继续";
				}
				else
				{
					lblStatus.Text = "服务未处于暂停和启动状态";
				}
			}
			else
				lblStatus.Text = "服务不能暂停";
		}
	}
}
