namespace SINCOABR_CONTEXT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teachers_Subjects
    {
        public Guid teachers_subjectsId { get; set; }

        public Guid subjectsId { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        public virtual Subjects Subjects { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}
