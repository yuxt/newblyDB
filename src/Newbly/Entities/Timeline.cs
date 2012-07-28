using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Newbly.Entities
{
    public class Timeline
    {
        /// <summary>
        /// Specific day, in DB will be 1065(3 years) such items. One item per one day.
        /// </summary>
        [BsonId]
        public int Day { get; set; }

        /// <summary>
        /// array of content items for this day
        /// </summary>
        public List<TimelineContentItem> ContentItems { get; set; }
    }

    public class TimelineContentItem
    {
        /// <summary>
        /// Foreign key to Content item
        /// </summary>
        public ObjectId MilestonesContentId { get; set; }

        /// <summary>
        /// array of integer values [0,23]
        /// </summary>
        public List<int> Hours { get; set; }

        /// <summary>
        /// Possible to denormalize content Title, for fast retrieving
        /// </summary>
        public string Title { get; set; }
    }
}
