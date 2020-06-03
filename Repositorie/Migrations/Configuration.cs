namespace Repositorie.Migrations
{
    using EnityModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Utilities;

    internal sealed class Configuration : DbMigrationsConfiguration<Repositorie.Infrastructure.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Repositorie.Infrastructure.DataBaseContext";
        }

        protected override void Seed(Repositorie.Infrastructure.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            IList<Client> defaultStandards = new List<Client>();
            var clientId = Guid.NewGuid();
            defaultStandards.Add(new Client() { client_id = "ReactApp", client_secret = "ReactAppSecret", CreatedDate = DateTime.Now, CreatedBy = clientId, Id = clientId, IsActive = true, Name = "myAPP", RefreshTokenLifeTime = 1400, AllowedOrigin = "http://localhost:3000" });

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

            defaultUser.Add(new UserOld() { UserName = "Test@gmail.com", FirstName = "Test", LastName = "zero", CreatedBy = userId, CreatedDate = DateTime.Now, IsActive = true, Id = userId, LastLoginTime = DateTime.Now, Mobile = "8099686585", Password = passwordManger.Encrypt("Admin123$"), Roles = userRoles });

            context.UserOld.AddRange(defaultUser);
            base.Seed(context);
        }

        /// <summary>
        /// I have moved the original seed method from the DataBaseContext file.
        /// </summary>
        /// <param name="context"></param>
        //protected override void SeedOriginal(DataBaseContext context)
        //{
        //    IList<Client> defaultStandards = new List<Client>();
        //    var clientId = Guid.NewGuid();
        //    defaultStandards.Add(new Client() { client_id = "ReactApp", client_secret = "ReactAppSecret", CreatedDate = DateTime.Now, CreatedBy = clientId, Id = clientId, IsActive = true, Name = "myAPP", RefreshTokenLifeTime = 1400, AllowedOrigin = "http://localhost:3000" });

        //    context.Client.AddRange(defaultStandards);
        //    var defaultUser = new List<User>();
        //    var userRoles = new List<UserRoles>();
        //    Guid userId = Guid.NewGuid();
        //    var supperAdminRole = new UserRoles()
        //    {
        //        Id = Guid.NewGuid(),
        //        Role = RoleName.SupperAdmin,
        //        CreatedBy = userId,
        //        CreatedDate = DateTime.Now,
        //        IsActive = true,
        //    };
        //    var adminRole = new UserRoles()
        //    {
        //        Id = Guid.NewGuid(),
        //        Role = RoleName.Admin,
        //        CreatedBy = userId,
        //        CreatedDate = DateTime.Now,
        //        IsActive = true
        //    };
        //    userRoles.Add(supperAdminRole);
        //    userRoles.Add(adminRole);
        //    var passwordManger = new PasswordManger();

        //    defaultUser.Add(new User() { UserName = "Test@gmail.com", FirstName = "Test", LastName = "zero", CreatedBy = userId, CreatedDate = DateTime.Now, IsActive = true, Id = userId, LastLoginTime = DateTime.Now, Mobile = "8099686585", Password = passwordManger.Encrypt("Admin123$"), Roles = userRoles });

        //    context.User.AddRange(defaultUser);
        //    base.Seed(context);
        //}
    }
}
