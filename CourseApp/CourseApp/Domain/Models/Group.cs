using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Group : BaseEntity
    {
        public string Teacher { get; set; }
        public string Room { get; set; }
    }
}
