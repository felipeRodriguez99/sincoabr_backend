using SINCOABR_CONTEXT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_CONTEXT.Models
{
    public class SubjectDOT
    {
        public Guid subjectsId { get; set; }
        public string name { get; set; }
        public double score { get; set; }

    }
}
