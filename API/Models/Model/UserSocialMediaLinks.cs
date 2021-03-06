﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public partial class UserSocialMediaLinks
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [StringLength(450)]
        public string Link { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Profile.UserSocialMediaLinks))]
        public virtual Profile User { get; set; }
    }
}
