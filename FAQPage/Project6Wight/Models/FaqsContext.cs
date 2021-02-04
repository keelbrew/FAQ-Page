using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Project6Wight.Models
{
    public class FaqsContext : DbContext
    {
        public FaqsContext(DbContextOptions<FaqsContext> options) : base(options)
        { }
        //creates the prop for FAWS
        public DbSet<FAQ> FAQs { get; set; }
        //creates the list for topic
        public DbSet<Topic> Topics { get; set; }
        //creates the list for categories
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// overried adn populates data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //populaltes the data for the topic
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "cs", Name = "C#"},
                new Topic { TopicId = "js", Name = "JavaScript" },
                new Topic { TopicId = "boot", Name = "Bootstrap" });
            //populates data for the categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "gen", Name = "General" },
                new Category { CategoryId = "hist", Name = "History" });
            //overrides data for the FAQS
            modelBuilder.Entity<FAQ>().HasData(
                //data for the FAQS
                new FAQ
                {
                    FAQId = 1,
                    Question = "What is C#?",
                    Answer = "A general purpose object oriented language that uses a concise, Java-like syntax.",
                    TopicId = "cs",
                    CategoryId = "gen"

                },
                new FAQ
                {
                    FAQId = 2,
                    Question = "When was C# first released",
                    Answer = "in 2002.",
                    TopicId = "cs",
                    CategoryId = "hist"
                },
                  new FAQ
                  {
                      FAQId = 3,
                      Question = "What is Javascript",
                      Answer = "A general purpose scripting language that executes in a web browser.",
                      TopicId = "js",
                      CategoryId = "gen"
                  },
                    new FAQ
                    {
                        FAQId = 4,
                        Question = "When was JavaScript first released?",
                        Answer = "in 1995.",
                        TopicId = "js",
                        CategoryId = "hist"
                    },
                      new FAQ
                      {
                          FAQId = 5,
                          Question = "What is Bootstrap",
                          Answer = "A CSS framework for creating responsive web apps for multiple screen sizes",
                          TopicId = "boot",
                          CategoryId = "gen"
                      },
                        new FAQ
                        {
                            FAQId = 6,
                            Question = "When was bootstrap first released",
                            Answer = "in 2011.",
                            TopicId = "boot",
                            CategoryId = "hist"
                        }
                        );




        }
    }

}
