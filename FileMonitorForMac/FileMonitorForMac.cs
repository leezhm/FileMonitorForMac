//
// FileMonitorForMac.cs
//
// Written by leezhm(c)126.com
//

using System;
using System.IO;
using System.Security.Permissions;

namespace FileMonitorForMac
{
	class MainClass
	{
		//public FileSystemWatcher monitor = null;
		
		public static void Main (string[] args)
		{
			Run();
		}
		
		[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
		private static void Run()
		{
			string currentDir = System.Environment.CurrentDirectory;
			
			Console.WriteLine("Current Application Directory -> " + currentDir);
			
			FileSystemWatcher monitor = new FileSystemWatcher(currentDir);
			
			monitor.BeginInit();
			
			monitor.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime |
								   NotifyFilters.FileName | NotifyFilters.DirectoryName |
								   NotifyFilters.LastAccess | NotifyFilters.LastWrite;
			
			monitor.Changed += delegate(object sender, FileSystemEventArgs e) {
				Console.WriteLine(e.ChangeType.ToString() + " " + e.FullPath);
			};
			
			monitor.Created += delegate(object sender, FileSystemEventArgs e) {
				Console.WriteLine(e.ChangeType.ToString() + " " + e.FullPath);
			};
			
			monitor.Deleted += delegate(object sender, FileSystemEventArgs e) {
				Console.WriteLine(e.ChangeType.ToString() + " " + e.FullPath);
			};
			
			monitor.Renamed += delegate(object sender, RenamedEventArgs e) {
				Console.WriteLine(e.ChangeType.ToString() + " " + e.FullPath +
				                  " Old Name -> " + e.OldFullPath);
			};
			
			monitor.EnableRaisingEvents = true;
			
			monitor.EndInit();
			
			Console.WriteLine("Press key \'q\' to quit");
			while(Console.Read() != 'q') ; 
		}
	}
}
