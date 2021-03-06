namespace Studio37API.Models.TempModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClassVideo")]
    public partial class ClassVideo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassVideo()
        {
            ClassRatings = new HashSet<ClassRating>();
            ClassVideoCattegories = new HashSet<ClassVideoCattegory>();
            ClassVideoSales = new HashSet<ClassVideoSale>();
            TutorialClasses = new HashSet<TutorialClass>();
        }

        public Guid id { get; set; }

        [StringLength(450)]
        public string VideoPath { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public DateTime? DateAdded { get; set; }

        [StringLength(450)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [StringLength(450)]
        public string VideoThumbnail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRating> ClassRatings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassVideoCattegory> ClassVideoCattegories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassVideoSale> ClassVideoSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TutorialClass> TutorialClasses { get; set; }
    }
}
