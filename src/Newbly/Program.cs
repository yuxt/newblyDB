using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paralect.Config.Settings;
using Newbly.Entities;
using MongoDB.Bson;

namespace Newbly
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = SettingsMapper.Map<Settings>();
            var mongo = new Mongo(settings.MongoConnectionString);
            mongo.Users.Insert(new User() { Email = "andrew@paralect.com", Id = ObjectId.GenerateNewId() });

        }
    }
}
