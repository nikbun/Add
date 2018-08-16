using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace AddressBook.Logging
{
	public static class Logger
	{
		private const string logName = "Address Book";
		private const string sourceName = "AddressBook2";
		private static EventLog log = new EventLog();

		/// <summary>
		/// Создает журнал если его нет
		/// </summary>
		public static void CreateLog()
		{
			if (!EventLog.SourceExists(sourceName))
			{
				var eventSourceData = new EventSourceCreationData(sourceName, logName);
				EventLog.CreateEventSource(eventSourceData);
			}
			
		}

		public static void WriteLog(string message, EventLogEntryType type)
		{

			log.Source = sourceName;
			//log.Log = logName;
			log.WriteEntry(message, type);
		}
	}
}