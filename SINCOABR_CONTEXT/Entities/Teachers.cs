namespace SINCOABR_CONTEXT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teachers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teachers()
        {
            Teachers_Subjects = new HashSet<Teachers_Subjects>();
        }

        [Key]
        [StringLength(50)]
        public string code { get; set; }

        public DateTime? birthDate { get; set; }

        public double? qualification { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(100)]
        public string specialization { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teachers_Subjects> Teachers_Subjects { get; set; }
    }
}
