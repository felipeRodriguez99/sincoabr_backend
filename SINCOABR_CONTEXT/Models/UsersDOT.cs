using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_CONTEXT.Models
{
    public class UsersDOT
    {


        public Guid userId { get; set; }

        public string email { get; set; }
     
        public string password { get; set; }

        public string name { get; set; }

        public string latName { get; set; }

        public DateTime? createDate { get; set; }

        public bool? state { get; set; }

        public Guid rolId { get; set; }

    }
}
