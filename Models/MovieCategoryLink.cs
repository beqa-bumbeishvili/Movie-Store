namespace MovieProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieCategoryLink")]
    public partial class MovieCategoryLink
    {
        public int ID { get; set; }

        public int? MovieID { get; set; }

        public int? CategoryID { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual MovieCategory MovieCategory { get; set; }
    }
}
