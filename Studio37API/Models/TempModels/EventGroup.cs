namespace Studio37API.Models.TempModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventGroup
    {
        public Guid id { get; set; }

        public Guid? EventID { get; set; }

        public Guid? GroupID { get; set; }

        public virtual Event Event { get; set; }

        public virtual Group Group { get; set; }
    }
}
