namespace Studio37API.Models.TempModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSocialMediaLink
    {
        public Guid id { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }

        [StringLength(450)]
        public string Link { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
