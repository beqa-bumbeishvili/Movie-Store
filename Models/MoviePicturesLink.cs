namespace MovieProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoviePicturesLink")]
    public partial class MoviePicturesLink
    {
        public int ID { get; set; }

        public int? MovieID { get; set; }

        public int? PictureID { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual MoviePicture MoviePicture { get; set; }
    }
}
