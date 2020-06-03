using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_CONTEXT.Models
{
    public class Teachers_SubjectsDOT
    {
        public Guid teachers_subjectsId { get; set; }

        public Guid subjectsId { get; set; }

        public string code { get; set; }

        public string subjectName { get; set; }
        public string nameUser { get; set; }
    }
}
