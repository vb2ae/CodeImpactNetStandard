using System;
using System.Collections.Generic;
using System.Text;

namespace CodeImpact2017Demo.Models
{


    public class Feed
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string GUID { get; set; }
        public int Position { get; set; }
        public string image { get; set; }
    }

}
