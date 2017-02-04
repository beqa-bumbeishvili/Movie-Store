namespace MovieProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            MovieActorLinks = new HashSet<MovieActorLink>();
            MovieCategoryLinks = new HashSet<MovieCategoryLink>();
            MoviePicturesLinks = new HashSet<MoviePicturesLink>();
            UserLikedFilms = new HashSet<UserLikedFilm>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public double? Duration { get; set; }

        public double? RatingIMDB { get; set; }

        [StringLength(200)]
        public string Trailer { get; set; }

        [StringLength(2000)]
        public string MovieDescription { get; set; }

        public double? Budget { get; set; }

        public double? Income { get; set; }

        public int? DirectorID { get; set; }

        public virtual Director Director { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieActorLink> MovieActorLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieCategoryLink> MovieCategoryLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoviePicturesLink> MoviePicturesLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLikedFilm> UserLikedFilms { get; set; }
    }
}
