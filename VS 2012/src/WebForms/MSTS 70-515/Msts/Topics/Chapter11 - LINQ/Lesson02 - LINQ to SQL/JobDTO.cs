using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public class JobDTO
    {
        public Int16 ID { get; set; }
        public string Description { get; set; }
        public byte Minimum { get; set; }
        public byte Maximum { get; set; }
    }
}