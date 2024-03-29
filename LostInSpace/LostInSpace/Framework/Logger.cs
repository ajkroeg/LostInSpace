﻿using System;
using System.IO;

namespace LostInSpace.Framework
{
    class Logger
    {
        private static StreamWriter logStreamWriter;
        private bool enableLogging = true;

        public Logger(string modDir, string fileName, bool enableLogging)
        {
            string filePath = Path.Combine(modDir, $"{fileName}.log");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            logStreamWriter = File.AppendText(filePath);
            logStreamWriter.AutoFlush = true;

            this.enableLogging = enableLogging;
        }

        public void LogMessage(string message)
        {
            if (enableLogging)
            {
                string ts = DateTime.UtcNow.ToString("HH:mm:ss.ffff", System.Globalization.CultureInfo.InvariantCulture);
                logStreamWriter.WriteLine($"INFO: {ts} - {message}");
            }
        }


        public void LogError(string message)
        {
            string ts = DateTime.UtcNow.ToString("HH:mm:ss.ffff", System.Globalization.CultureInfo.InvariantCulture);
            logStreamWriter.WriteLine($"ERROR: {ts} - {message}");
        }

        public void LogException(Exception exception)
        {
            string ts = DateTime.UtcNow.ToString("HH:mm:ss.ffff", System.Globalization.CultureInfo.InvariantCulture);
            logStreamWriter.WriteLine($"CRITICAL: {ts} - {exception}");
        }
    }
}
