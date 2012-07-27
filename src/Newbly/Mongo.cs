using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Newbly
{
    public class Mongo
    {
        /// <summary>
        /// MongoDB Server
        /// </summary>
        private readonly MongoServer _server;

        /// <summary>
        /// Name of database 
        /// </summary>
        private readonly string _databaseName;

        public MongoUrl MongoUrl { get; private set; }

        /// <summary>
        /// Opens connection to MongoDB Server
        /// </summary>
        public Mongo(String connectionString)
        {
            MongoUrl = MongoUrl.Create(connectionString);
            _databaseName = MongoUrl.DatabaseName;
            _server = MongoServer.Create(connectionString);
        }

        public void EnsureIndexes()
        {  
        }

        /// <summary>
        /// MongoDB Server
        /// </summary>
        public MongoServer Server
        {
            get { return _server; }
        }

        /// <summary>
        /// Get database
        /// </summary>
        public MongoDatabase Database
        {
            get { return _server.GetDatabase(_databaseName); }
        }

        public List<string> AllDatabases()
        {
            return _server.GetDatabaseNames().ToList();
        }

        public MongoDatabase GetDatabase(string name)
        {
            return _server.GetDatabase(name);
        }

        public MongoCollection Users
        {
            get { return Database.GetCollection("users"); }
        }
    }
}
