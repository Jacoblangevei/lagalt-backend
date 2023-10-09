using Lagalt_Backend.Data.Exceptions;
namespace Lagalt_Backend.Services
{
    public interface ICrudService<TEntity, TID>
    {
        /// <summary>
        /// Gets all the instances of <typeparamref name="TEntity"/> in the database. 
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets a specific <typeparamref name="TEntity"/> by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TID id);

        /// <summary>
        /// Adds an <typeparamref name="TEntity"/> to the database.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity obj);

        /// <summary>
        /// Updates a <typeparamref name="TEntity"/> in the database with new values.
        /// It is a full replace, any null fields will be updated to null in the database.
        /// This also does not add/update related entities to the database.
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity obj);

        /// <summary>
        /// Deletes an <typeparamref name="TEntity"/> by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <returns></returns>
        Task DeleteByIdAsync(TID id);

    }
}
