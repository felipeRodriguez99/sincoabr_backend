using SINCOABR_CONTEXT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_CONTEXT.Models
{
    public class StudentDOT
    {
        public string code { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public string latName { get; set; }
        public DateTime? birthDate { get; set; }
        public string attending { get; set; }
        public string attendingNumber { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string email { get; set; }

    }
}
