﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSpa.Contracts
{
    /// <summary>
    /// Generic repository.
    /// </summary>
    /// <typeparam name="T">The repository type</typeparam>
    public interface IBlogRepository<T> where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);
    }
}
