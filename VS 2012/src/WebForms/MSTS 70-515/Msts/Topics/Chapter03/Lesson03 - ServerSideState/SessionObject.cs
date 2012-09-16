using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter03.Lesson03___ServerSideState
{
    [Serializable]
    public class SessionObject
    {
        public DateTime? LastLogin { get; set; }
        public string User { get; set; }
    }
}