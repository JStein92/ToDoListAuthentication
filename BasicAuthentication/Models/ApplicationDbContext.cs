using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasicAuthentication.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}

			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(128);

			//Uncomment this to have Email length 128 too (not neccessary)
			//modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).HasMaxLength(128);

			builder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(128);
		}

		public DbSet<Item> Items { get; set; }

	}
}