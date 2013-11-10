using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSpa.Data.EF.SeedData
{
    /// <summary>
    /// Initialize with seed data the blog spa dbcontext.
    /// </summary>
    public class BlogSpaDataInitializer : DropCreateDatabaseIfModelChanges<BlogSpaDbContext>
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(BlogSpaDbContext context)
        {
            // TODO initilize seed data
        }
    }
}
