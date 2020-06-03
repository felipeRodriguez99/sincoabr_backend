namespace SINCOABR_CONTEXT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            Notes = new HashSet<Notes>();
        }

        [Key]
        [StringLength(100)]
        public string code { get; set; }

        public DateTime? birthDate { get; set; }

        [StringLength(100)]
        public string attending { get; set; }

        [StringLength(50)]
        public string attendingNumber { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notes> Notes { get; set; }

        public virtual Users Users { get; set; }
    }
}
