using Microsoft.EntityFrameworkCore;

namespace CreatioUsersWebApi.Models
{
	/// <summary>
	/// Контекст БД.
	/// </summary>
    public class CreatioUserDbContext : DbContext
    {
		/// <summary>
		/// Конструктор.
		/// </summary>
        public CreatioUserDbContext()
        {
        }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="options">Опции.</param>
        public CreatioUserDbContext(DbContextOptions<CreatioUserDbContext> options)
            : base(options)
        {
        }

		/// <summary>
		/// Пользователи.
		/// </summary>
        public virtual DbSet<SysAdminUnit> SysAdminUnit { get; set; }

		/// <summary>
		/// Контакты.
		/// </summary>
		public virtual DbSet<Contact> Contact { get; set; }

		/// <summary>
		/// Установить конфигурацию.
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
	            optionsBuilder.UseSqlServer("server=192.168.9.159;database=SBOX_7142_Shamsutdinov;user id=SQLU_QDS_DID56; password = Demo123; ");
            }
        }

		/// <summary>
		/// Создать модель данных.
		/// </summary>
		/// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysAdminUnit>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("IpL2EC2GiadbDGWVjfldDX8xREl4");

                entity.HasIndex(e => e.ContactId)
                    .HasName("IB8mtJGAxWsWh8AJDDUWv21oP1I");

                entity.HasIndex(e => e.Name)
                    .HasName("IUSysAdminUnitName")
                    .IsUnique();

				entity.Property(e => e.UserPassword)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.Id)
					.HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TimeZoneId)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SynchronizeWithLdap)
	                .HasColumnName("SynchronizeWithLDAP");
            });

			modelBuilder.Entity<Contact>(entity =>
			{
				entity.HasKey(e => e.Id)
					.HasName("PKDR5ErUGy8HVE2ImrX39YL4VU")
					.IsClustered(false);

				entity.HasIndex(e => e.AccountId)
					.HasName("I2B3V8tMwQleaBqV0SLIJJhVVCeI");

				entity.HasIndex(e => e.Email)
					.HasName("IBTZxfg7do7KqSayHny6nVSiN0pE");

				entity.HasIndex(e => e.Id)
					.HasName("ClusteredPrimaryKeyIndex")
					.IsUnique()
					.IsClustered();

				entity.HasIndex(e => e.MobilePhone)
					.HasName("IQx88b72EqeKlZNAW4C2AKp2iQtg");

				entity.HasIndex(e => e.Name)
					.HasName("IwbV3KyO458Zd7rNUAOfBWbBSHSs");

				entity.Property(e => e.Id)
					.HasDefaultValueSql("(newid())");

				entity.Property(e => e.BirthDate)
					.HasColumnType("date");

				entity.Property(e => e.CreatedOn)
					.HasColumnType("datetime2(3)")
					.HasDefaultValueSql("(getutcdate())");

				entity.Property(e => e.Dear)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.Email)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.GivenName)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.MiddleName)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.MobilePhone)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.Surname)
					.IsRequired()
					.HasMaxLength(250)
					.HasDefaultValueSql("('')");
			});
		}
    }
}
