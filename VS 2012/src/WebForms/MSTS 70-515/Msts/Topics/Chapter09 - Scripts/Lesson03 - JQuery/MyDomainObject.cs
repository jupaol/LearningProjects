using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter09___Scripts.Lesson03___JQuery
{
    public class MyDomainObject
    {
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public Guid ID { get; set; }
        public IEnumerable<int> Range { get; set; }
    }
}