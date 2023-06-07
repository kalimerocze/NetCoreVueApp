using Microsoft.EntityFrameworkCore;
using VueApp.Models;

namespace VueApp.Context
{
    //musim nainstalovat entity framework
    public class VueAppDbContext : DbContext
    {

        //musime poslat DbContextOptions parametr typu teto tridyaaaa
        //v tomto parametru musime poslat database providet mysql slserver a connection string 
        public VueAppDbContext(DbContextOptions<VueAppDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contact", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryContact");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });
            modelBuilder.Entity<News>().ToTable("News", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryNews");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });
            modelBuilder.Entity<Article>().ToTable("Article", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryArticle");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });
            modelBuilder.Entity<Link>().ToTable("Link", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryLink");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });
            modelBuilder.Entity<ArticleType>().ToTable("ArticleType", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryArticleType");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });
            modelBuilder.Entity<LinkType>().ToTable("LinkType", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryLinkType");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });
            modelBuilder.Entity<Models.File>().ToTable("File", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryFile");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });
            modelBuilder.Entity<Category>().ToTable("Category", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistoryCategory");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });

            });

        }
        public DbSet<Article>? Article { get; set; }
        public DbSet<Link>? Link { get; set; }
        public DbSet<Models.File>? File { get; set; }
        public DbSet<Contact>? Contact { get; set; }
        public DbSet<News>? News { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<ArticleType>? ArticleType { get; set; }
        public DbSet<LinkType>? LinkType { get; set; }
    }
}
