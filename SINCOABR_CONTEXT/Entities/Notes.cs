namespace SINCOABR_CONTEXT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Notes
    {
        [Key]
        public Guid noteId { get; set; }

        public double? note { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? updateDate { get; set; }

        [Required]
        [StringLength(100)]
        public string code { get; set; }

        public Guid subjectsId { get; set; }

        public Guid periodId { get; set; }

        public virtual Periods Periods { get; set; }

        public virtual Students Students { get; set; }

        public virtual Subjects Subjects { get; set; }
    }
}
