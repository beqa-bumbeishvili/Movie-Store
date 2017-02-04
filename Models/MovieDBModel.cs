namespace MovieProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieDBModel : DbContext
    {
        public MovieDBModel()
            : base("name=MovieDBModel")
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActorLink> MovieActorLinks { get; set; }
        public virtual DbSet<MovieCategory> MovieCategories { get; set; }
        public virtual DbSet<MovieCategoryLink> MovieCategoryLinks { get; set; }
        public virtual DbSet<MoviePicture> MoviePictures { get; set; }
        public virtual DbSet<MoviePicturesLink> MoviePicturesLinks { get; set; }
        public virtual DbSet<UserLikedFilm> UserLikedFilms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>()
                .HasMany(e => e.MovieCategoryLinks)
                .WithOptional(e => e.MovieCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<MoviePicture>()
                .HasMany(e => e.MoviePicturesLinks)
                .WithOptional(e => e.MoviePicture)
                .HasForeignKey(e => e.PictureID);
        }
    }
}
