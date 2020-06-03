using EnityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Utilities;

namespace Repositorie.Infrastructure
{
   
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=dbconnection")
        {
           // Database.SetInitializer(new DBInitializer());
            // Database.SetInitializer(new UserDBInitializer());
           // Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOld>().HasKey(x => x.Id);
            modelBuilder.Entity<UserOld>().HasIndex(p => new { p.UserName }).IsUnique();
            modelBuilder.Entity<UserProfileOld>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UserOld> UserOld { get; set; }
        public DbSet<UserRolesOld> UserRoleOld { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<RefreshToken> RefreshToken { get; set; }

        public DbSet<UserProfileOld> ProfileOld { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<CourseSubject> CourseSubject { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<SubjectChapter> SubjectChapter { get; set; }
        public DbSet<VideoType> VideoType { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<ChecklistType> ChecklistType { get; set; }
        public DbSet<CheckPoint> CheckPoint { get; set; }
        public DbSet<ChecklistTypeCheckPoint> ChecklistTypeCheckPoint { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ForgotPassword> ForgotPassword { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
    public class DBInitializer : DropCreateDatabaseAlways<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            IList<Client> defaultStandards = new List<Client>();
            var clientId = Guid.NewGuid();
            defaultStandards.Add(new Client() {client_id= "ReactApp", client_secret = "ReactAppSecret",CreatedDate=DateTime.Now,CreatedBy= clientId, Id= clientId, IsActive=true,Name="myAPP", RefreshTokenLifeTime=1400, AllowedOrigin= "http://localhost:3000" });
 
            context.Client.AddRange(defaultStandards);
            var defaultUser = new List<UserOld>();
            var userRoles = new List<UserRolesOld>();
            Guid userId = Guid.NewGuid();
            var supperAdminRole = new UserRolesOld()
            {
                Id = Guid.NewGuid(),
                Role = RoleName.SupperAdmin,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsActive = true,
            };
            var adminRole = new UserRolesOld()
            {
                Id = Guid.NewGuid(),
                Role = RoleName.Admin,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            userRoles.Add(supperAdminRole);
            userRoles.Add(adminRole);
            var passwordManger = new PasswordManager();

            defaultUser.Add(new UserOld() { UserName = "Test@gmail.com", FirstName = "Test", LastName = "zero", CreatedBy = userId, CreatedDate = DateTime.Now, IsActive = true, Id = userId, LastLoginTime = DateTime.Now, Mobile = "8099686585", Password = passwordManger.Encrypt("Admin123$"),  Roles = userRoles });

            context.UserOld.AddRange(defaultUser);

            //AddVideoTypeSeed
            //List<VideoType> videoTypes = new List<VideoType>();
            //VideoType videoTypeChapter = new VideoType()
            //{
            //    Id = Guid.NewGuid(),
            //    Name="ChapterVideo",
            //    Description="Contains Chapter Video",
            //    CreatedBy = userId,
            //    CreatedDate = DateTime.Now,
            //    IsActive = true
            //};

            //VideoType videoTypeCourse = new VideoType()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "CourseVideo",
            //    Description = "Contains Course Video",
            //    CreatedBy = userId,
            //    CreatedDate = DateTime.Now,
            //    IsActive = true
            //};

            //videoTypes.Add(videoTypeChapter);
            //videoTypes.Add(videoTypeCourse);
            //context.VideoType.AddRange(videoTypes);
            context.VideoType.AddRange(AddVideoTypeSeed());
            base.Seed(context);
        }

        public List<VideoType> AddVideoTypeSeed()
        {
            List<VideoType> videoTypes = new List<VideoType>();
            VideoType videoTypeChapter = new VideoType()
            {
                Id = Guid.NewGuid(),
                Name = "ChapterVideo",
                Description = "Contains Chapter Video",
                //CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            VideoType videoTypeCourse = new VideoType()
            {
                Id = Guid.NewGuid(),
                Name = "CourseVideo",
                Description = "Contains Course Video",
                //CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            videoTypes.Add(videoTypeCourse);
            videoTypes.Add(videoTypeChapter);

            return videoTypes;
        }
    }
}
