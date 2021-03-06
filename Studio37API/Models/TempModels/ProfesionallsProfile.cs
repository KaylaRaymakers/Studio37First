namespace Studio37API.Models.TempModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfesionallsProfile")]
    public partial class ProfesionallsProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfesionallsProfile()
        {
            LiveShows = new HashSet<LiveShow>();
            ProfesionalsDocuments = new HashSet<ProfesionalsDocument>();
            Sales = new HashSet<Sale>();
            Stickers = new HashSet<Sticker>();
        }

        [Key]
        [StringLength(450)]
        public string UserID { get; set; }

        public int YearsExperience { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [StringLength(450)]
        public string Logo { get; set; }

        [StringLength(250)]
        public string ProfesionalEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiveShow> LiveShows { get; set; }

        public virtual Profile Profile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfesionalsDocument> ProfesionalsDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sticker> Stickers { get; set; }
    }
}
