using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.OwnerModels;

namespace Lagalt_Backend.Services
{
    public interface ICrudService<TEntity, TID>
    {
        /// <summary>
        /// Gets all <typeparamref name="TEntity"/> from the database
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> GetAllAsync();
        /// <summary>
        /// Gets one <typeparamref name="TEntity"/> from database using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TID id);
        /// <summary>
        /// Adds an <typeparamref name="TEntity"/> to the database.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity obj);

        /// <summary>
        /// Deletes an <typeparamref name="TEntity"/> by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <returns></returns>
        Task DeleteByIdAsync(TID id);

    }
}
