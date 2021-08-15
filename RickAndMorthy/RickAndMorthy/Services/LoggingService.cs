using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace RickAndMorthy.Services
{
    public class LoggingService
    {
        public LoggingService(IConfiguration configuration)
        {
            AppCenter.Start($"android={configuration["AndroidAppCenter"]};" +
                  $"ios={configuration["iOSAppCenter"]}",
                  typeof(Analytics), typeof(Crashes));
        }

        /// <summary>
        /// Logs the specified log level.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="additional">The additional.</param>
        public void Log<TClass>(TClass typeClass, LogLevel logLevel, Exception ex, Dictionary<string, string> additional = null)
        {
            AppCenter.LogLevel = logLevel;

            Crashes.SetEnabledAsync(true);
            var addionalInformation = additional ?? new Dictionary<string, string>();
            addionalInformation.Add("class", typeClass.GetType().FullName);

            Crashes.TrackError(ex, addionalInformation);
        }

        /// <summary>
        /// Logs the specified log level.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="additional">The additional.</param>
        public void Log<TClass>(TClass typeClass, LogLevel logLevel, string message)
        {
            var addionalInformation =  new Dictionary<string, string>();
            addionalInformation.Add("class", typeClass.GetType().FullName);

            Analytics.TrackEvent($"{logLevel}: {message}",addionalInformation);
        }

    }
}
