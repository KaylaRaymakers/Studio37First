namespace Studio37API.Models.TempModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserChat")]
    public partial class UserChat
    {
        [StringLength(450)]
        public string UserID { get; set; }

        public Guid? ChatID { get; set; }

        public Guid id { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
