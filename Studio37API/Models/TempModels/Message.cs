namespace Studio37API.Models.TempModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public Guid MessageID { get; set; }

        [Column(TypeName = "text")]
        public string Msge { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(450)]
        public string UserID { get; set; }

        public Guid? ChatID { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
