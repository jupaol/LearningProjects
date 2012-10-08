using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    [Table(Name = "dbo.jobs")]
    public class JobEnityManual
    {
        private Int16 id;

        [Column(
            Name = "job_id", 
            IsPrimaryKey = true,
            Storage = "id",
            IsDbGenerated = true,
            DbType = "smallint",
            CanBeNull = false)]
        public Int16 ID
        {
            get
            {
                return this.id;
            }
            internal set
            {
                this.id = value;
            }
        }

        [Column(
            Name = "job_desc",
            CanBeNull = false)]
        public string Description { get; set; }

        [Column(
            Name = "min_lvl",
            CanBeNull = false)]
        public byte Minimum { get; set; }

        [Column(
            Name = "max_lvl",
            CanBeNull = false)]
        public byte Maximum { get; set; }
    }
}
