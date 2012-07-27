using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Newbly.Entities
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Email { get; set; }

    }
}
