namespace MovieProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieActorLink")]
    public partial class MovieActorLink
    {
        public int ID { get; set; }

        public int? ActorID { get; set; }

        public int? MovieID { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
