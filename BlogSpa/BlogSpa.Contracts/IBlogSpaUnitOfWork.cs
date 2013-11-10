using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSpa.Model;

namespace BlogSpa.Contracts
{
    /// <summary>
    /// Unit of work contract.
    /// </summary>
    public interface IBlogSpaUnitOfWork
    {
        /// <summary>
        /// Save pending changes to the data store.
        /// </summary>
        void Commit();

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        IBlogRepository<Post> Posts { get; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        IBlogRepository<Comment> Comments { get; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        IBlogRepository<Tag> Tags { get; }
    }
}
