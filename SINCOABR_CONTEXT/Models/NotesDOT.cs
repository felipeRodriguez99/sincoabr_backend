using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_CONTEXT.Models
{
    public class NotesDOT
    {
        public Guid noteId { get; set; }

        public double? note { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? updateDate { get; set; }

        public string code { get; set; }

        public Guid subjectsId { get; set; }

        public Guid periodId { get; set; }

        public string namePeriod { get; set; }

        public string nameSubject { get; set; }
    }
}
