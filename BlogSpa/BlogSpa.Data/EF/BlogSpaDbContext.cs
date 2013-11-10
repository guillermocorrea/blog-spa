using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSpa.Model;

namespace BlogSpa.Data.EF
{
    /// <summary>
    /// BlogSpa DbContext.
    /// </summary>
    public class BlogSpaDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogSpaDbContext"/> class.
        /// </summary>
        public BlogSpaDbContext()
            : base(nameOrConnectionString: "BlogSpa") { }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        public DbSet<Post> Posts { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public DbSet<Comment> Comments { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public DbSet<Tag> Tags { get; set; }
    }
}