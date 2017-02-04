namespace MovieProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLikedFilm")]
    public partial class UserLikedFilm
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? MovieID { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }
    }
}
