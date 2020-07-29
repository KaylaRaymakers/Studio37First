namespace Studio37API.Models.DataBaseMdels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel1")
        {

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ClassRating> ClassRatings { get; set; }
        public virtual DbSet<ClassVideo> ClassVideos { get; set; }
        public virtual DbSet<ClassVideoCattegory> ClassVideoCattegories { get; set; }
        public virtual DbSet<ClassVideoSale> ClassVideoSales { get; set; }
        public virtual DbSet<CommentComment> CommentComments { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<EventGroup> EventGroups { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventUser> EventUsers { get; set; }
        public virtual DbSet<GoupMediaLink> GoupMediaLinks { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<LiveShow> LiveShows { get; set; }
        public virtual DbSet<LiveShowCattegory> LiveShowCattegories { get; set; }
        public virtual DbSet<LiveShowComment> LiveShowComments { get; set; }
        public virtual DbSet<LiveShowView> LiveShowViews { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostCattegory> PostCattegories { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }
        public virtual DbSet<PostPhoto> PostPhotos { get; set; }
        public virtual DbSet<PostVideo> PostVideos { get; set; }
        public virtual DbSet<ProfesionallsProfile> ProfesionallsProfiles { get; set; }
        public virtual DbSet<ProfesionalsDocument> ProfesionalsDocuments { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<PromoPhoto> PromoPhotos { get; set; }
        public virtual DbSet<PromoVideo> PromoVideos { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Share> Shares { get; set; }
        public virtual DbSet<StickerCattegory> StickerCattegories { get; set; }
        public virtual DbSet<Sticker> Stickers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tutorial> Tutorials { get; set; }
        public virtual DbSet<TutorialCattegory> TutorialCattegories { get; set; }
        public virtual DbSet<TutorialClass> TutorialClasses { get; set; }
        public virtual DbSet<TutorialPromoPhoto> TutorialPromoPhotoes { get; set; }
        public virtual DbSet<TutorialPromoVideo> TutorialPromoVideos { get; set; }
        public virtual DbSet<TutorialRating> TutorialRatings { get; set; }
        public virtual DbSet<TutorialSale> TutorialSales { get; set; }
        public virtual DbSet<UserCattegory> UserCattegories { get; set; }
        public virtual DbSet<UserChat> UserChats { get; set; }
        public virtual DbSet<UserSocialMediaLink> UserSocialMediaLinks { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.ClassVideoCattegories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CattegoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.LiveShowCattegories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CattegoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.PostCattegories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.PostID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.StickerCattegories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.TutorialCattegories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CattegoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.UserCattegories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CattegorryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chat>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Chat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chat>()
                .HasMany(e => e.UserChats)
                .WithRequired(e => e.Chat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassVideo>()
                .Property(e => e.PriceRand)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ClassVideo>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ClassVideo>()
                .HasMany(e => e.ClassRatings)
                .WithRequired(e => e.ClassVideo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassVideo>()
                .HasMany(e => e.ClassVideoCattegories)
                .WithRequired(e => e.ClassVideo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassVideo>()
                .HasMany(e => e.ClassVideoSales)
                .WithRequired(e => e.ClassVideo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassVideo>()
                .HasMany(e => e.TutorialClasses)
                .WithRequired(e => e.ClassVideo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassVideoSale>()
                .Property(e => e.PriceRand)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Comment>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.CommentComments)
                .WithRequired(e => e.Comment)
                .HasForeignKey(e => e.newComment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.CommentComments1)
                .WithRequired(e => e.Comment1)
                .HasForeignKey(e => e.oldComment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.LiveShowComments)
                .WithRequired(e => e.Comment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.PostComments)
                .WithRequired(e => e.Comment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.Likes)
                .WithMany(e => e.Comments)
                .Map(m => m.ToTable("CommentLikes").MapLeftKey("CommentID").MapRightKey("LikeID"));

            modelBuilder.Entity<Event>()
                .Property(e => e.EventDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventGroups)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventUsers)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.EventGroups)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GoupMediaLinks)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Profiles)
                .WithMany(e => e.Groups1)
                .Map(m => m.ToTable("GroupUser").MapLeftKey("Groupid").MapRightKey("Userid"));

            modelBuilder.Entity<Like>()
                .HasMany(e => e.LiveShows)
                .WithMany(e => e.Likes)
                .Map(m => m.ToTable("LiveShowLikes").MapLeftKey("LikeID").MapRightKey("LiveShowID"));

            modelBuilder.Entity<Like>()
                .HasMany(e => e.Photos)
                .WithMany(e => e.Likes)
                .Map(m => m.ToTable("PhotoLike").MapLeftKey("LikeID").MapRightKey("photoID"));

            modelBuilder.Entity<Like>()
                .HasMany(e => e.Posts)
                .WithMany(e => e.Likes)
                .Map(m => m.ToTable("PostLike").MapLeftKey("LikeId").MapRightKey("PostId"));

            modelBuilder.Entity<Like>()
                .HasMany(e => e.Profiles)
                .WithMany(e => e.Likes)
                .Map(m => m.ToTable("ProfileLikes").MapLeftKey("LikeId").MapRightKey("UserId"));

            modelBuilder.Entity<Like>()
                .HasMany(e => e.Shares)
                .WithMany(e => e.Likes)
                .Map(m => m.ToTable("ShareLikes").MapLeftKey("LikeID").MapRightKey("ShareID"));

            modelBuilder.Entity<LiveShow>()
                .Property(e => e.PriceRand)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LiveShow>()
                .HasMany(e => e.LiveShowCattegories)
                .WithRequired(e => e.LiveShow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LiveShow>()
                .HasMany(e => e.LiveShowComments)
                .WithRequired(e => e.LiveShow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LiveShow>()
                .HasMany(e => e.LiveShowViews)
                .WithRequired(e => e.LiveShow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Msge)
                .IsUnicode(false);

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.PostPhotos)
                .WithRequired(e => e.Photo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostCattegories)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostComments)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostPhotos)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostVideos)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Shares)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfesionallsProfile>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ProfesionallsProfile>()
                .HasMany(e => e.LiveShows)
                .WithRequired(e => e.ProfesionallsProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfesionallsProfile>()
                .HasMany(e => e.ProfesionalsDocuments)
                .WithRequired(e => e.ProfesionallsProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfesionallsProfile>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.ProfesionallsProfile)
                .HasForeignKey(e => e.ProfesionalID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfesionallsProfile>()
                .HasMany(e => e.Stickers)
                .WithRequired(e => e.ProfesionallsProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfesionalsDocument>()
                .Property(e => e.Discription)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.ClassRatings)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.EventUsers)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Profile)
                .HasForeignKey(e => e.OwnerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.LiveShowViews)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasOptional(e => e.ProfesionallsProfile)
                .WithRequired(e => e.Profile);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Profile)
                .HasForeignKey(e => e.BuyerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.TutorialRatings)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.UserCattegories)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.UserChats)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.UserSocialMediaLinks)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Profile1)
                .WithMany(e => e.Profiles)
                .Map(m => m.ToTable("Followings").MapLeftKey("Followers").MapRightKey("Following"));

            modelBuilder.Entity<PromoPhoto>()
                .HasMany(e => e.TutorialPromoPhotoes)
                .WithRequired(e => e.PromoPhoto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PromoVideo>()
                .HasMany(e => e.TutorialPromoVideos)
                .WithRequired(e => e.PromoVideo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.ClassVideoSales)
                .WithRequired(e => e.Sale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.TutorialSales)
                .WithRequired(e => e.Sale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Share>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<Sticker>()
                .HasMany(e => e.StickerCattegories)
                .WithRequired(e => e.Sticker)
                .HasForeignKey(e => e.StickeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tutorial>()
                .Property(e => e.Desctription)
                .IsUnicode(false);

            modelBuilder.Entity<Tutorial>()
                .Property(e => e.PriceRand)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Tutorial>()
                .HasMany(e => e.TutorialCattegories)
                .WithRequired(e => e.Tutorial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tutorial>()
                .HasMany(e => e.TutorialPromoPhotoes)
                .WithRequired(e => e.Tutorial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tutorial>()
                .HasMany(e => e.TutorialPromoVideos)
                .WithRequired(e => e.Tutorial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tutorial>()
                .HasMany(e => e.TutorialRatings)
                .WithRequired(e => e.Tutorial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tutorial>()
                .HasMany(e => e.TutorialSales)
                .WithRequired(e => e.Tutorial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TutorialCattegory>()
                .HasMany(e => e.TutorialClasses)
                .WithRequired(e => e.TutorialCattegory)
                .HasForeignKey(e => e.TutorialID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TutorialSale>()
                .Property(e => e.PriceRand)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Video>()
                .HasMany(e => e.PostVideos)
                .WithRequired(e => e.Video)
                .WillCascadeOnDelete(false);
        }
    }
}
