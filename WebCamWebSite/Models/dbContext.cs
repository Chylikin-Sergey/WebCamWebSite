using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebCamWebSite.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class dbContext:DbContext
    {
        public dbContext():base("DefaultConnection")
        {
            //DbMigrationsConfiguration.AutomaticMigrationsEnabled
            this.Configuration.ValidateOnSaveEnabled = false;
           
        }
        public DbSet<Info> infos { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<GroupMessage> groupMessages { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}