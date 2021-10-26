using ElektrikFaturaWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElektrikFaturaWebApi
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Bolumler { get; set; }
        public DbSet<tesis> tesisler { get; set; }
        public DbSet<fatura> faturalar { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory
           = LoggerFactory.Create(builder =>
           {
               builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Debug)
               .AddConsole();
           });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=yatirim;Username=postgres;Password=modbus");


            //if (!optionsBuilder.IsConfigured)
            //{
            //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    optionsBuilder
            //        .UseLoggerFactory(ConsoleLoggerFactory)
            //        .UseOracle("connection string to test db.");
            //}
            //optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 172.16.15.51) (PORT=1521))(CONNECT_DATA=(SERVICE_NAME=sevde)));User Id=uavt;Password=uavt2017");
            //optionsBuilder.UseOracle(@"Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.15.51)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = sevde))); User Id = yatirim; Password = yatirim;");
            //optionsBuilder.UseOracle(@"Data Source= (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.15.51)(PORT = 1521))(CONNECT_DATA = (SERVICE_NAME = sevde))); User Id = yatirim; Password = yatirim;)");
            //optionsBuilder.UseOracle(@"User Id=yatirim;Password=yatirim;Data Source=(DESCRIPTION = (ADDRESS_LIST = (FAILOVER = on)(LOAD_BALANCE = on)(ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.15.51)(PORT = 1521))  # askidb01-vip (ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.15.53)(PORT = 1521))) # askidb02-vip(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = sevde))))");
            //optionsBuilder.UseNpgsql("Host=localhost;Database=my_db;Username=my_user;Password=my_pw");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
        }
    }
}