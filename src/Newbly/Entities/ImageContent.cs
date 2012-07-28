using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newbly.Entities
{
    public class ImageContent : ContentBase
    {
        public string ImageUrl { get; set; }

        public float Height { get; set; }

        public float Width { get; set; }
    }
}
