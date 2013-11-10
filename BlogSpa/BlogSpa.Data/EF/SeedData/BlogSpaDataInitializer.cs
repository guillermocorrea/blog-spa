using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSpa.Model;

namespace BlogSpa.Data.EF.SeedData
{
    /// <summary>
    /// Initialize with seed data the blog spa dbcontext.
    /// </summary>
    public class BlogSpaDataInitializer : DropCreateDatabaseAlways<BlogSpaDbContext>
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(BlogSpaDbContext context)
        {
            context.Posts.Add(new Post() {
                Title = "First Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.Posts.Add(new Post()
            {
                Title = "Second Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.Posts.Add(new Post()
            {
                Title = "Third Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.Posts.Add(new Post()
            {
                Title = "Fourth Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.Posts.Add(new Post()
            {
                Title = "Fifth Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.Posts.Add(new Post()
            {
                Title = "Sixth Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.Posts.Add(new Post()
            {
                Title = "Seventh Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.Posts.Add(new Post()
            {
                Title = "Eigth Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });

            context.Posts.Add(new Post()
            {
                Title = "Ninth Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });

            context.Posts.Add(new Post()
            {
                Title = "Tenth Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });

            context.Posts.Add(new Post()
            {
                Title = "Eleventh Post",
                Body = NLipsum.Core.LipsumGenerator.Generate(3),
            });
            context.SaveChanges();
        }
    }
}
