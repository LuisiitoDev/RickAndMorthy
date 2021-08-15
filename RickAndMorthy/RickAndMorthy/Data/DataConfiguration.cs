using Microsoft.Extensions.Configuration;
using SQLite;
using System;
using System.IO;

namespace RickAndMorthy.Data
{
    public static class DataConfiguration
    {
        const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        /// <summary>
        /// it allows to get tha phsycal path of the local database
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static SQLiteAsyncConnection GetSQLiteAsyncConnection(IConfiguration configuration)
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return new SQLiteAsyncConnection(Path.Combine(basePath,configuration["ApplicationBataBase"]),Flags);
        }

    }
}
