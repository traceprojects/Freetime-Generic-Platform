using System;
using System.Diagnostics;
using System.IO;
using Freetime.Configuration;
namespace Freetime.Base.Component.Diagnostics
{
    public class LogWriterTraceListener : TextWriterTraceListener
    {
        private static StreamWriter GetWriter()
        {
            var logfileLocation = ConfigurationManager.FreetimeConfiguration.LogFilesLocation;

            logfileLocation = string.Format("{0}/{1}", logfileLocation, DateTime.Now.ToString("yyyy/MM/dd"));

            if (!Directory.Exists(logfileLocation))
                Directory.CreateDirectory(logfileLocation);

            var logfile = string.Format("{0}/trace.log", logfileLocation);

            var writer = new StreamWriter(logfile, true);

            return writer;
        }

        private static void Write(DateTime timestamp, string message, string category, bool newLine)
        {
            using (StreamWriter writer = GetWriter())
            {
                if (newLine)
                {
                    writer.WriteLine();
                    writer.Write(string.Format("{0} {1} : {2}", timestamp.ToUniversalTime(), category, message));
                }
                else
                    writer.Write(string.Format("{0} {1} : {2}", timestamp.ToUniversalTime(), category, message));
            }
        }

        private static void Write(string message, string category, bool newLine)
        {
            Write(DateTime.Now, message, category, newLine);
        }
        
        public override void Write(object o)
        {
            Write(o.ToString(), "Information", false);
        }

        public override void Write(object o, string category)
        {
            Write(o.ToString(), category, false);
        }

        public override void Write(string message)
        {
            Write(message, "Information", false);
        }

        public override void Write(string message, string category)
        {
            Write(message, category, false);
        }

        public override void WriteLine(object o)
        {
            Write(o.ToString(), "Information", true);
        }

        public override void WriteLine(object o, string category)
        {
            Write(o.ToString(), category, true);
        }

        public override void WriteLine(string message)
        {
            Write(message, "Information", true);
        }

        public override void WriteLine(string message, string category)
        {
            Write(message, category, true);            
        }

    }
}
