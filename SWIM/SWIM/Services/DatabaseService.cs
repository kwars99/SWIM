using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SWIM.Models;

namespace SWIM.Services
{
    public class DatabaseService
    {
        static SQLiteAsyncConnection database;

        public DatabaseService(string dbPath)
        {

            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embeddedDatabaseStream = assembly.GetManifestResourceStream("SWIM.data.db");

            
            if (!File.Exists(dbPath))
            {

                FileStream fileStreamToWrite = File.Create(dbPath);
                embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
                embeddedDatabaseStream.CopyTo(fileStreamToWrite);
                fileStreamToWrite.Close();
            }
            

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTablesAsync<User, Bill, Usage, Transaction, Enquiry>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }
    }
}
