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
        /// <summary>
        /// Possible to use unique user name as Id
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Nick name of a user, required. Will be used to display reference to user profile 
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Child gender, can be Boy or Girl
        /// </summary>
        public Child Child { get; set; }

        /// <summary>
        /// Enumeration, in database we will store integer value. Can be Mother(0)|Father(1)|GrandMother(2), and so on based on application logic
        /// </summary>
        public Parent Parent { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Location Location { get; set; }

        public string TimeZone { get; set; }

        public Metadata Metadata { get; set; }
    }

    public class Metadata
    {
        public DateTime LastAccessDate { get; set; }

        /// <summary>
        /// Information obtained from user devices.
        /// Not from each request, if user already requested service from this device -- don't store. (atomic updates $ne)
        /// </summary>
        public List<ClientInfo> ClientInfos { get; set; }

        public class ClientInfo
        {
            public string Device { get; set; }
        }
    }

    public class Location
    {
        public string Country { get; set;}

        public string City { get; set; }

        public string Zip { get; set; }

        public string State { get; set; }
    }

    public enum Parent
    {
        Mother = 0,
        Father,
        GrandMother,
        GrandFather
    }

    public enum Child
    {
        Both,
        Boy = 1,
        Girl = 2
    }
}
