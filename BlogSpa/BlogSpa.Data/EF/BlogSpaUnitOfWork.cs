using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSpa.Contracts;
using BlogSpa.Data.EF.Helpers;
using BlogSpa.Model;

namespace BlogSpa.Data.EF
{
    /// <summary>
    /// Implements the pattern Unit of Work
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Post"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in BlogSpa).
    /// </remarks>
    public class BlogSpaUnitOfWork : IBlogSpaUnitOfWork, IDisposable
    {
        /// <summary>
        /// The _DB context
        /// </summary>
        private BlogSpaDbContext _dbContext;

        protected IRepositoryProvider RepositoryProvider { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogSpaUnitOfWork"/> class.
        /// </summary>
        /// <param name="postRepository">The post repository.</param>
        /// <param name="commentRepository">The comment repository.</param>
        /// <param name="tagRepository">The tag repository.</param>
        public BlogSpaUnitOfWork(IRepositoryProvider repositoryProvider)
        {
            InitDbContext();
            RepositoryProvider = repositoryProvider;
            repositoryProvider.DbContext = _dbContext;
        }

        /// <summary>
        /// Initializes the database context.
        /// </summary>
        private void InitDbContext()
        {
            _dbContext = new BlogSpaDbContext();

            // Do NOT enable proxied entities, else serialization fails
            _dbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            _dbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// Save pending changes to the data store.
        /// </summary>
        public void Commit()
        {
            _dbContext.SaveChanges();    
        }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        public IBlogRepository<Model.Post> Posts
        {
            get
            {
                return GetStandardRepo<Post>();
            }
        }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public IBlogRepository<Model.Comment> Comments
        {
            get
            {
                return GetStandardRepo<Comment>();
            }
        }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public IBlogRepository<Tag> Tags
        {
            get
            {
                return GetStandardRepo<Tag>();
            }
        }

        private IBlogRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region Dispose
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }
        #endregion
    }
}
