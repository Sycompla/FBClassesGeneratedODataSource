using Microsoft.EntityFrameworkCore;
using System.Linq;
using Ac4yUtilityContainer;
using Microsoft.Extensions.Configuration;
using CSUsers;

namespace  FBClassesCap
{

    public class Context : DbContext
    {
        public Context() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = null;

            config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();

            optionsBuilder.UseSqlServer(ConnectionStringBuilder(
                                                    config["DATABASESERVER"]
                                                    ,
                                                    config["DATABASENAME"]
                                                    ,
                                                    config["DATABASEUSERNAME"]
                                                    ,
                                                    config["DATABASEPASSWORD"]));

        }

        public DbSet<User> Users { get; set; }
public DbSet<UserToken> UserTokens { get; set; }
public DbSet<AuthenticationRequest> AuthenticationRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<User>().ToTable("Users");
modelBuilder.Entity<UserToken>().ToTable("UserTokens");
modelBuilder.Entity<AuthenticationRequest>().ToTable("AuthenticationRequests");

        }

        public string ConnectionStringBuilder(string ip, string databaseName, string username, string password)
        {
            return "Server=" + ip + ";Database=" + databaseName +
                ";Trusted_Connection=false;uid=" + username +
                ";pwd=" + password + ";";
        }
    } // Context

} // #suffix#