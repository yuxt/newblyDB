using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Newbly.Entities
{
    public class ContentBase
    {
        public ContentBase()
        {
            Tags = new List<string>();
        }

        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Use user name, to easy build url to submitter profile. 
        /// </summary>
        public string SubmittedBy { get; set; }

        /// <summary>
        /// array of tags, related to this content.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// array of voters and vote ratings, possibly be changed in the future.
        /// </summary>
        public List<MilestoneVote> Votes { get; set; }
        /// <summary>
        /// recalculate each time when perform update, or via batch processing
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// text/html/link/etc of content item
        /// </summary>
        public string RawBody { get; set; }

        /// <summary>
        /// Array of user permissions, enumeration, in database we store integer number. User(0)|Admin(1)
        /// </summary>
        public List<int> Permissions { get; set; }

        public DateTime DatePosted { get; set; } 
    }

    public class MilestoneVote
    {
        public string User { get; set; }

        public int Rating { get; set; }
    }
}
