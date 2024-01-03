using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace LibraryApp.Models {
	public class LibraryDbContext : DbContext {
		public LibraryDbContext() {

		}
		public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
			: base(options) {

		}

		public DbSet<MainPage> MainPages { get; set; }
		public DbSet<About> Abouts { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<ContactMessage> ContactMessages { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
				// TODO: Change server name
				optionsBuilder.UseSqlServer(
            "Server=DESKTOP-NM11S1H\\SQLEXPRESS;Database=LibraryDb;" +
			"TrustServerCertificate=True;Trusted_Connection=True;Encrypt=False"
			   );
			}

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Favorite>()
				.HasKey(x => new { x.BookId, x.UserId });

			base.OnModelCreating(modelBuilder);
		}
	}
}
